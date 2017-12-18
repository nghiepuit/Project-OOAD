namespace QuanLyLinhKienMayTinh.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private QuanLyLinhKienMayTinhDbContext dbContext;

        public QuanLyLinhKienMayTinhDbContext Init()
        {
            return dbContext ?? (dbContext = new QuanLyLinhKienMayTinhDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}