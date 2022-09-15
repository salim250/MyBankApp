using JwtAuthDemo.Data;
using JwtAuthDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandeChequierController : ControllerBase
    {
        private readonly DataContext _context;
        public DemandeChequierController(DataContext dataContext)
        {
            _context = dataContext;
        }
        // GET: api/<DemandeChequierController>
        [HttpGet]
        public IActionResult Get()
        {
            List<DemandeChequier> demande = _context.DemandeChequiers.Include(x => x.client)
                
                .ToList();
            List<Object> dem = new List<object>();
            foreach (var obj in demande)
            {
                dem.Add(
                    new {
                        id = obj.Id,
                        numero = obj.client.NumeroCompte,
                        nombre = obj.nombre,
                        etat = obj.etat,
                        date = obj.dateDemande,
                    });
            }
            return Ok(dem);
        }

        // GET api/<DemandeChequierController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.DemandeChequiers.Find(id));
        }

        // POST api/<DemandeChequierController>
        [HttpPost("{id}")]
        public IActionResult Post([FromBody] string nombre,int id)
        {
            DemandeChequier demandeChequier = new DemandeChequier();
            demandeChequier.client = _context.Client.Find(id);
            demandeChequier.dateDemande = DateTime.Now;
            demandeChequier.etat = "En attente";
            demandeChequier.nombre = Int32.Parse(nombre);
            _context.DemandeChequiers.Add(demandeChequier);
            _context.SaveChanges();
            return Ok(new {message = "la demande est cree avec succes"});
        }

        // PUT api/<DemandeChequierController>/5
        [HttpPut("{id}")]
        [AllowAnonymous]
        public IActionResult Put(int id, [FromBody] string etat)
        {
            DemandeChequier demandeChequier = _context.DemandeChequiers.Find(id);
            demandeChequier.etat = etat;
            _context.DemandeChequiers.Update(demandeChequier);
            _context.SaveChanges();
            return Ok(new {message = "etat est modifie avec succes"});
        }

        // DELETE api/<DemandeChequierController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.DemandeChequiers.Remove(_context.DemandeChequiers.Find(id));
            _context.SaveChanges();
            return Ok("demande supprime avec succes");
        }
    }
}
