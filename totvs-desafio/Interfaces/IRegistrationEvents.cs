using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using totvs_desafio.Models;

namespace totvs_desafio.Interfaces
{
    public interface IRegistrationEvents
    {
        public User create();

        public User get(int id);

        public User getAll();

        public User delete();
    }
}
