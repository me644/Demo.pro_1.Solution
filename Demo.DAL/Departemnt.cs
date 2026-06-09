using Demo.DAL.Emp_Module;
using Demo.DAL.Shared;

namespace Demo.DAL
{
    public class Departemnt:Base_Entity

    {

        public string code { get; set; } = null!;// to remove the_____compiler warnning  

        public string name { get; set; }= null!;


        public    ICollection<Employee> Employees = new HashSet<Employee>();
    }
}
