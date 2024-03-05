using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.ViewModels.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HouseRentingSystem.Controllers
{
   
    public class AgentController : BaseController
    {
        //Injecting the needed service to the controller before using it afterwards
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService)
        {
                _agentService = agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            var model = new BecomeAgentFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            return RedirectToAction(nameof(HouseController.All), "Houses");
        }
    }
}
