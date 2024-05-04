using SRT.Migrations;

namespace SRT.DBModels.Interface
{
    public interface ITrainingRepository
    {
        Task<List<Training>> GetAll();
        IQueryable<Training> Find();
        Task<Training?> Get(int id);
        Task<Training> Add(Training entity);
        Task<Training> Update(Training entity);
        Task<Training?> Delete(int id);

    }
}
