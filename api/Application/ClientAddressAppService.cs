using Application.Interface;
using Domain.Entities;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Application
{
    public class ClientAddressAppService : AppServiceBase<ClientAddress>, IClientAddressAppService
    {
        public readonly IClientAddressService _clientAddressService;

        public ClientAddressAppService(IClientAddressService clientAddressService) 
            : base(clientAddressService)
        {
            _clientAddressService = clientAddressService;
        }

        public IEnumerable<ClientAddress> BuscaPorNome(string nome)
        {
            throw new System.NotImplementedException();
        }
    }
}
