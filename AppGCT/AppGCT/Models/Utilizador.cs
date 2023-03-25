using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppGCT.Models
{
    public class Utilizador 
    {
        public int Id { get; set; }
        public string? EstadoUtilizador { get; set; }
        public string? Nome { get; set; }
        public int NIF { get; set; }
        public string? Morada { get; set; }
        public string? Mail { get; set; }
        public string? PrefixoTelemovel { get; set; }
        public string? NumTelemovel { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataNascim { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataAprovacao { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? UltimoLogin { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataCriacao { get; set; }
        public DateTime? HtimestCriacao { get; set; }
        public int? IdCriacao { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataModificacao { get; set; }
        public DateTime? HtimestModificacao { get; set; }
        public int? IdModificacao { get; set; }
    }
}
