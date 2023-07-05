using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Data.Interfaces
{
    public interface IUserRepository
    {
         List<User> GetAll();
         User GetById(int id);
    }
}
