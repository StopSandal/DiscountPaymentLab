namespace PaymentSystem.DataLayer.EntitiesDTO.Product
{
	public class ProductPurchaseDto
	{
		public int Quantity { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public decimal TotalPrice => Quantity * Price;

		public decimal Discount { get; set; }

		public decimal TotalDiscount => TotalPrice * Discount;
	}
}
