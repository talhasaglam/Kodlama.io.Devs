using Application.Features.ProgrammingLanguages.Dtos;
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

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand: IRequest<DeleteProgrammingLanguageDto>
    {
        public Guid Id { get; set; }
        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository programmingLanguageRepo;
            private readonly IMapper _mapper;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                 programmingLanguageRepo = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguage = await programmingLanguageRepo.GetAsync(x=>x.Id==request.Id);
                if (programmingLanguage == null)
                    throw new EntityNotFoundException(nameof(ProgrammingLanguage));
                await programmingLanguageRepo.DeleteAsync(programmingLanguage);
                var deleteProgramminLanguageDto =_mapper.Map<DeleteProgrammingLanguageDto>(programmingLanguage);
                return deleteProgramminLanguageDto;
            }
        }
    }
}
