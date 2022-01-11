﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using totvs_desafio.Interfaces;

namespace totvs_desafio.Models
{
    public class Profile: IProfile
    {
        [Key]
        public Guid ID { get; set; }

        public User User { get; set; }
        [ForeignKey("ID")]
        public Guid UserID { get; set; }
        
        public string? age { get; set; }
        public string? address { get; set; }

        public string? cpf { get; set; }

        public string? rg { get; set; }
    }
}