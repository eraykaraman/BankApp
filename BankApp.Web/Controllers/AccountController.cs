using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        //private readonly IRepository<Account> _accountRepository;
        //private readonly IRepository<User> _userRepository;

        //public AccountController(IRepository<Account> accountRepository, IRepository<User> userRepository)
        //{
        //    _accountRepository = accountRepository;
        //    _userRepository = userRepository;
        //}

        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Create(int id)
        {
            var user = _unitOfWork.GetRepository<User>().GetById(id);
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
            _unitOfWork.GetRepository<Account>().Create(new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                Balance = accountCreateModel.Balance,
                UserId = accountCreateModel.UserId,
            });
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult GetByUserId(int userId)
        {
            var query = _unitOfWork.GetRepository<Account>().GetQueryble();
            var accounts = query.Where(x => x.UserId == userId).ToList();
            var user = _unitOfWork.GetRepository<User>().GetById(userId);

            ViewBag.Name = user.Name;
            ViewBag.Lastname = user.Lastname;
            var list = new List<AccountListModel>();

            foreach (var account in accounts)
            {
                list.Add(new()
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    UserId = account.UserId,


                });
            }
            return View(list);



        }
        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query = _unitOfWork.GetRepository<Account>().GetQueryble();
            var accounts = query.Where(x => x.Id != accountId).ToList();

            var list = new List<AccountListModel>();

            ViewBag.SenderId = accountId;

            foreach (var item in accounts)
            {
                list.Add(new()
                {
                    Id = item.Id,
                    AccountNumber = item.AccountNumber,
                    Balance = item.Balance,
                    UserId = item.UserId,
                });
            }



            return View(new SelectList(list, "Id", "AccountNumber"));
        }


        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            var senderAccount = _unitOfWork.GetRepository<Account>().GetById(model.SenderId);
            senderAccount.Balance -= model.Amount;

            _unitOfWork.GetRepository<Account>().Update(senderAccount);

            var account = _unitOfWork.GetRepository<Account>().GetById(model.AccountId);

            account.Balance += model.Amount;
            _unitOfWork.GetRepository<Account>().Update(account);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
