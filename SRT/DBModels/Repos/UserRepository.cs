using Microsoft.EntityFrameworkCore;
using SRT.DBModels.Interface;

namespace SRT.DBModels.Repos
{
    public class UserRepository : IUserRepository
    {
        protected ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task ExecuteSqlRawAsync(string q)
        {
            await context.Database.ExecuteSqlRawAsync(q);
        }

        public virtual async Task<User> Add(User entity)
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<User?> Delete(int id)
        {
            var entity = await context.Users.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Users.Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<User?> Get(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public virtual async Task<List<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public virtual async Task<User> Update(User entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<User> Find()
        {
            return context.Users;
        }
    }
}
