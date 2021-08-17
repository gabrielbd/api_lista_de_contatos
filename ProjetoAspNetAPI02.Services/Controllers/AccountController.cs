using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspNetAPI02.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("Login")] //Account/Login (autenticação de usuario)
        public IActionResult Login(LoginModel model)
        {
            return Ok();
        }

        [HttpPost]
        [Route("Register")] //Account/Register (cadastro de usuario)
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost]
        [Route("PasswordRecover")] //Account/PasswordRecover (esqueci minha senha)
        public IActionResult PasswordRecover()
        {
            return Ok();
        }
    }
}
