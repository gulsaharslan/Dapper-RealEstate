using DapperRealEstate.Services.PropertyDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Controllers
{
    public class UIPropertyController : Controller
    {
        private readonly IPropertyDetailService _propertyDetailService;

        public UIPropertyController(IPropertyDetailService propertyDetailService)
        {
            _propertyDetailService = propertyDetailService;
        }

        public async Task<IActionResult> PropertyList()
        {
            var values= await _propertyDetailService.GetAllPropertyDetailAsync();
            return View(values);
        }
        
        public async Task<IActionResult> PropertySearchList(int locationId, int propertyId, int categoryId)
        {
            var values=await _propertyDetailService.GetSearchPropertyAsync(locationId, propertyId, categoryId);
            return View(values);
        }
    }
}
