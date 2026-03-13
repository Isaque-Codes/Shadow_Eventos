namespace Shadow_Eventos.DTOs.EventoDto
{
    public class LerEventoDto
    {
        public int EventoID { get; set; }

        public string Nome { get; set; } = null!;

        public DateTime Data { get; set; }

        public string Local { get; set; } = null!;
    }
}
