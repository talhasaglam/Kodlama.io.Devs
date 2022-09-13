using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology: Entity
    {
        public string Name { get; set; }

        public Guid ProgLangId { get; set; }

        public virtual ProgrammingLanguage?  ProgrammingLanguage { get; set; }
    }
}
