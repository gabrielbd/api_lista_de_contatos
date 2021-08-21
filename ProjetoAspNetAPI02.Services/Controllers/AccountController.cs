using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspNetAPI02.Data.Entities;
using ProjetoAspNetAPI02.Data.Interfaces;
using ProjetoAspNetAPI02.Messages;
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
        //atributo para acessar os métodos do repositorio
        private readonly IUsuarioRepository _usuariorepository;

        //construtor para inicializar o atributo (injeção de dependencia)
        public AccountController(IUsuarioRepository usuariorepository)
        {
            _usuariorepository = usuariorepository;
        }

        [HttpPost]
        [Route("Login")] //Account/Login (autenticação de usuario)
        public IActionResult Login(LoginModel model)
        {
            try
            {
                //pesquisar o usuario no banco de dados atraves do email e da senha
                var usuario = _usuariorepository.Obter(model.Email, model.Senha);

                //verificar se o usuario foi encontrado
                if (usuario != null)
                {
                    return Ok(new
                    {
                        mensagem = "Usuário autenticado com sucesso",
                        accessToken = "<TOKEN>", //TODO -> CHAVE DE AUTENTICAÇÂO GERADA PARA O USUARIO..
                        usuario = usuario.Nome,
                        email = usuario.Email
                    }); ;
                }
                else
                {
                    //ERRO 401 - Não autorizado!
                    return Unauthorized("Acesso negado, usuário inválido.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpPost]
        [Route("Register")] //Account/Register (cadastro de usuario)
        public IActionResult Register(RegisterModel model)
        {
            try
            {
                //verificar se o email informado já encontra-se cadastrado na base de dados
                if (_usuariorepository.Obter(model.Email) != null)
                {
                    //retornar erro
                    return UnprocessableEntity($"O email {model.Email} já está cadastrado no sistema.");
                }
                else
                {
                    var usuario = new Usuario();

                    usuario.IdUsuario = Guid.NewGuid();
                    usuario.Nome = model.Nome;
                    usuario.Email = model.Email;
                    usuario.Senha = model.Senha;
                    usuario.DataCadastro = DateTime.Now;

                    //cadastrar o usuario no banco de dados
                    _usuariorepository.Inserir(usuario);

                    return Ok($"Usuário {usuario.Nome}, cadastrado com sucesso.");
                }
            }
            catch (Exception e)
            {
                //retornar erro 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, "Erro:" + e.Message);
            }
        }

        [HttpPost]
        [Route("PasswordRecover")] //Account/PasswordRecover (esqueci minha senha)
        public IActionResult PasswordRecover(PasswordRecoverModel model)
        {
            try
            {
                //buscar o usuario no banco de dados atraves do email..
                var usuario = _usuariorepository.Obter(model.Email);

                //verificar se o usuario foi encontrado
                if (usuario != null)
                {
                    //gerar uma nova senha para o usuario..
                    var novaSenha = new Random().Next(99999999, 999999999).ToString();
                    //alterar a senha do usuario
                    _usuariorepository.AlterarSenha(usuario.IdUsuario, novaSenha);

                    //enviar a nova senha para o email do usuario
                    EnviarNovaSenha(usuario, novaSenha);

                    return Ok($"Nova senha gerada com sucesso. Verifique no email {model.Email} a nova senha de acesso.");
                }
                else
                {
                    return UnprocessableEntity($"Erro. O email fornecido {model.Email} não está cadastrado no sistema.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        //método para realizar o envio do email
        private void EnviarNovaSenha(Usuario usuario, string novaSenha)
        {
            var to = usuario.Email;
            var subject = "Nova senha gerada com sucesso - Sistema de controle de tarefas";
            var body = $@"
                            <div style='text-align: center; margin: 40px; padding: 60px; border: 2px solid #ccc; font-size: 16pt;'>
                            <img src='https://www.cotiinformatica.com.br/imagens/logo-coti-informatica.png' />
                            <br/><br/>
                            Olá <strong>{usuario.Nome}</strong>,
                            <br/><br/>    
                            O sistema gerou uma nova senha para que você possa acessar sua conta.<br/>
                            Por favor utilize a senha: <strong>{novaSenha}</strong>
                            <br/><br/>
                            Não esqueça de, ao acessar o sistema, atualizar esta senha para outra
                            de sua preferência.
                            <br/><br/>              
                            Att<br/>   
                            Equipe COTI Informatica
                            </div>
                        ";

            //enviando o email
            var message = new EmailServiceMessage();
            message.EnviarMensagem(to, subject, body);
        }
    }
}


