using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;
using System.Linq;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    public interface ILoaiThanhVienRepository : IRepository<LoaiThanhVien>
    {
        // Custom
    }

    public class LoaiThanhVienRepository : RepositoryBase<LoaiThanhVien>, ILoaiThanhVienRepository
    {
        public LoaiThanhVienRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}