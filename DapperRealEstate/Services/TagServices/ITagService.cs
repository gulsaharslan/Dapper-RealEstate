using DapperRealEstate.Dtos.TagDtos;

namespace DapperRealEstate.Services.TagServices
{
    public interface ITagService
    {
        Task<List<ResultTagDto>> GetAllTagAsync();
        Task CreateTagAsync(CreateTagDto createTagDto);
        Task DeleteTagAsync(int id);
   
    }
}
