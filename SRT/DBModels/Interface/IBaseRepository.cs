namespace SRT.DBModels.Interface
{
    public interface IBaseRepository<T, K> where T : ApplicationDbContext
    {
        Task<List<T>> GetAll();
        IQueryable<T> Find();
        Task<T?> Get(K id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T?> Delete(K id);
        Task ExecuteSqlRawAsync(string q);
    }
 
}
