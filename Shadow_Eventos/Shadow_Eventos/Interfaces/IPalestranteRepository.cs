using Shadow_Eventos.Domains;

namespace Shadow_Eventos.Interfaces
{
    public interface IPalestranteRepository
    {
        List<Palestrante> Listar();

        Palestrante? BuscarPorId(int id);

        void Cadastrar(Palestrante palestrante);

        void Atualizar(Palestrante palestrante);

        void Deletar(int id);
    }
}
