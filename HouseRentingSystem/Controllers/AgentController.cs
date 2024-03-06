using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Services;
using HouseRentingSystem.Core.ViewModels.Agent;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using HouseRentingSystem.Attributes;
using static HouseRentingSystem.Core.Constants.MessageConstants;

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
        [NotAnAgent]
        public IActionResult Become()
        {

            var model = new BecomeAgentFormModel();
            return View(model);
        }

        [HttpPost]
        [NotAnAgent]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {

            if (await _agentService.UserWithPhoneNumberExistsAsync(User.Id())) { }
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }

            if (await _agentService.UserHasRentsAsync(User.Id()))
            {
                ModelState.AddModelError("Error", HasRent);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await _agentService.CreateAsync(User.Id(), model.PhoneNumber);

            return RedirectToAction(nameof(HouseController.All), "Houses");
        }
    }
}
