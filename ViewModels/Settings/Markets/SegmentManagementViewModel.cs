using System;
using System.IO;
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
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.DataAccess.Native.Excel;
using SHEndevour.Views.Settings.Rooms.Dialogs;
using System.Windows;
using System.Windows.Input;

namespace SHEndevour.ViewModels.Settings.Markets
{
    public partial class SegmentManagementViewModel : ObservableObject
    {

        // Propiedades enlazadas en la vista
        [ObservableProperty]
        private ObservableCollection<SegmentModel> segments;

        [ObservableProperty]
        private SegmentModel? selectedSegment;

        // Comandos
        public ICommand AddSegmentCommand { get; }
        public ICommand ViewSegmentCommand { get; }
        public ICommand DeleteSegmentCommand { get; }

        public SegmentManagementViewModel()
        {
            Segments = new ObservableCollection<SegmentModel>();

            // Cargar las habitaciones desde la base de datos
            LoadSegments();

            // Inicializar los comandos
            AddSegmentCommand = new RelayCommand(AddSegment);
            ViewSegmentCommand = new RelayCommand(ViewSegment, CanEditOrDelete);
            DeleteSegmentCommand = new RelayCommand(DeleteSegment, CanEditOrDelete);
        }

        //Cargar las Habitaciones (Todas y las No Bloqueadas)
        private void LoadSegments()
        {
            using (var dbContext = new AppDbContext())
            {
                var segmentsFromDb = dbContext.SegmentTable
                                           .ToList();

                Segments.Clear();

                foreach (var segment in segmentsFromDb)
                {
                    Segments.Add(segment);
                }
            }
        }


        #region AddSegmentRegion
        private void AddSegment()
        {
            var addSegmentDialog = new ConfigurarSegmentoDialog();

            if (addSegmentDialog.ShowDialog() == true)
            {
                var newSegment = addSegmentDialog.Segment;

                using (var dbContext = new AppDbContext())
                {
                    dbContext.SegmentTable.Add(newSegment);
                    dbContext.SaveChanges();
                }

                LoadSegments();
                MessageBox.Show("Segmento añadido con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        #region ViewSegmentRegion
        private void ViewSegment()
        {
            if (SelectedSegment != null)
            {
                var editSegmentDialog = new ConfigurarSegmentoDialog(SelectedSegment);

                if (editSegmentDialog.ShowDialog() == true)
                {
                    var updatedSegment = editSegmentDialog.Segment;

                    using (var dbContext = new AppDbContext())
                    {
                        // Actualizar el Segmento en la base de datos
                        dbContext.SegmentTable.Update(updatedSegment);
                        dbContext.SaveChanges();
                    }

                    LoadSegments();
                    MessageBox.Show("Segmento actualizado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        #endregion

        #region DeleteSegmentRegion
        private void DeleteSegment()
        {
            if (SelectedSegment != null)
            {
                    // Confirmar eliminación
                    if (MessageBox.Show("¿Estás seguro de que deseas eliminar este Segmento?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        using (var dbContext = new AppDbContext())
                        {
                            dbContext.SegmentTable.Remove(SelectedSegment);
                            dbContext.SaveChanges();
                        }

                        Segments.Remove(SelectedSegment);
                        MessageBox.Show("Segmento eliminado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

            }
        }

        #endregion

        private bool CanEditOrDelete()
        {
            return SelectedSegment != null;
        }

        partial void OnSelectedSegmentChanged(SegmentModel? value)
        {
            (ViewSegmentCommand as RelayCommand)?.NotifyCanExecuteChanged();
            (DeleteSegmentCommand as RelayCommand)?.NotifyCanExecuteChanged();
        }





    }
}
