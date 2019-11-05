using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class AutoresController : Controller
    {
        private BlogPessoalContexto _ctx;

        public AutoresController(BlogPessoalContexto ctx)
        {
            _ctx = ctx;
        }
        public ActionResult Index()
        {
            var autores = _ctx.Autores
                .OrderBy(a => a.Nome)
                .ToList();
            return View(autores);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            if (!ModelState.IsValid)
                return View(autor);
            _ctx.Autores.Add(autor);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var autor = _ctx.Autores.Find(id);
            if (autor == null)
                return new HttpNotFoundResult();
            return View(autor);
        }

        [HttpPost]
        public ActionResult Edit(Autor autor)
        {
            if (!ModelState.IsValid)
                return View(autor);
            _ctx.Entry(autor).State = EntityState.Modified;
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var autor = _ctx.Autores.Find(id);
            if (autor == null)
                return new HttpNotFoundResult();
            return View(autor);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var autor = _ctx.Autores.Find(id);
            _ctx.Autores.Remove(autor);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}