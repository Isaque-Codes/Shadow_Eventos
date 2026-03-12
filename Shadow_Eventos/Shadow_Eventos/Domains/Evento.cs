using System;
using System.Collections.Generic;

namespace Shadow_Eventos.Domains;

public partial class Evento
{
    public int EventoID { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataEvento { get; set; }

    public string LocalEvento { get; set; } = null!;

    public int? PalestranteID { get; set; }

    public virtual ICollection<Inscricao> Inscricao { get; set; } = new List<Inscricao>();

    public virtual Palestrante? Palestrante { get; set; }
}
