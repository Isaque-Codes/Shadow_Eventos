using Shadow_Eventos.Exceptions;

namespace Shadow_Eventos.Applications.Regras.Participante
{
    public class ValidarEmailParticipante
    {
        public static void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException("E-mail inválido.");
            }
        }
    }
}
