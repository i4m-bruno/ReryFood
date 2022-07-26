using Microsoft.EntityFrameworkCore;
using ReryFood.Models.Context;

namespace ReryFood.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;
        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }


        #region Propriedades

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        #endregion

        #region Métodos

        public static CarrinhoCompra GetCarrinho(IServiceProvider service) // Obtém ou gera um novo carrinho de compras
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // inicia ou obtém uma session
            var context = service.GetService<AppDbContext>(); // obtem servico do tipo do contexto

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId,
            };
        }

        public void AddItemCarrinho(Lanche lanche)
        {
            var carrinhoItem = _context.CarrinhoCompraItens.SingleOrDefault
                (i => i.Lanche.LancheId == lanche.LancheId && i.CarrinhoCompraId == CarrinhoCompraId); // verifica se o item já existe no carrinho

            if (carrinhoItem == null)
            {
                carrinhoItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1,
                };
                _context.CarrinhoCompraItens.Add(carrinhoItem);
            }
            else
            {
                carrinhoItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public int DeleteItemCarrinho(Lanche lanche)
        {
            var carrinhoItem = _context.CarrinhoCompraItens.SingleOrDefault
                (i => i.Lanche.LancheId == lanche.LancheId && i.CarrinhoCompraId == CarrinhoCompraId);

            int qtdItem = 0;

            if (carrinhoItem != null)
            {
                if (carrinhoItem.Quantidade > 1)
                {
                    carrinhoItem.Quantidade--;
                    qtdItem = carrinhoItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhoItem);
                }
            }
            _context.SaveChanges();
            return qtdItem;
        }

        public List<CarrinhoCompraItem> GetItensCarrinho()
        {
            return CarrinhoCompraItens ?? (CarrinhoCompraItens = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                                            .Include(c => c.Lanche).ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId);
            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetTotalCarrinho()
        {
            var totalCarrinho = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                                                            .Select(c => c.Quantidade * c.Lanche.Preco).Sum();
            return totalCarrinho;
        }

        #endregion
    }
}
