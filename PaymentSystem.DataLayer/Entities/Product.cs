using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystem.DataLayer.Entities
{
	public class Product
	{
		public long Id { get; set; }
		public string Description { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }
		public int QuantityInStock { get; set; }
		public bool IsWholesaleProduct { get; set; }
	}
}
