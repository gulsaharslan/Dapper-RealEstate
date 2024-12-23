using DapperRealEstate.Context;
using DapperRealEstate.Services.AgentServices;
using DapperRealEstate.Services.CategoryServices;
using DapperRealEstate.Services.ImageServices;
using DapperRealEstate.Services.LocationServices;
using DapperRealEstate.Services.PropertyDetailServices;
using DapperRealEstate.Services.PropertyTypeServices;
using DapperRealEstate.Services.TagServices;
using DapperRealEstate.Services.TestimonialServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddScoped<RealEstateContext>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IPropertyTypeService, PropertyTypeService>();
builder.Services.AddScoped<IPropertyDetailService, PropertyDetailService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IImageService, ImageService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
