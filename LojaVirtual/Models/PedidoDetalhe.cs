using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models
{
    [Table("PedidoDetalhes")]
    public class PedidoDetalhe
    {
        public int PedidoDetalheId { get; set; }
        public int PedidoId { get; set; }
        public int MangaId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public virtual Manga Manga { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}