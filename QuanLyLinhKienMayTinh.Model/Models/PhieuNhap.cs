using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("PhieuNhap")]
    public class PhieuNhap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPN { get; set; }
        public int MaNCC { get; set; }
        [Required]
        [DisplayName("Ngày Nhập")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime NgayNhap { get; set; }
        public bool DaXoa { get; set; }
        public virtual IEnumerable<ChiTietPhieuNhap> DanhSachChiTietPhieuNhap { get; set; }
        [ForeignKey("MaNCC")]
        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}