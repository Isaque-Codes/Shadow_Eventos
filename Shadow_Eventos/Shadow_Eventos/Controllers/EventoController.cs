using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shadow_Eventos.Applications.Services;
using Shadow_Eventos.Domains;
using Shadow_Eventos.DTOs.EventoDto;
using Shadow_Eventos.DTOs.PalestranteDto;
using Shadow_Eventos.Exceptions;

namespace Shadow_Eventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly EventoService _service;

        public EventoController(EventoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerEventoDto>> Listar()
        {
            List<LerEventoDto> eventos = _service.Listar();

            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public ActionResult<LerEventoDto> BuscarPorId(int id)
        {
            try
            {
                LerEventoDto evento = _service.BuscarPorId(id);

                return Ok(evento);
            }

            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(CriarEventoDto criarEvento)
        {
            try
            {
                _service.Cadastrar(criarEvento);

                return StatusCode(201, criarEvento);
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public ActionResult Atualizar(int id, AtualizarEventoDto atualizarEvento)
        {
            try
            {
                _service.Atualizar(id, atualizarEvento);

                return NoContent();
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public ActionResult Deletar(int id)
        {
            try
            {
                _service.Deletar(id);

                return NoContent();
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
