using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto;
using Core.Entidades;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;
        
        public CompaniaController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compania>>> GetCompanias()
        {
            var lista = await _db.Companias.ToListAsync();
            _response.Resultado = lista;
            _response.Mensaje = "Listado de companias";
            return Ok(_response);
        }
        [HttpGet("{id}", Name="GetCompania")]
        public async Task<ActionResult<Compania>> GetCompania(int id)
        {
            var compania = await _db.Companias.FindAsync(id);
            _response.Resultado = compania;
            _response.Mensaje = "Datos de la compania" + compania.Id;
            return Ok(_response); // Status code 200
        }

        [HttpPost]
        public async Task<ActionResult<Compania>> PostCompania([FromBody] Compania compania)
        {
            await _db.Companias.AddAsync(compania);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetCompania", new {id = compania.Id}, compania); // Status code 201
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCompania(int id, [FromBody] Compania compania)
        {
            if (id != compania.Id)
            {
                return BadRequest("Id de compania no coincide");
            }
            _db.Update(compania);
            await _db.SaveChangesAsync();
            return Ok(compania);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompania(int id)
        {
            var compania = await _db.Companias.FindAsync(id);
            if (compania == null)
            {
                return NotFound();
            }
            _db.Companias.Remove(compania);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}