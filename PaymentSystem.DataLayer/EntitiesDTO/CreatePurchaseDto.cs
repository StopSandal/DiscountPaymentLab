using PaymentSystem.DataLayer.EntitiesDTO.Product;
using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.DataLayer.EntitiesDTO
{
	public class CreatePurchaseDto
	{
		public List<ProductDto> Products { get; set; } = [];

		public int? discountCard { get; set; }
		[Required]
		public decimal BalanceDebitCard { get; set; }
	}
}
