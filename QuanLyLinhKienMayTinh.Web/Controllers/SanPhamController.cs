﻿using QuanLyLinhKienMayTinh.Entities;
using QuanLyLinhKienMayTinh.Service;
using QuanLyLinhKienMayTinh.Web.Infrastructure.Core;
using System;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyLinhKienMayTinh.Web.Controllers
{
    public class SanPhamController : Controller
    {
        private ISanPhamService _spService;
        private ILoaiSanPhamService _lspService;

        public SanPhamController(
            ISanPhamService spService,
            ILoaiSanPhamService lspService
        )
        {
            this._spService = spService;
            this._lspService = lspService;
        }

        public ActionResult LaySanPhamTheoDanhMuc(int id, int nsx = -1, int page = 1, string sort = "")
        {
            int pageSize = 20;
            int totalRow = 0;
            var listSanPham = _spService.LaySanPhamTheoDanhMuc(id, nsx, page, pageSize, sort, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<SanPham>()
            {
                Items = listSanPham,
                MaxPage = 5,
                PageIndex = page,
                TotalCount = totalRow,
                TotalPages = totalPage,
                Count = listSanPham.Count()
            };

            var loaiSanPham = _lspService.LayTheoMa(id);
            ViewBag.LoaiSanPham = loaiSanPham;

            return View(paginationSet);
        }
    }
}