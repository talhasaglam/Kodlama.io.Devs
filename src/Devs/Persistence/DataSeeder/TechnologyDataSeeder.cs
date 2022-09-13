using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataSeeder
{
    public class TechnologyDataSeeder
    {
        private readonly ITechnologyRepository technologyRepo;
        private readonly IProgrammingLanguageRepository programmingLanguageRepo;

        public TechnologyDataSeeder(ITechnologyRepository technologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            this.technologyRepo = technologyRepository;
            this.programmingLanguageRepo = programmingLanguageRepository;
        }

        public async Task SeedAsync()
        {
            List < (string language, string techology) > list = new(){ new() { language="C#",techology="ASP.NET" } , new() { language = "C++", techology = "TEST" } };

            foreach (var item in list)
            {
                var programmingLanguage = await programmingLanguageRepo.GetAsync(a => a.Name == item.language);
                if (programmingLanguage != null)
                {
                    await technologyRepo.AddAsync(new Technology { Name = item.techology, ProgLangId = programmingLanguage.Id });
                }
            }
        }
    }
}
