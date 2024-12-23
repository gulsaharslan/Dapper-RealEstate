using DapperRealEstate.Dtos.AgentDtos;
using DapperRealEstate.Services.AgentServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperRealEstate.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public async Task<IActionResult> AgentList()
        {
            var values=await _agentService.GetAllAgentAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAgent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAgent(CreateAgentDto createAgentDto)
        {
            await _agentService.CreateAgentAsync(createAgentDto);
            return RedirectToAction("AgentList");
        }

        public async Task<IActionResult> DeleteAgent(int id)
        {
            await _agentService.DeleteAgentAsync(id);
            return RedirectToAction("AgentList");
        }

       
    }
}
