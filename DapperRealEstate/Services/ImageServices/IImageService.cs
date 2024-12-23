using DapperRealEstate.Dtos.ImageDtos;

namespace DapperRealEstate.Services.ImageServices
{
    public interface IImageService
    {
        Task<List<ResultImageDto>> GetAllImageAsync(int propertyDetailId);
        Task CreateImageAsync(CreateImageDto createImageDto);
        Task DeleteImageAsync(int id);
        Task UpdateImageAsync(UpdateImageDto updateImageDto);
        Task<GetByIdImageDto> GetImageAsync(int id);
    }
}
