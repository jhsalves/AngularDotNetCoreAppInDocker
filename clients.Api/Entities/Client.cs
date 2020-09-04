using System;
using System.Collections.Generic;

namespace clients.Api.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<ClientAddress> ClientAddresses { get; set; } = new List<ClientAddress>();
    }
}