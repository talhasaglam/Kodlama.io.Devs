using Application.Features.ProgrammingLanguages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Models
{
    public class GetProgrammingLanguageListModel
    {
        public IList<GetProgrammingLanguageListDto> Items { get; set; }
    }
}
