using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.PropertyTypeDtos;

namespace DapperRealEstate.Services.PropertyTypeServices
{
    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly RealEstateContext _context;

        public PropertyTypeService(RealEstateContext context)
        {
            _context = context;
        }

        public async Task CreatePropertyTypeAsync(CreatePropertyTypeDto createPropertyTypeDto)
        {
            string query = "Insert Into PropertyType (PropertyType) values (@propertyType)";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyTypeName", createPropertyTypeDto.PropertyType);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeletePropertyTypeAsync(int id)
        {
            string query = "Delete From PropertyType Where PropertyId=@propertyId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultPropertyTypeDto>> GetAllPropertyTypeAsync()
        {
            string query = "Select * From PropertyType";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultPropertyTypeDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdPropertyTypeDto> GetPropertyTypeAsync(int id)
        {
            string query = "Select * From PropertyType Where PropertyId=@propertyId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdPropertyTypeDto>(query, parameters);
            return values;
        }

        public Task UpdatePropertyTypeAsync(UpdatePropertyTypeDto updatePropertyTypeDto)
        {
            throw new NotImplementedException();
        }
    }
}
