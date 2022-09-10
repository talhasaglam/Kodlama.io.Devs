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
    public class UpdateProgrammingLanguageCommand : IRequest<UpdateProgrammingLanguageDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository programmingLanguageRepo;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRule programmingLanguageBusinessRule;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRule programmingLanguageBusinessRule)
            {
                programmingLanguageRepo = programmingLanguageRepository;
                _mapper = mapper;
                this.programmingLanguageBusinessRule = programmingLanguageBusinessRule;
            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguage = await programmingLanguageRepo.GetAsync(x => x.Id == request.Id);
                if (programmingLanguage == null)
                    throw new EntityNotFoundException(nameof(ProgrammingLanguage));
                //programmingLanguageBusinessRule.ValidateEntity(programmingLanguage);
                _mapper.Map<UpdateProgrammingLanguageCommand,ProgrammingLanguage>(request, programmingLanguage);
                await programmingLanguageBusinessRule.ValidateAsync(programmingLanguage, false);
                await programmingLanguageRepo.UpdateAsync(programmingLanguage);
                var updateProgrammingLanguageDto = _mapper.Map<UpdateProgrammingLanguageDto>(programmingLanguage);
                return updateProgrammingLanguageDto;
            }
        }
    }
}
