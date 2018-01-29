using Microsoft.EntityFrameworkCore;
using ShareFlow.Core.Specifications;
using ShareFlow.Domain.Entities.Interfaces;
using ShareFlow.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShareFlow.Infrastructure.Data.Repositories
{
    public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected DbContext Db { get; }
        protected DbSet<TEntity> Table;

        public EfCoreRepository(DbContext dbContext)
        {
            this.Db = dbContext;
            this.Table = Db.Set<TEntity>();
        }

        public void Delete(int id)
        {
            TEntity existing = this.GetByID(id);
            if (existing == null)
                return;

            this.Table.Remove(existing);
        }

        public void Delete(TEntity TEntity)
        {
            this.Table.Remove(TEntity);
        }

        public void Insert(TEntity entity)
        {
            this.Table.Add(entity);
        }

        public void Save()
        {
            this.Db.SaveChanges();
        }

        public IReadOnlyList<TEntity> List()
        {
            return this.Table.ToList();
        }

        public TEntity GetByID(int id)
        {
            return Table.FirstOrDefault(TEntity => TEntity.Id == id);
        }

        public void Update(TEntity entity)
        {
            Table.Attach(entity);
            this.Db.Entry(entity).State = EntityState.Modified;
        }

        public IReadOnlyList<TEntity> Find(Specification<TEntity> specification)
        {
            return this.Table
                            .Where(specification.ToExpression())
                            .ToList();
        }

        public IReadOnlyList<TEntity> FindListByParentId(int id)
        {
            return this.Table
                            .Where(TEntity => TEntity.ParentId == id)
                            .ToList();
        }
    }
}