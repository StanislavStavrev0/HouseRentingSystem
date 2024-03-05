using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;
        public Repository(HouseRentingDbContext houseDbContext)
        {
            dbContext = houseDbContext;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync( entity);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
