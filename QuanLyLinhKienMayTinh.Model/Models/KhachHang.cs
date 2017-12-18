using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKH { get; set; }
        [Required]
        [DisplayName("Tên Khách Hàng")]
        public string Ten { get; set; }
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Số Điện Thoại")]
        public string DienThoai { get; set; }
        public int MaTV { get; set; }
        public virtual IEnumerable<DonDatHang> DanhSachDonDatHang { get; set; }
        [ForeignKey("MaTV")]
        public virtual ThanhVien ThanhVien { get; set; }
    }
}