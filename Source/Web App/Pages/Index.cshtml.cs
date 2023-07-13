using Application.Conversion;
using Application.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Web_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConversionService _conversionService;

        public IndexModel(ILogger<IndexModel> logger, IConversionService conversionService)
        {
            _logger = logger;
            _conversionService = conversionService;
        }

        [BindProperty, Display(Name = "Konversi Dari")]
        public EConversion ConversionEnumFrom { get; set; }
        [BindProperty, Display(Name = "Angka Dari")]
        public double ConversionEnumFromValue { get; set; }
        [BindProperty, Display(Name = "Konversi Ke")]
        public EConversion ConversionEnumTo { get; set; }
        [BindProperty, Display(Name = "Angka Ke")]
        public double ConversionEnumToValue { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                var conversionDto = new ConversionDto()
                {
                    ConversionFrom = ConversionEnumFrom,
                    ConversionFromValue = ConversionEnumFromValue,
                    ConversionTo = ConversionEnumTo
                };
                ConversionEnumToValue = _conversionService.Convert(conversionDto);
            }
        }
    }
}