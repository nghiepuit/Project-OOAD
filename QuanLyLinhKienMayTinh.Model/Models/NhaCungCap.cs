using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("NhaCungCap")]
    public class NhaCungCap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNCC { get; set; }
        [Required]
        [DisplayName("Tên Nhà Cung Cấp")]
        public string Ten { get; set; }
        [DisplayName("Địa Chỉ")]
        [Required]
        public string DiaChi { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Số Điện Thoại")]
        [Required]
        public string DienThoai { get; set; }
        [DisplayName("Đã Xóa")]
        [DefaultValue(false)]
        public bool DaXoa { get; set; }
        public virtual IEnumerable<PhieuNhap> PhieuNhap { get; set; }
        public virtual IEnumerable<SanPham> DanhSachSanPham { get; set; }
    }
}