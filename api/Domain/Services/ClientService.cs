using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ClientService : ServiceBase<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientAddressService _clientAddressService;

        public ClientService(IClientRepository clientRepository,
                             IClientAddressService clientAddressService) : base(clientRepository)
        {
            _clientRepository = clientRepository;
            _clientAddressService = clientAddressService;
        }

        public new async Task Update(Client client)
        {
            var clientAddresses = client.ClientAddresses;
            client.ClientAddresses = null;
            base.Update(client);
            if (clientAddresses != null && clientAddresses.Any()) {
                await _clientAddressService.HardUpdate(client.Id, clientAddresses);
            }
        }

        public bool Remove(int id)
        {
            return _clientRepository.Remove(id);
        }
    }
}
