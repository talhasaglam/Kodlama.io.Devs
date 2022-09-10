using Application.Services.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataSeeder
{
    public class ProgrammingLanguageDataSeeder
    {
        private readonly IProgrammingLanguageRepository programmingLanguageRepo;
        public ProgrammingLanguageDataSeeder(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            programmingLanguageRepo = programmingLanguageRepository;
        }

        public async Task SeedAsync()
        {
            string[] brandEntitySeeds = { "C#","C++"};
            foreach (var item in brandEntitySeeds)
            {
                var brand = await programmingLanguageRepo.GetAsync(a => a.Name == item);
                if (brand == null)
                {
                   await programmingLanguageRepo.AddAsync(new ProgrammingLanguage { Name = item });
                }
            }
        }
    }
}
