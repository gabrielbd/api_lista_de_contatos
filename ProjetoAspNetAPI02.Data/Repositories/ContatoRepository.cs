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
    public class ContatoRepository : IContatoRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para inicialização do atributo (injeção de dependencia)
        public ContatoRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Inserir(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Contato> Consultar(Guid idUsuario)
        {
            return _context.Contato
                    .Where(c => c.IdUsuario.Equals(idUsuario))
                    .OrderBy(c => c.Nome)
                    .ToList();
        }

        public Contato ObterPorId(Guid idContato, Guid idUsuario)
        {
            return _context.Contato
                    .FirstOrDefault(c => c.IdContato.Equals(idContato)
                                      && c.IdUsuario.Equals(idUsuario));
        }
    }
}
