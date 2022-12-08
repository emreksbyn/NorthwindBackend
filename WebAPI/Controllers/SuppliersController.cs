using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var list = _supplierService.GetList();
            if (list.Success) return Ok(list);
            return BadRequest(list);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int supplierId)
        {
            var supplier = _supplierService.GetById(supplierId);
            if (supplier.Success) return Ok(supplier);
            return BadRequest(supplier);
        }

        [HttpPost("add")]
        public IActionResult Add(CreateSupplierDto createSupplierDto)
        {
            var result = _supplierService.Add(createSupplierDto);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UpdateSupplierDto updateSupplierDto)
        {
            var result = _supplierService.Update(updateSupplierDto);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UpdateSupplierDto updateSupplierDto)
        {
            var result = _supplierService.Delete(updateSupplierDto);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}