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

        public ActionResult Index(int page = 1)
        {
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
                    //Kiểm tra nội dung hình ảnh
                    if (HinhAnh[i].ContentLength > 0)
                    {
                        //Kiểm tra định dạng hình ảnh
                        if (HinhAnh[i].ContentType != "image/jpeg" && HinhAnh[i].ContentType != "image/png" && HinhAnh[i].ContentType != "image/gif" && HinhAnh[i].ContentType != "image/jpg")
                        {
                            ViewBag.upload += "Hình ảnh" + i + " không hợp lệ <br />";
                            loi++;
                        }
                        else
                        {
                            //Kiểm tra hình ảnh tồn tại

                            //Lấy tên hình ảnh
                            var fileName = Path.GetFileName(HinhAnh[0].FileName);
                            //Lấy hình ảnh chuyển vào thư mục hình ảnh
                            var path = Path.Combine(Server.MapPath("~/Assets/images/SanPham"), fileName);
                            //Nếu thư mục chứa hình ảnh đó rồi thì xuất ra thông báo
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
            sp.HinhAnh = HinhAnh[0].FileName;
            sp.HinhAnh1 = HinhAnh[1].FileName;
            sp.HinhAnh2 = HinhAnh[2].FileName;
            sp.HinhAnh3 = HinhAnh[3].FileName;

            for (int i = 0; i < HinhAnh.Count(); i++)
            {
                if (HinhAnh[i].ContentLength > 0)
                {
                    //Lấy tên hình ảnh
                    var fileName = Path.GetFileName(HinhAnh[i].FileName);
                    //Lấy hình ảnh chuyển vào thư mục hình ảnh
                    var path = Path.Combine(Server.MapPath("~/Assets/images/SanPham"), fileName);
                    HinhAnh[i].SaveAs(path);
                }
            }
            sp.SoLuongTon = 0;
            if(sp.NgayCapNhat == null)
            {
                sp.NgayCapNhat = DateTime.Now;
            }
            _spService.ThemMoi(sp);
            _spService.luu();
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

            ViewBag.ListNhaCungCap = new SelectList(_nccService.LayTatCa(), "MaNCC", "Ten");
            ViewBag.ListLoaiSanPham = new SelectList(_lspService.LayTatCa(), "MaLSP", "Ten");
            ViewBag.ListNhaSanXuat = new SelectList(_nsxService.LayTatCa(), "MaNSX", "Ten");
            return View(sp);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ChinhSua(SanPham sp, HttpPostedFileBase[] HinhAnh)
        {
            ViewBag.ListNhaCungCap = new SelectList(_nccService.LayTatCa(), "MaNCC", "Ten");
            ViewBag.ListLoaiSanPham = new SelectList(_lspService.LayTatCa(), "MaLSP", "Ten");
            ViewBag.ListNhaSanXuat = new SelectList(_nsxService.LayTatCa(), "MaNSX", "Ten");
            SanPham tp = _spService.LayTheoMa(sp.MaSP);
            // Lưu ảnh
            for (int i = 0; i < HinhAnh.Count(); i++)
            {
                if (HinhAnh[i] != null)
                {
                    //Kiểm tra nội dung hình ảnh
                    if (HinhAnh[i].ContentLength > 0)
                    {
                        //Lấy tên hình ảnh
                        var fileName = Path.GetFileName(HinhAnh[i].FileName);
                        //Lấy hình ảnh chuyển vào thư mục hình ảnh
                        var path = Path.Combine(Server.MapPath("~/Content/images/sanpham"), fileName);
                        //Nếu thư mục chứa hình ảnh đó rồi thì xuất ra thông báo
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        HinhAnh[i].SaveAs(path);
                    }
                }
            }

            if (HinhAnh[0] != null)
            {
                sp.HinhAnh = HinhAnh[0].FileName;
            }
            else
            {
                sp.HinhAnh = tp.HinhAnh;
            }
            if (HinhAnh[1] != null)
            {
                sp.HinhAnh1 = HinhAnh[1].FileName;
            }
            else
            {
                sp.HinhAnh1 = tp.HinhAnh1;
            }
            if (HinhAnh[2] != null)
            {
                sp.HinhAnh2 = HinhAnh[2].FileName;
            }
            else
            {
                sp.HinhAnh2 = tp.HinhAnh2;
            }
            if (HinhAnh[3] != null)
            {
                sp.HinhAnh3 = HinhAnh[3].FileName;
            }
            else
            {
                sp.HinhAnh3 = tp.HinhAnh3;
            }
            _spService.CapNhat(sp);
            _spService.luu();
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
            ViewBag.ThongBao = "Xóa thành công";

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