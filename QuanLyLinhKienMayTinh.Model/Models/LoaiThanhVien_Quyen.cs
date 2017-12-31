using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("LoaiThanhVien_Quyen")]
    public class LoaiThanhVien_Quyen
    {
        [Key]
        [Column(Order = 1)]
        public int MaLoaiTV { get; set; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string MaQuyen { get; set; }

        public string GhiChu { get; set; }

        [ForeignKey("MaLoaiTV")]
        public virtual LoaiThanhVien LoaiThanhVien { get; set; }

        [ForeignKey("MaQuyen")]
        public virtual Quyen Quyen { get; set; }
    }
}