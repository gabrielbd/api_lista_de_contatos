using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Services.Authentication
{
    //Classe para fazer a captura dos parametros configurados
    //no arquivo /appsettings.json que serão utilizados na
    //geração do TOKEN JWT
    public class JwtTokenSettings
    {
        public string SecretKey { get; set; }
        public int ExpirationInHours { get; set; }
    }
}