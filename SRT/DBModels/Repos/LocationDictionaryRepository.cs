using Microsoft.EntityFrameworkCore;
using SRT.DBModels.Interface;

namespace SRT.DBModels.Repos
{
    public class LocationDictionaryRepository : ILocationDictionaryRepository
    {
        protected ApplicationDbContext context;
        public LocationDictionaryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task ExecuteSqlRawAsync(string q)
        {
            await context.Database.ExecuteSqlRawAsync(q);
        }

        public virtual async Task<LocationDictionary> Add(LocationDictionary entity)
        {
            context.LocationDictionary.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<LocationDictionary?> Delete(int id)
        {
            var entity = await context.LocationDictionary.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.LocationDictionary.Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<LocationDictionary?> Get(int id)
        {
            return await context.LocationDictionary.FindAsync(id);
        }

        public virtual async Task<List<LocationDictionary>> GetAll()
        {
            return await context.LocationDictionary.ToListAsync();
        }

        public virtual async Task<LocationDictionary> Update(LocationDictionary entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<LocationDictionary> Find()
        {
            return context.LocationDictionary;
        }
    }
}
