using ANP___Atividade___Cliente.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Fornecedores.Controllers
{
    [Route("Fornecedor")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        List<Fornecedor> listaFornecedor = new FornecedorDAO().List();

        [HttpGet]
        public IActionResult List()
        {
            return Ok(listaFornecedor);
        }

        private bool ValidarCNPJ(string cnpj)
        {
            cnpj = Regex.Replace(cnpj, @"\D", "");
            return cnpj.Length == 14;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fornecedor = listaFornecedor.FirstOrDefault(item => item.Id == id);

            if (fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado.");
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

            var fornecedor = new Fornecedor();

            int ultimoId = listaFornecedor.LastOrDefault()?.Id ?? 0;
            fornecedor.Id = ultimoId + 1;
            fornecedor.Codigo = dto.Codigo;
            fornecedor.Nome = dto.Nome;
            fornecedor.Telefone = dto.Telefone;
            fornecedor.Email = dto.Email;
            fornecedor.CNPJ = dto.CNPJ;
            fornecedor.Endereco = dto.Endereco;
            fornecedor.Cep = dto.Cep;
            fornecedor.Rua = dto.Rua;
            fornecedor.Bairro = dto.Bairro;
            fornecedor.Numero = dto.Numero;
            fornecedor.Produto = dto.Produto;

            try
            {
                var dao = new FornecedorDAO();
                fornecedor.Id = dao.Insert(fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, "Fornecedor registrado com sucesso!");
        }

        [HttpPut("{cnpj}")]
        public IActionResult Put(string cnpj, [FromBody] FornecedorDTO dto)
        {
            if (!ValidarCNPJ(cnpj))
            {
                return BadRequest("CNPJ inválido.");
            }

            var fornecedor = listaFornecedor.FirstOrDefault(f => f.CNPJ == cnpj);

            if (fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado.");
            }

            fornecedor.Codigo = dto.Codigo;
            fornecedor.Nome = dto.Nome ?? fornecedor.Nome;
            fornecedor.Telefone = dto.Telefone ?? fornecedor.Telefone;
            fornecedor.Email = dto.Email ?? fornecedor.Email;
            fornecedor.Endereco = dto.Endereco ?? fornecedor.Endereco;
            fornecedor.Cep = dto.Cep ?? fornecedor.Cep;
            fornecedor.Rua = dto.Rua ?? fornecedor.Rua;
            fornecedor.Bairro = dto.Bairro ?? fornecedor.Bairro;
            fornecedor.Numero = dto.Numero ?? fornecedor.Numero;
            fornecedor.Produto = dto.Produto ?? fornecedor.Produto;

            return Ok("Fornecedor atualizado!");
        }

        [HttpDelete("{cnpj}")]
        public IActionResult Delete(string cnpj)
        {
            if (!ValidarCNPJ(cnpj))
            {
                return BadRequest("CNPJ inválido.");
            }

            var fornecedor = listaFornecedor.FirstOrDefault(f => f.CNPJ == cnpj);

            if (fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado.");
            }

            listaFornecedor.Remove(fornecedor);

            return Ok("Fornecedor removido!");
        }
    }
}
