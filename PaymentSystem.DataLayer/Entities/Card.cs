using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystem.DataLayer.Entities
{
	public class Card
	{
		public long Id { get; set; }
		public int CardNumber { get; set; }

		[Range(0, 1)]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Discount { get; set; }
	}
}
