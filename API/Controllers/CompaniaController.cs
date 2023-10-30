using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public CompaniaController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compania>>> GetCompanias()
        {
            var lista = await _db.Companias.ToListAsync();
            return Ok(lista);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Compania>> GetCompania(int id)
        {
            var compania = await _db.Companias.FindAsync(id);
            return Ok(compania);
        }
    }
}