using AutoMapper;
using Demo.DAL.Emp_Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.PLL.EDTO_S;
using Demo.PLL.DDTO_S;
using System.Net.Sockets;
//sing Microsoft.Data.SqlClient;


namespace Demo.PLL.Mappings
{
    public class MapProfile:Profile
    {


        public MapProfile() {





            CreateMap<Employee, EmpDto_s>()
.ForMember(dest => dest.gender, options => options.MapFrom(src => src.gender)).
            ForMember(dest => dest.department, options => options.MapFrom(src => (src.departemnt) != null ? src.departemnt.name : null)).
                         ForMember(dest => dest.Type, options => options.MapFrom(src => src.Type));

          




            CreateMap<EmpUpdatedDto_s, EmpDto_s>().ReverseMap();


            CreateMap<Employee, EmpDetalisDto_s>().ForMember(dest => dest.gender, options => options.MapFrom(src => src.gender));

           



            CreateMap<CreateDto_s, Employee>().ForMember(dest=>dest.departmentiD,option=>option.MapFrom(SRC=>SRC.Department_ID));

            CreateMap<EmpDetalisDto_s, EmpUpdatedDto_s>().ForMember(dest => dest.gender, options => options.MapFrom(src => src.gender))


             .ForMember(dest => dest.Type, options => options.MapFrom(src => src.Type));    ;
        }
    }
}
