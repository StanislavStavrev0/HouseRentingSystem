using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Core.ViewModels.House;
using HouseRentingSystem.Core.Contracts;
using System.Security.Claims;
using HouseRentingSystem.Attributes;

namespace HouseRentingSystem.Controllers
{

    public class HouseController : BaseController
    {
        //implementing the service in the HOUSE CONTROLLER

        private readonly IHouseService houseService;
        private readonly IAgentService agentService;
        public HouseController(IHouseService _houseService, IAgentService _agentService)
        {
            houseService = _houseService;
            agentService = _agentService;

        }
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = new AllHousesQueryModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Mine()
        {
            var model = new AllHousesQueryModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id)
        {
            var model = new HouseDetailsViewModel();
            return View(model);
        }

        [HttpGet]
        [MustBeAgent]
        public async Task<IActionResult> Add()
        {

            var model = new HouseFormModel()
            {
                Categories = await houseService.AllCategoriesAsync()
            };

            return View();
        }

        [HttpPost]
        [MustBeAgent]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            if (await houseService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await houseService.AllCategoriesAsync();
                return View(model);
            }

            int? agentId = await agentService.GetAgentIdAsync(User.Id());

            int newHouseId = await houseService.CreateAsync(model, agentId ?? 0);

            return RedirectToAction(nameof(Details), new { id = newHouseId });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new HouseFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseFormModel model)
        {

            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = new HouseDetailsViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HouseDetailsViewModel model)
        {

            return RedirectToAction(nameof(All));
        }


        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }


        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {

            return RedirectToAction(nameof(Mine));
        }




    }
}
