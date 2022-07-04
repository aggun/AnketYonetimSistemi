﻿using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.Repositories 
{
    // bu  clasta öncelikle veri tabanına bağlanmak için context sınıfı newlenerek bir nesne oluşturudk
    //ardından generic repository üzerinden miras alması ve bunun hangi parametreden alınacağı belli olunması
    //için bir parametre ve sınıfa bağlanıldı.
   public class GenericRepository<T> : IRepository <T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public void Delete(T p)
        {
            var DeletedEntity = c.Entry(p);
            DeletedEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var AddEntity = c.Entry(p);
            AddEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var UpdateEntity = c.Entry(p);
            UpdateEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
