using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    // Tự viết thêm phương thức
    public interface ISanPhamRepository : IRepository<SanPham>
    {
        IEnumerable<SanPham> TimSanPhamTheoTen(string Ten);
        IEnumerable<SanPham> LaySanPhamSapHetHang(int SoLuongTon);
        IEnumerable<SanPham> LaySanPhamMoiNhat(int MaLSP, int limit);
    }

    public class SanPhamRepository : RepositoryBase<SanPham>, ISanPhamRepository
    {
        public SanPhamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<SanPham> LaySanPhamMoiNhat(int MaLSP, int limit)
        {
            return this.DbContext.SanPham.Where(x => x.DaXoa == false && x.MaLSP == MaLSP && x.Moi == true).Take(limit);
        }

        public IEnumerable<SanPham> LaySanPhamSapHetHang(int SoLuongTon)
        {
            return this.DbContext.SanPham.Where(x => x.DaXoa == false && x.SoLuongTon <= SoLuongTon);
        }

        public IEnumerable<SanPham> TimSanPhamTheoTen(string Ten)
        {
            return this.DbContext.SanPham.Where(x => x.Ten == Ten);
        }
    }
}