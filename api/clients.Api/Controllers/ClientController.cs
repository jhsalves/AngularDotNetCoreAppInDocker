using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Data.Contexts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clients.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        [HttpGet("{id}")]
        public Client Get(int id) =>
            _clientAppService.GetById(id);

        [HttpGet]
        public IEnumerable<Client> GetList() =>
            _clientAppService
                     .GetAll(x => x.ClientAddresses)
                     .ToList();

        [HttpPost]
        public IActionResult Post(Client client)
        {
            _clientAppService.Add(client);
            return CreatedAtAction(nameof(Post), client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Client client){
            if(client.Id == 0 || id != client.Id){
                return BadRequest();
            }

            await _clientAppService.Update(client);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            _clientAppService.Remove(_clientAppService.GetById(id));
            return Ok();
        }
    }
}