using API_UrnaEletronica.Models.DataBase;
using API_UrnaEletronica.Models.Entities;
using API_UrnaEletronica.Models.Entities.Requests;
using System.Linq;

namespace API_UrnaEletronica.Repositories
{

    public interface ICandidatoRepository
    {
        public bool Create(PostCandidato candidato);

        public Candidato Read(int id);

        public bool Delete(int id);

        public List<Candidato> GetAll();

        public Candidato GetFromLegenda(int legenda);

        public List<CandidatoVotos> GetCandidatosVotos();
    }
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly DataBaseContext db;

        public CandidatoRepository(DataBaseContext _db)
        {
            db = _db;
        }

        public bool Create(PostCandidato candidato)
        {
            try
            {
                var candidato_db = new Candidato()
                {
                    Nome = candidato.Nome,
                    Legenda = candidato.Legenda,
                    NomeVice = candidato.NomeVice,
                    Data = candidato.Data,
                };

                db.Candidatos.Add(candidato_db);
                db.SaveChanges();

                return true;
            }
            catch
            { 
                return false;
            }
        }

        public Candidato Read(int id)
        {
            try
            {
                var candidato_db = db.Candidatos.Find(id);
                return candidato_db;
            }
            catch
            {
                return new Candidato();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var candidato_db = db.Candidatos.Find(id);
                db.Candidatos.Remove(candidato_db);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Candidato> GetAll()
        {
            return db.Candidatos.ToList();
        }

        public Candidato GetFromLegenda(int legenda)
        {
            try
            {
                return db.Candidatos.SingleOrDefault(x => x.Legenda == legenda);
            }
            catch (Exception)
            {
                return new Candidato();
            }
        }

        public List<CandidatoVotos> GetCandidatosVotos()
        {
            var candidatos = db.Candidatos.ToList();
            var candidatosVotos = new List<CandidatoVotos>();

            candidatos.ForEach(x =>
            {
                var votos = db.Votos.Where(v => v.IdCandidato == x.Id).ToList();

                candidatosVotos.Add(new CandidatoVotos() { Id = x.Id, Nome = x.Nome, NomeVice = x.NomeVice, Legenda = x.Legenda, TotalVotos = votos.Count() });
            });

            return candidatosVotos.OrderByDescending(x => x.TotalVotos).ToList();
        }
    }
}
