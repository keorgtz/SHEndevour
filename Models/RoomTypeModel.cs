using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHEndevour.Models
{
    public class RoomTypeModel : AuditableEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomTypeKey { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal SingleRate { get; set; }

        [Column(TypeName = "money")]
        public decimal MinSingleRate { get; set; }

        [Column(TypeName = "money")]
        public decimal DoubleRate { get; set; }

        [Column(TypeName = "money")]
        public decimal MinDoubleRate { get; set; }

        [Column(TypeName = "money")]
        public decimal TripleRate { get; set; }

        [Column(TypeName = "money")]
        public decimal MinTripleRate { get; set; }

        [Column(TypeName = "money")]
        public decimal QuadrupleRate { get; set; }

        [Column(TypeName = "money")]
        public decimal MinQuadrupleRate { get; set; }

        public ICollection<RoomModel> Rooms { get; set; }

        public bool IsSelected { get; set; }

    }
}
