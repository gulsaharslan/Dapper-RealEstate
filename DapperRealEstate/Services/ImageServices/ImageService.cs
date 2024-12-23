using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.ImageDtos;

namespace DapperRealEstate.Services.ImageServices
{
    public class ImageService : IImageService
    {
        private readonly RealEstateContext _context;

        public ImageService(RealEstateContext context)
        {
            _context = context;
        }

        public async Task CreateImageAsync(CreateImageDto createImageDto)
        {
            string query = "Insert Into Image (ImageName, PropertyDetailId) values (@imageName, @propertyDetailId)";
            var parameters = new DynamicParameters();
            parameters.Add("@imageName", createImageDto.ImageName);
            parameters.Add("@propertyDetailId", createImageDto.PropertyDetailId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteImageAsync(int id)
        {
            string query = "Delete From Image Where ImageId=@imageId";
            var parameters = new DynamicParameters();
            parameters.Add("@imageId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultImageDto>> GetAllImageAsync(int propertyDetailId)
        {
            string query = "Select * From Image Where PropertyDetailId=@propertyDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyDetailId", propertyDetailId);
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultImageDto>(query, parameters);
            return values.ToList();
        }

        public async Task<GetByIdImageDto> GetImageAsync(int id)
        {
            string query = "Select * From Image Where ImageId=@imageId";
            var parameters = new DynamicParameters();
            parameters.Add("@imageId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdImageDto>(query, parameters);
            return values;
        }

        public async Task UpdateImageAsync(UpdateImageDto updateImageDto)
        {
            string query = "Update Image Set ImageName=@imageName, PropertyDetailId=@propertyDetailId where ImageId=@imageId";
            var parameters = new DynamicParameters();
            parameters.Add("@imageId", updateImageDto.ImageId);
            parameters.Add("@imageName", updateImageDto.ImageName);
            parameters.Add("@propertyDetailId", updateImageDto.PropertyDetailId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
