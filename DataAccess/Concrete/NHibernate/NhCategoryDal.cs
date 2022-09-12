using Core.DataAccess.NHibernate;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal : NhEntityRepositoryBase<Category>, ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper) { }
    }
}