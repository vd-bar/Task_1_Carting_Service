using System.Collections.Generic;
using Common.Result;

namespace NLayerDAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ResultInfo<IEnumerable<T>> GetAll();
        ResultInfo Add(T id);
        ResultInfo Delete(int id);
        //T Get(int id);
        //IEnumerable<T> Find(Func<T, Boolean> predicate);
        //void Create(T item);
        // void Update(T item);

    }
}
