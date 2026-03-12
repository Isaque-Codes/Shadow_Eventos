using Shadow_Eventos.Domains;

namespace Shadow_Eventos.Interfaces
{
    public interface IParticipanteRepository
    {
        List<Participante> Listar();

        Participante? BuscarPorId(int id);

        void Cadastrar(Participante participante);

        void Atualizar(Participante participante);

        void Deletar(int id);
    }
}
