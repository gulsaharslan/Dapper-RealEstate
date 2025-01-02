using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.LocationDtos;

namespace DapperRealEstate.Services.LocationServices
{
    public class LocationService : ILocationService
    {
        private readonly RealEstateContext _context;

        public LocationService(RealEstateContext context)
        {
            _context = context;
        }

        public async Task CreateLocationAsync(CreateLocationDto createLocationDto)
        {
            string query = "Insert Into Location (LocationName) values (@locationName)";
            var parameters = new DynamicParameters();
            parameters.Add("@locationName", createLocationDto.LocationName);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteLocationAsync(int id)
        {
            string query = "Delete From Location Where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultLocationDto>> GetAllLocationAsync()
        {
            string query = "Select * From Location";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultLocationDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdLocationDto> GetLocationAsync(int id)
        {
            string query = "Select * From Location Where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdLocationDto>(query, parameters);
            return values;
        }

        public async Task<int> GetLocationCountAsync()
        {
            string query = "Select Count(*) From Location";
            var connection = _context.CreateConnection();
            var value=await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public Task UpdateLocationAsync(UpdateLocationDto updateLocationDto)
        {
            throw new NotImplementedException();
        }
    }
}
