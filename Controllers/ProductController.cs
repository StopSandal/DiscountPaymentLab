using Microsoft.AspNetCore.Mvc;
using PaymentSystem.DataLayer.EntitiesDTO.Product;

namespace PaymentSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _ProductService;
		private readonly ILogger<ProductController> _logger;

		public ProductController(IProductService ProductService, ILogger<ProductController> logger)
		{
			_ProductService = ProductService;
			_logger = logger;
		}

		/// <summary>
		/// Retrieves Product by id
		/// </summary>
		/// <param name="id">Product id</param>
		/// <returns>Info about asked Product</returns>
		/// <response code="200">Успешное выполнение</response>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductAsync(long id)
		{
			try
			{
				var Product = await _ProductService.GetProductAsync(id);
				if (Product == null)
				{
					return NotFound();
				}
				return Ok(Product);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error getting Product with ID {ProductId}", id);
				return BadRequest(ex.Message);
			}
		}


		[HttpGet]
		public async Task<IActionResult> GetProductsAsync()
		{
			try
			{
				var Products = await _ProductService.GetProductsAsync();
				return Ok(Products);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error getting Products");
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateProductAsync([FromBody] AddProductDto newProduct)
		{
			try
			{
				await _ProductService.CreateProductAsync(newProduct);
				return Created();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error creating Product");
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProductAsync(long id, [FromBody] UpdateProductDto editProduct)
		{
			try
			{
				await _ProductService.UpdateProductAsync(id, editProduct);
				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating Product with ID {ProductId}", id);
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProductAsync(long id)
		{
			try
			{
				await _ProductService.DeleteProductAsync(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error deleting Product with ID {ProductId}", id);
				return BadRequest(ex.Message);
			}
		}
	}

}
