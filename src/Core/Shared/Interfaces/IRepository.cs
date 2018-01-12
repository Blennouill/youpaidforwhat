using ShareFlow.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShareFlow.Domain.Shared.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IReadOnlyList<TEntity> List();

        TEntity GetByID(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        void Save();

        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression);
    }
}