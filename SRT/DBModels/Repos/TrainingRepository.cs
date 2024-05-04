using Microsoft.EntityFrameworkCore;
using SRT.DBModels.Interface;

namespace SRT.DBModels.Repos
{
    public class TrainingRepository : ITrainingRepository
    {
        protected ApplicationDbContext context;
        public TrainingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task ExecuteSqlRawAsync(string q)
        {
            await context.Database.ExecuteSqlRawAsync(q);
        }

        public virtual async Task<Training> Add(Training entity)
        {
            context.Trainings.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Training?> Delete(int id)
        {
            var entity = await context.Trainings.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Trainings.Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<Training?> Get(int id)
        {
            return await context.Trainings.FindAsync(id);
        }

        public virtual async Task<List<Training>> GetAll()
        {
            return await context.Trainings.ToListAsync();
        }

        public virtual async Task<Training> Update(Training entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<Training> Find()
        {
            return context.Trainings;
        }
    }
}
