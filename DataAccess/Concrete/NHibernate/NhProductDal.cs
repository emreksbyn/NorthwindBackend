using Core.DataAccess.NHibernate;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                var result = from product in session.Query<Product>()
                             join category in session.Query<Category>()
                             on product.CategoryId equals category.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = product.ProductId,
                                 ProductName = product.ProductName,
                                 CategoryName = category.CategoryName
                             };
                return result.ToList();
            }
        }
    }
}