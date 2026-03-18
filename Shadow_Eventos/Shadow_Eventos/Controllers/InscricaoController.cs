using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shadow_Eventos.Applications.Services;
using Shadow_Eventos.DTOs.InscricaoDto;
using Shadow_Eventos.Exceptions;

namespace Shadow_Eventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly InscricaoService _service;

        public InscricaoController(InscricaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerInscricaoDto>> Listar()
        {
            List<LerInscricaoDto> inscricoes = _service.Listar();

            return Ok(inscricoes);
        }

        [HttpGet("{id}")]
        public ActionResult<LerInscricaoDto> BuscarPorId(int id)
        {
            try
            {
                LerInscricaoDto inscricao = _service.BuscarPorId(id);

                return Ok(inscricao);
            }

            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(CriarInscricaoDto criarInscricao)
        {
            try
            {
                _service.Cadastrar(criarInscricao);

                return StatusCode(201);
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
