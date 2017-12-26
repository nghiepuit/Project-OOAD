using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    public interface INhaCungCapRepository : IRepository<NhaCungCap>
    {
        // customer
    }

    public class NhaCungCapRepository : RepositoryBase<NhaCungCap>, INhaCungCapRepository
    {
        public NhaCungCapRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}