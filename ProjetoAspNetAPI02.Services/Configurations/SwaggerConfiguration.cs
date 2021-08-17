using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Services.Configurations
{
    public class SwaggerConfiguration
    {
        //método para incluir a configuração do swagger
        public static void ConfigureServices(IServiceCollection services)
        {
            //configuração para gerar a documentação do Swagger
            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "API para autenticação de usuários - Treinamento em C# WebDeveloper.",
                        Description = "Projeto desenvolvido em AspNet 5 API com SqlServer e EntityFramework.",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "COTI Informática - Escola de NERDS",
                            Url = new Uri("http://www.cotiinformatica.com.br"),
                            Email = "contato@cotiinformatica.com.br"
                        }
                    });
                });
        }
    }
}
