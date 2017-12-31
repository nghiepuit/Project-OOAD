using QuanLyLinhKienMayTinh.Entities;
using QuanLyLinhKienMayTinh.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Areas.Admin.Controllers
{
    public class QuyenController : Controller
    {
        private IQuyenService _qService;
        private ILoaiThanhVienService _ltvService;
        private ILoaiThanhVien_QuyenService _ltv_qService;

        public QuyenController(
            IQuyenService qService,
            ILoaiThanhVienService ltvService,
            ILoaiThanhVien_QuyenService ltv_qService
        )
        {
            this._qService = qService;
            this._ltvService = ltvService;
            this._ltv_qService = ltv_qService;
        }

        // GET: Admin/Quyen
        public ActionResult Index()
        {
            var listQuyen = _qService.LayTatCa();
            return View(listQuyen);
        }

        [HttpGet]
        public ActionResult TaoMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoMoi(Quyen quyen)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _qService.ThemMoi(quyen);
                    _qService.luu();
                    ViewBag.Message = "Thêm thành công!";
                }
                catch (Exception)
                {
                    ViewBag.Message = "Quyền này đã tồn tại!";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Xoa(string id)
        {
            try
            {
                _qService.Xoa(id);
                _qService.luu();
                TempData["Message"] = "Xóa thành công!";
            }
            catch (Exception)
            {
                TempData["Message"] = "Xóa thất bại!";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PhanQuyen(int id)
        {
            LoaiThanhVien ltv = _ltvService.LayTheoMa(id);
            if (ltv != null)
            {
                ViewBag.DanhSachQuyen = _qService.LayTatCa();
                ViewBag.DanhSachPhanQuyen = _ltv_qService.LayDanhSachQuyenTheoLoaiThanhVien(id);
                return View(ltv);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult PhanQuyen(int id, IEnumerable<LoaiThanhVien_Quyen> listPhanQuyen)
        {
            LoaiThanhVien ltv = _ltvService.LayTheoMa(id);
            if (ltv != null)
            {
                ViewBag.DanhSachQuyen = _qService.LayTatCa();
                ViewBag.DanhSachPhanQuyen = _ltv_qService.LayDanhSachQuyenTheoLoaiThanhVien(id);

                // Phân Quyền
                var listDaPhanQuyen = _ltv_qService.LayDanhSachQuyenTheoLoaiThanhVien(id);

                if (listDaPhanQuyen != null)
                {
                    _ltv_qService.XoaNhieu(listDaPhanQuyen);
                    _ltv_qService.luu();
                }

                if(listPhanQuyen.Count() > 0)
                {
                    foreach (var item in listPhanQuyen)
                    {
                        if (item.MaQuyen != null)
                        {
                            _ltv_qService.ThemMoi(item);
                        }
                    }
                    _ltv_qService.luu();
                    ViewBag.Message = "Phân quyền thành công!";
                }
                return View(ltv);

            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}