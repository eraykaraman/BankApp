using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Models;

namespace BankApp.Web.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankContext _bankContext;

        public UserRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public List<User> GetAll()
        {
            return _bankContext.Users.ToList();
        }
        public User GetById(int id)
        {
            return _bankContext.Users.SingleOrDefault(x => x.Id == id);
        }

       
    }
}
