using System;
using System.Collections.Generic;

namespace DL;

public partial class DatosPersonale
{
    public int IdDatosPersonales { get; set; }

    public string Nombre { get; set; } = null!;

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public int? IdEstadoNacimiento { get; set; }

    public string? Telefono { get; set; }

    public string? Celular { get; set; }

    public int? IdDireccion { get; set; }

    public virtual Direccion? IdDireccionNavigation { get; set; }

    public virtual Estado? IdEstadoNacimientoNavigation { get; set; }
    public string EstadoActual { get; set; }
    public string Municipio { get; set; }
    public string Colonia { get; set; }
    public int IdEstado { get; set; }
    public int IdMunicipio { get; set; }
    public int IdColonia { get; set; }
    public string Calle { get; set; }
    public string Numero { get; set; }
    public string EstadoNacimiento { get; set; }
}
