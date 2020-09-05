using Application.Interface;
using Domain.Entities;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class ClientAppService : AppServiceBase<Client>,  IClientAppService
    {
        public readonly IClientService _clienteService;
        public ClientAppService(IClientService clienteService) : base(clienteService)
        {
            _clienteService = clienteService;
        }

        public new async Task Update(Client client)
        {
            await _clienteService.Update(client);
        }

        public IEnumerable<Client> ObterClientesEspeciais()
        {
            throw new System.NotImplementedException();
        }
    }
}
