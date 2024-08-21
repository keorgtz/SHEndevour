using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.XtraRichEdit.Import.Doc;

namespace SHEndevour.Models
{
    public class RoomModel: AuditableEntity
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
        [ForeignKey("RoomTypeModel")]
        public int RoomTypeId { get; set; }
        public RoomTypeModel RoomType { get; set; }
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
