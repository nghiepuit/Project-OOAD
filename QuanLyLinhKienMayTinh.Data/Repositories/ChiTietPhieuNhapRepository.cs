using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{

    public interface IChiTietPhieuNhapRepository : IRepository<ChiTietPhieuNhap>
    {
        // Custom
    }

    public class ChiTietPhieuNhapRepository : RepositoryBase<ChiTietPhieuNhap>, IChiTietPhieuNhapRepository
    {
        public ChiTietPhieuNhapRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
