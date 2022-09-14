using JwtAuthDemo.Data;
using JwtAuthDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirementController : ControllerBase
    {
        private readonly DataContext _context;
        public VirementController(DataContext dataContext)
        {
            _context = dataContext;
        }
        // GET: api/<VirementController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Virements.ToList());
        }

        // GET api/<VirementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VirementController>
        [HttpPost("{id}")]
        public IActionResult Post([FromBody] VirementRequest virementRequest,int id)
        {
            Client client = _context.Client.Find(id);
            Virement virement = new Virement();
            virement.compteACrediter = virementRequest.numeroCompte;
            virement.compteDebiteur = client.NumeroCompte;
            virement.motif = virementRequest.motif;
            virement.montant = virementRequest.montant;
            _context.Virements.Add(virement);
            _context.SaveChanges();
            addSolde(id, virementRequest.montant);
            return Ok(new {
                message = "virement a ete effectue avec succes"
            });
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public void addSolde(int id, int montant)
        {
            Client client = _context.Client.Find(id);
            Solde solde = new Solde();
            solde.client = client;
            solde.montantVerse = montant;
            solde.montantRetire = -montant;
            solde.operation = "virement";
            solde.date = DateTime.Now;
            _context.Soldes.Add(solde);
            _context.SaveChanges();
        }

        // PUT api/<VirementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VirementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class VirementRequest
    {
        [Required]
        [JsonPropertyName("montant")]
        public int montant { get; set; }

        [Required]
        [JsonPropertyName("numeroCompte")]
        public int numeroCompte { get; set; }

        [Required]
        [JsonPropertyName("motif")]
        public string motif { get; set; }
    }
}
