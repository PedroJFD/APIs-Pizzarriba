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
using MySqlX.XDevAPI;

namespace ANP___Atividade___Cliente.Controllers
{
    [Route("Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        List<Cliente> listaClientes = new ClienteDAO().List();

        [HttpGet]
        public IActionResult List()
        {
            return Ok(listaClientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = listaClientes.FirstOrDefault(item => item.Id == id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return Ok(cliente);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ClienteDTO item)
        {
            var cliente = new Cliente();
            int ultimoId = listaClientes.LastOrDefault()?.Id ?? 0;
            cliente.Id = ultimoId + 1;
            cliente.Codigo = item.Codigo;
            cliente.Nome = item.Nome;
            cliente.Sexo = item.Sexo;
            cliente.Cpf = item.Cpf;

            if (ValidadorCPF.ValidaCPF(cliente.Cpf))
            {
                cliente.Telefone = item.Telefone;
                cliente.Email = item.Email;
                cliente.Rua = item.Rua;
                cliente.Bairro = item.Bairro;
                cliente.Numero = item.Numero;
                cliente.Cidade = item.Cidade;
                cliente.Complemento = item.Complemento;

                listaClientes.Add(cliente);

                try
                {
                    var dao = new ClienteDAO();
                    cliente.Id = dao.Insert(cliente); 
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return StatusCode(StatusCodes.Status201Created, "Cliente registrado com sucesso!");
            }
            else
            {
                return BadRequest("CPF Inválido.");
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] ClienteDTO item)
        {
            var cliente = listaClientes.Where(item => item.Id == Id).FirstOrDefault();

            if (cliente == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            cliente.Codigo = item.Codigo;
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

                return Ok("Cliente Atualizado!");
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

            return Ok("Cliente removido!");
        }
    }
}
