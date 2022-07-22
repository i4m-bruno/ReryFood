using ReryFood.Models;
using ReryFood.Models.Context;
using ReryFood.Repositories.Interfaces;

namespace ReryFood.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categoria;
    }
}
