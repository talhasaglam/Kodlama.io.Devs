using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataSeeder
{
    public static class DataSeederServiceProvider
    {
        public static IServiceProvider DataSeed(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                //services.GetRequiredService<BrandDataSeeder>();
                var contexting = services.GetRequiredService<DataSeederContributor>();

                if (contexting is not null)
                     contexting.SeedAsync().Wait();
            }

            return serviceProvider;
        }
    }
}
