using Demo.DAL.Data.Contexts;
//using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                 
namespace Demo.DAL.Data.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        //private readonly  Lazy< EmployeeRepository> _EmployeeRepository;

        //private readonly Lazy< DepartemntRepository> _DepartemntRepository;

        private readonly APP_1 aPP_1;

       public UnitOfWork(APP_1 _app){ 


         

            this.aPP_1=_app;
         
        }
        public EmployeeRepository _employeeRepository { get=> new EmployeeRepository(aPP_1); } 
        public DepartemntRepository _departemntRepository { get=>  new DepartemntRepository(aPP_1); }

        public int SaveChanges()
        {


         return   aPP_1.SaveChanges();
        }

    }
}
