using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaVirtual.Models
{
    [Table("Autores")]
    public class Autor
    {
        public int AutorId { get; set; }
        public string Nome { get; set; }
    }
}