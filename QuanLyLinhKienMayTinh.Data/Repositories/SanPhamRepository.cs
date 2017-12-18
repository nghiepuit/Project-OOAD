using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    // Tự viết thêm phương thức
    public interface ISanPhamRepository : IRepository<SanPham>
    {
        IEnumerable<SanPham> TimSanPhamTheoTen(string Ten);
    }

    public class SanPhamRepository : RepositoryBase<SanPham>, ISanPhamRepository
    {
        public SanPhamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<SanPham> TimSanPhamTheoTen(string Ten)
        {
            return this.DbContext.SanPham.Where(x => x.Ten == Ten);
        }
    }
}