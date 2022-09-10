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
        public DataSeederContributor(ProgrammingLanguageDataSeeder brandDataSeeder)
        {
            this.programmingLanguageDataSeeder = brandDataSeeder;
        }

        public async Task SeedAsync()
        {
            await this.programmingLanguageDataSeeder.SeedAsync();
        }
    }


}
