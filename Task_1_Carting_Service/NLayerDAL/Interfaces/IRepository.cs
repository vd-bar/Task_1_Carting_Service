using System;
using System.Collections.Generic;

namespace NLayerDAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T id);
        void Delete(int id);
        //T Get(int id);
        //IEnumerable<T> Find(Func<T, Boolean> predicate);
        //void Create(T item);
        // void Update(T item);

    }
}
