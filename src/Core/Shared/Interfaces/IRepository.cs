using ShareFlow.Core.Specifications;
using ShareFlow.Domain.Entities.Interfaces;
using System.Collections.Generic;

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

        IReadOnlyList<TEntity> Find(Specification<TEntity> specification);

        IReadOnlyList<TEntity> FindByParentId(int id);
    }
}