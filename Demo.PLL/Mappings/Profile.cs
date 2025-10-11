using AutoMapper;
using Demo.DAL.Emp_Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.PLL.EDTO_S;
using Demo.PLL.DDTO_S;


namespace Demo.PLL.Mappings
{
    public class MapProfile:Profile
    {


        public MapProfile() {





            CreateMap<Employee,EmpDto_s>().ReverseMap()
.ForMember(dest=>dest.gender,options=>options.MapFrom(src=>src.gender))

                
             . ForMember(dest => dest.Type, options => options.MapFrom(src => src.Type));
            CreateMap<EmpUpdatedDto_s, EmpDto_s>().ReverseMap();
         


            CreateMap<Employee, EmpDetalisDto_s>() .ForMember(dest => dest.gender, options => options.MapFrom(src => src.gender))

             .ForMember(dest => dest.Type, options => options.MapFrom(src => src.Type)); ;




            CreateMap<CreateDto_s, Employee>();

            CreateMap<EmpDetalisDto_s, EmpUpdatedDto_s>().ForMember(dest => dest.gender, options => options.MapFrom(src => src.gender))


             .ForMember(dest => dest.Type, options => options.MapFrom(src => src.Type));    ;
        }
    }
}
