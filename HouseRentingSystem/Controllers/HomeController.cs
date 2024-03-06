using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.ViewModels.Home;
using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : BaseController
    {
        //Injecing the needed service to the controller before using it afterwards

        private readonly ILogger<HomeController> _logger;
        private readonly IHouseService _houseService;
        public HomeController(ILogger<HomeController> logger, IHouseService houseService)
        {
            _logger = logger;
            _houseService = houseService;
        }

        [AllowAnonymous] // cause HomeCTR inherits BaseCTR which is AUTHORIZED 
        public async Task<IActionResult> Index()
        {
            var model = await _houseService.LastThreeHousesAsync();
            return View(model);
        }


        [AllowAnonymous] // cause HomeCTR inherits BaseCTR which is AUTHORIZED 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
