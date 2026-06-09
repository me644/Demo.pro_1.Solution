using Demo.DAL.Data.Contexts;
using Demo.DAL.Shared;
using Microsoft.EntityFrameworkCore;
//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Emp_Module;
using System.Linq.Expressions;


namespace Demo.DAL.Data.Repository
{


    
    public class BaseRepositorycs<T>(APP_1 app) : IGenricRepository<T> where T : Base_Entity
    {



        public void Add(T t)
        {
           app.Set<T>().Add(t);
     //  return   app.SaveChanges();
        }

            public IQueryable<T> Get_All(bool withTracking = false)
        { 
             return   app.Set<T>().AsNoTracking().Where(e=>e.Is_delated==false);

        }

        public T Get_byID(int ID)
        {

          return  app.Set<T>().Find(ID);


        }

        public void re(T T)
        {
      app.Set<T>().Remove(T);
           // return app.SaveChanges();
        }

        public void update(T t)
        {
            app.Set<T>().Update(t);
         //  return app.SaveChanges();
        }
    }
}
