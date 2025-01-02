using DapperRealEstate.Services.PropertyDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Default
{
    public class SliderViewComponent :ViewComponent
    {
        private readonly IPropertyDetailService _propertyDetailService;

        public SliderViewComponent(IPropertyDetailService propertyDetailService)
        {
            _propertyDetailService = propertyDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _propertyDetailService.GetSliderPropertyAsync();
            return View(values);
        }
    }
}
