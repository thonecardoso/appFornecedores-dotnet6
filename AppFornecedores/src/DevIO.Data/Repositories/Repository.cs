using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace DevIO.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly AppDbContext _db;
    private DbSet<TEntity> _dbSet;

    protected Repository(AppDbContext db)
    {
        _db = db;
        _dbSet = _db.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task Add(TEntity entity)
    {
        _dbSet.Add(entity);
        await SaveChanges();
    }

    public virtual async Task DeleteById(Guid id)
    {
        _dbSet.Remove(new TEntity { Id = id});
        await SaveChanges();
    }

    public virtual async Task Upadate(TEntity entity)
    {
        _dbSet.Update(entity);
        await SaveChanges();
    }

    public async Task<int> SaveChanges()
    {
        return await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db?.Dispose();
    }

}