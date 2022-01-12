using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using totvs_desafio.Interfaces;

namespace totvs_desafio.Models
{
    public class Profile: IProfile
    {
        [Key]
        public Guid ID { get; set; }

        public ICollection<User>? User { get; set; }

        public string? profession { get; set; }

        public string? interests { get; set; }

    }
}