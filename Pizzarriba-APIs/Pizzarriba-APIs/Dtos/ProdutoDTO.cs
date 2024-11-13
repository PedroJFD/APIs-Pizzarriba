using System.ComponentModel.DataAnnotations;

namespace Pizzarriba_APIs.DTOs
{
    public class ProdutoDTO
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
