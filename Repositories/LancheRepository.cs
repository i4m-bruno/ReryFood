using Microsoft.EntityFrameworkCore;
using ReryFood.Models;
using ReryFood.Models.Context;
using ReryFood.Repositories.Interfaces;
using System.Linq;

namespace ReryFood.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanche.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanche.Where(l => l.IsLanchePreferido).Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanche.FirstOrDefault(l => l.LancheId == lancheId);
        }
    }
}
