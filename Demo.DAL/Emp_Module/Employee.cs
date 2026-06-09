using Demo.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Emp_Module
{
    public class Employee:Base_Entity
    {


        


        public string Name { get; set; }

        public int Age { get; set; }    

        public string? Address { get; set; }

        public bool Is_Active { get; set; }

        public string ?Email { get; set; }


        public string ?Phone_NUMBER { get; set; }



        
        public Employe_Type Type {  get; set; }

        public Gender gender { get; set; }




        public  Departemnt? departemnt { get; set; }

        public int? departmentiD { get; set; }
        public string? ImageName { get; set; }    
     
    }
}
