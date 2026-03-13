using Shadow_Eventos.Domains;
using Shadow_Eventos.DTOs.PalestranteDto;
using Shadow_Eventos.Exceptions;
using Shadow_Eventos.Interfaces;

namespace Shadow_Eventos.Applications.Services
{
    public class PalestranteService
    {
        private readonly IPalestranteRepository _repository;

        public PalestranteService(IPalestranteRepository repository)
        {
            _repository = repository;
        }

        private static LerPalestranteDto LerDto(Palestrante palestrante)
        {
            LerPalestranteDto lerDto = new LerPalestranteDto
            {
                PalestranteID = palestrante.PalestranteID,
                Nome = palestrante.Nome,
                AreaAtuacao = palestrante.AreaAtuacao
            };

            return lerDto;
        }

        public List<LerPalestranteDto> Listar()
        {
            List<Palestrante> palestrantes = _repository.Listar();

            List<LerPalestranteDto> lerDto = palestrantes.Select
                (p => LerDto(p)).ToList();

            return lerDto;
        }

        public LerPalestranteDto BuscarPorId(int id)
        {
            Palestrante palestrante = _repository.BuscarPorId(id);

            if (palestrante == null)
            {
                throw new DomainException("Não existe palestrante com este ID");
            }

            return LerDto(palestrante);
        }

        public LerPalestranteDto Cadastrar(CriarPalestranteDto palestranteDto)
        {
            if (palestranteDto.Nome == null || palestranteDto.AreaAtuacao == null)
            {
                throw new DomainException("O nome e a área de atuação são obrigatórios.");
            }

            Palestrante palestrante = new Palestrante
            {
                Nome = palestranteDto.Nome,
                AreaAtuacao = palestranteDto.AreaAtuacao
            };

            _repository.Cadastrar(palestrante);

            return LerDto(palestrante);
        }

        public LerPalestranteDto Atualizar(int id, AtualizarPalestranteDto palestranteDto)
        {
            Palestrante palestranteBanco = _repository.BuscarPorId(id);

            if (palestranteBanco == null)
            {
                throw new DomainException("Não existe palestrante com este ID.");
            }

            if (!string.IsNullOrWhiteSpace(palestranteDto.Nome))
            {
                palestranteBanco.Nome = palestranteDto.Nome;
            }

            if (!string.IsNullOrWhiteSpace(palestranteDto.AreaAtuacao))
            {
                palestranteBanco.AreaAtuacao = palestranteDto.AreaAtuacao;
            }

            _repository.Atualizar(palestranteBanco);

            return LerDto(palestranteBanco);
        }

        public void Deletar(int id)
        {
            Palestrante palestrante = _repository.BuscarPorId(id);

            if (palestrante == null)
            {
                throw new DomainException("Não existe palestrante com este ID.");
            }

            _repository.Deletar(id);
        }
    }
}