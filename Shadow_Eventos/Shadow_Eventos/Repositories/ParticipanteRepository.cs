using Shadow_Eventos.Contexts;
using Shadow_Eventos.Domains;
using Shadow_Eventos.Interfaces;

namespace Shadow_Eventos.Repositories
{
    public class ParticipanteRepository : IParticipanteRepository
    {
        private readonly Shadow_EventosContext _context;

        public ParticipanteRepository(Shadow_EventosContext context)
        {
            _context = context;
        }

        public List<Participante> Listar()
        {
            return _context.Participante.ToList();
        }

        public Participante? BuscarPorId(int id)
        {
            return _context.Participante.FirstOrDefault(p => p.ParticipanteID == id);
        }

        public void Cadastrar(Participante participante)
        {
            _context.Participante.Add(participante);
            _context.SaveChanges();
        }

        public void Atualizar(Participante participante)
        {
            Participante participanteBanco = _context.Participante.FirstOrDefault(p => p.ParticipanteID == participante.ParticipanteID);

            if (participanteBanco == null)
            {
                return;
            }

            participanteBanco.Nome = participante.Nome;
            participanteBanco.Email = participante.Email;

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Participante participanteBanco = _context.Participante.FirstOrDefault(p => p.ParticipanteID == id);

            if (participanteBanco == null)
            {
                return;
            }

            _context.Participante.Remove(participanteBanco);
        }
    }
}
