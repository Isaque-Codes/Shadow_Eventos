using Shadow_Eventos.Contexts;
using Shadow_Eventos.Domains;
using Shadow_Eventos.Interfaces;

namespace Shadow_Eventos.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Shadow_EventosContext _context;

        public EventoRepository(Shadow_EventosContext context)
        {
            _context = context;
        }

        public List<Evento> Listar()
        {
            return _context.Evento.ToList();
        }

        public Evento BuscarPorId(int id)
        {
            return _context.Evento.FirstOrDefault(e => e.EventoID == id);
        }

        public void Cadastrar(Evento evento)
        {
            _context.Evento.Add(evento);
            _context.SaveChanges();
        }

        public void Atualizar(Evento evento)
        {
            Evento? eventoBanco = _context.Evento.FirstOrDefault(e => e.EventoID == evento.EventoID);

            if (eventoBanco == null)
            {
                return;
            }

            eventoBanco.Nome = evento.Nome;
            eventoBanco.DataEvento = evento.DataEvento;
            eventoBanco.LocalEvento = evento.LocalEvento;

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Evento? eventoBanco = _context.Evento.FirstOrDefault(e => e.EventoID == id);
            if (eventoBanco == null)
            {
                return;
            }
            _context.Evento.Remove(eventoBanco);
            _context.SaveChanges();
        }
    }
}
