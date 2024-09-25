using Microsoft.AspNetCore.Mvc;
using Pizzarriba_APIs.DTOs;
using Pizzarriba_APIs.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pizzarriba_APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
       
        private static List<Produto> produtos = new List<Produto>();
        private static int nextId = 1;

       
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }
            return Ok(produto);
        }

      
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
            {
                return BadRequest("Produto inválido.");
            }

            var novoProduto = new Produto
            {
                Id = nextId++,
                Nome = produtoDto.Nome,
                Preco = produtoDto.Preco,
                Descricao = produtoDto.Descricao
            };

            produtos.Add(novoProduto);
            return Ok(novoProduto);
        }

     
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProdutoDTO produtoDto)
        {
            var produtoExistente = produtos.FirstOrDefault(p => p.Id == id);
            if (produtoExistente == null)
            {
                return NotFound("Produto não encontrado.");
            }

            produtoExistente.Nome = produtoDto.Nome;
            produtoExistente.Preco = produtoDto.Preco;
            produtoExistente.Descricao = produtoDto.Descricao;

            return Ok(produtoExistente);
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            produtos.Remove(produto);
            return Ok("Produto removido com sucesso.");
        }
    }
}
