using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVirtual.ViewModels
{
    public class CarrinhoCompraViewModel
    {
        public List<Carrinho> CartItems { get; set; }
        public decimal CarrinhoTotal { get; set; }
    }
}