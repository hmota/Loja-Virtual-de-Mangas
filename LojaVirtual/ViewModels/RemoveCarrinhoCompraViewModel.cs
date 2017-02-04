using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVirtual.ViewModels
{
    public class RemoveCarrinhoCompraViewModel
    {
        public string Mensagem { get; set; }
        public decimal CarrinhoTotal { get; set; }
        public int CarrinhoContagem { get; set; }
        public int ItemContagem { get; set; }
        public int DeleteId { get; set; }
    }
}