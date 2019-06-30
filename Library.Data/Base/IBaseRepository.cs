using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data
{
    public interface IBaseRepository<T>: ISuperBaseRepository<T>
        where T : class, new()
    {

    }
}
