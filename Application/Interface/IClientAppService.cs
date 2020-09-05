using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IClientAppService : IAppServiceBase<Client>
    {
        IEnumerable<Client> ObterClientesEspeciais();
        Task Update(Client client);
    }
}
