using DapperRealEstate.Dtos.LocationDtos;
using DapperRealEstate.Services.LocationServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> LocationList()
        {
            var values = await _locationService.GetAllLocationAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            await _locationService.CreateLocationAsync(createLocationDto);
            return RedirectToAction("LocationList");
        }

        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _locationService.DeleteLocationAsync(id);
            return RedirectToAction("LocationList");
        }
    }
}
