using QuanLyLinhKienMayTinh.Common.ViewModels;
using QuanLyLinhKienMayTinh.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        private IChiTietDonDatHangService _ctddhService;
        private IThanhVienService _tvService;
        private IDonDatHangService _ddhService;

        public ThongKeController(
               IChiTietDonDatHangService ctddhService,
               IThanhVienService tvService,
               IDonDatHangService ddhService
        )
        {
            this._ctddhService = ctddhService;
            this._tvService = tvService;
            this._ddhService = ddhService;
        }

        public ActionResult Index(string TuNgay, string DenNgay)
        {
            try
            {
                ViewBag.SoNguoiTruyCap = HttpContext.Application["SoNguoiTruyCap"];
                ViewBag.SoNguoiDangOnline = HttpContext.Application["SoNguoiDangOnline"];
                ViewBag.TongDoanhThu = _ctddhService.ThongKeDoanhThu();
                ViewBag.TongThanhVien = ThongKeThanhVien();
                DateTime rs;
                if (TuNgay == null || TuNgay == "" || !DateTime.TryParse(TuNgay, out rs))
                {
                    TuNgay = "1/1/1970";
                }
                if (DenNgay == null || DenNgay == "" || !DateTime.TryParse(DenNgay, out rs))
                {
                    DenNgay = DateTime.Now.ToString("MM/dd/yyyy");
                }
                TuNgay = DateTime.ParseExact(TuNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                DenNgay = DateTime.ParseExact(DenNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                IEnumerable<ThongKeDoanhThuLoiNhuan> ThongKe = _ddhService.ThongKeDoanhThuLoiNhuan(TuNgay, DenNgay);
                return View(ThongKe);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        public int ThongKeThanhVien()
        {
            var result = 0;
            result = _tvService.TongSoPhanTu();
            return result;
        }
    }
}