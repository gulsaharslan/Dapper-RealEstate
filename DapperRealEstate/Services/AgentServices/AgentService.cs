using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.AgentDtos;
using System.Globalization;

namespace DapperRealEstate.Services.AgentServices
{
    public class AgentService : IAgentService
    {
        private readonly RealEstateContext _context;

        public AgentService(RealEstateContext context)
        {
            _context = context;
        }

        public async Task CreateAgentAsync(CreateAgentDto createAgentDto)
        {
            string query = "Insert Into Agent(AgentName) values (@agentName)";
            var parameters = new DynamicParameters();
            parameters.Add("@agentName", createAgentDto.AgentName);
            var connection=_context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAgentAsync(int id)
        {
            string query = "Delete From Agent Where AgentId=@agentId";
            var parameters = new DynamicParameters();
            parameters.Add("@agentId", id);
            var connection=_context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<GetByIdAgentDto> GetAgentAsync(int id)
        {
            string query = "Select * From Agent Where AgentId=@agentId";
            var parameters = new DynamicParameters();
            parameters.Add("@agentId",id);
            var connection=_context.CreateConnection();
            var values=await connection.QueryFirstOrDefaultAsync<GetByIdAgentDto>(query);
            return values;
        }

        public async Task<List<ResultAgentDto>> GetAllAgentAsync()
        {
            string query = "Select * From Agent";
            var connection=_context.CreateConnection();
            var values=await connection.QueryAsync<ResultAgentDto>(query);
            return values.ToList();
        }

        public async Task UpdateAgentAsync(UpdateAgentDto updateAgentDto)
        {
            string query = "Update Agent Set AgentName=@agentName where AgentId=@agentId";
            var parameters = new DynamicParameters();
            parameters.Add("@agentName", updateAgentDto.AgentName);
            parameters.Add("@agentId", updateAgentDto.AgentId);
            var connection=_context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
