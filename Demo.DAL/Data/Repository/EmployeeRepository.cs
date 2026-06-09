using Demo.DAL.Data.Contexts;
using Demo.DAL.Emp_Module;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repository
{
    public class EmployeeRepository : BaseRepositorycs<Employee>
    {

        private readonly APP_1 _app;
        public EmployeeRepository(APP_1 app) : base(app) { _app = app; }

        public IQueryable<Employee> Get_All(bool withTracking = false)
        {
            return _app.Set<Employee>().Include(e => e.departemnt).Where(e => e.Is_delated == false);
        }
    }
    }

