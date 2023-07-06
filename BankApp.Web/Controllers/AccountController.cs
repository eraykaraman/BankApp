using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IUserRepository _userRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapper _accountMapper;
        //public AccountController(BankContext bankContext, IUserRepository userRepository, IUserMapper userMapper, IAccountRepository accountRepository, IAccountMapper accountMapper)
        //{
        //    _userRepository = userRepository;
        //    _userMapper = userMapper;
        //    _accountRepository = accountRepository;
        //    _accountMapper = accountMapper;
        //}

        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<User> _userRepository;

        public AccountController(IRepository<Account> accountRepository, IRepository<User> userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public IActionResult Create(int id)
        {
            var user = _userRepository.GetById(id);
            return View(new UserListModel
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname,


            });
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _accountRepository.Create(new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                Balance = accountCreateModel.Balance,
                UserId = accountCreateModel.UserId,
            });
            return RedirectToAction("Index", "Home");
        }
    }
}
