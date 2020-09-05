using Data.Contexts;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ClientAddressRepository : RepositoryBase<ClientAddress>, IClientAddressRepository
    {
        public ClientAddressRepository(ClientsContext db) : base(db)
        {

        }
        public IEnumerable<ClientAddress> BuscarPorNome(string produto)
        {
            return Db.ClientAddresses;//.Where(x => x.Nome == produto);
        }

        public override void Update(ClientAddress client)
        {
            var produtoBase = GetById(client.Id);
            Db.Entry(produtoBase).CurrentValues.SetValues(client);
            base.Update(produtoBase);
        }

        public async Task HardUpdate(int clientId, IEnumerable<ClientAddress> clientAddresses)
        {
            Db.ClientAddresses.RemoveRange(Db.ClientAddresses.Where(x => x.ClientId == clientId));
            await Db.SaveChangesAsync();
            foreach (var address in clientAddresses)
            {
                address.ClientId = clientId;
                address.Id = 0;
                Db.ClientAddresses.Add(address);
            }

            await Db.SaveChangesAsync();
        }
    }
}
