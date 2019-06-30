using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public abstract class SuperBaseRepository<C, T> : ISuperBaseRepository<T>
        where C : LibraryContext, new()
        where T : class, new()
    {
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            using (C Context = new C())
            {
                return Context.Set<T>().Where(predicate).ToList();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (C Context = new C())
            {
                return Context.Set<T>().ToList();
            }
        }

        public virtual void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveById(int id)
        {
            using (C Context = new C())
            {
                T entity = Context.Set<T>().Find(id);
                Context.Entry<T>(entity).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public virtual T Update(T entity)
        {
            using (C Context = new C())
            {
                Context.Set<T>().Attach(entity);
                var entry = Context.Entry(entity);
                entry.State = EntityState.Modified;
                // other changed properties
                Context.SaveChanges();
                return entity;
            }
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public virtual T Get(int id)
        {
            using (C Context = new C())
            {
                return Context.Set<T>().Find(id);
            }
        }

        public virtual T Add(T entity)
        {
            using (C Context = new C())
            {
                var added = Context.Set<T>().Add(entity);
                Context.SaveChanges();
                return added;

            }
        }
    }
}
