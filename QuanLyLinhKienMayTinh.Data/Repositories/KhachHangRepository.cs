using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    public interface IKhachHangRepository : IRepository<KhachHang>
    {
        // Custom
        IEnumerable<KhachHang> LayKhachHangTheoMaThanhVien(int MaTV);
    }

    public class KhachHangRepository : RepositoryBase<KhachHang>, IKhachHangRepository
    {
        public KhachHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<KhachHang> LayKhachHangTheoMaThanhVien(int MaTV)
        {
            return this.DbContext.KhachHang.Where(x => x.MaTV == MaTV);
        }
    }
}