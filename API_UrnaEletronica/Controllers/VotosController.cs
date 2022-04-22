using API_UrnaEletronica.Models.Entities.Requests;
using API_UrnaEletronica.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace API_UrnaEletronica.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VotosController : ControllerBase
    {

        private readonly IVotosRepository repos;

        public VotosController(IVotosRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute] VotoId voto)
        {
            var voto_db = repos.Read(voto.Id);
            return Ok(voto_db);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var votos = repos.ReadAll();
            return Ok(votos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostVoto voto)
        {
            voto.DataDoVoto = DateTime.Now;

            if (repos.Create(voto))
                return Ok();

            return BadRequest();
        }
    }
}
