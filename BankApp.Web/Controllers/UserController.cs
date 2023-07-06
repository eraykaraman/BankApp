using BankApp.Web.Data.Entities;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BankApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserMapper _userMapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUserMapper userMapper, IUnitOfWork unitOfWork)
        {
            _userMapper = userMapper;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Create()
        {
            return View(); 
        }




        [HttpPost]
        public IActionResult Create(UserCreateModel userCreateModel)
        {
            _unitOfWork.GetRepository<User>().Create(new User
            {
                Id = userCreateModel.Id,
                Name = userCreateModel.Name,
                Lastname = userCreateModel.Lastname,
            });
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Remove(int userId)
        {
            var user = _unitOfWork.GetRepository<User>().GetById(userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            _unitOfWork.GetRepository<User>().Remove(user);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

       
    }
}
