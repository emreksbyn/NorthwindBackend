using DataAccess.Concrete.EntityFramework;
using Xunit;

namespace DataAccess.Tests.EntityFrameworkTests
{
    public class EntityFrameworkTest
    {

        #region Ctor
        EfProductDal _efProductDal;
        public EntityFrameworkTest()
        {
            _efProductDal = new();
        }
        #endregion

        [Fact]
        public void Get_all_returns_all_products()
        {
            var productList = _efProductDal.GetList();
            Assert.Equal(78, productList.Count);
        }

        [Fact]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            var result = _efProductDal.GetList(x => x.ProductName.Contains("ab")).Count;
            Assert.Equal(4, result);
        }
    }
}