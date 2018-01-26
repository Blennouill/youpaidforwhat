using Microsoft.EntityFrameworkCore;
using ShareFlow.Domain.Entities.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ShareFlow.Infrastructure.Data.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> FilterBy<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity
        {
            return query.Where(expression);
        }

        public static IQueryable<TEntity> LoadChild<TEntity, TProperty>(this IQueryable<TEntity> query, Expression<Func<TEntity, TProperty>> expression) where TEntity : class, IEntity
        {
            return query.Include(expression);
        }
    }
}