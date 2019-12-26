using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Shopping.Models;
using Project_Shopping.Services;

namespace Project_Shopping.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly PasswordProcess _pwProcess;
        public UserAPIController(UserService userService, PasswordProcess passwordProcess)
        {
            _userService = userService;
            _pwProcess = passwordProcess;
        }

        [HttpGet]
        public IEnumerable<UserDBModel> GetAll()
        {
            var data = _userService.GetAllUser();
            return (data);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public UserDBModel GetByID(string id)
        {
            var data = _userService.GetUserBy_id(id);
            return data;
        }

        [HttpPost]
        public string RegisterUser(UserDBModel collection)
        {
            if (ModelState.IsValid)
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
                return "Success";
            }
            else
            {
                return "Fail";
            }
            
        }
    }
}
