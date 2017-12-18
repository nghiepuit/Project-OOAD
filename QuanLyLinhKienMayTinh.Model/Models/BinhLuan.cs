using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("BinhLuan")]
    public class BinhLuan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaBL { get; set; }

        [Required]
        [DisplayName("Nội Dung Bình Luận")]
        public string NoiDung { get; set; }

        public int MaTV { get; set; }
        public int MaSP { get; set; }
        [ForeignKey("MaTV")]
        public virtual ThanhVien ThanhVien { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }
    }
}