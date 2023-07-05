using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountMapper _accountMapper;
        public AccountController(BankContext bankContext, IUserRepository userRepository, IUserMapper userMapper, IAccountRepository accountRepository, IAccountMapper accountMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
            _accountRepository = accountRepository;
            _accountMapper = accountMapper;
        }
        public IActionResult Create(int id)
        {
            var user = _userMapper.MapToUserList(_userRepository.GetById(id));  
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _accountRepository.Create(_accountMapper.MapToAccount(accountCreateModel));
            return RedirectToAction("Index", "Home");
        }
    }
}
