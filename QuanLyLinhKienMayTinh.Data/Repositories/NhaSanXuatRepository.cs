using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{

    public interface INhaSanXuatRepository : IRepository<NhaSanXuat>
    {
        // Custom
    }

    public class NhaSanXuatRepository : RepositoryBase<NhaSanXuat>, INhaSanXuatRepository
    {
        public NhaSanXuatRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
