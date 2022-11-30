using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierDal _supplierDal;
        private readonly IMapper _mapper;

        public SupplierManager(ISupplierDal supplierDal, IMapper mapper)
        {
            _supplierDal = supplierDal;
            _mapper = mapper;
        }

        public IResult Add(CreateSupplierDto createSupplierDto)
        {
            Supplier supplier = _mapper.Map<Supplier>(createSupplierDto);
            _supplierDal.Add(supplier);
            return new SuccessResult(Messages.AddingSuccessful);
        }

        public IResult Delete(UpdateSupplierDto deleteSupplierDto)
        {
            Supplier supplier = _mapper.Map<Supplier>(deleteSupplierDto);
            _supplierDal.Delete(supplier);
            return new SuccessResult(Messages.DeletingSuccessful);
        }

        public IResult Update(UpdateSupplierDto updateSupplierDto)
        {
            Supplier supplier = _mapper.Map<Supplier>(updateSupplierDto);
            _supplierDal.Update(supplier);
            return new SuccessResult(Messages.UpdatingSuccessful);
        }

        public IDataResult<SupplierViewModel> GetById(int supplierId)
        {
            Supplier supplier = _supplierDal.Get(s => s.SupplierID == supplierId);
            SupplierViewModel supplierViewModel = _mapper.Map<SupplierViewModel>(supplier);
            return new SuccessDataResult<SupplierViewModel>(supplierViewModel);
        }

        public IDataResult<List<SupplierViewModel>> GetList()
        {
            List<Supplier> suppliers = _supplierDal.GetList().ToList();
            List<SupplierViewModel> supplierViewModels = _mapper.Map<List<SupplierViewModel>>(suppliers);
            return new SuccessDataResult<List<SupplierViewModel>>(supplierViewModels);
        }
    }
}