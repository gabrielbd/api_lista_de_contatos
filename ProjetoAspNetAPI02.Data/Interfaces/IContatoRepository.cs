using ProjetoAspNetAPI02.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Data.Interfaces
{
    public interface IContatoRepository
    {
        void Inserir(Contato contato);
        void Alterar(Contato contato);
        void Excluir(Contato contato);

        List<Contato> Consultar(Guid idUsuario);
        Contato ObterPorId(Guid idContato, Guid idUsuario);
    }
}


