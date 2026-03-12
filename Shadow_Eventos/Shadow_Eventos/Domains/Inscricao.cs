using System;
using System.Collections.Generic;

namespace Shadow_Eventos.Domains;

public partial class Inscricao
{
    public int InscricaoID { get; set; }

    public int? EventoID { get; set; }

    public int? ParticipanteID { get; set; }

    public virtual Evento? Evento { get; set; }

    public virtual Participante? Participante { get; set; }
}
