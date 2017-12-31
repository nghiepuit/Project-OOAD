using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyLinhKienMayTinh.Entities
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSP { get; set; }

        [Required]
        [DisplayName("Tên Sản Phẩm")]
        public string Ten { get; set; }

        [Required]
        [DisplayName("Giá")]
        public decimal DonGia { get; set; }

        [DisplayName("Ngày Cập Nhật")]
        public DateTime NgayCapNhat { get; set; }

        [DisplayName("Cấu Hình")]
        public string CauHinh { get; set; }

        [DisplayName("Mô Tả")]
        public string MoTa { get; set; }

        [DisplayName("Hình Ảnh")]
        public string HinhAnh { get; set; }

        [DisplayName("Hình Ảnh 1")]
        public string HinhAnh1 { get; set; }

        [DisplayName("Hình Ảnh 2")]
        public string HinhAnh2 { get; set; }

        [DisplayName("Hình Ảnh 3")]
        public string HinhAnh3 { get; set; }

        [Required]
        [DisplayName("Số Lượng Tồn")]
        public int SoLuongTon { get; set; }

        [DisplayName("Số Lượt Xem")]
        public int LuotXem { get; set; }

        [DisplayName("Số Lượt Bình Chọn")]
        public int LuotBinhChon { get; set; }

        [DisplayName("Số Lượt Bình Luận")]
        public int LuotBinhLuan { get; set; }

        [DisplayName("Số Lần Mua")]
        public int SoLanMua { get; set; }

        [DisplayName("Sản Phẩm Mới")]
        public bool Moi { get; set; }

        public int MaNCC { get; set; }
        public int MaNSX { get; set; }
        public int MaLSP { get; set; }

        [DisplayName("Đã Xoa")]
        public bool DaXoa { get; set; }

        public virtual IEnumerable<BinhLuan> DanhSachBinhLuan { get; set; }
        public virtual IEnumerable<ChiTietPhieuNhap> DanhSachChiTietPhieuNhap { get; set; }
        public virtual IEnumerable<ChiTietDonDatHang> DanhSachChiTietDonDatHang { get; set; }
        [ForeignKey("MaLSP")]
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        [ForeignKey("MaNCC")]
        public virtual NhaCungCap NhaCungCap { get; set; }
        [ForeignKey("MaNSX")]
        public virtual NhaSanXuat NhaSanXuat { get; set; }
    }
}