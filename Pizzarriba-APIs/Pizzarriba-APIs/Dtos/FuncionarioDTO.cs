using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Pizzarriba_APIs.Dtos
{
    public class FuncionarioDTO
    {
       [Required]
        public string Nome { get; set; }
        [Required]
        public int ID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string RG { get; set; }
        [Required]
        public string PISNIT { get; set; }
        [Required]
        public string OrgaoEmissorRG { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Complemento { get; set; }


    }

}
