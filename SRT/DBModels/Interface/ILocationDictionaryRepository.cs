using SRT.Migrations;

namespace SRT.DBModels.Interface
{
    public interface ILocationDictionaryRepository
    {
        Task<List<LocationDictionary>> GetAll();
        IQueryable<LocationDictionary> Find();
        Task<LocationDictionary?> Get(int id);
        Task<LocationDictionary> Add(LocationDictionary entity);
        Task<LocationDictionary> Update(LocationDictionary entity);
        Task<LocationDictionary?> Delete(int id);

    }
}
