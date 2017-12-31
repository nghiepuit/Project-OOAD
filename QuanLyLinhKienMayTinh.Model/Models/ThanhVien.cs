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

        [Column(TypeName = "VARCHAR")]
        [StringLength(20, ErrorMessage = "Tài khoản phải có độ dài dưới 20 ký tự!")]
        [Index(Order = 1, IsUnique = true)]
        [Required(ErrorMessage = "Tài khoản không được bỏ trống!")]
        [DisplayName("Tài Khoản")]
        public string TaiKhoan { get; set; }
        [MinLength(6, ErrorMessage = "Mật khẩu phải có độ dài từ 6 ký tự!")]
        [MaxLength(50, ErrorMessage = "Mật khẩu phải có độ dài tối đa 50 ký tự!")]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
        [DisplayName("Mật Khẩu")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Họ tên không được bỏ trống!")]
        [DisplayName("Họ và Tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được bỏ trống!")]
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Email không được bỏ trống!")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng!")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [RegularExpression(@"^0(1\d{9}|9\d{8})$", ErrorMessage = "Số điện thoại không đúng định dạng!")]
        [DisplayName("Điện Thoại")]
        public string DienThoai { get; set; }

        public int MaLTV { get; set; }
        public bool DaXoa { get; set; }
        /*
         * Quên mật khẩu
         */

        [Required(ErrorMessage = "Vui lòng chọn câu hỏi!")]
        [DisplayName("Câu Hỏi")]
        public string CauHoi { get; set; }

        [Required(ErrorMessage = "Câu trả lời không được bỏ trống!")]
        [DisplayName("Câu Trả Lời")]
        public string CauTraLoi { get; set; }

        public virtual IEnumerable<BinhLuan> DanhSachBinhLuan { get; set; }
        public virtual IEnumerable<KhachHang> DanhSachKhachHang { get; set; }

        [ForeignKey("MaLTV")]
        public virtual LoaiThanhVien LoaiThanhVien { get; set; }
    }
}