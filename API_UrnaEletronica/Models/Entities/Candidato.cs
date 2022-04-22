using System.ComponentModel.DataAnnotations;

namespace API_UrnaEletronica.Models.Entities
{
    public class Candidato
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } 

        public string NomeVice { get; set; }

        public DateTime Data { get; set; }

        public int Legenda{ get; set; }

    }
}
