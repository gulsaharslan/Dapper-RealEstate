using DapperRealEstate.Dtos.CategoryDtos;
using DapperRealEstate.Dtos.PropertyTypeDtos;

namespace DapperRealEstate.Services.PropertyTypeServices
{
    public interface IPropertyTypeService
    {
        Task<List<ResultPropertyTypeDto>> GetAllPropertyTypeAsync();
        Task CreatePropertyTypeAsync(CreatePropertyTypeDto createPropertyTypeDto);
        Task DeletePropertyTypeAsync(int id);
        Task UpdatePropertyTypeAsync(UpdatePropertyTypeDto updatePropertyTypeDto);
        Task<GetByIdPropertyTypeDto> GetPropertyTypeAsync(int id);
        Task<int> GetPropertyTypeCountAsync();
        Task<List<ResultPropertyTypeDto>> GetPropertyTypeWithPropertyCountAsync();
    }
}
