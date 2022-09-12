using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.DataAccess;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        // Baska bir servisi kullanmamiz gerektiginde Dal' i degil Service' i cagiracagiz.
        private ICategoryService _categoryService;
        //private readonly IQueryableRepository<Product> _queryable;

        public ProductManager(IProductDal productDal,
                              ICategoryService categoryService
                              //,
                              /*IQueryableRepository<Product> queryable */)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            //_queryable = queryable;
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), CheckIfCategoryIsEnabled());
            if (result != null)
                return result;
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(filter: p => p.ProductId == productId));
        }

        [PerformanceAspect(interval: 5)]
        public IDataResult<List<Product>> GetList()
        {
            //Thread.Sleep(5000);
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        [SecuredOperation("Product.List,Admin")]
        [CacheAspect(duration: 10)]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(filter: p => p.CategoryId == categoryId).ToList());
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            // _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);

            //using (TransactionScope scope = new TransactionScope())
            //{
            //    try
            //    {
            //        _productDal.Update(product);
            //        // _productDal.Add(product);
            //        return new SuccessResult(Messages.ProductUpdated);
            //        scope.Complete();
            //    }
            //    catch
            //    {
            //        scope.Dispose();
            //    }
            //}
        }

        #region Business Logics
        private IResult CheckIfProductNameExists(string productName)
        {
            if (_productDal.Get(x => x.ProductName == productName) != null)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryIsEnabled()
        {
            var result = _categoryService.GetList();
            if (result.Data.Count < 10)
            {
                return new ErrorResult(Messages.CategoryIsNotEnabled);
            }
            return new SuccessResult();
        }
        #endregion
    }
}