using Microsoft.EntityFrameworkCore;
using SRT.DBModels.Interface;

namespace SRT.DBModels.Repos
{
    public class ConfigRepository : IConfigRepository
    {
        protected ApplicationDbContext context;
        public ConfigRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task ExecuteSqlRawAsync(string q)
        {
            await context.Database.ExecuteSqlRawAsync(q);
        }

        public virtual async Task<Config> Add(Config entity)
        {
            context.Configs.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Config?> Delete(int id)
        {
            var entity = await context.Configs.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Configs.Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<Config?> Get(int id)
        {
            return await context.Configs.FindAsync(id);
        }

        public virtual async Task<List<Config>> GetAll()
        {
            return await context.Configs.ToListAsync();
        }

        public virtual async Task<Config> Update(Config entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<Config> Find()
        {
            return context.Configs;
        }
    }
}
