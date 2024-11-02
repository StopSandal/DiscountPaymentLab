using PaymentSystem.DataLayer.Interfaces;
using PaymentSystem.Services.Interfaces;
using System.Globalization;
using System.Text;

namespace PaymentSystem.Services.Factory.Converters
{
	internal class CsvConverter : IConverter
	{
		public string Convert(IConvertibleProductDto dto)
		{
			var csvBuilder = new StringBuilder();
			var culture = CultureInfo.InvariantCulture;

			// Date and Time
			csvBuilder.AppendLine($"Date;Time");
			csvBuilder.AppendLine($"{dto.GenerationDateTime:dd.MM.yyyy};{dto.GenerationDateTime:HH:mm:ss}");

			// Product List Header
			csvBuilder.AppendLine($"QTY;DESCRIPTION;PRICE;DISCOUNT;TOTAL");

			// Products
			foreach (var product in dto.Products)
			{
				csvBuilder.AppendLine($"{product.Quantity};{product.Description};{product.Price.ToString("0.00", culture)}$;" +
									  $"{product.TotalDiscount.ToString("0.00", culture)}$;{product.TotalPrice.ToString("0.00", culture)}$");
			}

			if (dto.DiscountCard is not null)
			{
				// Discount Card
				csvBuilder.AppendLine();
				csvBuilder.AppendLine($"DISCOUNT CARD;DISCOUNT PERCENTAGE");

				csvBuilder.AppendLine($"{dto.DiscountCard.CardNumber};{dto.DiscountCard.Discount.ToString("0.00", culture)}%");
			}


			// Summary
			csvBuilder.AppendLine();
			csvBuilder.AppendLine($"TOTAL PRICE;TOTAL DISCOUNT;TOTAL WITH DISCOUNT");
			csvBuilder.AppendLine($"{dto.TotalPrice.ToString("0.00", culture)}$;" +
								  $"{dto.TotalDiscount.ToString("0.00", culture)}$;" +
								  $"{dto.TotalWithDiscount.ToString("0.00", culture)}$");

			return csvBuilder.ToString();
		}
	}
}
