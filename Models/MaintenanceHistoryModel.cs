using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHEndevour.Models
{
    public class MaintenanceHistoryModel
    {
        public int Id { get; set; } // Campo de clave primaria
        public string? RoomKey { get; set; } // Clave de la habitación
        public string? MaintenanceAction { get; set; } // Acción realizada (Agregar, Editar, Liberar)
        public string? MaintenanceActionBy { get; set; } // Quien Realizo la Accion
        public string? MaintenanceDescription { get; set; } // Descripción del mantenimiento o causa
        public string? BlockType { get; set; } // Tipo de bloqueo
        public string? RoomStatus { get; set; } // Estado de la habitación
        public string? CreatedbyUser { get; set; } // Usuario que creo el Mantenimiento
        public string? UpdatedbyUser { get; set; } // Usuario que edito el Mantenimiento
        public string? CreatedOnDate { get; set; } // Fecha de Creacion del Mantenimiento
        public string? UpdatedOnDate { get; set; } // Fecha de Edicion del Mantenimiento
        public DateTime ActionDate { get; set; } // Fecha de la acción
        
    }

}
