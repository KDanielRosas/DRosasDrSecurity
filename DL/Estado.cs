using System;
using System.Collections.Generic;

namespace DL;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<DatosPersonale> DatosPersonales { get; set; } = new List<DatosPersonale>();

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
