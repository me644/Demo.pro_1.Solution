    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Shared
{
    public class Base_Entity
    {


        public int id {  get; set; }
        public int created_BY  { get; set; }
         
        public DateTime? Created_oN {  get; set; }  //  make it nullable bec   give him df value


        public int Modified_bY{ get; set; }

        public DateTime? Modified_oN { get; set; }

        public bool Is_delated {  get; set; } 

    }
}
