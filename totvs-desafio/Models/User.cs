using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using totvs_desafio.Interfaces;

namespace totvs_desafio.Models
{
    public class User : IUser, IBaseEntity
    {
        public int ID { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
        public DateTime? LastAccessed { get; set; }
        public List<Profile>? profiles { get; set; }
        public DateTime? created { get; set; } = DateTime.Now;
        public DateTime? modified { get; set; }

    }

}
