using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHEndevour.Utilities;
using SHEndevour.Views.Settings.Markets.Dialogs;
using SHEndevour.Models;
using Microsoft.EntityFrameworkCore;
using MessageBox = System.Windows.MessageBox;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SHEndevour.ViewModels.Settings.Markets
{
    public partial class GeoOriginManagementViewModel : ObservableObject
    {

        // Propiedades enlazadas en la vista
        [ObservableProperty]
        private ObservableCollection<GeoOriginModel> geos;

        [ObservableProperty]
        private GeoOriginModel? selectedGeo;

        // Comandos
        public ICommand AddGeoCommand { get; }
        public ICommand ViewGeoCommand { get; }
        public ICommand DeleteGeoCommand { get; }

        public GeoOriginManagementViewModel()
        {
            Geos = new ObservableCollection<GeoOriginModel>();

            // Cargar las habitaciones desde la base de datos
            LoadGeos();

            // Inicializar los comandos
            AddGeoCommand = new RelayCommand(AddGeo);
            ViewGeoCommand = new RelayCommand(ViewGeo, CanEditOrDelete);
            DeleteGeoCommand = new RelayCommand(DeleteGeo, CanEditOrDelete);
        }

        //Cargar las Habitaciones (Todas y las No Bloqueadas)
        private void LoadGeos()
        {
            using (var dbContext = new AppDbContext())
            {
                var geosFromDb = dbContext.GeoOriginTable
                                           .ToList();

                Geos.Clear();

                foreach (var geo in geosFromDb)
                {
                    Geos.Add(geo);
                }
            }
        }


        #region AddGeoRegion
        private void AddGeo()
        {
            var addGeoDialog = new ConfigurarOrigenGeoDialog();

            if (addGeoDialog.ShowDialog() == true)
            {
                var newGeo = addGeoDialog.Geo;

                using (var dbContext = new AppDbContext())
                {
                    dbContext.GeoOriginTable.Add(newGeo);
                    dbContext.SaveChanges();
                }

                LoadGeos();
                MessageBox.Show("Origen añadido con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        #region ViewGeoRegion
        private void ViewGeo()
        {
            if (SelectedGeo != null)
            {
                var editGeoDialog = new ConfigurarOrigenGeoDialog(SelectedGeo);

                if (editGeoDialog.ShowDialog() == true)
                {
                    var updatedGeo = editGeoDialog.Geo;

                    using (var dbContext = new AppDbContext())
                    {
                        // Actualizar el Segmento en la base de datos
                        dbContext.GeoOriginTable.Update(updatedGeo);
                        dbContext.SaveChanges();
                    }

                    LoadGeos();
                    MessageBox.Show("Origen actualizado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        #endregion

        #region DeleteGeoRegion
        private void DeleteGeo()
        {
            if (SelectedGeo != null)
            {
                // Confirmar eliminación
                if (MessageBox.Show("¿Estás seguro de que deseas eliminar este Origen?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.GeoOriginTable.Remove(SelectedGeo);
                        dbContext.SaveChanges();
                    }

                    Geos.Remove(SelectedGeo);
                    MessageBox.Show("Origen eliminado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
        }

        #endregion

        private bool CanEditOrDelete()
        {
            return SelectedGeo != null;
        }

        partial void OnSelectedGeoChanged(GeoOriginModel? value)
        {
            (ViewGeoCommand as RelayCommand)?.NotifyCanExecuteChanged();
            (DeleteGeoCommand as RelayCommand)?.NotifyCanExecuteChanged();
        }














    }
}
