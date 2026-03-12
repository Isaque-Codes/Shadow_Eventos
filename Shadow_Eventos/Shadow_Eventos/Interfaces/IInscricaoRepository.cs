using Shadow_Eventos.Domains;

namespace Shadow_Eventos.Interfaces
{
    public interface IInscricaoRepository
    {
        List<Inscricao> Listar();

        Inscricao? BuscarPorId(int id);

        void Cadastrar(Inscricao inscricao);
    }
}
