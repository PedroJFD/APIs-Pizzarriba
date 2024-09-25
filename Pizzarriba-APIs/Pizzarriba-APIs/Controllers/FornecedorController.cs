using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fornecedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : Controller
    {
        private static List<FornecedorDTO> fornecedores = new List<FornecedorDTO>();

        private bool ValidarCNPJ(string cnpj)
        {
            cnpj = Regex.Replace(cnpj, @"\D", "");
            return cnpj.Length == 14;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(fornecedores);
        }

        [HttpGet("{Id}")]
        public IActionResult GetByed(int Id)
        {
            var fornecedor = fornecedores.FirstOrDefault(f => f.Id == Id);

            if (fornecedor == null)
            {
                return BadRequest("Fornecedor não encontrado.");
            }

            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FornecedorDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            if (!ValidarCNPJ(dto.CNPJ))
            {
                return BadRequest("CNPJ inválido.");
            }

            var fornecedor = new FornecedorDTO
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Email = dto.Email,
                CNPJ = dto.CNPJ,
                Endereco = dto.Endereco,
                Cep = dto.Cep,
                Rua = dto.Rua,
                Bairro = dto.Bairro,
                Numero = dto.Numero,
                Produto = dto.Produto
            };

            fornecedores.Add(fornecedor);

            return StatusCode(StatusCodes.Status201Created, fornecedor);
        }

        [HttpPut("{cnpj}")]
        public IActionResult Put(string cnpj, [FromBody] FornecedorDTO dto)
        {
            if (!ValidarCNPJ(cnpj))
            {
                return BadRequest("CNPJ inválido.");
            }

            var fornecedor = fornecedores.FirstOrDefault(f => f.CNPJ == cnpj);

            if (fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado.");
            }

            fornecedor.Nome = dto.Nome ?? fornecedor.Nome;
            fornecedor.Telefone = dto.Telefone ?? fornecedor.Telefone;
            fornecedor.Email = dto.Email ?? fornecedor.Email;
            fornecedor.Endereco = dto.Endereco ?? fornecedor.Endereco;
            fornecedor.Cep = dto.Cep ?? fornecedor.Cep;
            fornecedor.Rua = dto.Rua ?? fornecedor.Rua;
            fornecedor.Bairro = dto.Bairro ?? fornecedor.Bairro;
            fornecedor.Numero = dto.Numero ?? fornecedor.Numero;
            fornecedor.Produto = dto.Produto ?? fornecedor.Produto;

            return Ok(fornecedor);
        }

        [HttpDelete("{cnpj}")]
        public IActionResult Delete(string cnpj)
        {
            if (!ValidarCNPJ(cnpj))
            {
                return BadRequest("CNPJ inválido.");
            }

            var fornecedor = fornecedores.FirstOrDefault(f => f.CNPJ == cnpj);

            if (fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado.");
            }

            fornecedores.Remove(fornecedor);

            return Ok(fornecedor);
        }
    }
}
