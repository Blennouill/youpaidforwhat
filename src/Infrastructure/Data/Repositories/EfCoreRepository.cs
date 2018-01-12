using Microsoft.EntityFrameworkCore;
using ShareFlow.Domain.Entities.Interfaces;
using ShareFlow.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShareFlow.Infrastructure.Data.Repositories
{
    public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected DbContext Db { get; }
        private DbSet<TEntity> Table;

        public EfCoreRepository(DbContext dbContext)
        {
            this.Db = dbContext;
            this.Table = Db.Set<TEntity>();
        }

        public void Delete(int id)
        {
            TEntity existing = this.GetByID(id);
            if (existing != null)
                this.Table.Remove(existing);
        }

        public void Delete(TEntity TEntity)
        {
            this.Table.Remove(TEntity);
            this.Save();
        }

        public void Insert(TEntity entity)
        {
            this.Table.Add(entity);
            this.Save();
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
            this.Save();
        }

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression)
        {
            return this.Table.Where(expression).ToList();
        }
    }
}