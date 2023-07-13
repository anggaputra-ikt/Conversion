using Application.Conversion;
using Application.Domain;
using Infrastructure.Service;

namespace Console_Test
{
	public class Program
	{
        static void Main(string[] args)
		{
			var conversionDto = new ConversionDto()
			{
				ConversionFrom = Application.Enum.EConversion.Meter,
				ConversionFromValue = 23,
				ConversionTo = Application.Enum.EConversion.KiloMeter
			};
			var conversionService = new ConversionService();
			var conversionResult = conversionService.Process(conversionDto);
            Console.WriteLine(conversionResult);
        }
	}
}