using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IClientService : IServiceBase<Client>
    {
        bool Remove(int id);
        new Task Update(Client client);
    }
}
