using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.TagDtos;

namespace DapperRealEstate.Services.TagServices
{
    public class TagService : ITagService
    {
        private readonly RealEstateContext _context;

        public TagService(RealEstateContext context)
        {
            _context = context;
        }

        public async Task CreateTagAsync(CreateTagDto createTagDto)
        {
            string query = "Insert Into Tag (TagName) values (@tagName)";
            var parameters = new DynamicParameters();
            parameters.Add("@tagName", createTagDto.TagName);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteTagAsync(int id)
        {
            string query = "Delete From Tag Where TagId=@tagId";
            var parameters = new DynamicParameters();
            parameters.Add("@tagId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultTagDto>> GetAllTagAsync()
        {
            string query = "Select * From Tag";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultTagDto>(query);
            return values.ToList();
        }
    }
}
