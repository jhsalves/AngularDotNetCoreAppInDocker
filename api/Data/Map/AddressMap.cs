using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Map
{
    class AddressMap : IEntityTypeConfiguration<ClientAddress>
    {
        public void Configure(EntityTypeBuilder<ClientAddress> builder)
        {
            builder
            .HasKey(x => x.Id);

            builder
            .HasOne(x => x.Client)
            .WithMany(x => x.ClientAddresses)
            .HasForeignKey(x => x.ClientId);
        }
    }
}
