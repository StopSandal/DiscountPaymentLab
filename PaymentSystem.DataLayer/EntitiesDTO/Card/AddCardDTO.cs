using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.DataLayer.EntitiesDTO.Card
{
	public class AddCardDTO
	{
		[Required]
		public int CardNumber { get; set; }

		[Range(0, 1)]
		[Required]
		public decimal Discount { get; set; }
	}
}
