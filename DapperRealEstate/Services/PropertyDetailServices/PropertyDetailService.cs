using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.LocationDtos;
using DapperRealEstate.Dtos.PropertyDetailDtos;

namespace DapperRealEstate.Services.PropertyDetailServices
{
    public class PropertyDetailService : IPropertyDetailService
    {
        private readonly RealEstateContext _context;

        public PropertyDetailService(RealEstateContext context)
        {
            _context = context;
        }

        public async Task CreatePropertyDetailAsync(CreatePropertyDetailDto createPropertyDetailDto)
        {
            string query = "Insert Into PropertyDetail(Name,Address,Description,Price,ImageUrl,BedRooms,BathRooms,Garage,Year,Area,VideoUrl,LocationId,AgentId,CategoryId,PropertyId,PropertySlider,PropertyHome) values (@name, @address,@description, @price, @imageUrl,@bedRooms,@bathRooms,@garage,@year,@area,@videoUrl,@locationId,@agentId,@categoryId,@propertyId,@propertySlider,@propertyHome)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createPropertyDetailDto.Name);
            parameters.Add("@address",createPropertyDetailDto.Address);
            parameters.Add("@description",createPropertyDetailDto.Description);
            parameters.Add("@price",createPropertyDetailDto.Price);
            parameters.Add("@imageUrl",createPropertyDetailDto.ImageUrl);
            parameters.Add("@bedRooms",createPropertyDetailDto.BedRooms);
            parameters.Add("@bathRooms",createPropertyDetailDto.BathRooms);
            parameters.Add("@garage", createPropertyDetailDto.Garage);
            parameters.Add("@year", createPropertyDetailDto.Year);
            parameters.Add("@area",createPropertyDetailDto.Area);
            parameters.Add("@videourl",createPropertyDetailDto.VideoUrl);
            parameters.Add("@locationId", createPropertyDetailDto.LocationId);
            parameters.Add("@agentId",createPropertyDetailDto.AgentId);
            parameters.Add("@categoryId", createPropertyDetailDto.CategoryId);
            parameters.Add("@propertyId", createPropertyDetailDto.PropertyId);
            parameters.Add("@propertySlider", createPropertyDetailDto.PropertySlider);
            parameters.Add("@propertyHome",createPropertyDetailDto.PropertyHome);
            var connection=_context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }

        public async Task DeletePropertyDetailAsync(int id)
        {
            string query = "Delete From PropertyDetail Where PropertyDetailId=@propertyDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyDetailId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultPropertyDetailDto>> GetAllPropertyDetailAsync()
        {
            string query = "Select * From PropertyDetail Inner Join Location On Location.LocationId=PropertyDetail.LocationId Inner Join Category on Category.CategoryId=PropertyDetail.CategoryId Inner Join PropertyType on PropertyType.PropertyId=PropertyDetail.PropertyId";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultPropertyDetailDto>(query);
            return values.ToList();
        }

        public async Task<List<ResultPropertyDetailDto>> GetLast4PropertyAsync()
        {
            string query = "SELECT TOP 4 PropertyDetailId,  Name,  PropertyType,Description,Area,BedRooms,BathRooms, CategoryName, ImageUrl, Price FROM PropertyDetail Inner Join Category on Category.CategoryId=PropertyDetail.CategoryId Inner Join PropertyType on PropertyType.PropertyId=PropertyDetail.PropertyId ORDER BY  CreatedDate DESC ";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultPropertyDetailDto>(query);
            return values.ToList();
        }

        public async Task<int> GetPropertyCount()
        {
            string query = "Select Count(*) From PropertyDetail";
            var connection = _context.CreateConnection();
            var value=await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<GetByIdPropertyDetailDto> GetPropertyDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultPropertyDetailDto>> GetRecentPropertyAsync()
        {
            string query = "SELECT PropertyDetailId, Name, PropertyType, CategoryName, ImageUrl,Price FROM PropertyDetail Inner Join Category on Category.CategoryId=PropertyDetail.CategoryId Inner Join PropertyType on PropertyType.PropertyId=PropertyDetail.PropertyId  WHERE PropertyHome = 1";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultPropertyDetailDto>(query);
            return values.ToList();
        }

        public async Task<List<ResultPropertyDetailDto>> GetSearchPropertyAsync(int locationId, int propertyId, int categoryId)
        {
            string query = "SELECT * FROM PropertyDetail WHERE LocationId = @locationId AND PropertyId = @propertyId AND CategoryId = @categoryId";

            var parameters = new DynamicParameters();
            parameters.Add("@locationId", locationId);
            parameters.Add("@propertyId", propertyId);
            parameters.Add("@categoryId", categoryId);
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultPropertyDetailDto>(query,parameters);
            return values.ToList();

        }

        public async Task<List<ResultSliderPropertyDto>> GetSliderPropertyAsync()
        {
            string query = "SELECT PropertyId, Name, Address, Description, ImageUrl, Price FROM PropertyDetail WHERE PropertySlider = 1";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultSliderPropertyDto>(query);
            return values.ToList();
        }

        public Task UpdatePropertyDetailAsync(UpdatePropertyDetailDto updatePropertyDetailDto)
        {
            throw new NotImplementedException();
        }
    }
}
