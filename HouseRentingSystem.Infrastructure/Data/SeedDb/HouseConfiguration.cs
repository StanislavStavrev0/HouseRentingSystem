using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Infrastructure.Data.SeedDb
{
    internal class HouseConfiguration : IEntityTypeConfiguration<House>
    {

        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder
                .HasOne(h => h.Category) // should always be with => or else it makes SHADOW entities 
                .WithMany(c => c.Houses)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.Agent)   // should always be with => or else it makes SHADOW entities 
                .WithMany(a => a.Houses)
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();
            builder.HasData(new House[] { data.FirstHouse, data.SecondHouse, data.ThirdHouse });
        }
    }
}
