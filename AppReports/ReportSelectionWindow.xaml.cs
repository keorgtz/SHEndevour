using System.Collections.Generic;
using System.Windows;
using SHEndevour.Models;
using SHEndevour.Utilities;
using SHEndevour.AppReports.AllAppReports;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MessageBox = System.Windows.MessageBox;
using System.Windows.Controls;

namespace SHEndevour.AppReports
{
    /// <summary>
    /// Lógica de interacción para ReportSeleccionWindow.xaml
    /// </summary>
    public partial class ReportSelectionWindow : Window
    {
        public ReportSelectionWindow()
        {
            InitializeComponent();
        }
        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            string selectedTable = (TableSelector.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedTable == null)
            {
                MessageBox.Show("Por favor, selecciona una tabla.");
                return;
            }

            // Dependiendo de la tabla seleccionada, generamos el reporte
            switch (selectedTable)
            {
                case "Users":
                    GenerateUserReport();
                    break;
                case "Rooms":
                    GenerateRoomReport();
                    break;
                case "RoomTypes":
                    GenerateRoomTypeReport();
                    break;
                default:
                    MessageBox.Show("Selección no válida.");
                    break;
            }
        }



        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =


        //Obtenemos los Datos y los Cargamos a sus Respectivos Reportes

        private void GenerateUserReport()
        {
            var reportWindow = new ReportWindow();
            List<UserModel> users = GetAllUsers();  // Aquí cargamos los datos de la tabla Users
            var report = new AllUsersReport();  // Agregamos el Reporte de Users
            report.DataSource = users;
            reportWindow.LoadReport(report);
            reportWindow.ShowDialog();
        }

        private void GenerateRoomReport()
        {
            var reportWindow = new ReportWindow();
            List<RoomModel> rooms = GetAllRooms();  // Aquí cargamos los datos de la tabla Rooms
            var report = new AllRoomsReport();  // Agregamos el Reporte de Rooms
            report.DataSource = rooms;
            reportWindow.LoadReport(report);
            reportWindow.ShowDialog();
        }

        private void GenerateRoomTypeReport()
        {
            var reportWindow = new ReportWindow();
            List<RoomTypeModel> roomtypes = GetAllRoomTypes();  // Aquí cargamos los datos de la tabla RoomTypes
            var report = new AllRoomTypesReport();  // Agregamos el Reporte de RoomTypes
            report.DataSource = roomtypes;
            reportWindow.LoadReport(report);
            reportWindow.ShowDialog();
        }



        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =



        // Métodos para obtener datos

        //Cargarmos Usuarios
        public List<UserModel> GetAllUsers()
        {
            using (var context = new AppDbContext())
            {
                // Cargar los usuarios junto con sus roles
                return context.Users.Include(u => u.Role).ToList();
            }
        }
        //Cargar Tipos de Cuartos
        public List<RoomTypeModel> GetAllRoomTypes()
        {
            using (var context = new AppDbContext())
            {
                // Obtén todos los tipos de cuartos de la tabla 
                return context.RoomTypeTable.ToList();
            }
        }
        //Cargar los Cuartos
        public List<RoomModel> GetAllRooms()
        {
            using (var context = new AppDbContext())
            {
                // Cargar los cuartos junto con su tipo de cuarto
                return context.RoomTable.Include(u => u.RoomType).ToList();
            }
        }



        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
    }
}