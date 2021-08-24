using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Data.Entities
{
    public class Contato
    {
        public Guid IdContato { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public Guid IdUsuario { get; set; }

        //Contato PERTENCE a 1 Usuario
        public Usuario Usuario { get; set; }
    }
}
