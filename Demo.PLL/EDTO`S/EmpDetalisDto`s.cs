using Demo.DAL.Emp_Module;
using Demo.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PLL.DDTO_S
{
    public  class EmpDetalisDto_s
    {

        public int id { get; set; }
        public int created_BY { get; set; }

        public DateTime? Created_oN { get; set; }  


        public int Modified_bY { get; set; }

        public DateTime? Modified_oN { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string? Address { get; set; }

        public bool Is_Active { get; set; }

        public string? Email { get; set; }


        public string? Phone_NUMBER { get; set; }


        public string Type { get; set; }

        public string gender { get; set; }
    }
}
