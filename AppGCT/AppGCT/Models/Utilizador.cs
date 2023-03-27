using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppGCT.Models
{
    public class Utilizador : IdentityUser
    {
        public string? EstadoUtilizador { get; set; }
        public string? Nome { get; set; }
        public int NIF { get; set; }
        public string? Morada { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataNascim { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataAprovacao { get; set; }
        public DateTime? UltimoLogin { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataCriacao { get; set; }
        public DateTime? HtimestCriacao { get; set; }
        public string? IdCriacao { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataModificacao { get; set; }
        public DateTime? HtimestModificacao { get; set; }
        public string? IdModificacao { get; set; }
    }
}
