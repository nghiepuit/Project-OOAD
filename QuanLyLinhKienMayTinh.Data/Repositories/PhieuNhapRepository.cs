using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    public interface IPhieuNhapRepository : IRepository<PhieuNhap>
    {
        // Custom
    }

    public class PhieuNhapRepository : RepositoryBase<PhieuNhap>, IPhieuNhapRepository
    {
        public PhieuNhapRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}