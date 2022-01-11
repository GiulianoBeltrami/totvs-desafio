using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace totvs_desafio.Models
{
    public class Profile
    {
        [Key]
        public int ID { get; set; }

        public User User { get; set; }
        [ForeignKey("ID")]
        public int UserID { get; set; }
        
        public string? age { get; set; }
        public string? address { get; set; }

        public string? cpf { get; set; }

        public string? rg { get; set; }
    }
}