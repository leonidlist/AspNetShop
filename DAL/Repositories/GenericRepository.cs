using DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void AddOrUpdate(T item)
        {
            _dbSet.AddOrUpdate(item);
            _context.SaveChanges();
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public void Delete(int itemId)
        {
            _dbSet.Remove(Get(itemId));
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        ~GenericRepository()
        {
            _context.Dispose();
        }
    }
}
