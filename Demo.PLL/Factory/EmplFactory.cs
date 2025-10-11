using Demo.DAL.Emp_Module;
using Demo.PLL.DDTO_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PLL.Factory
{
    internal static class EmplFactory
    {


        public static EmpDto_s to_DTO(this Employee employee)
        {

            return new EmpDto_s()
            {

                id = employee.id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Is_Active
                = employee.Is_Active,
                Email = employee.Email,
                gender = employee.gender.ToString(),
                Phone_NUMBER = employee.Phone_NUMBER,
                Type = employee.Type.ToString()


            };
    } }
}
