using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public HomeController(BankContext bankContext, IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToUserList(_userRepository.GetAll()));
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