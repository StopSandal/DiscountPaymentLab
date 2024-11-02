using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.DataLayer.EntitiesDTO.Product
{
	public class ProductDto
	{
		[Required]
		public long Id { get; set; }

		[Required]
		public int Quantity { get; set; }
	}
}
