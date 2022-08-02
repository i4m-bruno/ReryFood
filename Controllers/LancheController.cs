using Microsoft.AspNetCore.Mvc;
using ReryFood.Models;
using ReryFood.Repositories.Interfaces;
using ReryFood.ViewModels;

namespace ReryFood.Controllers
{
    public class LancheController : Controller
    {

        private ILancheRepository _lancheRepository;
        private ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrWhiteSpace(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.Nome);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                            .Where(l => l.Categoria.CategoriaNome
                            .Equals(categoria, StringComparison.OrdinalIgnoreCase))
                            .OrderBy(l => l.Nome);

                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LanchesListViewModel()
            {
                CategoriaAtual = categoriaAtual,
                Lanches = lanches,
            };


            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }
    }
}
