using System;
using System.Collections.Generic;

namespace totvs_desafio.Models
{
    public class User
    {
        public int ID { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public DateTime last_login { get; set; }
        public Profile profile { get; set; }

    }
}
