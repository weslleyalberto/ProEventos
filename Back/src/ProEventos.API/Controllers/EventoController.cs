
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        
        public EventoController()
        {

        }
        public IEnumerable<Evento> evento = new Evento[]{
             new Evento(){
                    EventoId =1,
                Tema = "Angular e .NET5",
                Local = "Belo Horizonte",
                Lote = "1º Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemUrl = "Foto.png"
               },
                new Evento(){
                    EventoId =2,
                Tema = "Angular e sua novidades",
                Local = "São Paulo",
                Lote = "2º Lote",
                QtdPessoas = 300,
                DataEvento = DateTime.Now.AddHours(2).ToString("dd/MM/yyyy"),
                ImagemUrl = "Foto2.png"
               }
        };




        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return evento;
        }
        [HttpGet("{id}")]
        public Evento GetById(int id){
            return  evento.FirstOrDefault(x=> x.EventoId == id);
          
               
          
        }
        [HttpPost]
        public string Post(){
            return "Exemplo post";
        }
        [HttpPut("{id}")]
        public string Put(int id){
            return $"Exemplo de Put com id = {id}";
        }
        [HttpDelete("{id}")]
        public string Delete(int id){
            return $"Exemplo de delete com id={id}";
        }
    }
}
