using QuanLyLinhKienMayTinh.Common.ViewModels;
using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.SqlClient;

namespace QuanLyLinhKienMayTinh.Data.Repositories
{
    public interface IDonDatHangRepository : IRepository<DonDatHang>
    {
        // Custom
        IEnumerable<ThongKeDoanhThuLoiNhuan> ThongKeDoanhThuLoiNhuan(string TuNgay, string DenNgay);
    }

    public class DonDatHangRepository : RepositoryBase<DonDatHang>, IDonDatHangRepository
    {
        public DonDatHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ThongKeDoanhThuLoiNhuan> ThongKeDoanhThuLoiNhuan(string TuNgay, string DenNgay)
        {
            var parameters = new object[]{
                new SqlParameter("@fromDate", TuNgay),
                new SqlParameter("@toDate", DenNgay)
            };
            return DbContext.Database.SqlQuery<ThongKeDoanhThuLoiNhuan>("ThongKeDoanhThuLoiNhuan @fromDate,@toDate", parameters);
        }
    }
}