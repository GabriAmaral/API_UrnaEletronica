using System.ComponentModel.DataAnnotations;

namespace API_UrnaEletronica.Models.Entities
{
    public class Votos
    {
        [Key]
        public int Id { get; set; } 
        public int IdCandidato { get; set; }
        public DateTime DataDoVoto { get; set; }
    }
}
