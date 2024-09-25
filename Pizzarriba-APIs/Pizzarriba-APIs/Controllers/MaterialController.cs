using Microsoft.AspNetCore.Mvc;
using MaterialApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MaterialApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private static List<Material> materials = new List<Material>();
        private static int currentId = 1;

        [HttpPost]
        public IActionResult AdicionarMaterial([FromBody] Material novoMaterial)
        {
            novoMaterial.Id = currentId++;
            materials.Add(novoMaterial);
            return CreatedAtAction(nameof(ConsultarMaterial), new { id = novoMaterial.Id }, novoMaterial);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Material>> ConsultarMateriais()
        {
            return Ok(materials);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarMaterial(int id)
        {
            var material = materials.FirstOrDefault(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }
            return Ok(material);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarMaterial(int id, [FromBody] Material materialAtualizado)
        {
            var material = materials.FirstOrDefault(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            material.Id = materialAtualizado.Id;
            material.Nome = materialAtualizado.Nome;
            material.Medida = materialAtualizado.Medida;
            material.Quantidade = materialAtualizado.Quantidade;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirMaterial(int id)
        {
            var material = materials.FirstOrDefault(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }
            materials.Remove(material);
            return NoContent();
        }
    }
}

