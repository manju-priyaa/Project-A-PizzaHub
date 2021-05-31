using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Services
{
    public interface IOrderrepo<T>
    {
        IEnumerable<T> GetAll();
        void Add(T t);
    }
}
