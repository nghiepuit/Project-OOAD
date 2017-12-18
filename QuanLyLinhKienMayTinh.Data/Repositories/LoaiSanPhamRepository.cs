using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    // Tự viết thêm phương thức
    public interface ILoaiSanPhamRepository : IRepository<LoaiSanPham>
    {
        IEnumerable<LoaiSanPham> TimLoaiSanPhamTheoTen(string Ten);
    }

    public class LoaiSanPhamRepository : RepositoryBase<LoaiSanPham>, ILoaiSanPhamRepository
    {
        public LoaiSanPhamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<LoaiSanPham> TimLoaiSanPhamTheoTen(string Ten)
        {
            return this.DbContext.LoaiSanPham.Where(x => x.Ten == Ten);
        }
    }
}