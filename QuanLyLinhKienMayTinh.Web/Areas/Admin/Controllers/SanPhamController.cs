using QuanLyLinhKienMayTinh.Common;
using QuanLyLinhKienMayTinh.Entities;
using QuanLyLinhKienMayTinh.Service;
using QuanLyLinhKienMayTinh.Web.Infrastructure.Core;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        private INhaCungCapService _nccService;
        private INhaSanXuatService _nsxService;
        private ILoaiSanPhamService _lspService;
        private ISanPhamService _spService;

        public SanPhamController(
            INhaCungCapService nccService,
            INhaSanXuatService nsxService,
            ILoaiSanPhamService lspService,
            ISanPhamService spService
        )
        {
            this._nccService = nccService;
            this._nsxService = nsxService;
            this._lspService = lspService;
            this._spService = spService;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            ViewBag.listLoaiSanPham = _lspService.LayTatCa();
            int pageSize = 10;
            int totalRow = 0;
            var list = _spService.LayTatCaPhanTrang(page, pageSize, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<SanPham>()
            {
                Items = list,
                MaxPage = 5,
                PageIndex = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
                Count = list.Count()
            };

            return View("Index", paginationSet);
        }

        [HttpPost]
        public ActionResult Index(FormCollection frmTimKiem, int page = 1)
        {
            ViewBag.listLoaiSanPham = _lspService.LayTatCa();
            int LoaiSanPham = -1;
            if (frmTimKiem["LoaiSanPham"] != null)
                LoaiSanPham = int.Parse(frmTimKiem["LoaiSanPham"].ToString());
            string TuNgay = frmTimKiem["TuNgay"].ToString();
            string DenNgay = frmTimKiem["DenNgay"].ToString();
            string TuKhoa = frmTimKiem["TuKhoa"].ToString();

            int pageSize = 10;
            int totalRow = 0;
            var list = _spService.LayTatCaPhanTrang(page, pageSize, out totalRow,
                LoaiSanPham, TuNgay, DenNgay, TuKhoa);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<SanPham>()
            {
                Items = list,
                MaxPage = 5,
                PageIndex = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
                Count = list.Count()
            };

            return View("Index", paginationSet);
        }

        [HttpGet]
        public ActionResult TaoMoi()
        {
            ViewBag.MaNCC = new SelectList(_nccService.LayTatCa(), "MaNCC", "Ten");
            ViewBag.MaLSP = new SelectList(_lspService.LayTatCa(), "MaLSP", "Ten");
            ViewBag.MaNSX = new SelectList(_nsxService.LayTatCa(), "MaNSX", "Ten");

            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult TaoMoi(SanPham sp, HttpPostedFileBase[] HinhAnh)
        {
            ViewBag.MaNCC = new SelectList(_nccService.LayTatCa(), "MaNCC", "Ten");
            ViewBag.MaLSP = new SelectList(_lspService.LayTatCa(), "MaLSP", "Ten");
            ViewBag.MaNSX = new SelectList(_nsxService.LayTatCa(), "MaNSX", "Ten");

            int loi = 0;
            for (int i = 0; i < HinhAnh.Count(); i++)
            {
                if (HinhAnh[i] != null)
                {
                    if (HinhAnh[i].ContentLength > 0)
                    {
                        if (HinhAnh[i].ContentType != "image/jpeg" && HinhAnh[i].ContentType != "image/png" && HinhAnh[i].ContentType != "image/gif" && HinhAnh[i].ContentType != "image/jpg")
                        {
                            ViewBag.upload += "Hình ảnh" + i + " không hợp lệ <br />";
                            loi++;
                        }
                        else
                        {
                            var fileName = Path.GetFileName(HinhAnh[0].FileName);
                            var path = Path.Combine(Server.MapPath("~/Assets/images/SanPham"), fileName);
                            if (System.IO.File.Exists(path))
                            {
                                ViewBag.upload = "Hình " + i + "đã tồn tại <br />";
                                loi++;
                            }
                        }
                    }
                }
            }
            if (loi > 0)
            {
                return View(sp);
            }

            if (HinhAnh[0] != null)
                sp.HinhAnh = UploadHelper.RenameImage(Path.GetExtension(HinhAnh[0].FileName));
            if (HinhAnh[1] != null)
                sp.HinhAnh1 = UploadHelper.RenameImage(Path.GetExtension(HinhAnh[1].FileName));
            if (HinhAnh[2] != null)
                sp.HinhAnh2 = UploadHelper.RenameImage(Path.GetExtension(HinhAnh[2].FileName));
            if (HinhAnh[3] != null)
                sp.HinhAnh3 = UploadHelper.RenameImage(Path.GetExtension(HinhAnh[3].FileName));

            if (HinhAnh[0] != null && HinhAnh[0].ContentLength > 0)
            {
                var fileName = Path.GetFileName(sp.HinhAnh);
                var path = Path.Combine(Server.MapPath("~/Assets/images/SanPham"), fileName);
                HinhAnh[0].SaveAs(path);
            }

            if (HinhAnh[1] != null && HinhAnh[1].ContentLength > 0)
            {
                var fileName1 = Path.GetFileName(sp.HinhAnh1);
                var path = Path.Combine(Server.MapPath("~/Assets/images/SanPham"), fileName1);
                HinhAnh[1].SaveAs(path);
            }

            if (HinhAnh[2] != null && HinhAnh[2].ContentLength > 0)
            {
                var fileName2 = Path.GetFileName(sp.HinhAnh2);
                var path = Path.Combine(Server.MapPath("~/Assets/images/SanPham"), fileName2);
                HinhAnh[2].SaveAs(path);
            }

            if (HinhAnh[3] != null && HinhAnh[3].ContentLength > 0)
            {
                var fileName3 = Path.GetFileName(sp.HinhAnh3);
                var path = Path.Combine(Server.MapPath("~/Assets/images/SanPham"), fileName3);
                HinhAnh[3].SaveAs(path);
            }

            sp.SoLuongTon = 0;
            sp.NgayCapNhat = DateTime.Now;
            _spService.ThemMoi(sp);
            _spService.luu();
            TempData["Message"] = "Thêm thành công!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChinhSua(int id)
        {
            SanPham sp = _spService.LayTheoMa(id);
            if (sp == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaNCC = new SelectList(_nccService.LayTatCa(), "MaNCC", "Ten");
            ViewBag.MaLSP = new SelectList(_lspService.LayTatCa(), "MaLSP", "Ten");
            ViewBag.MaNSX = new SelectList(_nsxService.LayTatCa(), "MaNSX", "Ten");
            return View(sp);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ChinhSua(int id, SanPham sp, HttpPostedFileBase[] HinhAnh)
        {
            ViewBag.MaNCC = new SelectList(_nccService.LayTatCa(), "MaNCC", "Ten");
            ViewBag.MaLSP = new SelectList(_lspService.LayTatCa(), "MaLSP", "Ten");
            ViewBag.MaNSX = new SelectList(_nsxService.LayTatCa(), "MaNSX", "Ten");
            SanPham tp = _spService.LayTheoMa(id);

            var fileName = "";
            var fileName1 = "";
            var fileName2 = "";
            var fileName3 = "";
            if (HinhAnh[0] != null)
            {
                if (HinhAnh[0].ContentLength > 0)
                {
                    fileName = UploadHelper.RenameImage(Path.GetExtension(HinhAnh[0].FileName));
                    var path = Path.Combine(Server.MapPath("~/Assets/images/SanPham"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    HinhAnh[0].SaveAs(path);
                }
            }

            if (HinhAnh[1] != null)
            {
                if (HinhAnh[1].ContentLength > 0)
                {
                    fileName = UploadHelper.RenameImage(Path.GetExtension(HinhAnh[1].FileName));
                    var path = Path.Combine(Server.MapPath("~/Assets/images/SanPham"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    HinhAnh[1].SaveAs(path);
                }
            }

            if (HinhAnh[2] != null)
            {
                if (HinhAnh[2].ContentLength > 0)
                {
                    fileName = UploadHelper.RenameImage(Path.GetExtension(HinhAnh[2].FileName));
                    var path = Path.Combine(Server.MapPath("~/Assets/images/SanPham"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    HinhAnh[2].SaveAs(path);
                }
            }

            if (HinhAnh[3] != null)
            {
                if (HinhAnh[3].ContentLength > 0)
                {
                    fileName = UploadHelper.RenameImage(Path.GetExtension(HinhAnh[3].FileName));
                    var path = Path.Combine(Server.MapPath("~/Assets/images/SanPham"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    HinhAnh[3].SaveAs(path);
                }
            }

            if (HinhAnh[0] != null)
            {
                sp.HinhAnh = fileName;
            }
            else
            {
                sp.HinhAnh = tp.HinhAnh;
            }
            if (HinhAnh[1] != null)
            {
                sp.HinhAnh1 = fileName1;
            }
            else
            {
                sp.HinhAnh1 = tp.HinhAnh1;
            }
            if (HinhAnh[2] != null)
            {
                sp.HinhAnh2 = fileName2;
            }
            else
            {
                sp.HinhAnh2 = tp.HinhAnh2;
            }
            if (HinhAnh[3] != null)
            {
                sp.HinhAnh3 = fileName3;
            }
            else
            {
                sp.HinhAnh3 = tp.HinhAnh3;
            }
            sp.NgayCapNhat = DateTime.Now;
            _spService.CapNhat(sp);
            _spService.luu();
            TempData["Message"] = "Cập nhật thành công!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int id)
        {
            SanPham sp = _spService.LayTheoMa(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            sp.DaXoa = true;
            _spService.CapNhat(sp);
            _spService.luu();
            TempData["Message"] = "Xóa thành công";

            return RedirectToAction("Index");
        }

        public ActionResult DanhSachDaXoa()
        {
            return View();
        }

        [HttpGet]
        public ActionResult HoanTac(int id)
        {
            SanPham sp = _spService.LayTheoMa(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            sp.DaXoa = false;
            _spService.CapNhat(sp);
            _spService.luu();
            ViewBag.ThongBao = "Hoàn tác thành công";

            return RedirectToAction("Index");
        }
    }
}