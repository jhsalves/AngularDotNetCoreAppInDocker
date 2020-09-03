using clients.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Entities = clients.Api.Entities;

namespace clients.Api.Data
{
    public class ClientsContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAddress> ClientAddresses { get; set; }

        public ClientsContext(DbContextOptions<ClientsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder moodelbuilder)
        {
            moodelbuilder.Entity<Client>()
                        .HasKey(x => x.Id);

            moodelbuilder.Entity<Client>().HasMany(x => x.ClientAddresses)
            .WithOne(x => x.Client)
            .HasForeignKey(x => x.ClientId);

            moodelbuilder.Entity<ClientAddress>()
                        .HasKey(x => x.Id);
                        
            moodelbuilder.Entity<ClientAddress>()
            .HasOne(x => x.Client)
            .WithMany(x => x.ClientAddresses)
            .HasForeignKey(x => x.ClientId);
        }
    }
}