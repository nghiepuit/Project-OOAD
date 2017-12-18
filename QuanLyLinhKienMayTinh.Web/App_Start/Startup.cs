using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Service;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(QuanLyLinhKienMayTinh.Web.App_Start.Startup))]

namespace QuanLyLinhKienMayTinh.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Tự chạy auto startup khi ứng dụng chạy
            ConfigAutofac(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<QuanLyLinhKienMayTinhDbContext>().AsSelf().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(LoaiSanPhamRepository).Assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Service
            builder.RegisterAssemblyTypes(typeof(LoaiSanPhamService).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
