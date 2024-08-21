using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using cc9.Models;

namespace cc9.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MoviesContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository()
        {
            _db = new MoviesContext();
            _dbSet = _db.Set<T>();
        }

        public void Delete(object id)
        {
            T entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            _dbSet.Add(obj);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(T obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
        }
    }
}