﻿namespace PaymentSystem.DataLayer.EntitiesDTO.Product
{
	public class AddProductDto
	{
		public string Description { get; set; }

		public decimal Price { get; set; }
		public int QuantityInStock { get; set; }
		public bool IsWholesaleProduct { get; set; }
	}
}