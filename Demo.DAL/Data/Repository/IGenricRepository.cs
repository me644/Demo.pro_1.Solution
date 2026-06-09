using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repository
{
    internal interface IGenricRepository<T>
    {

        void Add(T t);
        IQueryable<T> Get_All(bool withTracking = false);

        //IEnumerable<TResult> Get_All<TResult>(Expression<Func<T, TResult>> Selctor);    

       T Get_byID(int ID);
        void re(T T);
        void update(T t);

    }
}
