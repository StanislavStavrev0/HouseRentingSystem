using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Infrastructure.Data.Common;
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
        private readonly Repository _data;
        public AgentService(Repository data)
        {
            _data = data;
        }
        public Task<bool> ExistsById(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
