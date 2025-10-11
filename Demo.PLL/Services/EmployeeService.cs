using AutoMapper;
using Demo.DAL.Data.Repository;
using Demo.DAL.Emp_Module;
using Demo.PLL.DDTO_S;
using Demo.PLL.EDTO_S;
using Demo.PLL.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Emp_Module;
using Demo.DAL.Data.Repository;

namespace Demo.PLL.Services
{
    public class EmployeeService(EmployeeRepository _ER,IMapper  _mapper)
    {

       

        public int Update(EmpUpdatedDto_s U)
        {

            return  _ER.update( _mapper.Map<Employee>(U));

        }

        public int Create(CreateDto_s C)
        {


            var e=   _mapper.Map<CreateDto_s,Employee>(C); //_ER.Add(_mapper.Map<Employee>(C));
            return _ER.Add(e);
        }

        public IEnumerable<EmpDto_s> GetAll()
        {

           var empls= _ER.Get_All();
            return empls.Select(e => _mapper.Map<EmpDto_s>(e));//employee => new EmpDto_s()
            //{


            //    id = employee.id,
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Address = employee.Address,
            //    Is_Active
            //     = employee.Is_Active,
            //    Email = employee.Email,
            //    gender = employee.gender.ToString(),
            //    Phone_NUMBER = employee.Phone_NUMBER,
            //    Type = employee.Type.ToString()

                //});



            }

       
        public EmpDetalisDto_s ?GetById(int id)
        {

          var e=  _ER.Get_byID(id);

            return e is null ? null :  _mapper.Map<EmpDetalisDto_s>(e);
        }

  

        public bool Delete(int id)
        {
            

            var e= (_ER.Get_byID(id));
           if((e) is null){
            
            
            return false;
            }

            else
            {
           e.Is_delated=true;
                return _ER.update(e)>0?true:false;



            }
            ;



        }

    }

}
