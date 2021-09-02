using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjetoAspNetAPI02.Services.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //configuração do Swagger
            SwaggerConfiguration.ConfigureServices(services);

            //configuração da camada de repositorio
            RepositoryConfiguration.ConfigureServices(services, Configuration);

            //configuração da autenticação (JWT)
            JwtTokenConfiguration.ConfigureServices(services, Configuration);

            //Configuração do CORS (CROSS ORIGIN RESOURCE SHARING)
            services.AddCors(
                    s => s.AddPolicy("DefaultPolicy", builder =>
                    {
                        builder.AllowAnyOrigin() //qualquer origem pode acessar a API
                               .AllowAnyMethod() //qualquer método (POST, PUT, DELETE, GET)
                               .AllowAnyHeader(); //qualquer informação de cabeçalho
                    })
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //incluindo uma configuração adicional para gerar a documentação do swagger
            app.UseSwagger();
            app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "COTI API"); });

            app.UseRouting();

            app.UseCors("DefaultPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


