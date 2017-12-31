using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("Quyen")]
    public class Quyen
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        [DisplayName("Mã Quyền")]
        [Required(ErrorMessage = "Mã quyền không được bỏ trống!")]
        public string MaQuyen { get; set; }

        [DisplayName("Tên Quyền")]
        [Required(ErrorMessage = "Tên quyền không được bỏ trống!")]
        public string TenQuyen { get; set; }

        public virtual IEnumerable<LoaiThanhVien_Quyen> DanhSachLoaiThanhVien_Quyen { get; set; }
    }
}