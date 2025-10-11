
namespace Demo.DAL.Data.Repository
{
    public interface IDepartemntRepository
    {
        int Add(Departemnt departemnt);
        IEnumerable<Departemnt> Get_All(bool withTracking = false);
        Departemnt Get_byID(int ID);
        int re(Departemnt d);
        int update(Departemnt dep);
    }
}