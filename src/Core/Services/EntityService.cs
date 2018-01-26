using ShareFlow.Core.Specifications;
using ShareFlow.Domain.Entities.Interfaces;
using ShareFlow.Domain.Interfaces;
using ShareFlow.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShareFlow.Domain.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class, IEntity
    {
        protected readonly IRepository<TEntity> _repository;

        public EntityService(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        public virtual TEntity GetByID(int id)
        {
            return this._repository.GetByID(id);
        }

        public virtual TEntity Create(TEntity obj)
        {
            this._repository.Insert(obj);
            this.Save();
            return obj;
        }

        public virtual TEntity Update(TEntity obj)
        {
            this._repository.Update(obj);
            this.Save();
            return obj;
        }

        public virtual void Delete(int id)
        {
            this._repository.Delete(id);
            this.Save();
        }

        public virtual void Save()
        {
            this._repository.Save();
        }

        public virtual TEntity FindOne(Specification<TEntity> specification)
        {
            return this._repository.Find(specification).FirstOrDefault();
        }

        public virtual IReadOnlyList<TEntity> FindList(Specification<TEntity> specification)
        {
            return this._repository.Find(specification).ToList();
        }

        public IReadOnlyList<TEntity> FindByParentId(int id)
        {
            return this._repository.FindByParentId(id);
        }

        public TEntity FindOneByParentId(int id)
        {
            return this._repository.FindByParentId(id).FirstOrDefault();
        }
    }
}