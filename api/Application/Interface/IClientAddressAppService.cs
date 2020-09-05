using Application.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IClientAddressAppService : IAppServiceBase<ClientAddress>
    {
        IEnumerable<ClientAddress> BuscaPorNome(string nome);
    }
}
