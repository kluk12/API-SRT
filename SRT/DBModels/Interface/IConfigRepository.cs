using SRT.Migrations;

namespace SRT.DBModels.Interface
{
    public interface IConfigRepository
    {
        Task<List<Config>> GetAll();
        IQueryable<Config> Find();
        Task<Config?> Get(int id);
        Task<Config> Add(Config entity);
        Task<Config> Update(Config entity);
        Task<Config?> Delete(int id);

    }
}
