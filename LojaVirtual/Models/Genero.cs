using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaVirtual.Models
{
    [Table("Generos")]
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual List<Manga> Mangas { get; set; }
    }
}