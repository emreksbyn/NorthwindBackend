using Core.Utilities.Result;
using Entities.Dtos;
using Entities.ViewModels;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISupplierService
    {
        IDataResult<SupplierViewModel> GetById(int supplierId);
        IDataResult<List<SupplierViewModel>> GetList();
        IResult Add(CreateSupplierDto createSupplierDto);
        IResult Delete(UpdateSupplierDto deleteSupplierDto);
        IResult Update(UpdateSupplierDto updateSupplierDto);
    }
}