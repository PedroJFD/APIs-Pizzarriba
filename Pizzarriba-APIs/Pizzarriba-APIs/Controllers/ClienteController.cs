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
        public ClienteController()
        {
            var cliente1 = new Cliente()
            {
                Id = 1,
                Nome = "Gonzalez",
                Sexo = "Homem",
                Cpf = "006.308.312-46",
                Telefone = "(69)99999-9999",
                Email = "email",
                Rua = "Rua",
                Bairro = "Bairro",
                Numero = "1",
                Cidade = "Jipa",
                Complemento = "Esquina"
            };
        }
        [HttpGet]
        public IActionResult List()
        {
            return Ok(ListaClientes);
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
