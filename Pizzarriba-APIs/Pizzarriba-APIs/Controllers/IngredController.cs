using IngredienteAPI.Dtos;
using IngredienteAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace IngredienteAPI.Controllers
{
    [Route("ingrediente")]
    [ApiController]
    public class IngredController : ControllerBase
    {
        List<Ingred> listIngred = new List<Ingred>();
        public IngredController()//criar
        {
            var ingred1 = new Ingred()
            {
                Id = 2321,
                Nome = "30/01/2007",
                Fornecedor =  "Cassiane",
                Medida = "Feminino",
                Quantidade = 3221
            };
            var ingred2 = new Ingred()
            {
                Id = 2321,
                Nome = "30/01/2007",
                Fornecedor = "Cassiane",
                Medida = "Feminino",
                Quantidade = 3221
            };
          
            listIngred.Add(ingred1);
            listIngred.Add(ingred2);
            
        }
        [HttpGet("")]//listar
        public IActionResult Get()
        {
            return Ok(listIngred);
        }

        [HttpGet("{id}")]//buscar com cpf
        public IActionResult GetByCpf(int id)
        {
            var ingred = listIngred.Where(item => item.Id == id).FirstOrDefault();
            return Ok(ingred);
        }

        [HttpPost]//criar
        public IActionResult Post([FromBody] Ingred item)
        {
            var ingred = new Ingred();

            ingred.Id = item.Id;
            ingred.Nome = item.Nome;
            ingred.Fornecedor = item.Fornecedor;
            ingred.Medida = item.Medida;
            ingred.Quantidade = item.Quantidade;
   
            listIngred.Add(ingred);
           
            return StatusCode(StatusCodes.Status201Created, ingred);

        }


        [HttpPut("{id}")]//atualizar

        public IActionResult Put(int id, [FromBody] IngredDTO item)
        {
            var ingred = listIngred.Where(item => item.Id == id).FirstOrDefault();

            if (ingred == null)
            {
                return NotFound();

            }

            ingred.Id = item.Id;
            ingred.Nome = item.Nome;
            ingred.Fornecedor = item.Fornecedor;
            ingred.Medida = item.Medida;
            ingred.Quantidade = item.Quantidade;

            return Ok(listIngred);

        }

        [HttpDelete("{id}")]//Deletar

        public IActionResult Delete(int id)
        {
            var ingred = listIngred.Where(item => item.Id == id).FirstOrDefault();

            if (ingred == null)
            {
                return NotFound();
            }

            listIngred.Remove(ingred);

            return Ok(ingred);
        }

    }
}
