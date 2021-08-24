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
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            //nome da tabela
            builder.ToTable("CONTATO");

            //chave primaria
            builder.HasKey(c => c.IdContato);

            //demais campos
            builder.Property(c => c.IdContato)
                .HasColumnName("IDCONTATO");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnName("TELEFONE")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(c => c.Foto)
                .HasColumnName("FOTO")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.IdUsuario)
               .HasColumnName("IDUSUARIO")
               .IsRequired();

            //definir o relacionamento de 1 para muitos
            //e tambem a chave estrangeira
            builder.HasOne(c => c.Usuario) //Contato POSSUI 1 Usuario
                .WithMany(u => u.Contatos) //Usuario POSSUI MUitos Contatos
                .HasForeignKey(c => c.IdUsuario); //Chave estrangeira
        }
    }
}


