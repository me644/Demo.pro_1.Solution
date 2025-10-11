using Demo.DAL;
using Demo.PLL.DTO_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demo.PLL.Factory
{
    internal static class DepartmentFactory
    {

        //public static DDot_s_Detaileed To_DOTS_Detalies(this Departemnt x)
        //{

        //    return new DDot_s_Detaileed()
        //    {
        //        id = x.id,
        //        Name = x.name,

        //        Code = x.code,
        //        Created_on = x.Created_oN.HasValue ? DateOnly.FromDateTime(x.Created_oN.Value) : default,

        //        created_BY = x.created_BY,
        //        Modified_bY = x.Modified_bY
        //    };

        //}


        //public static Departemnt to_Depar(this Create_Dot_s c)
        //{

        //    return new Departemnt()
        //    {

        //        name = c.Name,
        //        code = c.Code,
        //        Created_oN = c.DateOfCreation.ToDateTime(default)


        //    };
        //}


        public static Departemnt to_Depar(this UpdateDto c)
        {

            return new Departemnt()
            {

                id = c.Id,
                name = c.Name,
                code = c.Code,

                


            };
            //}
            //public static Departemnt to_Depar(this Delete c)
            //{ 

            //    return new Departemnt()
            //    {

            //        id = c.id,



            //    };
            //}


        }
    }
}