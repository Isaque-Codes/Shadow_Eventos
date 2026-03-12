using Shadow_Eventos.Contexts;
using Shadow_Eventos.Domains;
using Shadow_Eventos.Interfaces;

namespace Shadow_Eventos.Repositories
{
    public class InscricaoRepository : IInscricaoRepository
    {
        private readonly Shadow_EventosContext _context;

        public InscricaoRepository(Shadow_EventosContext context)
        {
            _context = context;
        }

        public List<Inscricao> Listar()
        {
            return _context.Inscricao.ToList();
        }

        public Inscricao? BuscarPorId(int id)
        {
            return _context.Inscricao.FirstOrDefault(i => i.InscricaoID == id);
        }

        public void Cadastrar(Inscricao inscricao)
        {
            _context.Inscricao.Add(inscricao);
            _context.SaveChanges();
        }
    }
}
