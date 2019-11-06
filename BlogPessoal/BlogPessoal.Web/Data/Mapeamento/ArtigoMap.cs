using BlogPessoal.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BlogPessoal.Web.Data.Mapeamento
{
    public class ArtigoMap : EntityTypeConfiguration<Artigo>
    {
        public ArtigoMap()
        {
            ToTable("artigo");
            HasKey(a => a.Id);
            Property(a => a.Titulo)
                .IsRequired()
                .HasMaxLength(300);
            Property(a => a.Conteudo)
                .IsRequired();
            Property(a => a.DataPublicacao)
                .IsRequired()
                .HasColumnName("data_publicacao");
            Property(a => a.CategoriaDeArtigoId)
                .IsRequired()
                .HasColumnName("categoria_artigo_id");
            Property(a => a.AutorId)
                .IsRequired()
                .HasColumnName("autor_id");
            Property(a => a.Removido)
                .IsRequired();
            HasRequired(a => a.CategoriaDeArtigo)
                .WithMany(a => a.Artigos)
                .HasForeignKey(a => a.CategoriaDeArtigoId)
                .WillCascadeOnDelete(false);
            HasRequired(a => a.Autor)
                .WithMany(a => a.Artigos)
                .HasForeignKey(a => a.AutorId)
                .WillCascadeOnDelete(false);

        }
    }
}