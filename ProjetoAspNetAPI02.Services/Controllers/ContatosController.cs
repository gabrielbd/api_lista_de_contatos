using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        [HttpPost] //serviço para cadastrar um contato
        public IActionResult Post()
        {
            return Ok(); //TODO
        }

        [HttpPut] //serviço para atualizar um contato
        public IActionResult Put()
        {
            return Ok(); //TODO
        }

        [HttpDelete("{id}")] //serviço para excluir um contato
        public IActionResult Delete(Guid id)
        {
            return Ok(); //TODO
        }

        [HttpGet] //serviço para consultar os contatos do usuario
        public IActionResult GetAll()
        {
            return Ok(); //TODO
        }

        [HttpGet("{id}")] //serviço para consultar 1 contato pelo id
        public IActionResult GetById(Guid id)
        {
            return Ok(); //TODO
        }
    }
}


