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
    public class ClientAdressController : ControllerBase
    {
        private readonly IClientAddressAppService _clientAdressAppService;

        public ClientAdressController(IClientAddressAppService clientAppService)
        {
            _clientAdressAppService = clientAppService;
        }

        [HttpGet("{id}")]
        public ClientAddress Get(int id) =>
            _clientAdressAppService.GetById(id);

        [HttpGet]
        public IEnumerable<ClientAddress> GetList() =>
            _clientAdressAppService
                     .GetAll(x => x.Client)
                     .ToList();

        [HttpPost]
        public IActionResult Post(ClientAddress client)
        {
            _clientAdressAppService.Add(client);
            return CreatedAtAction(nameof(Post), client);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ClientAddress client){
            if(client.Id == 0 || id != client.Id){
                return BadRequest();
            }

            _clientAdressAppService.Update(client);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            _clientAdressAppService.Remove(_clientAdressAppService.GetById(id));
            return Ok();
        }
    }
}