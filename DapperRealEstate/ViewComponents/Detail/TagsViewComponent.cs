using DapperRealEstate.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Detail
{
    public class TagsViewComponent : ViewComponent
    {
        private readonly ITagService _tagService;

        public TagsViewComponent(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var values=await _tagService.GetAllTagAsync();
            return View(values);
        }
    }
}
