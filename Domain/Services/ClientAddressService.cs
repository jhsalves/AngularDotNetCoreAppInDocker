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
    public class ClientAddressService : ServiceBase<ClientAddress>, IClientAddressService
    {
        private readonly IClientAddressRepository _clientRepository;

        public ClientAddressService(IClientAddressRepository clientRepository) : base(clientRepository)
        {
            _clientRepository = clientRepository;  
        }

        public async Task HardUpdate(int clientId, IEnumerable<ClientAddress> clientAddresses)
        {
           await _clientRepository.HardUpdate(clientId, clientAddresses);
        }
    }
}
