using FuncionarioAPI.Models;
using FuncionarioAPI.Repositories;
using jenesepais.Recursos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FuncionarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        List<Funcionario> ListFunc = new List<Funcionario>();

        public FuncionarioController()
        {
            var funcionario = new Funcionario() 
            {
                Nome = "Giovanna",
                ID = "390239",
                Email = "gio@gmail.com",
                Telefone = "320903293",
                CPF = "320903293",
                RG = "320903293",
                PISNIT = "320903293",
                OrgaoEmissorRG = "320903293",
                Cargo = "320903293",
                Endereco = "320903293",
                Rua = "320903293",
                Numero = "320903293",
                Bairro = "320903293",
                Cidade = "saipjas",
                Complemento = "sdfsfsd",

            };
            ListFunc.Add(funcionario);
        }

        [HttpGet]
        public IActionResult ListarFuncionarios()
        {
            return Ok(ListFunc);
        }

        [HttpGet("{cpf}")]
        public IActionResult VisualizarFuncionario(string cpf)
        {
            var funcionario = ListFunc.FirstOrDefault(f => f.CPF == cpf);
            if (funcionario == null)
                return NotFound(new { message = "Funcionário não encontrado" });

            return Ok(funcionario);
        }

        [HttpPost]
        public IActionResult CriarFuncionario([FromBody] Funcionario novoFuncionario)
        {
            var funcionario = new Funcionario();

            funcionario.Nome = novoFuncionario.Nome;
            funcionario.ID = novoFuncionario.ID;
            funcionario.Email = novoFuncionario.Email;
            funcionario.Telefone = novoFuncionario.Telefone;
            funcionario.CPF = novoFuncionario.CPF;
            funcionario.RG = novoFuncionario.RG;
            funcionario.PISNIT = novoFuncionario.PISNIT;
            funcionario.OrgaoEmissorRG = novoFuncionario.OrgaoEmissorRG;
            funcionario.Cargo = novoFuncionario.Cargo;
            funcionario.Endereco = novoFuncionario.Endereco;
            funcionario.Rua = novoFuncionario.Rua;
            funcionario.Numero = novoFuncionario.Numero;
            funcionario.Bairro = novoFuncionario.Bairro;
            funcionario.Cidade = novoFuncionario.Cidade;
            funcionario.Complemento = novoFuncionario.Complemento;


            if (ValidadorCPF.ValidaCPF(funcionario.CPF) == true)
            {
                funcionario.Nome = novoFuncionario.Nome;
                funcionario.ID = novoFuncionario.ID;
                funcionario.Email = novoFuncionario.Email;
                funcionario.Telefone = novoFuncionario.Telefone;
                funcionario.CPF = novoFuncionario.CPF;
                funcionario.RG = novoFuncionario.RG;
                funcionario.PISNIT = novoFuncionario.PISNIT;
                funcionario.OrgaoEmissorRG = novoFuncionario.OrgaoEmissorRG;
                funcionario.Cargo = novoFuncionario.Cargo;
                funcionario.Endereco = novoFuncionario.Endereco;
                funcionario.Rua = novoFuncionario.Rua;
                funcionario.Numero = novoFuncionario.Numero;
                funcionario.Bairro = novoFuncionario.Bairro;
                funcionario.Cidade = novoFuncionario.Cidade;
                funcionario.Complemento = novoFuncionario.Complemento;

                ListFunc.Add(funcionario);
              

                return StatusCode(StatusCodes.Status201Created, funcionario);
            }
            else
            {
                return BadRequest("CPF Inválido.");
            }
        }

        [HttpPut("{cpf}")]
        public IActionResult AtualizarFuncionario(string Id, [FromBody] Funcionario funcionarioAtualizado)
        {
            var funcionario = ListFunc.Where(item => item.ID == Id).FirstOrDefault();

            if (funcionario == null)
            {
                return BadRequest("Funcionario não encontrado.");
            }

            funcionario.Nome = funcionarioAtualizado.Nome;
            funcionario.ID = funcionarioAtualizado.ID;
            funcionario.Email = funcionarioAtualizado.Email;
            funcionario.Telefone = funcionarioAtualizado.Telefone;
            funcionario.CPF = funcionarioAtualizado.CPF;
            funcionario.RG = funcionarioAtualizado.RG;
            funcionario.PISNIT = funcionarioAtualizado.PISNIT;
            funcionario.OrgaoEmissorRG = funcionarioAtualizado.OrgaoEmissorRG;
            funcionario.Cargo = funcionarioAtualizado.Cargo;
            funcionario.Endereco = funcionarioAtualizado.Endereco;
            funcionario.Rua = funcionarioAtualizado.Rua;
            funcionario.Numero = funcionarioAtualizado.Numero;
            funcionario.Bairro = funcionarioAtualizado.Bairro;
            funcionario.Cidade = funcionarioAtualizado.Cidade;
           
            if (ValidadorCPF.ValidaCPF(funcionario.CPF) == true)
                return BadRequest(new { message = "CPF inválido" });

            funcionario.Nome = funcionarioAtualizado.Nome;
            funcionario.ID = funcionarioAtualizado.ID;
            funcionario.Email = funcionarioAtualizado.Email;
            funcionario.Telefone = funcionarioAtualizado.Telefone;
            funcionario.CPF = funcionarioAtualizado.CPF;
            funcionario.RG = funcionarioAtualizado.RG;
            funcionario.PISNIT = funcionarioAtualizado.PISNIT;
            funcionario.OrgaoEmissorRG = funcionarioAtualizado.OrgaoEmissorRG;
            funcionario.Cargo = funcionarioAtualizado.Cargo;
            funcionario.Endereco = funcionarioAtualizado.Endereco;
            funcionario.Rua = funcionarioAtualizado.Rua;
            funcionario.Numero = funcionarioAtualizado.Numero;
            funcionario.Bairro = funcionarioAtualizado.Bairro;
            funcionario.Cidade = funcionarioAtualizado.Cidade;

            ListFunc.Add(funcionario);
            return Ok(funcionario);
        }

        [HttpDelete("{ID}")]
        public IActionResult ExcluirFuncionario(string ID)
        {
            var funcionario = ListFunc.Where(f => f.ID == ID).FirstOrDefault();

            if (funcionario == null)
            {
                return BadRequest("Funcionario não encontrado.");
            }

            ListFunc.Remove(funcionario);

            return Ok(funcionario);
        }
    }
}
