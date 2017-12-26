using QuanLyLinhKienMayTinh.Service;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILoaiSanPhamService _loaiSanPhamService;
        private ISanPhamService _sanPhamService;

        public HomeController(
            ILoaiSanPhamService loaiSanPhamService,
            ISanPhamService sanPhamService
        )
        {
            this._loaiSanPhamService = loaiSanPhamService;
            this._sanPhamService = sanPhamService;
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

    }
}