using Demo.PLL.DDTO_S;
using Demo.PLL.EDTO_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PLL.Services
{
    internal interface IEmoloyeeService
    {


        public IEnumerable<EmpDto_s> Getall();

             public EmpDto_s GetById(int id);


        public int Create(CreateDto_s C);
        public int Update(EmpUpdatedDto_s U);

        public bool Delete(int id);
       
       
    }
}