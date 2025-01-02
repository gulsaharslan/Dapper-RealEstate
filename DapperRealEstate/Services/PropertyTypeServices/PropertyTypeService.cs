using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.CategoryDtos;
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

        public async Task<int> GetPropertyTypeCountAsync()
        {
            string query = "Select Count(*) From PropertyType";
            var connection = _context.CreateConnection();
            var value=await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<List<ResultPropertyTypeDto>> GetPropertyTypeWithPropertyCountAsync()
        {
            string query = @"SELECT  pt.PropertyId,pt.PropertyType,COUNT(p.PropertyId) AS PropertyCount FROM 
            PropertyType pt LEFT JOIN PropertyDetail p ON pt.PropertyId = p.PropertyId GROUP BY  pt.PropertyId, pt.PropertyType";

            var connection = _context.CreateConnection();
            var propertyTypes = await connection.QueryAsync<ResultPropertyTypeDto>(query); // Aynı DTO kullanılabilir
            return propertyTypes.ToList();
        }

        public Task UpdatePropertyTypeAsync(UpdatePropertyTypeDto updatePropertyTypeDto)
        {
            throw new NotImplementedException();
        }
    }
}
