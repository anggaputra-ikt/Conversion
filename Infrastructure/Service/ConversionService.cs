using System.Runtime.InteropServices;
using Application.Conversion;
using Application.Domain;
using Application.Enum;

namespace Infrastructure.Service
{
	public class ConversionService : IConversionService
	{
		/// <summary>
		/// Proses konversi dari nilai satuan panjang ke satuan panjang yang lain
		/// </summary>
		/// <param name="conversionDto"></param>
		/// <returns>Hasil dari konversi 'double'</returns>
		public double Process(ConversionDto conversionDto)
		{
			if (conversionDto == null) return default;
			if (conversionDto.ConversionFrom == conversionDto.ConversionTo) return conversionDto.ConversionFromValue;
			var conversion = new Conversion()
			{
				ConversionFrom = conversionDto.ConversionFrom,
				ConversionTo = conversionDto.ConversionTo,
				ConversionFromValue = conversionDto.ConversionFromValue
			};

			/// Variable: conversionStatus
			/// Identifikasi jika status 'false' maka konversi dikali atau dari besar ke kecil
			/// Sebaliknya jika status 'true' maka konversi dibagi atau dari kecil ke besar
			bool conversionStatus = false;
			/// Variable: conversionLevel
			/// Identifikasi jika levelnya minus maka maka konversi dari besar ke kecil
			/// Sebaliknya jika levelnya tidak minus maka konversi dari kecil ke besar
			var conversionLevel = conversion.ConversionFrom - conversion.ConversionTo;
			if (conversionLevel < 0) conversionStatus = false;
			else conversionStatus = true;
			if (conversionStatus == false)
			{
				// Konversi besar ke kecil, mengubah nilai conversionLevel menjadi positif
				conversionLevel *= -1;
				// Perkalian antara nilai yang akan dikonversi dengan level konversinya
				conversion.ConversionToValue = conversionDto.ConversionFromValue * (conversionLevel * 10);
			}
			else
			{
				// Konversi dari kecil ke besar
				var conversionCount = 1;
				for (int i = 0; i < conversionLevel; i++)
				{
					conversionCount *= 10;
				}
				// Pembagian antara nilai yang akan dikonversi dengan level konversinya
				conversion.ConversionToValue = conversionDto.ConversionFromValue / conversionCount;
			}
			return conversion.ConversionToValue;
		}
	}
}