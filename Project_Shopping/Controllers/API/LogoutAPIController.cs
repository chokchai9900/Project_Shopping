using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Shopping.Services;

namespace Project_Shopping.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutAPIController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly PasswordProcess _pwProcess;
        public LogoutAPIController(UserService userService, PasswordProcess passwordProcess)
        {
            _userService = userService;
            _pwProcess = passwordProcess;
        }
        [HttpPost]
        public string Login(string username, string password)
        {
            var LoginInfo = _userService.LoginByUser(username, password);
            if (LoginInfo == true)
            {
                var data = _userService.GetUserBy_user(username);
                data.userStatus = "Offline";
                _userService.UpdateUserByID(data._id, data);
                return "Logout Success";
            }
            else
            {
                return "User Or Password not match";
            }
        }
    }
}