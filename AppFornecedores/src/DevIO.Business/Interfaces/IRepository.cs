﻿using DevIO.Business.Models;
using System.Linq.Expressions;

namespace DevIO.Business.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task Add(TEntity entity);
    Task DeleteById(Guid id);
    Task<TEntity> GetById(Guid id);
    Task Update(TEntity entity);
    Task<List<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}