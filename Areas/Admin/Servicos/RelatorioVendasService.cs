using Microsoft.EntityFrameworkCore;
using ReryFood.Models;
using ReryFood.Models.Context;

namespace ReryFood.Areas.Admin.Servicos
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext _context;

        public RelatorioVendasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? mindate, DateTime? maxDate)
        {
            var resultado = from obj in _context.Pedido select obj;

            if (mindate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= mindate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            var r = await resultado
                            .Include(i => i.PedidoItens)
                            .ThenInclude(l => l.Lanche)
                            .OrderByDescending(x => x.PedidoEnviado)
                            .ToListAsync();
            return r;
        }
    }
}
