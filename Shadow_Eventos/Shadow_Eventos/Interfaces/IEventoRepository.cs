using Shadow_Eventos.Domains;

namespace Shadow_Eventos.Interfaces
{
    public interface IEventoRepository
    {
        List<Evento> Listar();

        Evento? BuscarPorId(int id);

        void Cadastrar(Evento evento);

        void Atualizar(Evento evento);

        void Deletar(int id);
    }
}
