using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using totvs_desafio.Interfaces;

namespace totvs_desafio.Models
{
    public class User : IUser, IBaseEntity
    {
        [Key]
        public int ID { get; set; }

        public string name { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
        public DateTime? LastAccessed { get; set; }

        [ForeignKey("ID")]
        public List<Profile>? profile { get; set; }
        public DateTime? created { get; set; } = DateTime.Now;
        public DateTime? modified { get; set; }

    }

}
