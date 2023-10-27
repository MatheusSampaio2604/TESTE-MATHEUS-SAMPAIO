using AutoMapper;
using TESTE_MATHEUS_SAMPAIO.Models.Repository;

namespace TESTE_MATHEUS_SAMPAIO.Services
{
    public class Service<TViewModel, TModel> : IService<TViewModel, TModel>
     where TViewModel : class
     where TModel : class
    {
        protected readonly ILogger<Service<TViewModel, TModel>> _logger;
        protected readonly IMapper _mapper;
        protected readonly IRepository<TModel> _repository;

        public Service(ILogger<Service<TViewModel, TModel>> logger, IMapper mapper, IRepository<TModel> repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task<TModel> CreateAsync(TViewModel viewModel)

        {

            try

            {

                var map = _mapper.Map<TViewModel, TModel>(viewModel);

                await _repository.CreateAsync(map);

                return map;

            }

            catch (Exception ex)

            {

                _logger.LogError(ex.Message);

                return null;

            }

        }


        public virtual async Task<TViewModel> EditAsync(TViewModel entity)
        {
            try
            {
                var map = _mapper.Map<TViewModel, TModel>(entity);

                await _repository.EditAsync(map);

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }


        public virtual async Task<TViewModel> FindOneAsync(int id)
        {
            TModel map = await _repository.FindOneAsync(id);

            TViewModel mapper = _mapper.Map<TModel, TViewModel>(map);

            return mapper;
        }


        public virtual async Task<IEnumerable<TViewModel>> FindAllAsync()
        {
            try
            {
                IEnumerable<TModel> models = await _repository.FindAllAsync();

                IEnumerable<TViewModel> modelViews = _mapper.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(models);

                return modelViews;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return new List<TViewModel>();
        }


        public void Remove(TModel model)
        {
            _repository.Remove(model);
        }


    }

    public class Service<TModel> : IService<TModel> where TModel : class
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<Service<TModel>> _logger;
        protected readonly IRepository<TModel> _repository;

        public Service(ILogger<Service<TModel>> logger, IMapper mapper, IRepository<TModel> repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }


        public virtual async Task<TModel> CreateAsync(TModel viewModel)
        {
            try
            {
                await _repository.CreateAsync(viewModel);

                return viewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;
            }
        }


        public virtual async Task<TModel> EditAsync(TModel viewModel)
        {
            try
            {
                await _repository.EditAsync(viewModel);

                return viewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }


        public virtual async Task<TModel> FindOneAsync(int id)
        {
            try
            {
                return await _repository.FindOneAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return default;
        }


        public virtual async Task<IEnumerable<TModel>> FindAllAsync()
        {
            try
            {
                return await _repository.FindAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return new List<TModel>();
        }


        public void Remove(TModel model)
        {
            _repository.Remove(model);
        }
    }
}