using System;
using System.Collections.Generic;

namespace Shadow_Eventos.Domains;

public partial class Palestrante
{
    public int PalestranteID { get; set; }

    public string Nome { get; set; } = null!;

    public string AreaAtuacao { get; set; } = null!;

    public virtual ICollection<Evento> Evento { get; set; } = new List<Evento>();
}
