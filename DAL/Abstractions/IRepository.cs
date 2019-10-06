using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstractions
{
    public interface IRepository<T>
    {
        void AddOrUpdate(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Delete(T item);
        void Delete(int itemId);
    }
}
