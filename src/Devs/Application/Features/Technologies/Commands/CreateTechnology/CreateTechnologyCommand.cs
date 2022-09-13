using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.Technologies.Commands.Dtos;
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

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand: IRequest<CreateTechnologyCommandDto>
    {
        public string Name { get; set; }

        public Guid ProgLangId { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreateTechnologyCommandDto>
        {
            private readonly ITechnologyRepository technologyRepo;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRule programmingLanguageBusinessRule;

            public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                technologyRepo = technologyRepository;
                _mapper = mapper;
            }

            public async Task<CreateTechnologyCommandDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                var technology = _mapper.Map<Technology>(request);
                if (technology == null)
                    throw new EntityNotFoundException(nameof(Technology));

               await technologyRepo.AddAsync(technology);
                return _mapper.Map<CreateTechnologyCommandDto>(technology); ;
            }
        }
    }
}
