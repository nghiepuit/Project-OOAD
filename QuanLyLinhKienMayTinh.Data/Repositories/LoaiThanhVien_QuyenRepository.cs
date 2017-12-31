using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    public interface ILoaiThanhVien_QuyenRepository : IRepository<LoaiThanhVien_Quyen>
    {
        // Custom
    }

    public class LoaiThanhVien_QuyenRepository : RepositoryBase<LoaiThanhVien_Quyen>, ILoaiThanhVien_QuyenRepository
    {
        public LoaiThanhVien_QuyenRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}