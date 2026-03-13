using Shadow_Eventos.Exceptions;

namespace Shadow_Eventos.Applications.Regras.Evento
{
    public class ValidarDataEvento
    {
        public static bool ValidarData(DateTime data)
        {
            if (data <= DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }
}
