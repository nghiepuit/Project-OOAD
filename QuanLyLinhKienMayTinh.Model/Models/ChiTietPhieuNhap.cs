using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("ChiTietPhieuNhap")]
    public class ChiTietPhieuNhap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCTPN { get; set; }
        public int MaPN { get; set; }
        public int MaSP { get; set; }
        [Required]
        [DisplayName("Đơn Giá Nhập")]
        public decimal DonGiaNhap { get; set; }
        [Required]
        [DisplayName("Số Lượng Nhập")]
        public int SoLuongNhap { get; set; }
        [ForeignKey("MaPN")]
        public virtual PhieuNhap PhieuNhap { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }
    }
}