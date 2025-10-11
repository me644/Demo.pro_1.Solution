      using Demo.DAL.Emp_Module;
using Demo.DAL.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PLL.DDTO_S
{
    public  class EmpDto_s//index
    {
        public int id {  get; set; }


        public string Name { get; set; }

        public int Age { get; set; }

        public DateOnly D { get; set; }


        public string? Address { get; set; }


        [Display(Name="Is Active")]
        public bool Is_Active { get; set; }



        [EmailAddress]
        public string? Email { get; set; }


        public string? Phone_NUMBER { get; set; }



        [Display(Name="Employye Type")]
        public String Type { get; set; }




        
        public String gender { get; set; }
    }
}
