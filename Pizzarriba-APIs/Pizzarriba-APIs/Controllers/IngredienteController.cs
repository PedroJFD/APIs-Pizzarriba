using IngredienteAPI.Dtos;
using IngredienteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Pizzarriba_APIs.Models;
namespace IngredienteAPI.Controllers
{
    [Route("ingrediente")]
    [ApiController]
    public class IngredController : ControllerBase
    {
        List<Ingrediente> listIngredientes = new List<Ingrediente>();


        [HttpGet]
        public IActionResult List()
        {
            return Ok(listIngredientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ingredientes = listIngredientes.FirstOrDefault(item => item.Id == id);

            if (ingredientes == null)
            {
                return NotFound("Ingrediente não encontrado.");
            }

            return Ok(ingredientes);
        }
        [HttpPost]
        public IActionResult Post([FromBody] IngredDTO item)
        {
            var ingredientes = new Ingrediente();

            int ultimoId = listIngredientes.LastOrDefault()?.Id ?? 0;
            ingredientes.Id = ultimoId + 1;
            ingredientes.Codigo = item.Codigo;
            ingredientes.Nome = item.Nome;
            ingredientes.Medida = item.Medida;
            ingredientes.Quantidade = item.Quantidade;

            listIngredientes.Add(ingredientes);

            try
            {
                var dao = new IngredienteDAO();
                ingredientes.Id = dao.Insert(ingredientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, "Ingrediente registrado com sucesso!");
        }




        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] IngredDTO item)
        {
            var ingredientes = listIngredientes.Where(item => item.Id == Id).FirstOrDefault();

            if (ingredientes == null)
            {
                return BadRequest("Ingrediente não encontrado.");
            }

            ingredientes.Codigo = item.Codigo;
            ingredientes.Nome = item.Nome;
            ingredientes.Medida = item.Medida;
            ingredientes.Quantidade = item.Quantidade;

            return Ok("Ingrediente Atualizado!");

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var ingredientes = listIngredientes.Where(item => item.Id == Id).FirstOrDefault();

            if (ingredientes == null)
            {
                return BadRequest("Ingrediente não encontrado.");
            }

            listIngredientes.Remove(ingredientes);

            return Ok("Ingrediente Removido!");
        }
    }
}