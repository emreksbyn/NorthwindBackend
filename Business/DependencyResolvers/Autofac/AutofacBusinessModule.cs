using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
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
            //builder.RegisterType<NorthwindContext>().As<DbContext>();
            //builder.RegisterType<SqlServerHelper>().As<NHibernateHelper>();


            //builder.RegisterType(typeof(EfQueryableRepository<>)).As(typeof(IQueryableRepository<>));


            // IProductService istenirse sen ona ProductManager ver.
            builder.RegisterType<ProductManager>().As<IProductService>();


            // IProductDal istenirse sen ona EfProductDal / NhProductDal ver.
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            //builder.RegisterType<NhProductDal>().As<IProductDal>();



            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            //builder.RegisterType<NhCategoryDal>().As<ICategoryDal>();


            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            // Bütün aspectleri kayıt etmiş oluyoruz.
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}