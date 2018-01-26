using AutoMapper;
using ShareFlow.Domain.Entities.Interfaces;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Interface.Process.Interfaces;
using ShareFlow.Interface.Shared.Interfaces;

namespace ShareFlow.Interface.Process
{
    public abstract class ResourceProcess<TModel, TEntity> : IResourceProcess<TModel>
                    where TModel : class, IModel
                    where TEntity : class, IEntity
    {
        protected readonly IEntityService<TEntity> _entityService;
        protected readonly IMapper _mapper;

        public ResourceProcess(IEntityService<TEntity> entityService, IMapper mapper)
        {
            _entityService = entityService;
            _mapper = mapper;
        }

        /*public virtual TModel Create(TModel obj)
        {
            var entity = _mapper.Map<TModel, TEntity>(obj);

            entity = _entityService.Create((TEntity)entity);

            obj = _mapper.Map<TEntity, TModel>(entity);

            return obj;
        }

        public virtual void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual TModel Update(TModel obj)
        {
            throw new System.NotImplementedException();
        }*/

        public virtual void Save()
        {
            _entityService.Save();
        }

        public virtual TModel GetByID(int id)
        {
            var model = _mapper.Map<TModel>(_entityService.GetByID(id));

            return model;
        }
    }
}