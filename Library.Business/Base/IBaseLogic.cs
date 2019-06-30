using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business
{
    public interface IBaseLogic<T>
        where T : class, new()
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void RemoveById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Update(T entity);
    }
}
