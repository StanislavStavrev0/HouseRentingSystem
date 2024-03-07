using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        //implementing the Repository (copy of the DB) to take/use data from it
        private readonly IRepository data;
        public AgentService(IRepository _data)
        {
            data = _data;
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await data.AddAsync(new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });

            await data.SaveChangeAsync();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await data.AllReadOnly<Agent>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int?> GetAgentIdAsync(string userId)
        {
            return (await data.AllReadOnly<Agent>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id;

        }

        public async Task<bool> UserHasRentsAsync(string userId)
        {
            return await data.AllReadOnly<Infrastructure.Data.Models.House>()
                  .AnyAsync(h => h.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await data.AllReadOnly<Agent>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
