using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoAspNetAPI02.Data.Contexts;
using ProjetoAspNetAPI02.Data.Interfaces;
using ProjetoAspNetAPI02.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Services.Configurations
{
    public class RepositoryConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //lendo a connectionstring do arquivo /appsettings.json
            var connectionstring = configuration.GetConnectionString("ProjetoAPI");

            //configurar a classe principal do projeto EntityFramework,
            //passando para ela a connectionstring do banco de dados
            services.AddDbContext<SqlServerContext>(
                options => options.UseSqlServer(connectionstring)
                );

            //mapear cada repositorio do projeto..
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }
    }
}


