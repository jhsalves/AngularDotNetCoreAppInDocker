using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IClientAddressRepository : IRepositoryBase<ClientAddress>
    {
        Task HardUpdate(int clientId, IEnumerable<ClientAddress> clientAddresses);
    }
}
