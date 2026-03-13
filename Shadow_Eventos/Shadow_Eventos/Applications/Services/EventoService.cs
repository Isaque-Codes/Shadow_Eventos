using Shadow_Eventos.Applications.Regras.Evento;
using Shadow_Eventos.Domains;
using Shadow_Eventos.DTOs.EventoDto;
using Shadow_Eventos.DTOs.PalestranteDto;
using Shadow_Eventos.Exceptions;
using Shadow_Eventos.Interfaces;
using Shadow_Eventos.Applications.Regras.Evento;

namespace Shadow_Eventos.Applications.Services
{
    public class EventoService
    {
        private readonly IEventoRepository _repository;

        public EventoService(IEventoRepository repository)
        {
            _repository = repository;
        }

        private static LerEventoDto LerDto(Evento evento)
        {
            LerEventoDto lerDto = new LerEventoDto
            {
                EventoID = evento.EventoID,
                Nome = evento.Nome,
                Data = evento.DataEvento,
                Local = evento.LocalEvento,
            };

            return lerDto;
        }

        public List<LerEventoDto> Listar()
        {
            List<Evento> eventos = _repository.Listar();

            List<LerEventoDto> lerDto = eventos.Select
                (e => LerDto(e)).ToList();

            return lerDto;
        }

        public LerEventoDto BuscarPorId(int id)
        {
            Evento evento = _repository.BuscarPorId(id);

            if (evento == null)
            {
                throw new DomainException("Não existe evento com este ID.");
            }

            return LerDto(evento);
        }

        public LerEventoDto Cadastrar(CriarEventoDto criarEvento)
        {
            if (criarEvento.Nome == null || criarEvento.Local == null)
            {
                throw new DomainException("Preencha todos os dados do evento.");
            }

            if (ValidarDataEvento.ValidarData(criarEvento.Data) == false)
            {
                throw new DomainException("A data do evento deve ser futura.");
            }

            Evento evento = new Evento
            {
                Nome = criarEvento.Nome,
                DataEvento = criarEvento.Data,
                LocalEvento = criarEvento.Local
            };

            _repository.Cadastrar(evento);

            return LerDto(evento);
        }

        public LerEventoDto Atualizar(int id, AtualizarEventoDto atualizarEvento)
        {
            Evento eventoBanco = _repository.BuscarPorId(id);

            if (eventoBanco == null)
            {
                throw new DomainException("Não existe evento com este ID.");
            }

            if (atualizarEvento.Data.HasValue)
            {
                // Método booleano
                if (!ValidarDataEvento.ValidarData(atualizarEvento.Data.Value))
                {
                    throw new DomainException("A data do evento deve ser futura.");
                }

                if (ValidarDataEvento.ValidarData(atualizarEvento.Data.Value))
                {
                    eventoBanco.DataEvento = atualizarEvento.Data.Value;
                }
            }

            if (!string.IsNullOrWhiteSpace(atualizarEvento.Nome))
            {
                eventoBanco.Nome = atualizarEvento.Nome;
            }

            if (!string.IsNullOrWhiteSpace(atualizarEvento.Local))
            {
                eventoBanco.LocalEvento = atualizarEvento.Local;
            }

            _repository.Atualizar(eventoBanco);

            return LerDto(eventoBanco);
        }

        public void Deletar(int id)
        {
            Evento evento = _repository.BuscarPorId(id);

            if (evento == null)
            {
                throw new DomainException("Não existe evento com este ID.");
            }

            _repository.Deletar(id);
        }
    }
}