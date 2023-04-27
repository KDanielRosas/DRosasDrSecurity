using System;
using System.Collections.Generic;

namespace DL;

public partial class Ciudad
{
    public int IdCiudad { get; set; }

    public string? Nombre { get; set; }

    public int? IdEstado { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
