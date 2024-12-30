using DapperRealEstate.Dtos.PropertyDetailDtos;

namespace DapperRealEstate.Services.PropertyDetailServices
{
    public interface IPropertyDetailService
    {
        Task<List<ResultPropertyDetailDto>> GetAllPropertyDetailAsync();
        Task CreatePropertyDetailAsync(CreatePropertyDetailDto createPropertyDetailDto);
        Task DeletePropertyDetailAsync(int id);
        Task UpdatePropertyDetailAsync(UpdatePropertyDetailDto updatePropertyDetailDto);
        Task<GetByIdPropertyDetailDto> GetPropertyDetailAsync(int id);
        Task<List<ResultPropertyDetailDto>> GetSearchPropertyAsync(int locationId, int propertyTypeId, int categoryId);
    }
}
