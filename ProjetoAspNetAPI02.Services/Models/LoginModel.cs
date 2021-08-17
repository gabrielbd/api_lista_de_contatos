using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Services.Models
{
    public class LoginModel
    {
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        [Required(ErrorMessage = "Informe seu email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha.")]
        public string Senha { get; set; }
    }
}


