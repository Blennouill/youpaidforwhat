using ShareFlow.Domain.Entities.Interfaces;
using System.Collections.Generic;

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
    }
}