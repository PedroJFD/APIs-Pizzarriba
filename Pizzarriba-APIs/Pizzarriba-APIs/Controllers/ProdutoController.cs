using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ANP___Atividade___Cliente.Models;
using ANP___Atividade___Cliente.Recursos;
using ANP___Atividade___Cliente.Dtos;
using System.Xml;
using System.Xml.Linq;
using System.Reflection.PortableExecutable;
using System.Xml.Serialization;
using static ANP___Atividade___Cliente.Models.Cliente;

namespace ANP___Atividade___Cliente.Controllers
{
    [Route("Produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        List<Cliente> listaProdutos = new ProdutoDAO().List();

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

            produto.Id = item.Id;
            produto.Nome = item.Nome;
            produto.Preco = item.Preco;
            produto.Descricao = item.Descricao;

        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] ClienteDTO item)
        {
            var cliente = listaClientes.Where(item => item.Id == Id).FirstOrDefault();

            if (cliente == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            cliente.Nome = item.Nome;
            cliente.Sexo = item.Sexo;
            cliente.Cpf = item.Cpf;

            if (ValidadorCPF.ValidaCPF(cliente.Cpf) == true)
            {
                cliente.Telefone = item.Telefone;
                cliente.Email = item.Email;
                cliente.Rua = item.Rua;
                cliente.Bairro = item.Bairro;
                cliente.Numero = item.Numero;
                cliente.Cidade = item.Cidade;
                cliente.Complemento = item.Complemento;

                return Ok(cliente);
            }
            else
            {
                return BadRequest("CPF Inválido.");
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var cliente = listaClientes.Where(item => item.Id == Id).FirstOrDefault();

            if (cliente == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            listaClientes.Remove(cliente);

            return Ok(cliente);
        }
    }
}
