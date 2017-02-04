using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaVirtual.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        public int PedidoId { get; set; }
        public string Usuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public DateTime DataPedido { get; set; }
        
        public List<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}