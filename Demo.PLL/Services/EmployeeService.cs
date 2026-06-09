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
using System.Net.Http.Headers;
using Demo.PLL.Services.Attachments;

namespace Demo.PLL.Services
{
    public class EmployeeService(IAttachment _attachment,IUnitOfWork Uw, IMapper  _mapper)
    {

       

        public int  Update(EmpUpdatedDto_s U)
        {

             Uw._employeeRepository. update( _mapper.Map<Employee>(U));
            return Uw.SaveChanges();


        }

        public int Create(CreateDto_s C)
        {
            var e = _mapper.Map<CreateDto_s, Employee>(C);

            if (C.Image is not null)
            {
                string file_name = _attachment.Upload(C.Image,"Images");
                e.ImageName = file_name;

            }
                 //_ER.Add(_mapper.Map<Employee>(C));
                 
            Uw._employeeRepository.Add(e);

            return Uw.SaveChanges();
        }


        //public IEnumerable<EmpDto_s> GetAll()
        //{

        //    _ER.Get_All(E=>new EmpDto_s()
        //    {

        //        Address= E.Address,

        //    })
        //}

        public IEnumerable<EmpDto_s> GetAll()
        {

            var empls = Uw._employeeRepository.Get_All().ToList();
            return empls.Select(e => _mapper.Map<EmpDto_s>(e)).ToList();//employee => new EmpDto_s()
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

          var e=  Uw._employeeRepository.Get_byID(id);

           

            return e is null ? null :  _mapper.Map<EmpDetalisDto_s>(e);


        }

  

        public bool Delete(int id)
        {
            

            var e= (Uw._employeeRepository.Get_byID(id));
           if((e) is null){
            
            
            return false;
            }

            else
            {
           e.Is_delated=true;
                Uw._employeeRepository.update(e);
                return Uw.SaveChanges()>0?true:false;



            }
            ;



        }

    }

}
