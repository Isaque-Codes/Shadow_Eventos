using Shadow_Eventos.Domains;
using Shadow_Eventos.DTOs.ParticipanteDto;
using Shadow_Eventos.Interfaces;

namespace Shadow_Eventos.Applications.Services
{
    public class ParticipanteService
    {
        private readonly IParticipanteRepository _repository;

        public ParticipanteService(IParticipanteRepository repository)
        {
            _repository = repository;
        }

        private static LerParticipanteDto LerDto(Participante participante)
        {
            LerParticipanteDto lerDto = new LerParticipanteDto
            {
                ParticipanteID = participante.ParticipanteID,
                Nome = participante.Nome,
                Email = participante.Email
            };

            return lerDto;
        }

        public List<LerParticipanteDto> Listar()
        {
            List<Participante> participantes = _repository.Listar();

            List<LerParticipanteDto> lerDto = participantes.Select
                (p => lerDto(p)).ToList();

            return lerDto;
        }
    }
}
