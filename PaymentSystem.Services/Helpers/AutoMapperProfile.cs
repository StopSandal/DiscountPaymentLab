using AutoMapper;
using PaymentSystem.DataLayer.Entities;
using PaymentSystem.DataLayer.EntitiesDTO.Card;
using PaymentSystem.DataLayer.EntitiesDTO.Product;

namespace PaymentSystem.Services.Helpers
{
	public class AutoMapperProfile : Profile
	{

		public AutoMapperProfile()
		{
			ConfigEntitiesMap();
		}
		private void ConfigEntitiesMap()
		{
			MapCard();
			MapProduct();
		}
		private void MapCard()
		{
			// AddCardDTO -> Card
			CreateMap<AddCardDTO, Card>();

			// EditCardDTO -> Card
			CreateMap<EditCardDTO, Card>();

			CreateMap<Card, EditCardDTO>();

			CreateMap<Card, CardDto>();
		}
		private void MapProduct()
		{
			// AddCardDTO -> Card
			CreateMap<AddProductDto, Product>();

			// EditCardDTO -> Card
			CreateMap<UpdateProductDto, Product>();

			CreateMap<Product, UpdateProductDto>();

			CreateMap<Product, ProductPurchaseDto>()
;
		}

	}
}
