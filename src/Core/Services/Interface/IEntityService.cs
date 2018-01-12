using ShareFlow.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShareFlow.Domain.Interfaces
{
    public interface IEntityService<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetByID(int id);

        TEntity Create(TEntity obj);

        TEntity Update(TEntity obj);

        void Delete(int id);

        void Save();

        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression);
    }
}