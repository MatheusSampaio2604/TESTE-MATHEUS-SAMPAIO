namespace TESTE_MATHEUS_SAMPAIO.Models.Repository
{
    public interface IRepository<T> : IDisposable where T : class

    {

        Task<int> CreateAsync(T entity);

        Task<int> EditAsync(T entity);

        Task<T> FindOneAsync(int id);

        Task<IEnumerable<T>> FindAllAsync();

        void Remove(T entity);



    }
}