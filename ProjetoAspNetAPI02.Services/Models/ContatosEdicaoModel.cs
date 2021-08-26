using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Services.Models
{
    public class ContatosEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do contato.")]
        public Guid IdContato { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do contato.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o telefone do contato.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do contato.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a foto do contato.")]
        public string Foto { get; set; }
    }
}
