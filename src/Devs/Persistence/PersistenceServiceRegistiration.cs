using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.DataSeeder;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistiration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                        IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("RentACarCampConnectionString")));
            services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();

            var dataSeeder = bool.Parse(configuration["DbOptions:DataSeeder"]);
            if (dataSeeder)
                AddDataSeederServices(services);

            return services;
        }

        public static void AddDataSeederServices(IServiceCollection services)
        {
            services.AddScoped<ProgrammingLanguageDataSeeder>();
            services.AddScoped<DataSeederContributor>();
        }
    }
}
