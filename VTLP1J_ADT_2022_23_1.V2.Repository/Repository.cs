using System.Linq;
using System.Reflection.Metadata;
using VTLP1J_ADT_2022_23_1.V2.Data;

namespace VTLP1J_ADT_2022_23_1.V2.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public LensDatabaseContext Context;

        protected Repository(LensDatabaseContext ctx)
        {
            this.Context = ctx;
        }

        public abstract T GetOne(int id);

        public IQueryable<T> GetAll()
        {
            return this.Context.Set<T>();

        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }
    }
}