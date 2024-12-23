using DapperRealEstate.Dtos.TestimonialDtos;
using DapperRealEstate.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var values = await _testimonialService.GetAllTestimonialAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialService.CreateTestimonialAsync(createTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("TestimonialList");
        }
    }
}
