﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    //generic constraint
    //class : referans tip demek
    // where : Kural koyuyoruz
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new(): new'lenebilir olmali demek
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
