using Microsoft.Identity.Client;
using Shadow_Eventos.Domains;
using Shadow_Eventos.DTOs.ParticipanteDto;
using Shadow_Eventos.Exceptions;
using Shadow_Eventos.Interfaces;
using System.Diagnostics;

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
                (p => LerDto(p)).ToList();

            return lerDto;
        }

        public LerParticipanteDto BuscarPorId(int id)
        {
            Participante participante = _repository.BuscarPorId(id);

            if (participante == null)
            {
                throw new DomainException("Não existe participante com este ID.");
            }

            return LerDto(participante);
        }

        public LerParticipanteDto Cadastrar(CriarParticipanteDto criarParticipante)
        {
            if (criarParticipante.Nome == null || criarParticipante.Email == null)
            {
                throw new DomainException("Preencha todos os campos.");
            }

            Participante participante = new Participante
            {
                Nome = criarParticipante.Nome,
                Email = criarParticipante.Email
            };

            _repository.Cadastrar(participante);

            return LerDto(participante);
        }

        public LerParticipanteDto Atualizar(int id, AtualizarParticipanteDto atualizarParticipante)
        {
            Participante participanteBanco = _repository.BuscarPorId(id);

            if (participanteBanco == null)
            {
                throw new DomainException("Não existe participante com este ID.");
            }

            if (!string.IsNullOrWhiteSpace(atualizarParticipante.Nome))
            {
                participanteBanco.Nome = atualizarParticipante.Nome;
            }

            if (!string.IsNullOrWhiteSpace(atualizarParticipante.Email))
            {
                participanteBanco.Email = atualizarParticipante.Email;
            }

            _repository.Atualizar(participanteBanco);

            return LerDto(participanteBanco);
        }

        public void Deletar(int id)
        {
            Participante participanteBanco = _repository.BuscarPorId(id);

            if (participanteBanco == null)
            {
                throw new DomainException("Não existe participante com este ID.");
            }

            _repository.Deletar(id);
        }
    }
}