using API_UrnaEletronica.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_UrnaEletronica.Models.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Candidato> Candidatos { get; set; }

        public DbSet<Votos> Votos { get; set; }
    }
}
