using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRule
    {
        private readonly IProgrammingLanguageRepository programmingLanguageRepo;
        public ProgrammingLanguageBusinessRule(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            programmingLanguageRepo=programmingLanguageRepository;
        }
        public void ValidateEntity(ProgrammingLanguage programmingLanguage, bool isCrated = true)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested Programming Language does not exist");

        }
        public async Task ValidateAsync(ProgrammingLanguage programmingLanguage,bool isCrated = true)
        {
            //if (string.IsNullOrEmpty(programmingLanguage.Name)) throw new BusinessException("Requested Programming Language Name Cannot be null or empty.");

            var existingProgrammingLanguage = isCrated ? await programmingLanguageRepo.GetAsync(r => r.Name == programmingLanguage.Name)
                                                        : await programmingLanguageRepo.GetAsync(r => r.Name == programmingLanguage.Name && r.Id != programmingLanguage.Id);
            if (existingProgrammingLanguage != null) throw new BusinessException("Requested Programming Language Name exist.");
        }


    }
}
