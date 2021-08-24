using Microsoft.EntityFrameworkCore;
using ProjetoAspNetAPI02.Data.Entities;
using ProjetoAspNetAPI02.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Data.Contexts
{
    //REGRA 1) HERDAR DbContext
    public class SqlServerContext : DbContext
    {
        //REGRA 2) Construtor para receber os parametros de conexão
        //com o SqlServer, como por exemplo, a connectionstring
        //O valor do parametro deste construtor será passado pela classe \Startup do projeto
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        //REGRA 3) Declarar um DbSet para cada entidade do projeto
        //Irá permitir programar os métodos de CRUD para qualquer entidade
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Contato> Contato { get; set; }

        //REGRA 4) Implementar o método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar cada classe de mapeamento do projeto
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
        }
    }
}


