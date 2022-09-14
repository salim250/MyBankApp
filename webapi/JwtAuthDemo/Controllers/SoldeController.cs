using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthDemo.Data;
using JwtAuthDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace JwtAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldeController : ControllerBase
    {
        private readonly DataContext _context;

        public SoldeController(DataContext dataContext)
        {
            _context = dataContext;
        }

        // GET: api/Solde
        [HttpGet]
        public List<Solde> Get()
        {
            return _context.Soldes.ToList();
        }

        // GET: api/Solde/5
        [HttpGet("{id}", Name = "Get")]
        [AllowAnonymous]
        public async Task<Object> Get(int id)
        {
            try
            {
                Client client = new Client();
                client = _context.Client.Find(id);

                var soldes = _context.Soldes.ToList().FindAll(x => x.client == client);
                
                return Ok(soldes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
        }

        // POST: api/Solde
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Solde/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Solde/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}