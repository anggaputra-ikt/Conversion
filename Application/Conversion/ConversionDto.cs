using Application.Enum;

namespace Application.Conversion
{
	public class ConversionDto
	{
		public EConversion ConversionFrom { get; set; }
		public double ConversionFromValue { get; set; }
		public EConversion ConversionTo { get; set; }
		public double ConversionToValue { get; set; }
	}
}
