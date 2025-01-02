using DapperRealEstate.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Default
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialViewComponent(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _testimonialService.GetAllTestimonialAsync();
            return View(values);
        }
    }
}
