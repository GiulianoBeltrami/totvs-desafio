using System;
using System.Collections.Generic;

namespace totvs_desafio.Models
{
    public class User
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public List<Profile>? profiles { get; set; }

        public DateTime? created { get; set; }

        public DateTime? modified { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? LastAccessed { get; set; }

    }
}
