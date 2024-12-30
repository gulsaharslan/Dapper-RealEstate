using DapperRealEstate.Dtos.PropertyDetailDtos;
using DapperRealEstate.Services.AgentServices;
using DapperRealEstate.Services.CategoryServices;
using DapperRealEstate.Services.ImageServices;
using DapperRealEstate.Services.LocationServices;
using DapperRealEstate.Services.PropertyDetailServices;
using DapperRealEstate.Services.PropertyTypeServices;
using DapperRealEstate.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Controllers
{
    public class PropertyDetailController : Controller
    {
        private readonly IPropertyTypeService _propertyTypeService;
        private readonly IAgentService _agentService;
        private readonly ILocationService _locationService;
        private readonly IImageService _imageService;
        private readonly ITagService _tagService;
        private readonly ICategoryService _categoryService;
        private readonly IPropertyDetailService _propertyDetailService;

        public PropertyDetailController(IPropertyTypeService propertyTypeService, IAgentService agentService, ILocationService locationService, IImageService imageService, ITagService tagService, ICategoryService categoryService, IPropertyDetailService propertyDetailService)
        {
            _propertyTypeService = propertyTypeService;
            _agentService = agentService;
            _locationService = locationService;
            _imageService = imageService;
            _tagService = tagService;
            _categoryService = categoryService;
            _propertyDetailService = propertyDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> PropertyList()
        {
            var values=await _propertyDetailService.GetAllPropertyDetailAsync();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Tags = await _tagService.GetAllTagAsync();
            ViewBag.Agents = await _agentService.GetAllAgentAsync();
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.Locations = await _locationService.GetAllLocationAsync();
            ViewBag.PropertyTypes = await _propertyTypeService.GetAllPropertyTypeAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreatePropertyDetailDto createPropertyDetailDto)
        {
            await _propertyDetailService.CreatePropertyDetailAsync(createPropertyDetailDto);
            return RedirectToAction("PropertyList");
        }

        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _propertyDetailService.DeletePropertyDetailAsync(id);
            return RedirectToAction("PropertyList");
        }
    }
}
