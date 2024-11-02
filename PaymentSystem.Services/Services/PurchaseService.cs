using AutoMapper;
using PaymentSystem.DataLayer.Entities;
using PaymentSystem.DataLayer.EntitiesDTO;
using PaymentSystem.DataLayer.EntitiesDTO.Card;
using PaymentSystem.DataLayer.EntitiesDTO.Product;
using PaymentSystem.Services.Interfaces;

namespace PaymentSystem.Services.Services
{
	public class PurchaseService : IPurchaseService
	{
		IProductService productService;
		ICardService cardService;
		IMapper mapper;

		public PurchaseService(IProductService productService, ICardService cardService, IMapper mapper)
		{
			this.productService = productService;
			this.cardService = cardService;
			this.mapper = mapper;
		}

		public async Task<PurchaseDto> GetPurchaseAsync(CreatePurchaseDto createPurchaseDto)
		{
			if (createPurchaseDto.Products.Any())
			{
				throw new Exception($"No products at bill");
			}

			if (createPurchaseDto.Products.Any(x => x.Quantity <= 0))
			{
				throw new Exception($"Wrong quantity number for one of products");
			}
			Card? discountCard = null;
			var result = new PurchaseDto();
			if (createPurchaseDto.discountCard.HasValue)
			{
				discountCard = await cardService.GetCardByCardNumberAsync(createPurchaseDto.discountCard.Value);
				result.DiscountCard = mapper.Map<CardDto>(discountCard);
			}

			foreach (var product in createPurchaseDto.Products)
			{
				var temp = await productService.GetProductAsync(product.Id);
				if (temp.QuantityInStock < product.Quantity)
				{
					throw new Exception($"For product {temp.Description} quantity in stock is lesser than wanted;");
				}
				temp.QuantityInStock -= product.Quantity;
				var tempDto = mapper.Map<ProductPurchaseDto>(temp);
				tempDto.Quantity = product.Quantity;

				if (tempDto.Quantity >= 5 && temp.IsWholesaleProduct)
					tempDto.Discount = 0.05m;
				else if (discountCard is not null)
					tempDto.Discount = discountCard.Discount;
				else tempDto.Discount = 0;

				result.Products.Add(tempDto);
			}
			result.GenerationDateTime = DateTime.Now;
			result.TotalDiscount = result.Products.Sum(x => x.TotalDiscount);
			result.TotalPrice = result.Products.Sum(x => x.TotalPrice);

			if (result.TotalWithDiscount > createPurchaseDto.BalanceDebitCard)
			{
				throw new Exception($"Not enough money on debit card. Need to have at least {result.TotalWithDiscount}");
			}

			foreach (var product in createPurchaseDto.Products)
			{
				var temp = await productService.GetProductAsync(product.Id);

				await productService.UpdateProductAsync(product.Id, mapper.Map<UpdateProductDto>(temp));
			}
			return result;
		}
	}
}
