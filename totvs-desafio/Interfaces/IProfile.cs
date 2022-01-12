using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using totvs_desafio.Models;

namespace totvs_desafio.Interfaces
{
    public interface IProfile
    {
        public Guid ID { get; set; }

        public ICollection<User>? User { get; set; }

        public string? profession { get; set; }

        public string? interests { get; set; }
    }
}
