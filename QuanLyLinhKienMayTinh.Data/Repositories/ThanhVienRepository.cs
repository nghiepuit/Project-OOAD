using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;
using System.Linq;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    public interface IThanhVienRepository : IRepository<ThanhVien>
    {
        // Custom
    }

    public class ThanhVienRepository : RepositoryBase<ThanhVien>, IThanhVienRepository
    {
        public ThanhVienRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}