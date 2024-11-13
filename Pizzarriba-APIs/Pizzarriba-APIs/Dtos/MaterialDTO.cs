using System.ComponentModel.DataAnnotations;

namespace Pizzarriba_APIs.DTOs
{
    public class MaterialDTO
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Medida { get; set; }
        [Required]
        public double Quantidade { get; set; }
    }
}
