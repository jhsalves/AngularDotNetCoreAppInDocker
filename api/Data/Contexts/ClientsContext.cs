using Data.Map;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class ClientsContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAddress> ClientAddresses { get; set; }

        public ClientsContext(DbContextOptions<ClientsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
        }
    }
}
