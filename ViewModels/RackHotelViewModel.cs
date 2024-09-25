using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHEndevour.Models;
using SHEndevour.Utilities;
using System;
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

        // Propiedad para el filtro de RoomStatus
        private RoomStatus? _roomStatusFilter;
        public RoomStatus? RoomStatusFilter
        {
            get => _roomStatusFilter;
            set
            {
                if (SetProperty(ref _roomStatusFilter, value))
                {
                    // Aplica el filtro cuando se cambia la selección
                    ApplyRoomStatusFilter();
                }
            }
        }

        // Lista para los estados del ComboBox (sin la opción "Todos")
        public ObservableCollection<RoomStatus> RoomStatusOptions { get; }

        // Lista para almacenar y mostrar los cuartos
        public ObservableCollection<RoomModel> Rooms { get; }

        // Propiedades para las cantidades de cuartos por estado
        // (sin cambios aquí)
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

        // Cambiamos a ICollectionView para poder ordenar y filtrar
        private ICollectionView _roomsView;
        public ICollectionView RoomsView
        {
            get => _roomsView;
            set => SetProperty(ref _roomsView, value);
        }

        public ICommand ChangeRoomStatusCommand { get; }
        public ICommand ClearFiltersCommand { get; }  // Nuevo comando



        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

        public RackHotelViewModel()
        {
            _context = new AppDbContext();

            // Inicializar la lista de opciones de RoomStatus (sin "Todos")
            RoomStatusOptions = new ObservableCollection<RoomStatus>(Enum.GetValues(typeof(RoomStatus)).Cast<RoomStatus>());

            // Inicializar la lista de cuartos
            Rooms = new ObservableCollection<RoomModel>(LoadRoomsFromDatabase());

            // Crear la vista ordenada y filtrada de los cuartos
            RoomsView = CollectionViewSource.GetDefaultView(Rooms);
            RoomsView.SortDescriptions.Add(new SortDescription(nameof(RoomModel.RoomKey), ListSortDirection.Ascending));

            // Calcular las cantidades de cuartos por estado
            CalculateRoomStatusCounts(Rooms);

            // Comandos
            ChangeRoomStatusCommand = new RelayCommand<RoomModel>(OnChangeRoomStatus);
            ClearFiltersCommand = new RelayCommand(OnClearFilters);  // Nuevo comando

            // Inicializar el filtro a 'null'
            RoomStatusFilter = null;
        }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =



        /// Aplicar el filtro basado en el RoomStatus seleccionado
        private void ApplyRoomStatusFilter()
        {
            if (RoomsView != null)
            {
                if (RoomStatusFilter == null)
                {
                    // Eliminar cualquier filtro si RoomStatusFilter es null
                    RoomsView.Filter = null;
                }
                else
                {
                    // Aplicar el filtro para el RoomStatus seleccionado
                    RoomsView.Filter = roomObj =>
                    {
                        var room = roomObj as RoomModel;
                        return room != null && room.RoomStatus == RoomStatusFilter;
                    };
                }

                // Refrescar la vista para que los cambios tengan efecto
                RoomsView.Refresh();
            }
        }

        // Nuevo método para limpiar filtros y mostrar todas las habitaciones
        private void OnClearFilters()
        {
            RoomStatusFilter = null;  // Restablecer el filtro
            ApplyRoomStatusFilter();  // Aplicar el cambio de filtro
            RoomsView.SortDescriptions.Clear();  // Limpiar cualquier orden anterior
            RoomsView.SortDescriptions.Add(new SortDescription(nameof(RoomModel.RoomKey), ListSortDirection.Ascending));  // Ordenar por RoomKey
            RoomsView.Refresh();  // Refrescar la vista
        }

        // Función para cargar los estados disponibles para el ComboBox (modificado para no incluir null)
        private IEnumerable<RoomStatus> GetRoomStatusOptions()
        {
            return Enum.GetValues(typeof(RoomStatus)).Cast<RoomStatus>();
        }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =










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

                // Refrescar la lista de cuartos
                Rooms.Clear();
                foreach (var newRoom in LoadRoomsFromDatabase())
                {
                    Rooms.Add(newRoom);
                }

                // Volver a calcular las cantidades de cuartos por estado
                CalculateRoomStatusCounts(Rooms);
            }
            catch (System.Exception ex)
            {
                // Manejar errores al cambiar el estatus
                System.Console.WriteLine($"Error cambiando estatus de la habitación: {ex.Message}");
            }
        }
    }
}
