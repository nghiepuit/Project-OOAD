using QuanLyLinhKienMayTinh.Entities;
using QuanLyLinhKienMayTinh.Service;
using QuanLyLinhKienMayTinh.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Controllers
{
    public class GioHangController : Controller
    {
        private ISanPhamService _spService;
        private IKhachHangService _khService;
        private IDonDatHangService _ddhService;
        private IChiTietDonDatHangService _ctddhService;

        public GioHangController(
            ISanPhamService spService, 
            IKhachHangService khService,
            IDonDatHangService ddhService,
            IChiTietDonDatHangService ctddhService
        )
        {
            this._spService = spService;
            this._khService = khService;
            this._ddhService = ddhService;
            this._ctddhService = ctddhService;
        }

        public List<VatPhamTrongGioHang> LayGioHang()
        {
            List<VatPhamTrongGioHang> lstGioHang = Session["GioHang"] as List<VatPhamTrongGioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<VatPhamTrongGioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        public ActionResult XemGioHang()
        {
            List<VatPhamTrongGioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        public ActionResult ThemVaoGioHang(int MaSP, string strURL)
        {
            SanPham sp = _spService.LayTheoMa(MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<VatPhamTrongGioHang> GioHang = LayGioHang();
            VatPhamTrongGioHang spCheck = GioHang.SingleOrDefault(x => x.MaSP == MaSP);
            if (spCheck != null)
            {
                if (sp.SoLuongTon - spCheck.SoLuong < spCheck.SoLuong)
                {
                    return View("ThongBao");
                }
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
                return Redirect(strURL);
            }

            VatPhamTrongGioHang item = new VatPhamTrongGioHang();
            item.MaSP = MaSP;
            item.TenSP = sp.Ten;
            item.HinhAnh = sp.HinhAnh;
            item.DonGia = sp.DonGia;
            item.SoLuong = 1;
            item.ThanhTien = item.DonGia * item.SoLuong;

            if (sp.SoLuongTon < item.SoLuong)
            {
                return View("ThongBao");
            }

            GioHang.Add(item);
            return Redirect(strURL);
        }

        [HttpGet]
        public ActionResult CapNhatGioHang(int MaSP)
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            SanPham sp = _spService.LayTheoMa(MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<VatPhamTrongGioHang> lstGioHang = LayGioHang();
            VatPhamTrongGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.GioHang = lstGioHang;
            return View(spCheck);
        }

        [HttpPost]
        public ActionResult CapNhatGioHang(VatPhamTrongGioHang item)
        {
            SanPham spCheck = _spService.LayTheoMa(item.MaSP);
            if (spCheck.SoLuongTon < item.SoLuong)
            {
                return View("ThongBao");
            }
            List<VatPhamTrongGioHang> lstGH = LayGioHang();
            VatPhamTrongGioHang itemGHUpdate = lstGH.Find(n => n.MaSP == item.MaSP);
            itemGHUpdate.SoLuong = item.SoLuong;
            itemGHUpdate.ThanhTien = itemGHUpdate.SoLuong * itemGHUpdate.DonGia;
            return RedirectToAction("XemGioHang");
        }

        public ActionResult XoaGioHang(int MaSP)
        {
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            SanPham sp = _spService.LayTheoMa(MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<VatPhamTrongGioHang> lstGioHang = LayGioHang();
            VatPhamTrongGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            lstGioHang.Remove(spCheck);
            return RedirectToAction("XemGioHang");
        }

        public ActionResult DatHang(KhachHang kh)
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KhachHang KhachHang = new KhachHang();
            if (Session["TaiKhoan"] == null)
            {
                KhachHang = kh;
                _khService.ThemMoi(KhachHang);
                _khService.luu();
            }
            else
            {
                ThanhVien tv = Session["TaiKhoan"] as ThanhVien;
                var khachhang = _khService.LayKhachHangTheoMaThanhVien(tv.MaTV);
                if (!khachhang.Any())
                {
                    KhachHang.Ten = tv.HoTen;
                    KhachHang.DiaChi = tv.DiaChi;
                    KhachHang.Email = tv.Email;
                    KhachHang.DienThoai = tv.DienThoai;
                    KhachHang.MaTV = tv.MaTV;
                    _khService.ThemMoi(KhachHang);
                    _khService.luu();
                }
                else
                {
                    KhachHang = khachhang.FirstOrDefault();
                }
            }

            DonDatHang ddh = new DonDatHang();
            ddh.MaKH = KhachHang.MaKH;
            ddh.NgayDatHang = DateTime.Now;
            ddh.TinhTrangGiaoHang = false;
            ddh.DaThanhToan = false;
            ddh.UuDai = 0;
            ddh.DaXoa = false;
            ddh.DaHuy = false;
            _ddhService.ThemMoi(ddh);
            _ddhService.luu();

            List<VatPhamTrongGioHang> lstGH = LayGioHang();
            foreach (var item in lstGH)
            {
                ChiTietDonDatHang ctdh = new ChiTietDonDatHang();
                ctdh.MaDDH = ddh.MaDDH;
                ctdh.MaSP = item.MaSP;
                ctdh.TenSP = item.TenSP;
                ctdh.SoLuong = item.SoLuong;
                ctdh.DonGia = item.DonGia;
                _ctddhService.ThemMoi(ctdh);
            }
            _ctddhService.luu();
            Session["GioHang"] = null;
            TempData["ThongBao"] = "Mua hàng thành công! chúng tôi sẽ liên hệ với bạn trong thời gian sớm nhất!";
            return RedirectToAction("XemGioHang");
        }

    }
}