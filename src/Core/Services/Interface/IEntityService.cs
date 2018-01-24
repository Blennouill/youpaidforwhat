﻿using ShareFlow.Core.Specifications;
using ShareFlow.Domain.Entities.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShareFlow.Domain.Interfaces
{
    public interface IEntityService<TEntity> where TEntity : IEntity
    {
        TEntity GetByID(int id);

        TEntity Create(TEntity obj);

        TEntity Update(TEntity obj);

        void Delete(int id);

        void Save();
        
        TEntity FindOne(Specification<TEntity> specification);

        IReadOnlyList<TEntity> FindList(Specification<TEntity> specification);

    }
}