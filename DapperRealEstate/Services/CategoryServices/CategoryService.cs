using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.CategoryDtos;

namespace DapperRealEstate.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly RealEstateContext _context;

        public CategoryService(RealEstateContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "Insert Into Category(CategoryName) values(@categoryName)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategoryDto.CategoryName);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "Delete From Category Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();
        }


        public async Task<GetByIdCategoryDto> GetCategoryAsync(int id)
        {
            string query = "Select * From Category Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
            return values;
        }

        public Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
