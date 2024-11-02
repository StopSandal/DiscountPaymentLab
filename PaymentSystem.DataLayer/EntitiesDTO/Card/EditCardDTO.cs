using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.DataLayer.EntitiesDTO.Card
{
	public class EditCardDTO
	{
		public long Id { get; set; }
		public int? CardNumber { get; set; }

		[Range(0, 1)]
		public decimal? Discount { get; set; }
	}
}
