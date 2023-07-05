using BankApp.Web.Data.Context;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly BankContext _bankContext;

        public HomeController(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public IActionResult Index()
        {
            return View(_bankContext.Users.Select(x=> new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                Lastname = x.Lastname,

            }).ToList());
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