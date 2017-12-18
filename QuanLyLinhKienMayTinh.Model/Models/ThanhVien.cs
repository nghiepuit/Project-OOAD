using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("ThanhVien")]
    public class ThanhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTV { get; set; }
        [Required]
        [DisplayName("Tài Khoản")]
        public string TaiKhoan { get; set; }
        [Required]
        [DisplayName("Mật Khẩu")]
        public string MatKhau { get; set; }
        [Required]
        [DisplayName("Họ và Tên")]
        public string HoTen { get; set; }
        [Required]
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Điện Thoại")]
        public string DienThoai { get; set; }
        public int MaLTV { get; set; }
        public bool DaXoa { get; set; }
        /*
         * Quên mật khẩu
         */
        [DisplayName("Câu Hỏi")]
        public string CauHoi { get; set; }
        [DisplayName("Câu Trả Lời")]
        public string CauTraLoi { get; set; }
        public virtual IEnumerable<BinhLuan> DanhSachBinhLuan { get; set; }
        public virtual IEnumerable<KhachHang> DanhSachKhachHang { get; set; }
        [ForeignKey("MaLTV")]
        public virtual LoaiThanhVien LoaiThanhVien { get; set; }
    }
}