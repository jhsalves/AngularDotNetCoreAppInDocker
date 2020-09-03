namespace clients.Api.Entities
{
    public class ClientAddress
    {
        public int Id { get; set; }
        public string AdressName  { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}