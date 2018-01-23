﻿using ShareFlow.Domain.Entities.Interfaces;
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

        public virtual IEnumerable<TEntity> List()
        {
            return this._repository.List();
        }

        public virtual TEntity GetByID(int id)
        {
            return this._repository.GetByID(id);
        }

        public virtual TEntity Create(TEntity obj)
        {
            this._repository.Insert(obj);
            return obj;
        }

        public virtual TEntity Update(TEntity obj)
        {
            this._repository.Update(obj);
            return obj;
        }

        public virtual void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public virtual void Save()
        {
            this._repository.Save();
        }

        public IQueryable<TEntity> AsQuery()
        {
            return this._repository.AsQuery();
        }
    }
}