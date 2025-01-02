using DapperRealEstate.Services.AgentServices;
using DapperRealEstate.Services.CategoryServices;
using DapperRealEstate.Services.LocationServices;
using DapperRealEstate.Services.PropertyDetailServices;
using DapperRealEstate.Services.PropertyTypeServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Default
{
    public class StatisticViewComponent : ViewComponent
    {
        private readonly IPropertyDetailService _propertyDetailService;
        private readonly ILocationService _locationService;
        private readonly IAgentService _agentService;
        private readonly IPropertyTypeService _propertyTypeService;

        public StatisticViewComponent(IPropertyDetailService propertyDetailService, ILocationService locationService, IAgentService agentService, IPropertyTypeService propertyTypeService)
        {
            _propertyDetailService = propertyDetailService;
            _locationService = locationService;
            _agentService = agentService;
            _propertyTypeService = propertyTypeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.location=await _locationService.GetLocationCountAsync();
            ViewBag.type=await _propertyTypeService.GetPropertyTypeCountAsync();
            ViewBag.agent=await _agentService.GetAgentCountAsync();
            ViewBag.property=await _propertyDetailService.GetPropertyCount();
            return View();
        }
    }
}
