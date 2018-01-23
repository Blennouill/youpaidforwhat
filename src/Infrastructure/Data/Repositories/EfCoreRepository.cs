using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using ShareFlow.Domain.Entities.Interfaces;
using ShareFlow.Domain.Shared.Interfaces;
using ShareFlow.Infrastructure.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShareFlow.Infrastructure.Data.Repositories
{
    public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private DbContext Db { get; }
        private DbSet<TEntity> Table;

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
            this.Save();
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

        public IQueryable<TEntity> AsQuery()
        {
            return this.Table.AsQueryable();
        }
        
    }
}