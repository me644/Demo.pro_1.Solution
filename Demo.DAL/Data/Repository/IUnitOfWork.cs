using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repository
{
    public interface IUnitOfWork
    {


      public  EmployeeRepository _employeeRepository {  get; }

       public  DepartemntRepository _departemntRepository { get; }


        public int SaveChanges();
    }
}
