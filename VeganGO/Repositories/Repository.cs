using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeganGO.Infrastructure;

namespace VeganGO.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly IDbContextFactory<EfContext> _contextFactory;

        protected Repository(IDbContextFactory<EfContext> contextFactory)
            => _contextFactory = contextFactory;

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await using var context = _contextFactory.CreateDbContext();
            var createdEntity = await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public virtual async Task<bool> Delete(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var entity = await Get(id);
            if (entity == null) return false;
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<TEntity> Get(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var entity = await context.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            await using var context = _contextFactory.CreateDbContext();
            var entities = await context.Set<TEntity>().ToListAsync();
            return entities;
        }

        public virtual async Task<TEntity> Update(int id, TEntity entity)
        {
            await using var context = _contextFactory.CreateDbContext();
            var entityToUpdate = await Get(id);
            if (entityToUpdate == null) return null;
            entity.Id = id;
            var updatedEntity = context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}