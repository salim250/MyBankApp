using JwtAuthDemo.Data;
using JwtAuthDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly DataContext _context;
        public ClientController(DataContext dataContext)
        {
            _context = dataContext;
        }
       
        [HttpGet]
        [Route("Get_All_Client")]
        [Authorize()]
        public async Task<IActionResult> Get_All_Client()
        {
            List<Client> clients = _context.Client.ToList();

            return Ok(clients);
        }

        [HttpPost]
        [Route("addclient")]
        [AllowAnonymous]
        public async Task<IActionResult> addClient([FromBody] Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
            return Ok(client);
        }

        [HttpGet]
        [Route("{id}")]
        
        public User clientById(int id)
        {
            var item = _context.User.FirstOrDefault(t => t.Id == id);
            /*if(item == null)
            {
                return NotFound();
            }*/
            
            return item;
        }

        [HttpDelete]
        [Route("{id}")]
        
        public async Task<IActionResult> DeleteClient(int id)
        {
            var item = _context.Client.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Client.Remove(item);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> updateClient(int id, [FromBody] Client client)
        {

            var item = _context.Client.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            item.Email = client.Email;
            item.nom = client.nom;
            item.prenom = client.prenom;
            _context.Client.Update(item);
            _context.SaveChanges();
            return Ok(item);
        }

    }
}
