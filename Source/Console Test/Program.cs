using Application.Conversion;
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
            var conversionResult = conversionService.Convert(conversionDto);
            Console.WriteLine(conversionResult);
        }
    }
}