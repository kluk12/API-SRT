using Microsoft.EntityFrameworkCore;
using SRT.DBModels.Interface;

namespace SRT.DBModels.Repos
{

    public abstract class BaseRepository<T, K> : IBaseRepository<T, K> where T : ApplicationDbContext
    {
        protected ApplicationDbContext context;
        protected DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            _dbSet = this.context.Set<T>(); 
        }
        public async Task ExecuteSqlRawAsync(string q)
        {
            await context.Database.ExecuteSqlRawAsync(q);
        }

        public virtual async Task<T> Add(T entity)
        {
            _dbSet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T?> Delete(K id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _dbSet.Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T?> Get(K id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

      
        public virtual IQueryable<T> Find()
        {
            return _dbSet;
        }
    }
}
