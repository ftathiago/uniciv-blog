using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class CategoriasDeArtigoController : Controller
    {
        private readonly BlogPessoalContexto _ctx = new BlogPessoalContexto();
        public CategoriasDeArtigoController(){}

        public ActionResult Index()
        {
            var categorias = _ctx.CategoriasDeArtigo
                .OrderBy(c => c.Nome)
                .ToList();

            return View(categorias);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaDeArtigo categoria)
        {
            if (!ModelState.IsValid)
                return View(categoria);

            _ctx.CategoriasDeArtigo.Add(categoria);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var categoria = _ctx.CategoriasDeArtigo.Find(id);
            if (categoria == null)
                return new HttpNotFoundResult();
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit(CategoriaDeArtigo categoria)
        {
            if (!ModelState.IsValid)
                return View(categoria);

            _ctx.Entry(categoria).State = EntityState.Modified;
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var categoria = _ctx.CategoriasDeArtigo.Find(id);
            if (categoria == null)
                return new HttpNotFoundResult();

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var categoria = _ctx.CategoriasDeArtigo.Find(id);
            _ctx.CategoriasDeArtigo.Remove(categoria);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}