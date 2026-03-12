using System;
using System.Collections.Generic;

namespace Shadow_Eventos.Domains;

public partial class Participante
{
    public int ParticipanteID { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Inscricao> Inscricao { get; set; } = new List<Inscricao>();
}
