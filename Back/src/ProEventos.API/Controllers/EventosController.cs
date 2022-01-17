
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly DataContext _context;
        public EventosController(DataContext context)
        {
            _context = context;
        }
       




        [HttpGet]
        public async Task<IEnumerable<Evento>> Get()
        {
            return await _context.Eventos.AsNoTracking().ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<Evento> GetById(int id)
        {
            return await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);



        }
        [HttpPost]
        public async Task<ActionResult<Evento>> Post(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return Ok("Evento adicionado com sucesso");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Evento>> Put(int id,Evento evento)
        {
            if(id != evento.EventoId){
                return BadRequest("Evento id não encontrado!");
            }
           // Evento ev = await GetById(id); 
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Dados adicionados com sucesso");
        }
        [HttpDelete("{id}")]
            public async Task<ActionResult<Evento>> Delete(int id)
        {
            Evento ev = await GetById(id);
            if(ev is null){
                return NotFound("Evento não encontrado");
            }
            _context.Eventos.Remove(ev);
            await _context.SaveChangesAsync();
            return Ok($"Evento removido com sucesso. Nº Id evento: {id}");
        }
    }
}
