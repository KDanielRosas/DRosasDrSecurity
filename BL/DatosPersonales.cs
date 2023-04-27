using CURP;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class DatosPersonales
    {
        public static List<object> EstadoGetAll()
        {
            List<object> listEstados = new List<object>();
            using (DL.DrosasDrSecurityContext context = new())
            {
                var query = context.Estados.FromSqlRaw("EstadoGetAll").ToList();

                if (query != null)
                {                   
                    foreach (var item in query)
                    {
                        ML.Estado estado = new();
                        estado.IdEstado = item.IdEstado;
                        estado.Nombre = item.Nombre;

                        listEstados.Add(estado);
                    }
                }
            }
            return listEstados;
        }//EstadoGetAll

        public static string GenerarCURP(ML.DatosPersonales datos)
        {
            ML.Estado state = new();
            using (DL.DrosasDrSecurityContext context = new())
            {
                var query = context.Estados.FromSqlRaw(
                    $"EstadoGetById {datos.EstadoNacimiento.IdEstado}").AsEnumerable().FirstOrDefault();

                state.IdEstado = query.IdEstado;
                state.Nombre = query.Nombre;
            }
            state.Nombre = state.Nombre.Replace(' ', '_');
            var estadoNac = new CURP.Enums.Estado();
            foreach (CURP.Enums.Estado item in Enum.GetValues(typeof(CURP.Enums.Estado)))
            {
                if (state.Nombre.Equals(item.ToString()))
                {
                    estadoNac = item;
                    break;
                }
            }

            var sex = datos.Sexo.Equals("M") ? CURP.Enums.Sexo.Hombre : CURP.Enums.Sexo.Mujer;

            var curp = Curp.Generar(datos.Nombre, datos.PrimerApellido, datos.SegundoApellido,
                sex, datos.FechaNacimiento, estadoNac);

            return curp;
        }
    }
}