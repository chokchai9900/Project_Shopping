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
    public class EncryptProcessController : ControllerBase
    {
        private readonly PasswordProcess _pwProcess;
        public EncryptProcessController(PasswordProcess passwordProcess)
        {
            _pwProcess = passwordProcess;
        }

        [HttpGet("{PasswordEncrypt}", Name = "GetinputEncrypt")]
        public string PasswordEncrypt(string PasswordEncrypt)
        {
            var data = _pwProcess.Encrypt(PasswordEncrypt);
            return data;
        }
    }
}