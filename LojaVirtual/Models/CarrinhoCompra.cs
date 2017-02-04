using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Models
{
    public partial class CarrinhoCompra : ICarrinhoCompra
    {
        LojaVirtualEntities lojaDB = new LojaVirtualEntities();

        string CarrinhoComprasGuid { get; set; }

        public const string CarrinhoSessionKey = "CarrinhoGuid";

        /// <summary>
        /// Retorna carrinho de compras
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static CarrinhoCompra ObterCarrinho(HttpContextBase context)
        {
            var carrinho = new CarrinhoCompra();
            carrinho.CarrinhoComprasGuid = carrinho.ObterCarrinhoGuid(context);
            return carrinho;
        }

        /// <summary>
        /// Simplificar chamada ao carrinho pelo controller
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static CarrinhoCompra ObterCarrinho(Controller controller)
        {
            return ObterCarrinho(controller.HttpContext);
        }

        public void Adicionar(Manga manga)
        {
            var carrinhoItem = lojaDB.Carrinhos.SingleOrDefault(
                c => c.CarrinhoGuid == CarrinhoComprasGuid
                && c.MangaId == manga.MangaId);

            if (carrinhoItem == null)
            {
                carrinhoItem = new Carrinho
                {
                    MangaId = manga.MangaId,
                    CarrinhoGuid = CarrinhoComprasGuid,
                    Count = 1,
                    DataCriacao = DateTime.Now
                };
                lojaDB.Carrinhos.Add(carrinhoItem);
            }
            else
            {
                carrinhoItem.Count++;
            }
            lojaDB.SaveChanges();
        }

        /// <summary>
        /// remove item do carrinho
        /// </summary>
        /// <param name="id">id do carrinho</param>
        /// <returns></returns>
        public int Remover(int id)
        {
            var carrinhoItem = lojaDB.Carrinhos.SingleOrDefault(
                c => c.CarrinhoGuid == CarrinhoComprasGuid
                && c.CarrinhoId == id);

            int itemCount = 0;

            if (carrinhoItem != null)
            {
                if (carrinhoItem.Count > 1)
                {
                    carrinhoItem.Count--;
                    itemCount = carrinhoItem.Count;
                }
                else
                {
                    lojaDB.Carrinhos.Remove(carrinhoItem);
                }

                lojaDB.SaveChanges();
            }

            return itemCount;
        }

        public List<Carrinho> ObterCarrinhoItens()
        {
            return lojaDB.Carrinhos.Where(c => c.CarrinhoGuid == CarrinhoComprasGuid).ToList();
        }

        public int ObterContagem()
        {
            int? count = (from carrinhoItens in lojaDB.Carrinhos
                          where carrinhoItens.CarrinhoGuid == CarrinhoComprasGuid
                          select (int?)carrinhoItens.Count).Sum();
            return count ?? 0;
        }

        public decimal ObterTotal()
        {
            decimal? total = (from carrinhoItens in lojaDB.Carrinhos
                              where carrinhoItens.CarrinhoGuid == CarrinhoComprasGuid
                              select (int?)carrinhoItens.Count * carrinhoItens.Manga.Preco).Sum();
            return total ?? decimal.Zero;
        }

        public int CriarPedido(Pedido pedido)
        {
            decimal pedidoTotal = 0;

            var carrinhoItens = ObterCarrinhoItens();

            foreach (var item in carrinhoItens)
            {
                var pedidoDetalhe = new PedidoDetalhe
                {
                    MangaId = item.MangaId,
                    PedidoId = pedido.PedidoId,
                    PrecoUnitario = item.Manga.Preco,
                    Quantidade = item.Count
                };

                pedidoTotal += (item.Count * item.Manga.Preco);

                lojaDB.PedidoDetalhes.Add(pedidoDetalhe);
            }

            pedido.Total = pedidoTotal;

            lojaDB.SaveChanges();

            Esvaziar();

            return pedido.PedidoId;
        }

        public void Esvaziar()
        {
            var carrinhoItens = lojaDB.Carrinhos.Where(c => c.CarrinhoGuid == CarrinhoComprasGuid);
            foreach (var carrinho in carrinhoItens)
            {
                lojaDB.Carrinhos.Remove(carrinho);
            }
            lojaDB.SaveChanges();
        }

        /// <summary>
        /// Le o httpContext e retorna o carrinho da sessao do usuario
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string ObterCarrinhoGuid(HttpContextBase context)
        {
            if (context.Session[CarrinhoSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CarrinhoSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    //gera novo guid para nome do carrinho
                    Guid tempCarrinhoGuid = Guid.NewGuid();
                    //envia para o cliente como cookie
                    context.Session[CarrinhoSessionKey] = tempCarrinhoGuid.ToString();
                }
            }
            return context.Session[CarrinhoSessionKey].ToString();
        }

        /// <summary>
        /// Se o usuario estiver logar, associa os carrinhos ao seu usuario
        /// </summary>
        /// <param name="usuario"></param>
        public void Migrar(string usuario)
        {
            var carrinhoCompras = lojaDB.Carrinhos.Where(c => c.CarrinhoGuid == CarrinhoComprasGuid);

            foreach (var item in carrinhoCompras)
            {
                item.CarrinhoGuid = usuario;
            }
            lojaDB.SaveChanges();
        }


    }
}