using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHEndevour.Models;
using SHEndevour.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace SHEndevour.ViewModels
{
    public class RackHotelViewModel : ObservableObject
    {
        private readonly AppDbContext _context;

        // Propiedades para las cantidades de cuartos por estado
        private int _cleanVacantRoomCount;
        public int VLRoomCount
        {
            get => _cleanVacantRoomCount;
            set => SetProperty(ref _cleanVacantRoomCount, value);
        }

        private int _dirtyVacantRoomCount;
        public int VSRoomCount
        {
            get => _dirtyVacantRoomCount;
            set => SetProperty(ref _dirtyVacantRoomCount, value);
        }

        private int _occupiedCleanRoomCount;
        public int OLRoomCount
        {
            get => _occupiedCleanRoomCount;
            set => SetProperty(ref _occupiedCleanRoomCount, value);
        }

        private int _occupiedDirtyRoomCount;
        public int OSRoomCount
        {
            get => _occupiedDirtyRoomCount;
            set => SetProperty(ref _occupiedDirtyRoomCount, value);
        }

        private int _maintenanceRoomCount;
        public int MRoomCount
        {
            get => _maintenanceRoomCount;
            set => SetProperty(ref _maintenanceRoomCount, value);
        }

        private int _blockedRoomCount;
        public int BRoomCount
        {
            get => _blockedRoomCount;
            set => SetProperty(ref _blockedRoomCount, value);
        }

        // Cambiamos a ICollectionView para poder ordenar
        private ICollectionView _roomsView;
        public ICollectionView RoomsView
        {
            get => _roomsView;
            set => SetProperty(ref _roomsView, value);
        }

        public ICommand ChangeRoomStatusCommand { get; }

        public RackHotelViewModel()
        {
            // Inicializar AppDbContext
            _context = new AppDbContext();

            // Cargar y ordenar los cuartos desde la base de datos
            var roomsList = LoadRoomsFromDatabase();

            // Crear la vista ordenada de los cuartos
            RoomsView = CollectionViewSource.GetDefaultView(roomsList);
            RoomsView.SortDescriptions.Add(new SortDescription(nameof(RoomModel.RoomKey), ListSortDirection.Ascending));

            // Calcular las cantidades de cuartos por estado
            CalculateRoomStatusCounts(roomsList);

            // Comandos
            ChangeRoomStatusCommand = new RelayCommand<RoomModel>(OnChangeRoomStatus);
        }

        /// Cargar los cuartos desde la base de datos
        private IEnumerable<RoomModel> LoadRoomsFromDatabase()
        {
            try
            {
                // Incluye el tipo de habitación en la carga de los cuartos
                return _context.RoomTable.Include(r => r.RoomType).ToList();
            }
            catch (System.Exception ex)
            {
                // Manejar errores al cargar los cuartos si es necesario
                System.Console.WriteLine($"Error cargando cuartos: {ex.Message}");
                return new List<RoomModel>();
            }
        }

        /// Función para calcular la cantidad de cuartos en cada estado
        private void CalculateRoomStatusCounts(IEnumerable<RoomModel> rooms)
        {
            VLRoomCount = rooms.Count(r => r.RoomStatus == RoomStatus.VacioLimpio);
            VSRoomCount = rooms.Count(r => r.RoomStatus == RoomStatus.VacioSucio);
            OLRoomCount = rooms.Count(r => r.RoomStatus == RoomStatus.OcupadoLimpio);
            OSRoomCount = rooms.Count(r => r.RoomStatus == RoomStatus.OcupadoSucio);
            MRoomCount = rooms.Count(r => r.RoomStatus == RoomStatus.Mantenimiento);
            BRoomCount = rooms.Count(r => r.RoomStatus == RoomStatus.Bloqueado);
        }

        /// Cambiar el estatus de la habitación
        private void OnChangeRoomStatus(RoomModel room)
        {
            try
            {
                // Cambia el estatus de la habitación (aquí puedes poner lógica más compleja)
                if (room.RoomStatus == RoomStatus.OcupadoLimpio)
                {
                    room.RoomStatus = RoomStatus.VacioLimpio; // Ejemplo de cambio de estatus
                }
                else
                {
                    room.RoomStatus = RoomStatus.OcupadoSucio; // Cambiar a ocupado si está limpio
                }

                // Guardar los cambios en la base de datos
                _context.RoomTable.Update(room);
                _context.SaveChanges();

                // Volver a calcular las cantidades de cuartos por estado
                var roomsList = LoadRoomsFromDatabase();
                CalculateRoomStatusCounts(roomsList);
            }
            catch (System.Exception ex)
            {
                // Manejar errores al cambiar el estatus
                System.Console.WriteLine($"Error cambiando estatus de la habitación: {ex.Message}");
            }
        }
    }
}
