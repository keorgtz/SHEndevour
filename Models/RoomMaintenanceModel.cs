using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHEndevour.Models
{
    public class RoomMaintenanceModel : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoomKey { get; set; }

        [Required]
        public RoomStatus RoomStatus { get; set; } // Bloqueado o Mantenimiento

        [Required]
        [StringLength(500)]
        public string CauseDescription { get; set; } // Descripción de la causa del bloqueo o mantenimiento

        [Required]
        public BlockType BlockType { get; set; } // Indefinido o Programado

        public DateTime? EndDate { get; set; } // Fecha de terminación del bloqueo o mantenimiento (si es programado)

        // Foreign key for the Room
        [ForeignKey("RoomModel")]
        public int RoomId { get; set; }

        // Navigation property for the room
        public RoomModel Room { get; set; }
    }

    // Enum for Block Type
    public enum BlockType
    {
        Indefinido,
        Programado
    }
}
