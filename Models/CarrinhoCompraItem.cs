using System.ComponentModel.DataAnnotations;

namespace ReryFood.Models
{
    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemId { get; set; }
        public Lanche Lanche { get; set; }
        public int Quantidade { get; set; }

        [StringLength(100)]
        public string CarrinhoCompraId { get; set; }
    }
}
