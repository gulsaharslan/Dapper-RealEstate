using Dapper;
using DapperRealEstate.Context;
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

        public Task DeletePropertyDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultPropertyDetailDto>> GetAllPropertyDetailAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdPropertyDetailDto> GetPropertyDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePropertyDetailAsync(UpdatePropertyDetailDto updatePropertyDetailDto)
        {
            throw new NotImplementedException();
        }
    }
}
