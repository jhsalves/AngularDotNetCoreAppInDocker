using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Contexts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Address.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdressController : ControllerBase
    {
        private readonly ClientsContext _db;

        public AdressController(ClientsContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ClientAddress> Get(int id) =>
            await _db.ClientAddresses.FirstOrDefaultAsync(x => x.Id == id);

        [HttpGet]
        public async Task<IEnumerable<ClientAddress>> GetList(int id) =>
            await _db.ClientAddresses
                     .Where(x => x.Id == id)
                     .ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Post(ClientAddress client)
        {
            _db.ClientAddresses.Add(client);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClientAddress client){
            if(client.Id == 0 || id != client.Id){
                return BadRequest();
            }

            _db.Entry(client).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var client = await _db.ClientAddresses.FirstOrDefaultAsync(x => x.Id == id);
            if(client == null){
                return NotFound();
            }
            _db.ClientAddresses.Remove(client);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}