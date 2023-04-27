using System;
using System.Collections.Generic;

namespace DL;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public int? IdEstado { get; set; }

    public int? IdMunicipio { get; set; }

    public int? IdColonia { get; set; }

    public string? Calle { get; set; }

    public string? Numero { get; set; }

    public virtual ICollection<DatosPersonale> DatosPersonales { get; set; } = new List<DatosPersonale>();

    public virtual Colonium? IdColoniaNavigation { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual Municipio? IdMunicipioNavigation { get; set; }
}
