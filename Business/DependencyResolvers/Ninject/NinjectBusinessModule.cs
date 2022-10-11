using Business.Abstract;
using Business.Concrete;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.DataAccess.NHibernate;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;

namespace Business.DependencyResolvers.Ninject
{
    public class NinjectBusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();


            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            //Bind(typeof(IQueryableRepository<>)).To(typeof(NhQueryableRepository<>));


            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();
            //Bind<IProductDal>().To<NhProductDal>();


            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>();
        }
    }
}
