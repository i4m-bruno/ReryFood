using ReryFood.Models;
using ReryFood.Models.Context;
using ReryFood.Repositories.Interfaces;

namespace ReryFood.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appContext;
        private readonly CarrinhoCompra _carrinhoCompra;
        public PedidoRepository(AppDbContext appContext, CarrinhoCompra carrinhoCompra)
        {
            _appContext = appContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appContext.Pedido.Add(pedido);
            _appContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach (var item in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = item.Quantidade,
                    LancheId = item.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = item.Lanche.Preco
                };
                _appContext.PedidoDetalhe.Add(pedidoDetail);
            }

            _appContext.SaveChanges();
        }
    }
}
