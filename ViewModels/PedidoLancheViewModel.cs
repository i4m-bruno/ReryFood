using ReryFood.Models;

namespace ReryFood.ViewModels
{
    public class PedidoLancheViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhe { get; set; }
    }
}
