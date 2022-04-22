using API_UrnaEletronica.Models.DataBase;
using API_UrnaEletronica.Models.Entities;
using API_UrnaEletronica.Models.Entities.Requests;

namespace API_UrnaEletronica.Repositories
{

    public interface IVotosRepository
    {
        public bool Create(PostVoto voto);

        public Votos Read(int id);

        public List<Votos> ReadAll();

    }

    public class VotosRepository : IVotosRepository
    {
        private readonly DataBaseContext db;

        public VotosRepository(DataBaseContext _db)
        {
            db = _db;
        }

        public bool Create(PostVoto voto)
        {
            try
            {
                var voto_db = new Votos()
                {
                    IdCandidato = voto.IdCandidato,
                    DataDoVoto = voto.DataDoVoto,
                };

                db.Votos.Add(voto_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Votos Read(int id)
        {
            try
            {
                var voto_db = db.Votos.Find(id);
                return voto_db;
            }
            catch
            {
                return new Votos();
            }
        }

        public List<Votos> ReadAll()
        {
            return db.Votos.ToList();
        }
    }
}
