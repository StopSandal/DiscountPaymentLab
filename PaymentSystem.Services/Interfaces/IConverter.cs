using PaymentSystem.DataLayer.Interfaces;

namespace PaymentSystem.Services.Interfaces
{
	public interface IConverter
	{
		public string Convert(IConvertibleProductDto dto);
	}
}
