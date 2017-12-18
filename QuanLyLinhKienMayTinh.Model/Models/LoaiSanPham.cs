using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("LoaiSanPham")]
    public class LoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLSP { get; set; }

        [Required(ErrorMessage = "Loại sản phẩm không được bỏ trống")]
        [DisplayName("Tên Loại Sản Phẩm")]
        public string Ten { get; set; }

        [DisplayName("Icon")]
        public string Icon { get; set; }

        [DisplayName("Bí Danh")]
        public string BiDanh { get; set; }

        public virtual IEnumerable<SanPham> DanhSachSanPham { get; set; }
    }
}