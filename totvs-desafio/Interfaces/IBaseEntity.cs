using System;

namespace totvs_desafio.Interfaces
{
    public interface IBaseEntity
    {
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
        public DateTime? LastAccessed { get; set; }
    }
}
