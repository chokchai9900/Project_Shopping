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
    public class DecryptProcessController : ControllerBase
    {
        private readonly PasswordProcess _pwProcess;
        public DecryptProcessController(PasswordProcess passwordProcess)
        {
            _pwProcess = passwordProcess;
        }

        [HttpGet("{PasswordDecrypt}", Name = "GetinputDecrypt")]
        public string PasswordDecrypt(string PasswordDecrypt)
        {
            var data = _pwProcess.Decrypt(PasswordDecrypt);
            return data;
        }
    }
}