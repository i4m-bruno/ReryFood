using ReryFood.Models;
using ReryFood.Models.Context;

namespace ReryFood.Areas.Admin.Servicos
{
    public class GraficosVendaService
    {
        private readonly AppDbContext _context;

        public GraficosVendaService(AppDbContext context)
        {
            _context = context;
        }

        public List<LancheGrafico> GetGrafico(int days = 360)
        {
            var data = DateTime.Now.AddDays(-days);

            var lanches = (from pd in _context.PedidoDetalhe
                           join l in _context.Lanche on pd.LancheId equals l.LancheId
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LancheId, l.Nome, pd.Quantidade }
                           into g
                           select new
                           {
                               LancheNome = g.Key.Nome,
                               LanchesQtd = g.Sum(q => q.Quantidade),
                               LanchesValorTotal = g.Sum(a => a.Quantidade * a.Preco),
                           }
                           );

            var lista = new List<LancheGrafico>();

            foreach (var item in lanches)
            {
                var lanche = new LancheGrafico();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQtd = item.LanchesQtd;
                lanche.LanchesValorTotal = item.LanchesValorTotal;
                lista.Add(lanche);
            }

            return lista;
        }
    }
}
