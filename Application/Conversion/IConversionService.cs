using Application.Enum;

namespace Application.Conversion
{
	public interface IConversionService
	{
		double Process(ConversionDto conversionDto);
	}
}
