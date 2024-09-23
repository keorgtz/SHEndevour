using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHEndevour.Models;
using SHEndevour.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace SHEndevour.ViewModels
{
    public class RackHotelViewModel : ObservableObject
    {
        private readonly AppDbContext _context;

        private ObservableCollection<RoomModel> _rooms;
        public ObservableCollection<RoomModel> Rooms
        {
            get => _rooms;
            set => SetProperty(ref _rooms, value);
        }

        public ICommand ChangeRoomStatusCommand { get; }
        public ICommand EditRoomPositionsCommand { get; }

        public RackHotelViewModel()
        {
            // Inicializar AppDbContext
            _context = new AppDbContext();

            // Cargar los cuartos desde la base de datos
            Rooms = new ObservableCollection<RoomModel>(LoadRoomsFromDatabase());

            // Comandos
            ChangeRoomStatusCommand = new RelayCommand<RoomModel>(OnChangeRoomStatus);
            EditRoomPositionsCommand = new RelayCommand(OnEditRoomPositions);
        }

        /// <summary>
        /// Cargar los cuartos desde la base de datos
        /// </summary>
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

        /// <summary>
        /// Cambiar el estatus de la habitación
        /// </summary>
        /// <param name="room"></param>
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
            }
            catch (System.Exception ex)
            {
                // Manejar errores al cambiar el estatus
                System.Console.WriteLine($"Error cambiando estatus de la habitación: {ex.Message}");
            }
        }

        /// <summary>
        /// Habilitar la edición de posiciones visuales de los cuartos
        /// </summary>
        private void OnEditRoomPositions()
        {
            // Aquí puedes añadir la lógica que permita habilitar la reubicación visual de los cuartos
            // Por ejemplo, podrías cambiar un flag en la UI para habilitar el "arrastrar y soltar"
            System.Console.WriteLine("Modo de edición de posiciones habilitado.");
        }
    }
}
