using API_UrnaEletronica.Models.Entities.Requests;
using API_UrnaEletronica.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_UrnaEletronica.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoRepository repos;

        public CandidatosController(ICandidatoRepository _repos)
        {
            repos = _repos;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] PostCandidato candidato)
        {
            if (repos.Create(candidato))
                return Ok(true);

            return BadRequest();
        }

        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute] CandidatoId candidato)
        {
            var candidato_db = repos.Read(candidato.Id);
            return Ok(candidato_db);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var candidatos = repos.GetAll();
            return Ok(candidatos);
        }

        [HttpGet("{legenda}")]
        public IActionResult GetFromLegenda([FromRoute] int legenda)
        {
            var candidato = repos.GetFromLegenda(legenda);
            return Ok(candidato);
        }

        [HttpGet]
        public IActionResult GetCandidatosVotos()
        {
            var candidatos = repos.GetCandidatosVotos();
            return Ok(candidatos); 
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] CandidatoId candidato)
        {
            if (repos.Delete(candidato.Id))
                return Ok();

            return BadRequest();
        }


    }
}
