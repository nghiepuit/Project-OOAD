using QuanLyLinhKienMayTinh.Entities;
using QuanLyLinhKienMayTinh.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Areas.Admin.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        private ILoaiSanPhamService _lspService;

        public LoaiSanPhamController(ILoaiSanPhamService lspService)
        {
            this._lspService = lspService;
        }

        // GET: Admin/LoaiSanPham
        public ActionResult Index()
        {
            IEnumerable<LoaiSanPham> DanhSachLoaiSanPham = _lspService.LayTatCa();
            return View(DanhSachLoaiSanPham);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LoaiSanPham model)
        {
            if (ModelState.IsValid)
            {
                _lspService.ThemMoi(model);
                _lspService.luu();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}