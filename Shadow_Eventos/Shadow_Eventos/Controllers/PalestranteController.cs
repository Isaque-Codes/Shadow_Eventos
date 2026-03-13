using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shadow_Eventos.Applications.Services;
using Shadow_Eventos.DTOs.PalestranteDto;
using Shadow_Eventos.DTOs.ParticipanteDto;
using Shadow_Eventos.Exceptions;

namespace Shadow_Eventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        private readonly PalestranteService _service;

        public PalestranteController(PalestranteService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerPalestranteDto>> Listar()
        {
            List<LerPalestranteDto> palestrantes = _service.Listar();

            return StatusCode(200, palestrantes);
        }

        [HttpGet("{id}")]
        public ActionResult<LerPalestranteDto> BuscarPorId(int id)
        {
            try
            {
                LerPalestranteDto palestrante = _service.BuscarPorId(id);

                return Ok(palestrante);
            }

            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(CriarPalestranteDto criarPalestrante)
        {
            try
            {
                _service.Cadastrar(criarPalestrante);

                return StatusCode(201, criarPalestrante);
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Atualizar(int id, AtualizarPalestranteDto atualizarPalestrante)
        {
            try
            {
                _service.Atualizar(id, atualizarPalestrante);

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