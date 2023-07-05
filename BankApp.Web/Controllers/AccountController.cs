using BankApp.Web.Data.Context;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankContext _bankContext;

        public AccountController(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public IActionResult Create(int id)
        {
            var user = _bankContext.Users.Select(x=> new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                Lastname = x.Lastname,
            }).SingleOrDefault(x => x.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _bankContext.Accounts.Add(new Data.Entities.Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                Balance = accountCreateModel.Balance,
                UserId = accountCreateModel.UserId,
            });
            _bankContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
