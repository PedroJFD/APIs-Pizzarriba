using FuncionarioAPI.Models;
using ANP___Atividade___Cliente.Recursos;
using Microsoft.AspNetCore.Mvc;
using Pizzarriba_APIs.Dtos;
using ANP___Atividade___Funcionario.Models;

namespace FuncionarioAPI.Controllers
{
    [ApiController]
    [Route("Funcionario")]
    public class FuncionarioController : ControllerBase
    {
        List<Funcionario> ListaFuncionarios = new FuncionarioDAO().List();

        [HttpGet]
        public IActionResult ListarFuncionarios()
        {
            return Ok(ListaFuncionarios);
        }

        [HttpGet("{CPF}")]
        public IActionResult VisualizarFuncionario(string cpf)
        {
            var funcionario = ListaFuncionarios.FirstOrDefault(item => item.CPF == cpf);

            if (funcionario == null)
            {
                return NotFound("Funcionario não encontrado.");
            }

            return Ok(funcionario);
        }

        [HttpPost]
        public IActionResult CriarFuncionario([FromBody] Funcionario novoFuncionario)
        {
            var funcionario = new Funcionario();

            funcionario.Nome = novoFuncionario.Nome;
            int ultimoId = ListaFuncionarios.LastOrDefault()?.ID ?? 0;
            funcionario.ID = ultimoId + 1;
            funcionario.Codigo = novoFuncionario.Codigo;
            funcionario.Email = novoFuncionario.Email;
            funcionario.Telefone = novoFuncionario.Telefone;
            funcionario.CPF = novoFuncionario.CPF;

            if (ValidadorCPF.ValidaCPF(funcionario.CPF) == true)
            {
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

                ListaFuncionarios.Add(funcionario);

                try
                {
                    var dao = new FuncionarioDAO();
                    funcionario.ID = dao.Insert(funcionario);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return StatusCode(StatusCodes.Status201Created, "Funcionario registrado com sucesso!");
            }
            else
            { return BadRequest("CPF Inválido."); }
        }
    

        [HttpPut("{cpf}")]
        public IActionResult Put(int Id, [FromBody] FuncionarioDTO item)
        {
            var funcionario = ListaFuncionarios.Where(item => item.ID == Id).FirstOrDefault();

            if(funcionario == null)
            {
                return BadRequest("Funcionario não encontrado.");
            }

            funcionario.Nome = item.Nome;
            funcionario.Codigo = item.Codigo;
            funcionario.Email = item.Email;
            funcionario.Telefone = item.Telefone;
            funcionario.CPF = item.CPF;

            if (ValidadorCPF.ValidaCPF(funcionario.CPF) == true)
            {
                funcionario.CPF = item.CPF;
                funcionario.RG = item.RG;
                funcionario.PISNIT = item.PISNIT;
                funcionario.OrgaoEmissorRG = item.OrgaoEmissorRG;
                funcionario.Cargo = item.Cargo;
                funcionario.Endereco = item.Endereco;
                funcionario.Rua = item.Rua;
                funcionario.Numero = item.Numero;
                funcionario.Bairro = item.Bairro;
                funcionario.Cidade = item.Cidade;

                return Ok("Funcionario atualizado!");
            } else
            { return BadRequest("CPF Inválido. ");  }

                
        }
        [HttpDelete("{Id}")]
            public IActionResult Delete(int ID)
            {
                var funcionario = ListaFuncionarios.Where(item => item.ID == ID).FirstOrDefault();

                if (funcionario == null)
                {
                    return BadRequest("Funcionario não encontrado.");
                }

                ListaFuncionarios.Remove(funcionario);

                return Ok("Funcionario removido!");
            }
    }
}
