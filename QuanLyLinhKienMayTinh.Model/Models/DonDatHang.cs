using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("DonDatHang")]
    public class DonDatHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDDH { get; set; }
        [Required]
        [DisplayName("Ngày Đặt Hàng")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime NgayDatHang { get; set; }
        [Required]
        [DisplayName("Tình Trạng Giao Hàng")]
        [DefaultValue(false)]
        public bool TinhTrangGiaoHang { get; set; }
        [Required]
        [DisplayName("Ngày Giao Hàng")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime NgayGiaoHang { get; set; }
        [DisplayName("Đã Thanh Toán")]
        public bool DaThanhToan { get; set; }
        public int MaKH { get; set; }
        public int UuDai { get; set; }
        public bool DaHuy { get; set; }
        public bool DaXoa { get; set; }
        public virtual IEnumerable<ChiTietDonDatHang> DanhSachChiTietDonDatHang { get; set; }
        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }
    }
}