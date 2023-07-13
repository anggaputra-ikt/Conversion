using Application.Enum;

namespace Application.Domain
{
    public class Conversion
    {
        public EConversion ConversionFrom { get; set; }
        public double ConversionFromValue { get; set; }
        public EConversion ConversionTo { get; set; }
        public double ConversionToValue { get; set; }
    }
}
