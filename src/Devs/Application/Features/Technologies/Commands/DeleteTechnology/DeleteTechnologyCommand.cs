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

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeleteProgrammingLanguageDto>
    {
        public Guid Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeleteProgrammingLanguageDto>
        {
            private readonly ITechnologyRepository technologyRepo;
            private readonly IMapper _mapper;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                technologyRepo = technologyRepository;
                _mapper = mapper;
            }

            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                var technology = await technologyRepo.GetAsync(x => x.Id == request.Id);
                if (technology == null)
                    throw new EntityNotFoundException(nameof(Technology));

                await technologyRepo.DeleteAsync(technology);

                return _mapper.Map<DeleteProgrammingLanguageDto>(technology); ;
            }
        }
    }
}
