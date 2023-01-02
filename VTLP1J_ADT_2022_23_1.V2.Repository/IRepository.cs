using System.Linq;


namespace VTLP1J_ADT_2022_23_1.V2.Repository
{
    public interface IRepository<T> where T: class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
    }
}