using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Models
{
    [Table("Mangas")]
    [Bind(Exclude ="AlbumID")]
    public class Manga
    {
        [ScaffoldColumn(false)]
        public int MangaId { get; set; }
        [DisplayName("Genero")]
        public int GeneroId { get; set; }
        [DisplayName("Autor")]
        public int AutorId { get; set; }

        [Required(ErrorMessage ="Necessario titulo do Manga")]
        [StringLength(160)]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="Necessario preço")]
        [Range(0.01, 100.00, ErrorMessage ="Preço deve estar entre 0,01 a 100")]
        public decimal Preco { get; set; }
        [DisplayName("Capa Manga URL")]
        [StringLength(1024)]
        public string CapaMangaUrl { get; set; }

        public virtual Genero Genero { get; set; }
        public virtual Autor Autor { get; set; }
    }
}