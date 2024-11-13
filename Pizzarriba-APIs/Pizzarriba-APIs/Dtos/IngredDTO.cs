using System.ComponentModel.DataAnnotations;
using IngredienteAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IngredienteAPI.Dtos
{
    public class IngredDTO
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Fornecedor { get; set; }
        [Required]
        public string Medida { get; set; }
        [Required]
        public double Quantidade { get; set; }

    }
}
