using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;
using System.Linq;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    public interface IChiTietDonDatHangRepository : IRepository<ChiTietDonDatHang>
    {
        // Custom
    }

    public class ChiTietDonDatHangRepository : RepositoryBase<ChiTietDonDatHang>, IChiTietDonDatHangRepository
    {
        public ChiTietDonDatHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}