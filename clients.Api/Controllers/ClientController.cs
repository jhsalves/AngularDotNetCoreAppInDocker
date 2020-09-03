using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clients.Api.Data;
using clients.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clients.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientsContext _db;

        public ClientController(ClientsContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<Client> Get(int id) =>
            await _db.Clients.FirstOrDefaultAsync(x => x.Id == id);

        [HttpGet]
        public async Task<IEnumerable<Client>> GetList() =>
            await _db.Clients
                     .Include(x => x.ClientAddresses)
                     .ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Client client)
        {
            _db.Clients.Add(client);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Client client){
            if(client.Id == 0 || id != client.Id){
                return BadRequest();
            }

            _db.Entry(client).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var client = await _db.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if(client == null){
                return NotFound();
            }
            _db.Clients.Remove(client);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}