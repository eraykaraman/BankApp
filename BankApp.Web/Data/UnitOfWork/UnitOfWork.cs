using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.Repositories;

namespace BankApp.Web.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankContext _bankContext;

        public UnitOfWork(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_bankContext);
        }

        public void SaveChanges()
        {
            _bankContext.SaveChanges();
        }
    }
}
