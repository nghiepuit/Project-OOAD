using CaptchaMvc.HtmlHelpers;
using QuanLyLinhKienMayTinh.Entities;
using QuanLyLinhKienMayTinh.Service;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILoaiSanPhamService _loaiSanPhamService;
        private ISanPhamService _sanPhamService;
        private IThanhVienService _thanhVienService;

        public HomeController(
            ILoaiSanPhamService loaiSanPhamService,
            ISanPhamService sanPhamService,
            IThanhVienService thanhVienService
        )
        {
            this._loaiSanPhamService = loaiSanPhamService;
            this._sanPhamService = sanPhamService;
            this._thanhVienService = thanhVienService;
        }

        public ActionResult Index()
        {
            // Điện Thoại Mới Nhất
            var listDienThoaiMoiNhat = _sanPhamService.LayDienThoaiMoiNhat(8);
            ViewBag.ListDienThoaiMoiNhat = listDienThoaiMoiNhat;
            // Laptop Mới Nhất
            var listLaptopMoiNhat = _sanPhamService.LayLaptopMoiNhat(8);
            ViewBag.ListLaptopMoiNhat = listLaptopMoiNhat;
            // Tablet Mới Nhất
            var listTabletMoiNhat = _sanPhamService.LayTabletMoiNhat(8);
            ViewBag.ListTabletMoiNhat = listTabletMoiNhat;
            // Linh Kiện Mới Nhất
            var listLinhKienMoiNhat = _sanPhamService.LayLinhKienMoiNhat(8);
            ViewBag.ListLinhKienMoiNhat = listLinhKienMoiNhat;
            return View();
        }

        // Menu
        public ActionResult MenuPartial()
        {
            var listSanPham = _sanPhamService.LayTatCa();
            return PartialView(listSanPham);
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(ThanhVien tv, FormCollection frmData)
        {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            try
            {
                if (ModelState.IsValid)
                {
                    var repass = frmData["NhapLaiMatKhau"];
                    if (!tv.MatKhau.Equals(repass))
                    {
                        ViewBag.Message = "Mật khẩu xác nhận không chính xác!";
                        return View();
                    }
                    if (this.IsCaptchaValid("Captcha is not valid"))
                    {
                        tv.MaLTV = 1;
                        _thanhVienService.ThemMoi(tv);
                        _thanhVienService.luu();
                        ViewBag.Message = "Thêm Thành Công";
                        return View();
                    }
                    ViewBag.Message = "Sai mã captcha";
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Tài khoản đã tồn tại! vui lòng đăng ký tài khoản khác!";
                ModelState.AddModelError("TaiKhoan", "Tài khoản đã tồn tại!");
            }
            return View();
        }

        public List<string> LoadCauHoi()
        {
            List<string> listCauHoi = new List<string>();
            listCauHoi.Add("Thầy giáo mà bạn yêu thích nhất ?");
            listCauHoi.Add("Con vật mà bạn yêu thích ?");
            listCauHoi.Add("Nghề nghiệp của bạn là gì ?");
            return listCauHoi;
        }
    }
}