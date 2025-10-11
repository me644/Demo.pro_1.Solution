using Demo.PLL.DTO_S;

namespace Demo.PLL.Services
{
    public interface IDepartmentServices
    {
      //  int add(Create_Dot_s c);
        bool Delete(int id);
       // DDot_s_Detaileed? GetDepartemntRepository_ID(int id);


        public int Dto_update(UpdateDto y);
        IEnumerable<Depa_Dots> Get_all();
        //int upptodate(UpdateDot_s U);
    }
}