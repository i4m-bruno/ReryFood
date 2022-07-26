using Microsoft.AspNetCore.Mvc;
using ReryFood.Models;
using ReryFood.Repositories.Interfaces;

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
            return View();
        }
    }
}
