using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Models
{
    public interface ICarrinhoCompra
    {
        void Adicionar(Manga manga);
        int Remover(int id);
        void Esvaziar();
        List<Carrinho> ObterCarrinhoItens();
        int ObterContagem();
        decimal ObterTotal();
        int CriarPedido(Pedido pedido);
        string ObterCarrinhoGuid(HttpContextBase context);
        void Migrar(string usuario);
    }
}