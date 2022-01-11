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

        public User User { get; set; }
        public Guid UserID { get; set; }

        public string? age { get; set; }
        public string? address { get; set; }

        public string? cpf { get; set; }

        public string? rg { get; set; }
    }
}
