using ApiSeguidores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSeguidores.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguidoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeguidoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seguidor>>> Get()
        {
            return await _context.Seguidores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seguidor>> GetById(int id)
        {
            var seguidor = await _context.Seguidores.FindAsync(id);
            if (seguidor == null) return NotFound();
            return seguidor;
        }

        // POST - Id gerenciado pelo banco
        [HttpPost]
        public async Task<ActionResult<Seguidor>> Create(CreateSeguidorDto dto)
        {
            var seguidor = new Seguidor
            {
                Nome = dto.Nome,
                Idade = dto.Idade,
                Hora = dto.Hora
            };

            _context.Seguidores.Add(seguidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = seguidor.Id }, seguidor);
        }

        // PUT - Id vem só pela URL
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSeguidorDto dto)
        {
            var seguidor = await _context.Seguidores.FindAsync(id);
            if (seguidor == null) return NotFound();

            seguidor.Nome = dto.Nome;
            seguidor.Idade = dto.Idade;
            seguidor.Hora = dto.Hora;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var seguidor = await _context.Seguidores.FindAsync(id);
            if (seguidor == null) return NotFound();

            _context.Seguidores.Remove(seguidor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
