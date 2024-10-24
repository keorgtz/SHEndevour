﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using SHEndevour.Models;
using SHEndevour.Utilities;
using SHEndevour.Views.Settings.Rooms.Dialogs;
using MessageBox = System.Windows.MessageBox;
using Timer = System.Timers.Timer;

namespace SHEndevour.ViewModels.Settings.Rooms
{
    public partial class RoomMaintenanceViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<RoomMaintenanceModel> maintenances;

        //Coleccion de los registros del Historial
        [ObservableProperty]
        private ObservableCollection<MaintenanceHistoryModel> historys;

        [ObservableProperty]
        private ObservableCollection<RoomStatus> roomStatuses;

        [ObservableProperty]
        private ObservableCollection<BlockType> blockTypes;

        private Timer _maintenanceCheckTimer;

        public ICommand AddMaintenanceCommand { get; }
        public ICommand ViewMaintenanceCommand { get; }
        public ICommand ReleaseMaintenanceCommand { get; }

        public RoomMaintenanceViewModel()
        {
            Maintenances = new ObservableCollection<RoomMaintenanceModel>();
            Historys = new ObservableCollection<MaintenanceHistoryModel>();

            AddMaintenanceCommand = new RelayCommand(AddMaintenance);
            ViewMaintenanceCommand = new RelayCommand(ViewMaintenance, CanEditOrRelease);
            ReleaseMaintenanceCommand = new RelayCommand(ReleaseMaintenance, CanEditOrRelease);

            LoadMaintenances();
            LoadHistorys();

        }

        #region Cargar Mantenimientos, RoomStatus y BlockTypes / Cargar Historial
        private void LoadMaintenances()
        {
            using (var dbContext = new AppDbContext())
            {
                var records = dbContext.RoomMaintenanceTable.ToList();
                Maintenances = new ObservableCollection<RoomMaintenanceModel>(records);
            }
        }

        //Carga el Historial de la Base de Datos a la Variable 'Historys' como una coleccion
        private void LoadHistorys()
        {
            using (var dbContext = new AppDbContext())
            {
                var hRecords = dbContext.MaintenanceHistoryTable.ToList();
                Historys = new ObservableCollection<MaintenanceHistoryModel>(hRecords);
            }
        }

        #endregion



        //Metodo que Crea el Historial
        private void SaveMaintenanceHistory(string action, string? actionBy, RoomMaintenanceModel maintenance)
        {
            //var maintenanceActionBy = App.CurrentUser.Id >= 1 ? App.CurrentUser.Username : "SYSTEM";

            var historyRecord = new MaintenanceHistoryModel
            {
                RoomKey = maintenance.RoomKey,
                MaintenanceAction = action,
                MaintenanceActionBy = actionBy,
                MaintenanceDescription = maintenance.CauseDescription,
                BlockType = maintenance.BlockType.ToString(),
                RoomStatus = maintenance.RoomStatus.ToString(),
                CreatedbyUser = maintenance.CreatedBy.ToString(),
                CreatedOnDate = maintenance.CreatedAt.ToString(),
                UpdatedbyUser = maintenance.UpdatedBy.ToString(),
                UpdatedOnDate = maintenance.UpdatedAt.ToString(),
                ActionDate = DateTime.Now

            };

            using (var dbContext = new AppDbContext())
            {
                dbContext.MaintenanceHistoryTable.Add(historyRecord);
                dbContext.SaveChanges();
            }
        }





        #region Agregar Mantenimiento
        private void AddMaintenance()
        {
            var addMaintenanceDialog = new AddEditMaintenanceDialog();
            if (addMaintenanceDialog.ShowDialog() == true)
            {
                var newMaintenance = addMaintenanceDialog.RoomMaintenance;

                using (var dbContext = new AppDbContext())
                {
                    var room = dbContext.RoomTable.FirstOrDefault(r => r.RoomKey == newMaintenance.RoomKey);

                    if (room != null)
                    {
                        newMaintenance.RoomId = room.Id;
                        room.RoomStatus = newMaintenance.RoomStatus;
                        dbContext.RoomTable.Update(room);
                        dbContext.RoomMaintenanceTable.Add(newMaintenance);
                        dbContext.SaveChanges();

                        
                        // Agregar registro al historial
                        SaveMaintenanceHistory("Agregar", App.CurrentUser.Username, newMaintenance);

                        Maintenances.Add(newMaintenance);
                        MessageBox.Show("Mantenimiento añadido con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("La habitación seleccionada no existe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        #endregion

        #region Ver o Editar Mantenimiento
        private void ViewMaintenance()
        {
            if (SelectedMaintenance != null)
            {
                var editMaintenanceDialog = new AddEditMaintenanceDialog(SelectedMaintenance);

                if (editMaintenanceDialog.ShowDialog() == true)
                {
                    using (var dbContext = new AppDbContext())
                    {
                        var maintenanceToUpdate = dbContext.RoomMaintenanceTable
                                                           .FirstOrDefault(m => m.Id == SelectedMaintenance.Id);

                        if (maintenanceToUpdate != null)
                        {

                            

                            maintenanceToUpdate.RoomKey = SelectedMaintenance.RoomKey;
                            maintenanceToUpdate.RoomStatus = SelectedMaintenance.RoomStatus;
                            maintenanceToUpdate.CauseDescription = SelectedMaintenance.CauseDescription;
                            maintenanceToUpdate.BlockType = SelectedMaintenance.BlockType;
                            maintenanceToUpdate.EndDate = SelectedMaintenance.BlockType == BlockType.Programado ? SelectedMaintenance.EndDate : null;

                            var room = dbContext.RoomTable.FirstOrDefault(r => r.RoomKey == SelectedMaintenance.RoomKey);
                            if (room != null && room.RoomStatus != SelectedMaintenance.RoomStatus)
                            {
                                room.RoomStatus = SelectedMaintenance.RoomStatus;
                                dbContext.RoomTable.Update(room);
                            }

                            // Código de editar mantenimiento
                            SaveMaintenanceHistory("Editar", App.CurrentUser.Username, SelectedMaintenance); // Guardar historial

                            dbContext.SaveChanges();

                            

                            MessageBox.Show("Mantenimiento actualizado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("El registro de mantenimiento no se encontró en la base de datos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                    LoadMaintenances();
                }
            }
        }

        #endregion

        #region Liberar Mantenimiento
        private void ReleaseMaintenance()
        {
            if (SelectedMaintenance != null)
            {
                using (var dbContext = new AppDbContext())
                {
                    var room = dbContext.RoomTable.FirstOrDefault(r => r.RoomKey == SelectedMaintenance.RoomKey);
                    if (room != null)
                    {
                        

                        room.RoomStatus = RoomStatus.VacioLimpio;
                        dbContext.RoomTable.Update(room);
                        dbContext.RoomMaintenanceTable.Remove(SelectedMaintenance);


                        dbContext.SaveChanges();
                    }
                }

                // Código de liberar mantenimiento
                SaveMaintenanceHistory("Liberar", App.CurrentUser.Username, SelectedMaintenance); // Guardar historial

                Maintenances.Remove(SelectedMaintenance);

                MessageBox.Show("Habitación liberada con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool CanEditOrRelease()
        {
            return SelectedMaintenance != null;
        }
        #endregion

        [ObservableProperty]
        private RoomMaintenanceModel selectedMaintenance;

        partial void OnSelectedMaintenanceChanged(RoomMaintenanceModel value)
        {
            (ViewMaintenanceCommand as RelayCommand)?.NotifyCanExecuteChanged();
            (ReleaseMaintenanceCommand as RelayCommand)?.NotifyCanExecuteChanged();
        }
    }
}
