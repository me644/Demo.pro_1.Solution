using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repository
{
    internal interface IGenricRepository<T>
    {

        int Add(T t);
        IEnumerable<T> Get_All(bool withTracking = false);
        T Get_byID(int ID);
        int re(T T);
        int update(T t);

    }
}
