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
            _bankContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _bankContext.Set<T>().Update(entity);
            _bankContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            _bankContext.Set<T>().Remove(entity);
            _bankContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _bankContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _bankContext.Set<T>().Find(id);
        }
    }
}
