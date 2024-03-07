using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.ViewModels.Home;
using HouseRentingSystem.Core.ViewModels.House;
using HouseRentingSystem.Infrastructure.Data.Common;
using static HouseRentingSystem.Infrastructure.Data.Models.House;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRentingSystem.Infrastructure.Data.Models;

namespace HouseRentingSystem.Core.Services.House
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository; //declaring and using the IRepository that will give as a unified copy of the DB that we can reuse
        public HouseService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>().
                Select(c => new HouseCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>().
                AllAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(HouseFormModel model, int agentId)
        {
            Infrastructure.Data.Models.House house = new Infrastructure.Data.Models.House()
            {
                Address = model.Address,
                AgentId = agentId,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Title = model.Title,

            };

            await repository.AddAsync(house);
            await repository.SaveChangeAsync();

            return house.Id;
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.House>()
                .OrderByDescending(h => h.Id)
                .Take(3)
                .Select(h => new HouseIndexServiceModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl
                }).ToListAsync();
        }
    }
}
