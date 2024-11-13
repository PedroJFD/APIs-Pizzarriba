using Microsoft.AspNetCore.Mvc;
using MaterialApi.Models;
using Pizzarriba_APIs.DTOs;

namespace MaterialApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private List<Material> materials = new MaterialDAO().List();

        [HttpGet]
        public IActionResult List()
        {
            return Ok(materials);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarMaterial(int id)
        {
            var material = materials.FirstOrDefault(item => item.Id == id);
            if (material == null)
            {
                return NotFound("Material não encontrado."); 
            }
            return Ok(material);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MaterialDTO item)
        {
            var material = new Material();
            int ultimoId = materials.LastOrDefault()?.Id ?? 0;
            material.Id = ultimoId + 1;
            material.Codigo = item.Codigo;
            material.Nome = item.Nome;
            material.Medida = item.Medida;
            material.Quantidade = item.Quantidade;

            try
            {
                var dao = new MaterialDAO();
                material.Id = dao.Insert(material);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return StatusCode(StatusCodes.Status201Created, "Material registrado com sucesso!");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarMaterial(int id, [FromBody] Material materialAtualizado)
        {
            if (materialAtualizado == null || !ModelState.IsValid)
            {
                return BadRequest("Dados inválidos.");
            }

            var material = materials.FirstOrDefault(m => m.Id == id);
            if (material == null)
            {
                return NotFound("Material não encontrado.");
            }

            material.Nome = materialAtualizado.Nome;
            material.Medida = materialAtualizado.Medida;
            material.Quantidade = materialAtualizado.Quantidade;

            return Ok("Material atualizado!");
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirMaterial(int id)
        {
            var material = materials.FirstOrDefault(m => m.Id == id);
            if (material == null)
            {
                return NotFound("Material não encontrado.");
            }

            materials.Remove(material);
            return Ok("Material removido!");
        }
    }
}

