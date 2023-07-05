using BankApp.Web.Data.Entities;

namespace BankApp.Web.Data.Interfaces
{
    public interface IAccountRepository
    {
        public void Create(Account account);
    }
}
