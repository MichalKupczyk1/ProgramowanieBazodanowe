using BLL.DTOModels;
using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Model;

namespace Zad2PB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductInterface _productService;

        public ProductsController(IProductInterface productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProductsByFilters([FromQuery] ProductFilterDto filter, bool descending)
        {
            var products = _productService.GetProductsByFilters(filter.Name, filter.GroupId, filter.ActiveOnly, descending);

            if (products == null || !products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost]
        public int AddProduct([FromBody] ProductRequestDTO productDto)
        {
            var id = -1;
            if (productDto != null)
                id = _productService.AddNewProduct(productDto.Name, productDto.Image, productDto.Price, productDto.GroupId);
            return id;
        }

        [HttpPut("{id}/deactivate")]
        public void DeactivateProduct(int? id)
        {
            if (id.HasValue)
                _productService.DeactivateProduct(id.Value);
        }

        [HttpPut("{id}/activate")]
        public void ActivateProduct(int? id)
        {
            if (id.HasValue)
                _productService.ActivateProduct(id.Value);
        }

        [HttpDelete("{id}")]
        public bool DeleteProduct(int? id)
        {
            return id.HasValue ? _productService.RemoveProduct(id.Value) : false;
        }

        [HttpGet("AddProductToBasket")]
        public bool AddProductToBasket(int productId, int basketId)
        {
            return _productService.AddProductToBasket(productId, basketId);
        }
    }

    public class ProductFilterDto
    {
        public string? Name { get; set; }
        public int? GroupId { get; set; }
        public bool? ActiveOnly { get; set; }
    }
}
