using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Mapping.AutoMapper;
using Castle.DynamicProxy;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.DataAccess.NHibernate;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.NHibernate;
using DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region NHibernate
            //builder.RegisterType<SqlServerHelper>().As<NHibernateHelper>();
            //builder.RegisterType<NhProductDal>().As<IProductDal>();
            //builder.RegisterType<NhCategoryDal>().As<ICategoryDal>();
            #endregion
            #region in Comment
            //builder.RegisterType<NorthwindContext>().As<DbContext>();
            //builder.RegisterType(typeof(EfQueryableRepository<>)).As(typeof(IQueryableRepository<>)); 
            #endregion

            // IProductService istenirse sen ona ProductManager ver.
            builder.RegisterType<ProductManager>().As<IProductService>();
            // IProductDal istenirse sen ona EfProductDal / NhProductDal ver.
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();


            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<SupplierManager>().As<ISupplierService>().SingleInstance();
            builder.RegisterType<EfSupplierDal>().As<ISupplierDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            #region Aspect Register
            // Bütün aspectleri kayıt etmiş oluyoruz.
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
            #endregion

            #region AutoMapper Register
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                // Register Mapper Profile
                cfg.AddProfile<MappingProfiles>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                // This resolves a new context that can bu used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            #endregion
        }
    }
}