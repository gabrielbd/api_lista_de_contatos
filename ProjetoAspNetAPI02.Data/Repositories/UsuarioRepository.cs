using Microsoft.EntityFrameworkCore;
using ProjetoAspNetAPI02.Data.Contexts;
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
            _context.Entry(usuario).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
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
            return _context.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email)
                                      && u.Senha.Equals(senha));

        }
    }
}
