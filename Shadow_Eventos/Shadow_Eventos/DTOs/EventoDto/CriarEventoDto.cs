namespace Shadow_Eventos.DTOs.EventoDto
{
    public class CriarEventoDto
    {
        public string Nome { get; set; } = null!;

        public DateTime Data { get; set; }

        public string Local { get; set; } = null!;
    }
}
