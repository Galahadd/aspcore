﻿using Abc.Core.DataAccess;
using Abc.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Abc.Core.EntityFramework
{
    public class EfEntitiyRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
            where TEntity : class, IEntity, new()
            where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
               var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> Filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(Filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
            }
                
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedntity = context.Entry(entity);
                updatedntity.State = EntityState.Modified;
                context.SaveChanges();
            } 
        }
    }
}
