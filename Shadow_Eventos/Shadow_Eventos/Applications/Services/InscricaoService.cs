using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Shadow_Eventos.Domains;
using Shadow_Eventos.DTOs.EventoDto;
using Shadow_Eventos.DTOs.InscricaoDto;
using Shadow_Eventos.Exceptions;
using Shadow_Eventos.Interfaces;
using Shadow_Eventos.Repositories;

namespace Shadow_Eventos.Applications.Services
{
    public class InscricaoService
    {
        private readonly IInscricaoRepository _repository;
        private readonly IEventoRepository _eventoRepository;
        private readonly IParticipanteRepository _participanteRepository;

        public InscricaoService(IInscricaoRepository repository, IEventoRepository eventoRepository, IParticipanteRepository participanteRepository)
        {
            _repository = repository;
            _eventoRepository = eventoRepository;
            _participanteRepository = participanteRepository;
        }

        private static LerInscricaoDto LerDto(Inscricao inscricao)
        {
            LerInscricaoDto lerDto = new LerInscricaoDto
            {
                InscricaoID = inscricao.InscricaoID,
                EventoID = inscricao.EventoID,
                ParticipanteID = inscricao.ParticipanteID
            };

            return lerDto;
        }

        public List<LerInscricaoDto> Listar()
        {
            List<Inscricao> inscricoes = _repository.Listar();

            List<LerInscricaoDto> lerDto = inscricoes.Select
                (i => LerDto(i)).ToList();

            return lerDto;
        }

        public LerInscricaoDto BuscarPorId(int id)
        {
            Inscricao inscricao = _repository.BuscarPorId(id);

            if (inscricao == null)
            {
                throw new CannotUnloadAppDomainException("Não existe inscrição com este ID.");
            }

            return LerDto(inscricao);
        }

        public LerInscricaoDto Cadastrar(CriarInscricaoDto criarInscricao)
        {
            if (criarInscricao.EventoID == null || criarInscricao.ParticipanteID == null)
            {
                throw new DomainException("Os campos são obrigatórios.");
            }

            var evento = _eventoRepository.BuscarPorId(criarInscricao.EventoID.Value);
            var participante = _participanteRepository.BuscarPorId(criarInscricao.ParticipanteID.Value);

            if (evento == null || participante == null)
            {
                throw new DomainException("Evento ou Participante não encontrado.");
            }

            Inscricao novaInscricao = new Inscricao
            {
                EventoID = criarInscricao.EventoID.Value,
                ParticipanteID = criarInscricao.ParticipanteID.Value
            };

            _repository.Cadastrar(novaInscricao);

            return LerDto(novaInscricao);
        }
    }
}
