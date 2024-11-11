using Microsoft.AspNetCore.Mvc;
using MaterialApi.Models;
using System.Collections.Generic;
using System.Linq;
using ANP___Atividade___Cliente.Models;
using Fornecedores;
using ANP___Atividade___Cliente.Dtos;
using ANP___Atividade___Cliente.Recursos;
using Pizzarriba_APIs.DTOs;
using MySqlX.XDevAPI;

namespace MaterialApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private List<Material> materials = new MaterialDAO().List();

        [HttpGet]
        public ActionResult<IEnumerable<Material>> ConsultarMateriais()
        {
            if (!materials.Any())
            {
                return NoContent();
            }
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
            if (item == null || !ModelState.IsValid) 
            {
                return BadRequest("Dados inválidos.");
            }

            var material = new Material
            {
                Id = item.Id, 
                Nome = item.Nome,
                Medida = item.Medida,
                Quantidade = item.Quantidade
            };

            try
            {
                var dao = new MaterialDAO();
                material.Id = dao.Insert(material); 

                return CreatedAtAction(nameof(ConsultarMaterial), new { id = material.Id }, material);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao inserir material: {ex.Message}");
            }
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

            return Ok(material);
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
            return Ok(material);
        }
    }
}

