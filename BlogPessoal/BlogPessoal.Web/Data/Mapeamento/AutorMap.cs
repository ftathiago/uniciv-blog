using BlogPessoal.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BlogPessoal.Web.Data.Mapeamento
{
    public class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("autor");
            HasKey(a => a.Id);
            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("nome");
            Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(150)
                //Índice único
                .HasColumnName("email");
            Property(a => a.Administrador)
                .IsRequired()
                //Valor padrao
                .HasColumnName("administrador");
            Property(a => a.DataCadastro)
                .IsRequired()
                .HasColumnName("data_cadastro");
        }
    }
}