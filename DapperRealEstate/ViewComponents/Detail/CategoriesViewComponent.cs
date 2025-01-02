using DapperRealEstate.Services.CategoryServices;
using DapperRealEstate.Services.PropertyTypeServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Detail
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly IPropertyTypeService _propertyTypeService;

        public CategoriesViewComponent(IPropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _propertyTypeService.GetPropertyTypeWithPropertyCountAsync();
            return View(values);
        }
    }
}
