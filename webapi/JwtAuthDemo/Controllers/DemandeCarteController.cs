using JwtAuthDemo.Data;
using JwtAuthDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandeCarteController : ControllerBase
    {
        private readonly DataContext _context;
        public DemandeCarteController(DataContext dataContext)
        {
            _context = dataContext;
        }
        // GET: api/<DemandeCarteController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.DemandeCartes.ToList());
        }

        // GET api/<DemandeCarteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.DemandeCartes.Find(id));
        }

        // POST api/<DemandeCarteController>
        [HttpPost("{id}")]
        public IActionResult Post([FromBody] string type,int id)
        {
            DemandeCarte demandeCarte = new DemandeCarte();
            demandeCarte.client = _context.Client.Find(id);
            demandeCarte.dateDemande = DateTime.Now;
            demandeCarte.etat = "En cours";
            demandeCarte.type = type;
            _context.DemandeCartes.Add(demandeCarte);
            _context.SaveChanges();
            return Ok(new {message = "la demande de type "+ demandeCarte.type +" est cree avec succes"});
        }

        // PUT api/<DemandeCarteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string etat)
        {
            DemandeCarte demandeCarte = _context.DemandeCartes.Find(id);
            demandeCarte.etat = etat;
            _context.DemandeCartes.Update(demandeCarte);
            _context.SaveChanges();
            return Ok(new {message = "etat est modifie avec succes"});
        }

        // DELETE api/<DemandeCarteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.DemandeCartes.Remove(_context.DemandeCartes.Find(id));
            _context.SaveChanges();
            return Ok("demande supprime avec succes");

        }
    }
}
