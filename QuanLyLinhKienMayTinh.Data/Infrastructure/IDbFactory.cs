using System;

namespace QuanLyLinhKienMayTinh.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        QuanLyLinhKienMayTinhDbContext Init();
    }
}