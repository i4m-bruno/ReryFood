using Microsoft.AspNetCore.Mvc;
using ReryFood.Models;
using ReryFood.ViewModels;

namespace ReryFood.Components
{
    public class CarrinhoResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinho;

        public CarrinhoResumo(CarrinhoCompra carrinho)
        {
            _carrinho = carrinho;
        }

        public IViewComponentResult Invoke()
        {
            var itens = new List<CarrinhoCompraItem>()
            {
                new CarrinhoCompraItem(),
                new CarrinhoCompraItem(),
                new CarrinhoCompraItem(),
            };//_carrinho.GetItensCarrinho();
            _carrinho.CarrinhoCompraItens = itens;

            var carrinhoVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinho,
                CarrinhoCompraTotal = _carrinho.GetTotalCarrinho(),
            };

            return View(carrinhoVM);
        }
    }
}
