using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Project_Shopping.Models;
using Project_Shopping.Services;

namespace Project_Shopping.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly PasswordProcess _pwProcess;
        public UserController(UserService userService, PasswordProcess passwordProcess)
        {
            _userService = userService;
            _pwProcess = passwordProcess;
        }

        // GET: User
        public ActionResult Index()
        {
            var data = _userService.GetAllUser();
            return View(data);
        }

        // GET: User/RegisterUser
        public ActionResult RegisterUser()
        {
            return View();
        }

        // POST: User/RegisterUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(UserDBModel collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var datetimeFrist = DateTime.Now.ToString("MMyyyy");
                    var datetimeLast = DateTime.Now.ToString("HHmmss");
                    collection._id = String.Join(datetimeFrist, "", datetimeLast);
                    collection.password = _pwProcess.Encrypt(collection.password);
                    collection.CreateDateTime = DateTime.Now;
                    collection.UpdateDateTime = DateTime.Now;
                    collection.role = "User";
                    collection.userStatus = "Offline";
                    _userService.CreateUser(collection);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Please add data");
                }
            }

            return View();
        }
    }
}