using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAspNetAPI02.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAspNetAPI02.Data.Mappings
{
    //Classe de mapeamento para a entidade Usuario
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //nome da tabela
            builder.ToTable("USUARIO");

            //campo chave primária
            builder.HasKey(u => u.IdUsuario);

            //mapear cada campo da tabela
            builder.Property(u => u.IdUsuario)
                .HasColumnName("IDUSUARIO");

            builder.Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.DataCadastro)
                .HasColumnName("DATACADASTRO")
                .IsRequired();
        }
    }
}


