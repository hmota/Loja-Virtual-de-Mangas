using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaVirtual.Models;

namespace LojaVirtual.Controllers
{
    public class LojaController : Controller
    {
        LojaVirtualEntities lojaDB = new LojaVirtualEntities();

        // GET: Loja/
        public ActionResult Index()
        {
            var generos = lojaDB.Generos.ToList();

            return View(generos);
        }

        // GET: Loja/Categoria?Genero=SciFi
        public ActionResult Categoria(string genero)
        {
            var generoModel = lojaDB.Generos.Include("Mangas")
                .Single(g => g.Nome == genero);

            return View(generoModel);
        }

        // GET: Loja/
        public ActionResult Detalhes(int id)
        {
            var dbManga = lojaDB.Mangas.Find(id);
            return View(dbManga);
        }
    }
}