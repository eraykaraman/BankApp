using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {

        //private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(BankContext bankContext, IUserMapper userMapper, IUnitOfWork unitOfWork)
        {
            //_userRepository = userRepository;
            _userMapper = userMapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToUserList(_unitOfWork.GetRepository<User>().GetAll()));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}