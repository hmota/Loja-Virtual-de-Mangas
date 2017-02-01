using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaVirtual.Models
{
    [Table("Mangas")]
    public class Manga
    {
        public int MangaId { get; set; }
        public int GeneroId { get; set; }
        public int AutorId { get; set; }

        public string Titulo { get; set; }
        public decimal Preco { get; set; }
        public string CapaMangaUrl { get; set; }

        public virtual Genero Genero { get; set; }
        public virtual Autor Autor { get; set; }
    }
}