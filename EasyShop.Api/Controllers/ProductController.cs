using EasyShop.Api.Data;
using EasyShop.Api.Dtos.Product;
using EasyShop.Api.Repository.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : Controller
    {
		private readonly IProductService _productService;
		private readonly IProductImageService _productImageService;

		public ProductController(IProductService productService, IProductImageService productImageService)
		{
			_productService = productService;
			_productImageService = productImageService;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllProducts()
		{
			var products = await _productService.GetAllProductsAsync();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(int id)
		{
			var product = await _productService.GetProductByIdAsync(id);
			if (product == null) return NotFound();

			return Ok(product);
		}

		[HttpPost]
		public async Task<IActionResult> AddProduct([FromBody] AddProductDto product)
		{
			if (product == null) return BadRequest("Product data is required.");
		
			var newProduct = await _productService.AddProductAsync(product);
			return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProduct(int id, [FromBody] AddProductDto product)
		{

			var updatedProduct = await _productService.UpdateProductAsync(id,product);
			if (updatedProduct == null) return NotFound();

			return Ok(updatedProduct);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var result = await _productService.DeleteProductAsync(id);
			if (!result) return NotFound();

			return Ok(result);
		}
	}
}
