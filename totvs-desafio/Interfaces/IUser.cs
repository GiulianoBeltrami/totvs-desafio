using System;
using System.Collections.Generic;
using totvs_desafio.Models;

namespace totvs_desafio.Interfaces
{
    public interface IUser
    {
        public Guid ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Profile> profile { get; set; }
    }
}
