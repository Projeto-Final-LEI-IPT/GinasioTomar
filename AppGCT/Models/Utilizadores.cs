namespace AppGCT.Models
{
    public class Utilizadores
    {
        public int id {  get; set; }
        public int? FK_idRole { get; set; }
        public int estadoUtilizador { get; set; }
        public string nome { get; set; }

    }
}
