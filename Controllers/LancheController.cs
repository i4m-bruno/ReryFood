using Microsoft.AspNetCore.Mvc;
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

        public IActionResult List()
        {
            var lanches = _lancheRepository.Lanches;
            var categorias = _categoriaRepository.Categorias;

            LanchesListViewModel lanchesListViewModel = new();
            lanchesListViewModel.Lanches = lanches;
            return View(lanchesListViewModel);
        }
    }
}
