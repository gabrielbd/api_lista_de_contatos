using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Services.Authentication
{
    public class JwtTokenServices
    {
        //atributo
        private readonly JwtTokenSettings _jwtTokenSettings;
        //construtor para injeção de dependência
        public JwtTokenServices(JwtTokenSettings jwtTokenSettings)
        {
            _jwtTokenSettings = jwtTokenSettings;
        }

        //método para gerar e retornar o TOKEN criptografado do usuário
        public string GenerateToken(string email)
        {
            //utilizando a chave secreta anti-falsificação para gerar a criptografia do token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtTokenSettings.SecretKey); //SecretKey criado no appsettings.json

            //definindo o conteudo do TOKEN..
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //gravando no token o email do usuario autenticado
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, email) }),

                //definindo o tempo de validade do token
                Expires = DateTime.Now.AddHours(_jwtTokenSettings.ExpirationInHours),

                //criptografar o token com a chave secreta
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //retornar o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}


