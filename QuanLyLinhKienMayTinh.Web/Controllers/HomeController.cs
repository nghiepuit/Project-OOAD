using QuanLyLinhKienMayTinh.Service;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILoaiSanPhamService _loaiSanPhamService;

        public HomeController(ILoaiSanPhamService loaiSanPhamService)
        {
            this._loaiSanPhamService = loaiSanPhamService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}