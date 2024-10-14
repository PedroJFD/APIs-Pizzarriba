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
    [Route("Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        List<Cliente> ListaClientes = new List<Cliente>();

        [HttpGet]
        public IActionResult List()
        {
            List<Cliente> listaCliente = new ClienteDAO().List();

            return Ok(listaCliente);
        }
        [HttpGet("{Id}")]
        public IActionResult GetByed(int Id)
        {
            var cliente = ListaClientes.Where(item => item.Id == Id).FirstOrDefault();

            if (cliente == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            return Ok(cliente);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ClienteDTO item)
        {
            var cliente = new Cliente();

            cliente.Id = item.Id;
            cliente.Nome = item.Nome;
            cliente.Sexo = item.Sexo;
            cliente.Cpf = item.Cpf;

            if(ValidadorCPF.ValidaCPF(cliente.Cpf) == true)
            {  
                cliente.Telefone = item.Telefone;
                cliente.Email = item.Email;
                cliente.Rua = item.Rua;
                cliente.Bairro = item.Bairro;
                cliente.Numero = item.Numero;
                cliente.Cidade = item.Cidade;
                cliente.Complemento = item.Complemento;

                ListaClientes.Add(cliente);

                try
                {
                    var dao = new ClienteDAO();
                    cliente.Id = dao.Insert(cliente);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return StatusCode(StatusCodes.Status201Created, cliente);
            }
            else
            {
                return BadRequest("CPF Inválido.");
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] ClienteDTO item)
        {
            var cliente = ListaClientes.Where(item => item.Id == Id).FirstOrDefault();

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
            var cliente = ListaClientes.Where(item => item.Id == Id).FirstOrDefault();

            if (cliente == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            ListaClientes.Remove(cliente);

            return Ok(cliente);
        }
    }
}
