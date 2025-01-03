﻿using DapperRealEstate.Services.PropertyDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.ViewComponents.Default
{
    public class RecentPropertyViewComponent : ViewComponent
    {
        private readonly IPropertyDetailService _propertyDetailService;

        public RecentPropertyViewComponent(IPropertyDetailService propertyDetailService)
        {
            _propertyDetailService = propertyDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values=await _propertyDetailService.GetRecentPropertyAsync();
            return View(values);
        }
    }
}
