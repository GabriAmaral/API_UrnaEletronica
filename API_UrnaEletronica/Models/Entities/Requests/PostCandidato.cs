namespace API_UrnaEletronica.Models.Entities.Requests
{
    public class PostCandidato
    {
        public string Nome { get; set; }

        public string NomeVice { get; set; }

        public DateTime Data { get; set; }

        public int Legenda { get; set; }
    }
}
