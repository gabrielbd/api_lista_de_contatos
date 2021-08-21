using Microsoft.EntityFrameworkCore;
using ProjetoAspNetAPI02.Data.Contexts;
using ProjetoAspNetAPI02.Data.Cryptography;
using ProjetoAspNetAPI02.Data.Entities;
using ProjetoAspNetAPI02.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para inicializar o atributo (injeção de dependência)
        public UsuarioRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Inserir(Usuario usuario)
        {
            //criptografar a senha do usuario
            usuario.Senha = MD5Cryptography.Encrypt(usuario.Senha);

            _context.Entry(usuario).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AlterarSenha(Guid idUsuario, string novaSenha)
        {
            //buscar o usuario atraves do idUsuario
            var usuario = _context.Usuario.Find(idUsuario);

            //criptografar a nova senha do usuario
            usuario.Senha = MD5Cryptography.Encrypt(novaSenha);

            //atualizar o usuario
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Usuario> Consultar()
        {
            return _context.Usuario
                .OrderBy(u => u.Nome)
                .ToList();
        }

        public Usuario ObterPorId(Guid idUsuario)
        {
            return _context.Usuario.Find(idUsuario);
        }

        public Usuario Obter(string email)
        {
            return _context.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario Obter(string email, string senha)
        {
            //criptografar a senha do usuario
            senha = MD5Cryptography.Encrypt(senha);

            return _context.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email)
                                      && u.Senha.Equals(senha));

        }
    }
}


