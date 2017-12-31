using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    public interface IQuyenRepository : IRepository<Quyen>
    {
        // Custom
    }

    public class QuyenRepository : RepositoryBase<Quyen>, IQuyenRepository
    {
        public QuyenRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}