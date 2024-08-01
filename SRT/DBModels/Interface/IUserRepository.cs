using SRT.Migrations;

namespace SRT.DBModels.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        IQueryable<User> Find();
        Task<User?> Get(int id);
        Task<User> Add(User entity);
        Task<User> Update(User entity);
        Task<User?> Delete(int id);

    }
}
