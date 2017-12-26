using QuanLyLinhKienMayTinh.Entities;
using QuanLyLinhKienMayTinh.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Areas.Admin.Controllers
{
    public class NhaSanXuatController : Controller
    {

        private INhaSanXuatService _nsxService;

        public NhaSanXuatController(INhaSanXuatService nsxService)
        {
            this._nsxService = nsxService;
        }

        // GET: Admin/NhaSanXuat
        public ActionResult Index()
        {
            IEnumerable<NhaSanXuat> listNhaSanXuat = _nsxService.LayTatCa();
            return View(listNhaSanXuat);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NhaSanXuat model)
        {
            return View();
        }

    }
}