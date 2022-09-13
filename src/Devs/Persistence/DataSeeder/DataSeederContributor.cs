using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataSeeder
{
    public class DataSeederContributor
    {
        private readonly ProgrammingLanguageDataSeeder programmingLanguageDataSeeder;
        private readonly TechnologyDataSeeder technologyDataSeeder;
        public DataSeederContributor(ProgrammingLanguageDataSeeder brandDataSeeder, TechnologyDataSeeder technologyDataSeeder)
        {
            this.programmingLanguageDataSeeder = brandDataSeeder;
            this.technologyDataSeeder = technologyDataSeeder;
        }

        public async Task SeedAsync()
        {
            await this.programmingLanguageDataSeeder.SeedAsync();
            await this.technologyDataSeeder.SeedAsync();
        }
    }


}
