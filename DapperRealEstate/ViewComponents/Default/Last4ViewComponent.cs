using DapperRealEstate.Services.PropertyDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Default
{
    public class Last4ViewComponent : ViewComponent
    {
        private readonly IPropertyDetailService _propertyDetailService;

        public Last4ViewComponent(IPropertyDetailService propertyDetailService)
        {
            _propertyDetailService = propertyDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _propertyDetailService.GetLast4PropertyAsync();
            return View(values);
        }
    }
}
