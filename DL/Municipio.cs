using System;
using System.Collections.Generic;

namespace DL;

public partial class Municipio
{
    public int IdMunicipio { get; set; }

    public string? Nombre { get; set; }

    public int? IdEstado { get; set; }

    public virtual ICollection<Colonium> Colonia { get; set; } = new List<Colonium>();

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual Estado? IdEstadoNavigation { get; set; }
}
