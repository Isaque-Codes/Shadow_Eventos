using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shadow_Eventos.Applications.Services;
using Shadow_Eventos.Domains;
using Shadow_Eventos.DTOs.ParticipanteDto;
using Shadow_Eventos.Exceptions;

namespace Shadow_Eventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private readonly ParticipanteService _service;

        public ParticipanteController(ParticipanteService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerParticipanteDto>> Listar()
        {
            List<LerParticipanteDto> participantes = _service.Listar();

            return Ok(participantes);
        }

        [HttpGet("{id}")]
        public ActionResult<LerParticipanteDto> BuscarPorId(int id)
        {
            try
            {
                LerParticipanteDto participante = _service.BuscarPorId(id);

                return participante;
            }

            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(CriarParticipanteDto criarParticipante)
        {
            try
            {
                _service.Cadastrar(criarParticipante);

                return StatusCode(201, criarParticipante);
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, AtualizarParticipanteDto atualizarParticipante)
        {
            try
            {
                _service.Atualizar(id, atualizarParticipante);

                return NoContent();
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
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
