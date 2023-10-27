namespace TESTE_MATHEUS_SAMPAIO.Services
{
    public interface IService<TViewModel, TModel>

     where TViewModel : class

     where TModel : class
    {
        Task<TModel> CreateAsync(TViewModel viewModel);
        Task<TViewModel> EditAsync(TViewModel entity);
        Task<TViewModel> FindOneAsync(int id);
        Task<IEnumerable<TViewModel>> FindAllAsync();
        void Remove(TModel model);
    }

    public interface IService<TModel>
    where TModel : class
    {
        Task<TModel> CreateAsync(TModel viewModel);
        Task<TModel> EditAsync(TModel viewModel);
        Task<TModel> FindOneAsync(int id);
        Task<IEnumerable<TModel>> FindAllAsync();
        void Remove(TModel model);
    }
}