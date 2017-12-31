using QuanLyLinhKienMayTinh.Entities;
using QuanLyLinhKienMayTinh.Service;
using QuanLyLinhKienMayTinh.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "QuanTri,QuanLyPhieuNhap")]
    public class PhieuNhapController : Controller
    {
        private INhaCungCapService _nccService;
        private ISanPhamService _spService;
        private IPhieuNhapService _pnService;
        private IChiTietPhieuNhapService _ctpnService;

        public PhieuNhapController(
            INhaCungCapService nccService,
            ISanPhamService spService,
            IPhieuNhapService pnService,
            IChiTietPhieuNhapService ctpnService
        )
        {
            this._nccService = nccService;
            this._spService = spService;
            this._pnService = pnService;
            this._ctpnService = ctpnService;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)

        {
            int pageSize = 10;
            int totalRow = 0;
            var list = _ctpnService.LayTatCaPhanTrang(page, pageSize, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<ChiTietPhieuNhap>()
            {
                Items = list,
                MaxPage = 5,
                PageIndex = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
                Count = list.Count()
            };

            return View("DanhSachPhieuNhap", paginationSet);
        }

        // GET: Admin/PhieuNhap
        [HttpGet]
        public ActionResult NhapHang()
        {
            ViewBag.MaNCC = _nccService.LayTatCa();
            ViewBag.ListSanPham = _spService.LayTatCa();
            return View();
        }

        [HttpPost]
        public ActionResult NhapHang(PhieuNhap pn, IEnumerable<ChiTietPhieuNhap> ctpn)
        {
            ViewBag.MaNCC = _nccService.LayTatCa();
            ViewBag.ListSanPham = _spService.LayTatCa();
            _pnService.ThemMoi(pn);
            _pnService.luu();
            foreach (var item in ctpn)
            {
                // update Số Lượng Tồn
                SanPham sp = _spService.LayTheoMa(item.MaSP);
                sp.SoLuongTon += item.SoLuongNhap;

                item.MaPN = pn.MaPN;
                _ctpnService.ThemMoi(item);
            }
            _ctpnService.luu();
            ViewBag.Message = "Nhập hàng thành công!";
            return View();
        }

        [HttpGet]
        public ActionResult SanPhamSapHetHang()
        {
            var listSanPham = _spService.LaySanPhamSapHetHang(5);
            return View(listSanPham);
        }

        [HttpGet]
        public ActionResult NhapHangDon(int id)
        {
            ViewBag.MaNCC = _nccService.LayTatCa();
            SanPham sp = _spService.LayTheoMa(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

        [HttpPost]
        public ActionResult NhapHangDon(PhieuNhap pn, ChiTietPhieuNhap ctpn)
        {
            ViewBag.MaNCC = _nccService.LayTatCa();
            if (pn.NgayNhap == null)
            {
                pn.NgayNhap = DateTime.Now;
            }
            _pnService.ThemMoi(pn);
            _pnService.luu();
            // update Số Lượng Tồn
            SanPham sp = _spService.LayTheoMa(ctpn.MaSP);
            sp.SoLuongTon += ctpn.SoLuongNhap;
            ctpn.MaPN = pn.MaPN;
            _ctpnService.ThemMoi(ctpn);
            _ctpnService.luu();
            return RedirectToAction("SanPhamSapHetHang");
        }
    }
}