using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspNetAPI02.Data.Entities;
using ProjetoAspNetAPI02.Data.Interfaces;
using ProjetoAspNetAPI02.Services.Models;
using System;
using System.Collections.Generic;

namespace ProjetoAspNetAPI02.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        //atributos
        private readonly IContatoRepository _contatoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        //construtor para injeção de dependencia..
        public ContatosController(IContatoRepository contatoRepository, IUsuarioRepository usuarioRepository)
        {
            _contatoRepository = contatoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost] //serviço para cadastrar um contato
        public IActionResult Post(ContatosCadastroModel model)
        {
            try
            {
                //obtendo o email do usuario autenticado pelo TOKEN
                var email = User.Identity.Name;
                //buscar os dados do usuario no banco atraves do email
                var usuario = _usuarioRepository.Obter(email);

                var contato = new Contato(); //preenchendo os dados do contato
                contato.IdContato = Guid.NewGuid();
                contato.Nome = model.Nome;
                contato.Telefone = model.Telefone;
                contato.Email = model.Email;
                contato.Foto = model.Foto;
                contato.IdUsuario = usuario.IdUsuario; //relacionamento

                //gravando no banco de dados
                _contatoRepository.Inserir(contato);

                return Ok($"Contato {contato.Nome}, cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpPut] //serviço para atualizar um contato
        public IActionResult Put(ContatosEdicaoModel model)
        {
            try
            {
                //obtendo o email do usuario autenticado pelo TOKEN
                var email = User.Identity.Name;
                //buscar os dados do usuario no banco atraves do email
                var usuario = _usuarioRepository.Obter(email);

                //pesquisar o contato no banco de dados
                var contato = _contatoRepository.ObterPorId(model.IdContato, usuario.IdUsuario);

                //verificar se o contato foi encontrado
                if (contato != null)
                {
                    //atualizar os dados do contato
                    contato.Nome = model.Nome;
                    contato.Email = model.Email;
                    contato.Telefone = model.Telefone;
                    contato.Foto = model.Foto;

                    _contatoRepository.Alterar(contato);

                    return Ok($"Contato {contato.Nome}, atualizado com sucesso.");
                }
                else
                {
                    return UnprocessableEntity("Contato não encontrado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpDelete("{idContato}")] //serviço para excluir um contato
        public IActionResult Delete(Guid idContato)
        {
            try
            {
                //obtendo o email do usuario autenticado pelo TOKEN
                var email = User.Identity.Name;
                //buscar os dados do usuario no banco atraves do email
                var usuario = _usuarioRepository.Obter(email);

                //pesquisar o contato no banco de dados
                var contato = _contatoRepository.ObterPorId(idContato, usuario.IdUsuario);

                //verificar se o contato foi encontrado
                if (contato != null)
                {
                    _contatoRepository.Excluir(contato);
                    return Ok($"Contato {contato.Nome}, excluido com sucesso.");
                }
                else
                {
                    return UnprocessableEntity("Contato não encontrado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet] //serviço para consultar os contatos do usuario
        public IActionResult GetAll()
        {
            try
            {
                //obtendo o email do usuario autenticado pelo TOKEN
                var email = User.Identity.Name;
                //buscar os dados do usuario no banco atraves do email
                var usuario = _usuarioRepository.Obter(email);

                //consultar os contatos do usuario autenticado
                var contatos = _contatoRepository.Consultar(usuario.IdUsuario);

                var lista = new List<ContatosConsultaModel>(); //modelo de dados
                foreach (var item in contatos) //percorrer os contatos do banco de dados
                {
                    var model = new ContatosConsultaModel();
                    model.IdContato = item.IdContato;
                    model.Nome = item.Nome;
                    model.Telefone = item.Telefone;
                    model.Email = item.Email;
                    model.Foto = item.Foto;

                    lista.Add(model); //adicionar na lista
                }

                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet("{idContato}")] //serviço para consultar 1 contato pelo id
        public IActionResult GetById(Guid idContato)
        {
            try
            {
                //obtendo o email do usuario autenticado pelo TOKEN
                var email = User.Identity.Name;
                //buscar os dados do usuario no banco atraves do email
                var usuario = _usuarioRepository.Obter(email);

                //consultar o contato do usuario autenticado pelo id
                var contato = _contatoRepository.ObterPorId(idContato, usuario.IdUsuario);

                if (contato != null) //contato foi encontrado
                {
                    var model = new ContatosConsultaModel();
                    model.IdContato = contato.IdContato;
                    model.Nome = contato.Nome;
                    model.Telefone = contato.Telefone;
                    model.Email = contato.Email;
                    model.Foto = contato.Foto;

                    return Ok(model);
                }
                else
                {
                    return NoContent(); //vazio!
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}


