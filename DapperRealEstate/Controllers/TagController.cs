using DapperRealEstate.Dtos.TagDtos;
using DapperRealEstate.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> TagList()
        {
            var values = await _tagService.GetAllTagAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateTag(CreateTagDto createTagDto)
        {
            await _tagService.CreateTagAsync(createTagDto);
            return RedirectToAction("TagList");
        }

        public async Task<IActionResult> DeleteTag(int id)
        {
            await _tagService.DeleteTagAsync(id);
            return RedirectToAction("TagList");
        }
    }
}
