using Demo.DAL.Data.Contexts;
using Demo.DAL.Emp_Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repository
{
    public  class EmployeeRepository:BaseRepositorycs<Employee>
    {


        public EmployeeRepository(APP_1 _app) : base(_app)
        {



        }
    }
}
