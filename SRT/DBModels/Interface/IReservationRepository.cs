using SRT.Migrations;

namespace SRT.DBModels.Interface
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAll();
        IQueryable<Reservation> Find();
        Task<Reservation?> Get(int id);
        Task<Reservation> Add(Reservation entity);
        Task<Reservation> Update(Reservation entity);
        Task<Reservation?> Delete(int id);

    }
}
