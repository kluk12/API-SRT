using Microsoft.EntityFrameworkCore;
using SRT.DBModels.Interface;

namespace SRT.DBModels.Repos
{
    public class ReservationRepository : IReservationRepository
    {
        protected ApplicationDbContext context;
        public ReservationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task ExecuteSqlRawAsync(string q)
        {
            await context.Database.ExecuteSqlRawAsync(q);
        }

        public virtual async Task<Reservation> Add(Reservation entity)
        {
            context.Reservations.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Reservation?> Delete(int id)
        {
            var entity = await context.Reservations.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Reservations.Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<Reservation?> Get(int id)
        {
            return await context.Reservations.FindAsync(id);
        }

        public virtual async Task<List<Reservation>> GetAll()
        {
            return await context.Reservations.ToListAsync();
        }

        public virtual async Task<Reservation> Update(Reservation entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<Reservation> Find()
        {
            return context.Reservations;
        }
    }
}
