using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ANP___Atividade___Cliente.Models;
using ANP___Atividade___Cliente.Recursos;
using ANP___Atividade___Cliente.Dtos;
using Pizzarriba_APIs.DTOs;
using Pizzarriba_APIs.Models;
using MySqlX.XDevAPI;

namespace ANP___Atividade___Cliente.Controllers
{
    [Route("Produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        List<Produto> listaProdutos = new ProdutoDAO().List();
        int contadorID = 1;

        [HttpGet]
        public IActionResult List()
        {
            return Ok(listaProdutos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = listaProdutos.FirstOrDefault(item => item.Id == id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok(produto);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO item)
        {
            var produto = new Produto();

            int ultimoId = listaProdutos.LastOrDefault()?.Id ?? 0;
            produto.Id = ultimoId + 1;
            produto.Codigo = item.Codigo;
            produto.Nome = item.Nome;
            produto.Preco = item.Preco;
            produto.Descricao = item.Descricao;

            listaProdutos.Add(produto);

            try
            {
                var dao = new ProdutoDAO();
                produto.Id = dao.Insert(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, "Produto registrado com sucesso!");
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] ProdutoDTO item)
        {
            var produto = listaProdutos.Where(item => item.Id == Id).FirstOrDefault();

            if (produto == null)
            {
                return BadRequest("Produto não encontrado.");
            }

            produto.Codigo = item.Codigo;
            produto.Nome = item.Nome;
            produto.Preco = item.Preco;
            produto.Descricao = item.Descricao;

            return Ok("Produto Atualizado!");
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var cliente = listaProdutos.Where(item => item.Id == Id).FirstOrDefault();

            if (cliente == null)
            {
                return BadRequest("Produto não encontrado.");
            }

            listaProdutos.Remove(cliente);

            return Ok("Produto removido!");
        }
    }
}
