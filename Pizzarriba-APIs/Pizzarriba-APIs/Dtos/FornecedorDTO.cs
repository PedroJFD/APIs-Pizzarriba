using System.ComponentModel.DataAnnotations;

namespace Fornecedores
{
    public class FornecedorDTO
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CNPJ { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Produto { get; set; }
    }
}
