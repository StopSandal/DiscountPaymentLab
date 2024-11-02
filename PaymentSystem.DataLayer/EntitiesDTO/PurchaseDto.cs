using PaymentSystem.DataLayer.EntitiesDTO.Card;
using PaymentSystem.DataLayer.EntitiesDTO.Product;
using PaymentSystem.DataLayer.Interfaces;

namespace PaymentSystem.DataLayer.EntitiesDTO
{
	public class PurchaseDto : IConvertibleProductDto
	{
		public DateTime GenerationDateTime { get; set; }

		public List<ProductPurchaseDto> Products { get; set; } = [];
		public CardDto DiscountCard { get; set; }


		public decimal TotalPrice { get; set; }
		public decimal TotalDiscount { get; set; }
		public decimal TotalWithDiscount => TotalPrice - TotalDiscount;


	}
}
