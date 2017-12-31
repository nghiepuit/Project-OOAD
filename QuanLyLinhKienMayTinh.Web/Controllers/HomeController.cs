using CaptchaMvc.HtmlHelpers;
using QuanLyLinhKienMayTinh.Common;
using QuanLyLinhKienMayTinh.Entities;
using QuanLyLinhKienMayTinh.Service;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyLinhKienMayTinh.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILoaiSanPhamService _loaiSanPhamService;
        private ISanPhamService _sanPhamService;
        private IThanhVienService _tvService;
        private ILoaiThanhVien_QuyenService _ltv_quyenService;

        public HomeController(
            ILoaiSanPhamService loaiSanPhamService,
            ISanPhamService sanPhamService,
            IThanhVienService thanhVienService,
            ILoaiThanhVien_QuyenService ltv_quyenService
        )
        {
            this._loaiSanPhamService = loaiSanPhamService;
            this._sanPhamService = sanPhamService;
            this._tvService = thanhVienService;
            this._ltv_quyenService = ltv_quyenService;
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
            if (Session["TaiKhoan"] != null)
            {
                return RedirectToAction("Index");
            }
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
                        ModelState.Remove("MatKhau");
                        return View();
                    }
                    if (this.IsCaptchaValid("Captcha is not valid"))
                    {
                        tv.MaLTV = 2;
                        tv.MatKhau = PasswordHelper.ComputeHash(tv.MatKhau, "MD5", PasswordHelper.GetBytes("Website"));
                        _tvService.ThemMoi(tv);
                        _tvService.luu();
                        ViewBag.Message = "Đăng ký tài khoản thành công! vui lòng đăng nhập để mua hàng";
                        return View();
                    }
                    ModelState.Remove("MatKhau");
                    ViewBag.Message = "Sai mã captcha";
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Tài khoản đã tồn tại! vui lòng đăng ký tài khoản khác!";
                ModelState.AddModelError("TaiKhoan", "Tài khoản đã tồn tại!");
                ModelState.Remove("MatKhau");
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

        [HttpGet]
        public ActionResult DangNhap()
        {
            if (Session["TaiKhoan"] != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection frmDangNhap)
        {
            string TaiKhoan = frmDangNhap["TaiKhoan"].ToString();
            string MatKhau = frmDangNhap["MatKhau"].ToString();
            ThanhVien tv = _tvService.DangNhap(TaiKhoan);
            if (tv != null)
            {
                if (PasswordHelper.VerifyHash(MatKhau, "MD5", tv.MatKhau))
                {
                    var listQuyen = _ltv_quyenService.LayDanhSachQuyenTheoLoaiThanhVien(tv.MaLTV);
                    string Quyen = "";
                    foreach (var item in listQuyen)
                    {
                        Quyen += item.Quyen.MaQuyen + ",";
                    }
                    if(Quyen.Length > 0)
                    {
                        Quyen = Quyen.Substring(0, Quyen.Length - 1);
                        PhanQuyen(tv.TaiKhoan.ToString(), Quyen);
                    }
                    Session["TaiKhoan"] = tv;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ThongBao = "Mật khẩu không chính xác!";
                }
            }
            else
            {
                ViewBag.ThongBao = "Tài khoản không tồn tại!";
            }
            return View();
        }

        private void PhanQuyen(string TaiKhoan, string Quyen)
        {
            FormsAuthentication.Initialize();
            var ticket = new FormsAuthenticationTicket(1,
                TaiKhoan,
                DateTime.Now,
                DateTime.Now.AddHours(3),
                false,
                Quyen,
                FormsAuthentication.FormsCookiePath
            );
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;
            Response.Cookies.Add(cookie);
        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult KhongDuQuyenHan()
        {
            return View();
        }

    }
}