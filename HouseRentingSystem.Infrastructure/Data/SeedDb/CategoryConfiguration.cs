﻿using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Infrastructure.Data.SeedDb
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();
            builder.HasData(new Category[] { data.CottageCategory, data.DuplexCategory, data.SingleCategory });
        }
    }
}
