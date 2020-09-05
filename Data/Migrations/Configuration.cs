using Data.Contexts;

namespace Data.Migrations
{
    internal sealed class Configuration
    {
        public void Seed(ClientsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
