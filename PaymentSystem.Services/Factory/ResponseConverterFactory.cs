using PaymentSystem.Services.Factory.Converters;
using PaymentSystem.Services.Interfaces;

namespace PaymentSystem.Services.Factory
{
	public static class ResponseConverterFactory
	{
		public static IConverter GetConverter(ConvertTypeEnum toType)
		{
			switch (toType)
			{
				case ConvertTypeEnum.CSV: return new CsvConverter();
				default: return null;
			}
		}
	}
}
