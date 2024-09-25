using System.ComponentModel.DataAnnotations;

namespace ANP___Atividade___Cliente.Dtos
{
    public class ClienteDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Complemento { get; set; }
    }
}