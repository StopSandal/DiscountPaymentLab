using PaymentSystem.DataLayer.EntitiesDTO;

namespace PaymentSystem.Services.Interfaces
{
	public interface IPurchaseService
	{
		public Task<PurchaseDto> GetPurchaseAsync(CreatePurchaseDto createPurchaseDto);
	}
}
