using JwtAuthDemo.Data;
using JwtAuthDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfertController : ControllerBase
    {
        private readonly DataContext _context;
        public TransfertController(DataContext dataContext)
        {
            _context = dataContext;
        }
        // GET: api/<TransfertController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            List<Transfert> transferts = _context.Transferts.Include(x=>x.clientRecepteur).ToList();
            List<Object> trans = new List<object>();
            foreach (var obj in transferts)
            {
                trans.Add(
                new {
                    cin = obj.clientRecepteur.cin,
                    montant = obj.montant,
                    nom = obj.clientRecepteur.nom,
                    prenom = obj.clientRecepteur.prenom,
                    date = obj.date,
                });
            }
            return Ok(trans);
        }

        // GET api/<TransfertController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransfertController>
        [HttpPost("{id}")]
        public IActionResult Post([FromBody] TransfertRequest transfertRequest,int id)
        {
            List<Client> clients = _context.Client.ToList();
            var clientAcrediter = clients.Where(c => c.NumeroCompte == transfertRequest.numeroCompte).ToList();
            Client clientDebiteur = _context.Client.Find(id);
            Transfert transfert = new Transfert();
            transfert.clientDebiteur = clientDebiteur;
            transfert.clientRecepteur = clientAcrediter[0];
            transfert.montant = transfertRequest.montant;
            transfert.date = DateTime.Now;
            clientDebiteur.solde = clientDebiteur.solde - transfertRequest.montant;
            clientAcrediter[0].solde = clientAcrediter[0].solde + transfertRequest.montant;
            _context.Client.Update(clientDebiteur);
            _context.Client.Update(clientAcrediter[0]);
            _context.Transferts.Add(transfert);
            addSolde(id,transfertRequest.montant);
            _context.SaveChanges();
            
            return Ok(new {message = "transfert a ete etablie"});

        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public void addSolde(int id,int montant)
        {
            Client client = _context.Client.Find(id);
            Solde solde = new Solde();
            solde.client = client;
            solde.montantVerse = montant;
            solde.montantRetire = -montant;
            solde.operation = "transfert";
            solde.date = DateTime.Now;
            _context.Soldes.Add(solde);
            
        }

        // PUT api/<TransfertController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransfertController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class TransfertRequest
    {
        [Required]
        [JsonPropertyName("montant")]
        public int montant { get; set; }

        [Required]
        [JsonPropertyName("numeroCompte")]
        public int numeroCompte { get; set; }
    }
}
