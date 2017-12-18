using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("NhaSanXuat")]
    public class NhaSanXuat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNSX { get; set; }
        [Required]
        [DisplayName("Tên Nhà Sản Xuất")]
        public string Ten { get; set; }
        [DisplayName("Thông Tin")]
        public string ThongTin { get; set; }
        [DisplayName("Logo")]
        public string Logo { get; set; }
        [DisplayName("Đã Xóa")]
        [DefaultValue(false)]
        public bool DaXoa { get; set; }
        public virtual IEnumerable<SanPham> DanhSachSanPham { get; set; }
    }
}