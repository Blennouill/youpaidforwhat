using ShareFlow.Domain.Entities.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        IQueryable<TEntity> AsQuery();
    }
}