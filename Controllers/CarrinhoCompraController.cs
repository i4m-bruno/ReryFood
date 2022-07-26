using Microsoft.AspNetCore.Mvc;
using ReryFood.Models;
using ReryFood.Repositories.Interfaces;
using ReryFood.ViewModels;

namespace ReryFood.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(CarrinhoCompra carrinhoCompra, ILancheRepository lancheRepository)
        {
            _carrinhoCompra = carrinhoCompra;
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            List<CarrinhoCompraItem> itens = _carrinhoCompra.GetItensCarrinho();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetTotalCarrinho(),
            };

            return View(carrinhoCompraVM);
        }

        public IActionResult AddItemNoCarrinho(int lancheId)
        {
            Lanche lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);

            if (lancheSelecionado != null)
                _carrinhoCompra.AddItemCarrinho(lancheSelecionado);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteItemCarrinho(int lancheId)
        {
            Lanche lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);

            if (lancheSelecionado != null)
                _carrinhoCompra.DeleteItemCarrinho(lancheSelecionado);

            return RedirectToAction("Index");
        }
    }
}
