using Data.Contexts;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Linq;

namespace Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {

        public ClientRepository(ClientsContext db) : base(db)
        {

        }

        public override Client GetById(int id)
        {
            return GetAll(x => x.ClientAddresses)
                        .FirstOrDefault(x => x.Id == id);
        }

        public bool Remove(int id)
        {
            var client = GetById(id);
            if (client == null)
            {
                return false;
            }
            Remove(client);
            return true;
        }
    }
}
