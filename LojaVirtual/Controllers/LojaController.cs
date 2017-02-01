using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Controllers
{
    public class LojaController : Controller
    {
        // GET: Loja/
        public string Index()
        {
            return "Bem vindo ao indice";
        }

        // GET: Loja/Categoria?Genero=SciFi
        public string Categoria(string genero)
        {
            var mensagem = HttpUtility.HtmlEncode("Categoria: " + genero);
            return mensagem;
        }

        // GET: Loja
        public string Detalhes()
        {
            return "Detalhes";
        }
    }
}