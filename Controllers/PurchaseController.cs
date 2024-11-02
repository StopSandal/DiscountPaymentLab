using Microsoft.AspNetCore.Mvc;
using PaymentSystem.DataLayer.EntitiesDTO;
using PaymentSystem.Services.Factory;
using PaymentSystem.Services.Interfaces;

namespace PaymentSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseController : Controller
	{
		private readonly IPurchaseService _purchaseService;
		private readonly ILogger<ProductController> _logger;

		public PurchaseController(IPurchaseService purchaseService, ILogger<ProductController> logger)
		{
			_purchaseService = purchaseService;
			_logger = logger;
		}

		[HttpPost("Buy")]
		public async Task<IActionResult> Buy([FromBody] CreatePurchaseDto purchaseDto)
		{
			try
			{
				var Bill = await _purchaseService.GetPurchaseAsync(purchaseDto);
				var converter = ResponseConverterFactory.GetConverter(ConvertTypeEnum.CSV);

				return Ok(converter.Convert(Bill));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error creating taking a bill");
				return BadRequest(ex.Message);
			}
		}
	}
}
