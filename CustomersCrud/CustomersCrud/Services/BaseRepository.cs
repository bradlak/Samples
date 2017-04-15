using AutoMapper;
using CustomersCrud.Data;
using CustomersCrud.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CustomersCrud.Services
{
    public abstract class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly CustomersContext dbContext;

        protected readonly IMapper mapper;

        protected BaseRepository(CustomersContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;
        }

        protected IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? dbContext.Set<TEntity>() : dbContext.Set<TEntity>().Where(predicate);
        }

        protected TEntity GetById(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        protected TEntity Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();

            return entity;
        }

        protected TEntity Update(TEntity entity)
        {
            var toUpdate = GetById(entity.Id);

            dbContext.Entry<TEntity>(toUpdate).CurrentValues.SetValues(entity);
            dbContext.SaveChanges();

            return toUpdate;
        }

        protected bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                dbContext.Remove(entity);
            }

            return dbContext.SaveChanges() > 0;
        }

        protected TDto InvokeWithMapping<TDto>(TDto dto, Func<TEntity, TEntity> func)
        {
            var entity = mapper.Map<TEntity>(dto);
            var resultEntity = func(entity);

            return mapper.Map<TDto>(resultEntity);
        }
    }
}
