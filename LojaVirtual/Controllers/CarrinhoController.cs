using System.Linq;
using System.Web.Mvc;
using LojaVirtual.Models;
using LojaVirtual.ViewModels;

namespace LojaVirtual.Controllers
{
    public class CarrinhoController : Controller
    {
        LojaVirtualEntities lojaDb = new LojaVirtualEntities();
        //
        // GET: /CarrinhoCompra/
        public ActionResult Index()
        {
            var carrinho = CarrinhoCompra.ObterCarrinho(this.HttpContext);
            // Set up our ViewModel
            var viewModel = new CarrinhoCompraViewModel
            {
                CartItems = carrinho.ObterCarrinhoItens(),
                CarrinhoTotal = carrinho.ObterTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult Adicionar(int id)
        {
            // Retrieve the album from the database
            var mangaAdicionado = lojaDb.Mangas
            .Single(manga => manga.MangaId == id);
            // Add it to the shopping cart
            var carrinho = CarrinhoCompra.ObterCarrinho(this.HttpContext);
            carrinho.Adicionar(mangaAdicionado);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /CarrinhoCompra/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var carrinho = CarrinhoCompra.ObterCarrinho(this.HttpContext);
            // Get the name of the album to display confirmation
            string mangaNome = lojaDb.Carrinhos
            .Single(item => item.CarrinhoId == id).Manga.Titulo;
            // Remove from cart
            int itemCount = carrinho.Remover(id);
            // Display the confirmation message
            var results = new RemoveCarrinhoCompraViewModel
            {
                Mensagem = Server.HtmlEncode(mangaNome) +
            " has been removed from your shopping cart.",
                CarrinhoTotal = carrinho.ObterTotal(),
                CarrinhoContagem = carrinho.ObterContagem(),
                ItemContagem = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /CarrinhoCompra/CartSummary
        [ChildActionOnly]
        public ActionResult CarrinhoResumo()
        {
            var carrinho = CarrinhoCompra.ObterCarrinho(this.HttpContext);
            ViewData["CarrinhoContagem"] = carrinho.ObterContagem();
            return PartialView("CarrinhoResumo");
        }
    }
}