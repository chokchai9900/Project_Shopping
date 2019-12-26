using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Shopping.Services;

namespace Project_Shopping.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _userService;
        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var LoginInfo = _userService.LoginByUser(username, password);
            if (LoginInfo == true)
            {
                var data = _userService.GetUserBy_user(username);
                
                return RedirectToAction(nameof(Details));
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(string username)
        {
            var data = _userService.GetUserBy_user(username);
            return View(data);
        }


    }
}