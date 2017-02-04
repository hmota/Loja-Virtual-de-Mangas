using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaVirtual.Models
{
    [Table("Carrinhos")]
    public class Carrinho
    {
        [Key]
        public int CarrinhoId { get; set; }
        public string CarrinhoGuid { get; set; }
        public int MangaId { get; set; }
        public int Count { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual Manga Manga { get; set; }
    }
}