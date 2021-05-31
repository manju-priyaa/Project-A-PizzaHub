using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Services
{
    public interface ICartRepo<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T t);
        void Delete(T t);
    }
}
