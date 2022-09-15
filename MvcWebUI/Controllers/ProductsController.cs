using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult GetList()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetList().Data
            };
            return View(model);
        }
    }
}