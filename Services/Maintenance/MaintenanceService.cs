using SHEndevour.Models;
using SHEndevour.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SHEndevour.Services.Maintenance
{
    public class MaintenanceService
    {
        private Timer _maintenanceCheckTimer;

        public MaintenanceService()
        {
            // Inicializa el Timer para que se ejecute cada minuto
            _maintenanceCheckTimer = new Timer(60000); // 60000 ms = 1 minuto
            _maintenanceCheckTimer.Elapsed += CheckMaintenanceStatus;
            _maintenanceCheckTimer.Start();
        }

        // Método que se ejecuta cada minuto para verificar los mantenimientos
        private void CheckMaintenanceStatus(object sender, ElapsedEventArgs e)
        {
            using (var dbContext = new AppDbContext())
            {
                var expiredMaintenances = dbContext.RoomMaintenanceTable
                    .Where(m => m.BlockType == BlockType.Programado && m.EndDate <= DateTime.Now)
                    .ToList();

                foreach (var maintenance in expiredMaintenances)
                {
                    var room = dbContext.RoomTable.FirstOrDefault(r => r.RoomKey == maintenance.RoomKey);
                    if (room != null)
                    {
                        room.RoomStatus = RoomStatus.VacioLimpio; // Cambiar el estatus de la habitación
                        dbContext.RoomTable.Update(room);

                        dbContext.RoomMaintenanceTable.Remove(maintenance); // Eliminar el mantenimiento cumplido
                        dbContext.SaveChanges();

                        SaveMaintenanceHistory("Liberar", "SYSTEM", maintenance); // Guardar el historial de liberación
                    }
                }
            }
        }

        #region Crear el Historial del Mantenimiento Liberado Por el Sistema
        // Método para guardar el historial de mantenimiento (puedes reutilizar el de tu ViewModel)
        private void SaveMaintenanceHistory(string action, string? actionBy, RoomMaintenanceModel maintenance)
        {
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
        #endregion


        // Detiene el Timer cuando se cierra la aplicación
        public void StopTimer()
        {
            _maintenanceCheckTimer?.Stop();
        }
    }

}
