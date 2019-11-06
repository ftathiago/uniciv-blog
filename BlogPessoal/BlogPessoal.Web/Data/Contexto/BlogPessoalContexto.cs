using BlogPessoal.Web.Data.Mapeamento;
using BlogPessoal.Web.Models;
using System.Data.Entity;

namespace BlogPessoal.Web.Data.Contexto
{
    public class BlogPessoalContexto : DbContext
    {
        public BlogPessoalContexto() : base(typeof(BlogPessoalContexto).Name)
        {

        }
        public DbSet<CategoriaDeArtigo> CategoriasDeArtigo { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Artigo> Artigos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaDeArtigoMap());
            modelBuilder.Configurations.Add(new AutorMap());
            modelBuilder.Configurations.Add(new ArtigoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}