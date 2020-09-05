using Application;
using Application.Interface;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clients.Api
{
    public static class DependencyInjection
    {
        public static void RegisterDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IClientAppService, ClientAppService>();
            serviceCollection.AddScoped<IClientAddressAppService, ClientAddressAppService>();

            serviceCollection.AddScoped<IClientService, ClientService>();
            serviceCollection.AddScoped<IClientAddressService, ClientAddressService>();

            serviceCollection.AddScoped<IClientRepository, ClientRepository>();
            serviceCollection.AddScoped<IClientAddressRepository, ClientAddressRepository>();
        }
    }
}
