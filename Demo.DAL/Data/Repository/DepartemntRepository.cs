using Demo.DAL.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repository
{
    public class DepartemntRepository(APP_1 app) : IDepartemntRepository
    {
        public Departemnt Get_byID(int ID)
        {
            var department = app.Set<Departemnt>().Find(ID);
            //Find() take PK  Search IN LOCAL FIRST   
            return department;



        }




        public IEnumerable<Departemnt> Get_All(bool withTracking = false)
        {



            if (withTracking == false)
            {

                return app.Set<Departemnt>().ToList();
            }

            else return app.Set<Departemnt>().AsNoTracking().ToList();

        }

        public int Add(Departemnt departemnt)
        {

            app.Set<Departemnt>().Add(departemnt);


            return app.SaveChanges();

        }


        public int update(Departemnt dep)
        {


            app.Set<Departemnt>().Update(dep);
            return app.SaveChanges();



        }


        public int re(Departemnt d)
        {



            app.Set<Departemnt>().Remove(d);
            return app.SaveChanges();
        }
    }
}
