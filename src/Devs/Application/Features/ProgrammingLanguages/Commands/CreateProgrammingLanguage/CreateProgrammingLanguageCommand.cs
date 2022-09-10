using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand: IRequest<CreateProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository programmingLanguageRepo;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRule programmingLanguageBusinessRule;

            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRule programmingLanguageBusinessRule)
            {
                programmingLanguageRepo = programmingLanguageRepository;
                _mapper = mapper;
                this.programmingLanguageBusinessRule = programmingLanguageBusinessRule;
            }

            public async Task<CreateProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                if (programmingLanguage == null)
                    throw new EntityNotFoundException(nameof(ProgrammingLanguage));
                //programmingLanguageBusinessRule.ValidateEntity(programmingLanguage);
                await programmingLanguageBusinessRule.ValidateAsync(programmingLanguage);
                var createdProgrammingLanguage = await programmingLanguageRepo.AddAsync(programmingLanguage);
                var createProgrammingLanguageDto = _mapper.Map<CreateProgrammingLanguageDto>(createdProgrammingLanguage);
                return createProgrammingLanguageDto;
            }
        }
    }
}
