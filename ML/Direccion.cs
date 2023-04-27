using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public Estado Estado { get; set; }
        public Municipio Municipio { get; set; }
        public Colonia Colonia { get; set; }
        public string Calle { get; set; }
        public string? Numero { get; set; }
    }
}
