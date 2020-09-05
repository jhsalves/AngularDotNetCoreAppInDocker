﻿using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes) =>
           _repository.GetAll(predicate, includes);

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes) =>
            _repository.GetAll(includes);

        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public virtual void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}
