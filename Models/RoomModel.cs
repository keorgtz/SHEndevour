using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHEndevour.Models
{
    public class RoomModel : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomKey { get; set; }

        [Required]
        public RoomStatus RoomStatus { get; set; }

        [Required]
        public HousekeeperStatus HousekeeperStatus { get; set; }

        // Foreign key to RoomType
        [Required]
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }

        // Navigation property for RoomType
        public RoomTypeModel RoomType { get; set; }

        public bool IsSelected { get; set; }
    }

    // Enum for Room Status
    public enum RoomStatus
    {
        Ocupado,
        Vacio,
        Bloqueado,
        Mantenimiento,
        OcupadoLimpio,
        OcupadoSucio,
        VacioLimpio,
        VacioSucio
    }

    // Enum for Housekeeper Status
    public enum HousekeeperStatus
    {
        Bloqueada,
        Mantenimiento,
        OcupadaSucia,
        OcupadaLimpia,
        VaciaSucia,
        VaciaLimpia,
        PocoEquipaje,
        Pasador
    }
}
