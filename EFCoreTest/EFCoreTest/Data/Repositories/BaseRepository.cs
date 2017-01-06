using EFCoreTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EFCoreTest.Data.Repositories
{
    public class BaseRepository<TContext> : IDisposable where TContext : DbContext, new()
    {
        private TContext context;

        protected TContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new TContext();
                }
                return context;
            }
        }


        protected TEntity GetSingle<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
        {
            if (predicate != null)
            {
                return Context.Set<TEntity>().Where(predicate).SingleOrDefault();
            }
            else
            {
                return null;
            }
        }

        protected IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : BaseEntity
        {
            if (predicate != null)
            {
                return Context.Set<TEntity>().Where(predicate);
            }
            else
            {
                return Context.Set<TEntity>();
            }
        }

        protected bool Add<TEntity>(TEntity data) where TEntity : BaseEntity
        {
            Context.Add<TEntity>(data);
            return Context.SaveChanges() > 0;
        }

        protected bool Delete<TEntity>(int id) where TEntity : BaseEntity
        {
            var entity = Context.Set<TEntity>().FirstOrDefault(z => z.Id == id);
            if (entity != null)
            {
                Context.Remove<TEntity>(entity);
                return Context.SaveChanges() > 0;
            }

            throw new KeyNotFoundException("Not found entity with given id");
        }

        protected void RemoveAll<TEntity>() where TEntity : BaseEntity
        {
            Context.Set<TEntity>().RemoveRange(context.Set<TEntity>());
            Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
            context = null;
        }
    }
}