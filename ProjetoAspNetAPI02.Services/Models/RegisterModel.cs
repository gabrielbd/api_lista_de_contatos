using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Services.Models
{
    public class RegisterModel
    {
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe seu nome.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        [Required(ErrorMessage = "Informe seu email.")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe sua senha.")]
        public string Senha { get; set; }

        [StrongPassword(ErrorMessage = "Por favor, informe uma senha com pelo menos" +
        " 1 letra maiuscula, 1 letra  minuscula, 1 digito numerico e 1 caractere especial.")]
        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Confirme sua senha.")]
        public string SenhaConfirmacao { get; set; }
    }

    //criando um validador customizado para o campo de senha
    public class StrongPassword : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var senha = value.ToString();

                return senha.Any(char.IsUpper) //pelo menos 1 letra maiuscula
                    && senha.Any(char.IsLower) //pelo menos 1 letra minuscula
                    && senha.Any(char.IsDigit) //pelo menos 1 digito numerico
                    && (senha.Contains("@") //pelo menos 1 dos caracteres especiais:
                        || senha.Contains("#")
                        || senha.Contains("$")
                        || senha.Contains("%")
                        || senha.Contains("&")
                        || senha.Contains("!"));
            };

            return false;
        }
    }
}

