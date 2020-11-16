using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AeroAPI.Model;
using AeroAPI.DTO;

namespace AeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VooController : ControllerBase
    {
        private readonly AeroContext _context;

        public VooController(AeroContext context)
        {
            _context = context;
        }

        // GET: api/Local
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(Convert(_context.Voos.ToList()));


        }

        [HttpGet("ComFiltro")]
        public ActionResult GetComFiltro([FromQuery] FiltroVooDTO filtro)
        {
            var listaParaRetornar = _context.Voos.Where(item => item.LocalDestinoId == filtro.DestinoId && item.LocalOrigemId == filtro.OrigemId && item.DataIda > filtro.DataInicial
            && item.DataIda <= filtro.DataFinal);
            return Ok(Convert(listaParaRetornar.ToList()));
        }

        private IEnumerable<dynamic> Convert(List<Voo> lista)
        {
            return lista.Select(item => new
            {
                item.Id,
                item.DataIda,
                item.DataVolta,
                item.LocalDestinoId,
                item.LocalOrigemId,
                item.NumeroParadas,
                item.Preco,
                PrecoComDesconto = item.Preco * 0.9
            });
        }

        // GET: api/Voo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voo>> GetVoo(int id)
        {
            var voo = await _context.Voos.FindAsync(id);

            if (voo == null)
            {
                return NotFound();
            }

            return voo;
        }

        // PUT: api/Voo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoo(int id, Voo voo)
        {
            if (id != voo.Id)
            {
                return BadRequest();
            }

            _context.Entry(voo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VooExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Voo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Voo>> PostVoo(Voo voo)
        {
            _context.Voos.Add(voo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoo", new { id = voo.Id }, voo);
        }

        // DELETE: api/Voo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Voo>> DeleteVoo(int id)
        {
            var voo = await _context.Voos.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }

            _context.Voos.Remove(voo);
            await _context.SaveChangesAsync();

            return voo;
        }

        private bool VooExists(int id)
        {
            return _context.Voos.Any(e => e.Id == id);
        }
    }
}