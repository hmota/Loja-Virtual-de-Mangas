using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LojaVirtual.Models;

namespace LojaVirtual.Controllers
{
    public class GerenciaController : Controller
    {
        private LojaVirtualEntities db = new LojaVirtualEntities();

        // GET: Gerencia
        public ActionResult Index()
        {
            var mangas = db.Mangas.Include(m => m.Autor).Include(m => m.Genero);
            return View(mangas.ToList());
        }

        // GET: Gerencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manga manga = db.Mangas.Find(id);
            if (manga == null)
            {
                return HttpNotFound();
            }
            return View(manga);
        }

        // GET: Gerencia/Create
        public ActionResult Create()
        {
            ViewBag.AutorId = new SelectList(db.Autores, "AutorId", "Nome");
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome");
            return View();
        }

        // POST: Gerencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MangaId,GeneroId,AutorId,Titulo,Preco,CapaMangaUrl")] Manga manga)
        {
            if (ModelState.IsValid)
            {
                db.Mangas.Add(manga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorId = new SelectList(db.Autores, "AutorId", "Nome", manga.AutorId);
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome", manga.GeneroId);
            return View(manga);
        }

        // GET: Gerencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manga manga = db.Mangas.Find(id);
            if (manga == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorId = new SelectList(db.Autores, "AutorId", "Nome", manga.AutorId);
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome", manga.GeneroId);
            return View(manga);
        }

        // POST: Gerencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MangaId,GeneroId,AutorId,Titulo,Preco,CapaMangaUrl")] Manga manga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorId = new SelectList(db.Autores, "AutorId", "Nome", manga.AutorId);
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome", manga.GeneroId);
            return View(manga);
        }

        // GET: Gerencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manga manga = db.Mangas.Find(id);
            if (manga == null)
            {
                return HttpNotFound();
            }
            return View(manga);
        }

        // POST: Gerencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manga manga = db.Mangas.Find(id);
            db.Mangas.Remove(manga);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
