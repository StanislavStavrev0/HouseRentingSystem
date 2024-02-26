using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Infrastructure.Data.SeedDb
{

    internal class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        //this will seed only the users with the help of the SeedData() class that we configured
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new SeedData(); //!!!!!!!!!
            builder.HasData(new IdentityUser[] { data.AgentUser, data.GuestUser });
        }
    }
}
