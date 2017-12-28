using QuanLyLinhKienMayTinh.Service;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        private IChiTietDonDatHangService _ctddhService;
        private IThanhVienService _tvService;

        public ThongKeController(
               IChiTietDonDatHangService ctddhService,
               IThanhVienService tvService
        )
        {
            this._ctddhService = ctddhService;
            this._tvService = tvService;
        }

        public ActionResult Index()
        {
            ViewBag.SoNguoiTruyCap = HttpContext.Application["SoNguoiTruyCap"];
            ViewBag.SoNguoiDangOnline = HttpContext.Application["SoNguoiDangOnline"];
            ViewBag.TongDoanhThu = _ctddhService.ThongKeDoanhThu();
            ViewBag.TongThanhVien = ThongKeThanhVien();
            return View();
        }

        public int ThongKeThanhVien()
        {
            var result = 0;
            result = _tvService.TongSoPhanTu();
            return result;
        }
    }
}