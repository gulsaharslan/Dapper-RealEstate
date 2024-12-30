using DapperRealEstate.Services.CategoryServices;
using DapperRealEstate.Services.LocationServices;
using DapperRealEstate.Services.PropertyDetailServices;
using DapperRealEstate.Services.PropertyTypeServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Controllers
{
    

    public class DefaultController : Controller
    {

        private readonly IPropertyTypeService _propertyTypeService;
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;
        private readonly IPropertyDetailService _propertyDetailService;

        public DefaultController(IPropertyTypeService propertyTypeService, ICategoryService categoryService, ILocationService locationService, IPropertyDetailService propertyDetailService)
        {
            _propertyTypeService = propertyTypeService;
            _categoryService = categoryService;
            _locationService = locationService;
            _propertyDetailService = propertyDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Locations = await _locationService.GetAllLocationAsync();
            ViewBag.PropertyTypes = await _propertyTypeService.GetAllPropertyTypeAsync();
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int locationId, int propertyId, int categoryId)
        {
            return RedirectToAction("PropertySearchList", "UIProperty", new {locationId,propertyId,categoryId});
        }


    }
}
