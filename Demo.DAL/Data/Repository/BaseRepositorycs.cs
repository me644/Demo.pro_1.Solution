using Demo.DAL.Data.Contexts;
using Demo.DAL.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Emp_Module;


namespace Demo.DAL.Data.Repository
{


    
    public class BaseRepositorycs<T>(APP_1 app) : IGenricRepository<T> where T : Base_Entity
    {
  

        public int Add(T t)
        {
           app.Set<T>().Add(t);
       return   app.SaveChanges();
        }

        public IEnumerable<T> Get_All(bool withTracking = false)
        {
         return   app.Set<T>().AsNoTracking().Where(e=>e.Is_delated==false).ToList();

        }

        public T Get_byID(int ID)
        {

          return  app.Set<T>().Find(ID);


        }

        public int re(T T)
        {
      app.Set<T>().Remove(T);
            return app.SaveChanges();
        }

        public int update(T t)
        {
            app.Set<T>().Update(t);
            return app.SaveChanges();
        }
    }
}
