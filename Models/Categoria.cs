using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReryFood.Models
{
    [Table("TB_Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo categoria obrigatório")]
        [StringLength(100, ErrorMessage = "Tamanho máximo - 100 caracteres")]
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        [Required(ErrorMessage = "Campo descrição obrigatório")]
        [StringLength(200, ErrorMessage = "Tamanho máximo - 200 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }
    }
}
