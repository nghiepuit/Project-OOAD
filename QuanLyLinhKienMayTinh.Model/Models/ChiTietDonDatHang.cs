using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("ChiTietDonDatHang")]
    public class ChiTietDonDatHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCTDDH { get; set; }
        [Required]
        public int MaDDH { get; set; }
        [Required]
        public int MaSP { get; set; }
        [Required]
        [DisplayName("Tên Sản Phẩm")]
        public string TenSP { get; set; }
        [Required]
        [DisplayName("Số Lượng")]
        public int SoLuong { get; set; }
        [Required]
        [DisplayName("Đơn Giá")]
        public decimal DonGia { get; set; }
        [ForeignKey("MaDDH")]
        public virtual DonDatHang DonDatHang { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }
    }
}