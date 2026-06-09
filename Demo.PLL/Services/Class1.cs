  using Demo.DAL;
using Demo.DAL.Data.Contexts;
using Demo.DAL.Data.Repository;
using Demo.PLL.DTO_S;
using Demo.PLL.Factory;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;

namespace Demo.PLL.Services
{
    public class DepartmentServices : IDepartmentServices
    {

        private readonly IDepartemntRepository _departemntRepository;

        public DepartmentServices(IDepartemntRepository departemntRepository)
        {
            _departemntRepository = departemntRepository;
            // From compiler perspective, it’s legal C#.

            //It doesn’t know whether DI will succeed at runtime.
        }



        public IEnumerable<Depa_Dots> Get_all()
        {


            var departements = _departemntRepository.Get_All();
            return departements.Select(x => new Depa_Dots
            {
                id = x.id, 
                name = x.name,
                Code= x.code
              


            });


        }


        ////public DDot_s_Detaileed? GetDepartemntRepository_ID(int id)
        ////{

        ////    var x = _departemntRepository.Get_byID(id);

        ////    return x?.To_DOTS_Detalies() ?? null;

        ////    //if (x is not null)
        ////    //{

        ////    //    return x.To_DOTS_Detalies();
        ////    //}
        ////    //else return null; 


        ////}
        ////public int add(Create_Dot_s c)
        ////{


        ////    return _departemntRepository.Add(c.to_Depar());

        ////}

        public int upptodate(UpdateDto U)
        {

            return _departemntRepository.update(U.to_Depar());
        }



        public int Dto_update(UpdateDto U)
        {

            return _departemntRepository.update(U.to_Depar());
        }


        public bool Delete(int id)
        {


            var d = _departemntRepository.Get_byID(id);
            if (d is null)
            {

                return false;
            }
            return _departemntRepository.re(d) > 0 ? true : false;
             

        }

    }
}
