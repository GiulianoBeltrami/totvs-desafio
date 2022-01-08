using System;
using System.ComponentModel.DataAnnotations;

namespace totvs_desafio.Models
{
    public class Profile
    {
        [Key]
        public int ID { get; set; }
        public string? age { get; set; }
        public string? address { get; set; }

        public string? cpf { get; set; }

        public string? rg { get; set; }
    }
}