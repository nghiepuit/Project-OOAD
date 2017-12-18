using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("LoaiThanhVien")]
    public class LoaiThanhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLTV { get; set; }
        [Required]
        [DisplayName("Loại Thành Viên")]
        public string Ten { get; set; }
        [DisplayName("Khuyến Mãi")]
        [DefaultValue(0)]
        public int KhuyenMai { get; set; }
        public virtual IEnumerable<ThanhVien> DanhSachThanhVien { get; set; }
    }
}