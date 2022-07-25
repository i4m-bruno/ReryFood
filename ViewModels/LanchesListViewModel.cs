using ReryFood.Models;

namespace ReryFood.ViewModels
{
    public class LanchesListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
