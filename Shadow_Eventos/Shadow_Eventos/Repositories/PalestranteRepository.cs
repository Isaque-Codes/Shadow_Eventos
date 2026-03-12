using Shadow_Eventos.Contexts;
using Shadow_Eventos.Domains;
using Shadow_Eventos.Interfaces;

namespace Shadow_Eventos.Repositories
{
    public class PalestranteRepository : IPalestranteRepository
    {
        private readonly Shadow_EventosContext _context;

        public PalestranteRepository(Shadow_EventosContext context)
        {
            _context = context;
        }

        public List<Palestrante> Listar()
        {
            return _context.Palestrante.ToList();
        }

        public Palestrante? BuscarPorId(int id)
        {
            return _context.Palestrante.FirstOrDefault(p => p.PalestranteID == id);
        }

        public void Cadastrar(Palestrante palestrante)
        {
            _context.Palestrante.Add(palestrante);
            _context.SaveChanges();
        }

        public void Atualizar(Palestrante palestrante)
        {
            Palestrante? palestranteBanco = _context.Palestrante.FirstOrDefault(p => p.PalestranteID == palestrante.PalestranteID);

            if (palestranteBanco == null)
            {
                return;
            }

            palestranteBanco.Nome = palestrante.Nome;
            palestranteBanco.AreaAtuacao = palestrante.AreaAtuacao;

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Palestrante? palestranteBanco = _context.Palestrante.FirstOrDefault(p => p.PalestranteID == id);

            if (palestranteBanco == null)
            {
                return;
            }

            _context.Palestrante.Remove(palestranteBanco);
        }
    }
}
