using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;

namespace BankApp.Web.Data.Repositories
{
    public class Repository<T>: IRepository<T> where T : class , new()
    {
        private readonly BankContext _bankContext;

        public Repository(BankContext context)
        {
            _bankContext = context;
        }

        public void Create(T entity)
        {
            _bankContext.Set<T>().Add(entity);
         
        }

        public void Update(T entity)
        {
            _bankContext.Set<T>().Update(entity);
           
        }

        public void Remove(T entity)
        {
            _bankContext.Set<T>().Remove(entity);
            
        }

        public List<T> GetAll()
        {
            return _bankContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _bankContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetQueryble()
        {
            return _bankContext.Set<T>().AsQueryable();
        }
    }
}
