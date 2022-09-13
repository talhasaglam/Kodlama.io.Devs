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

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdateProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public Guid ProgLangId { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdateProgrammingLanguageDto>
        {
            private readonly ITechnologyRepository technologyRepo;
            private readonly IMapper _mapper;

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                technologyRepo = technologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                var technology = _mapper.Map<Technology>(request);
                if (technology == null)
                    throw new EntityNotFoundException(nameof(Technology));

                await technologyRepo.UpdateAsync(technology);
                return _mapper.Map<UpdateProgrammingLanguageDto>(technology); ;
            }
        }
    }
}
