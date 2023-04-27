using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CRUD
    {
        public static bool Add(ML.DatosPersonales datos)
        {
            using (DL.DrosasDrSecurityContext context = new())
            {
                int query = context.Database.ExecuteSqlRaw($"DatosPersonalesAdd '{datos.Nombre}'," +
                    $"'{datos.PrimerApellido}','{datos.SegundoApellido}', '{datos.FechaNacimiento}', " +
                    $"'{datos.Sexo}', {datos.EstadoNacimiento.IdEstado}, '{datos.Telefono}', '{datos.Celular}', " +
                    $"{datos.Direccion.Estado.IdEstado}, {datos.Direccion.Municipio.IdMunicipio}, " +
                    $"{datos.Direccion.Colonia.IdColonia}, '{datos.Calle}', '{datos.Numero}'");

                return (query > 1);
            }
        }//Add

        public static bool Delete(int idDatos)
        {
            using (DL.DrosasDrSecurityContext context = new())
            {
                int query = context.Database.ExecuteSqlRaw($"DatosPersonalesDelete {idDatos}");

                return (query > 0);
            }
        }//Delete

        public static bool Update(ML.DatosPersonales datos)
        {
            using (DL.DrosasDrSecurityContext context = new())
            {
                int query = context.Database.ExecuteSqlRaw($"DatosPersonalesUpdate {datos.IdDatosPersonales}, '{datos.Nombre}'," +
                    $"'{datos.PrimerApellido}','{datos.SegundoApellido}', '{datos.FechaNacimiento}', " +
                    $"'{datos.Sexo}', {datos.EstadoNacimiento.IdEstado}, '{datos.Telefono}', '{datos.Celular}', " +
                    $"{datos.Direccion.Estado.IdEstado}, {datos.Direccion.Municipio.IdMunicipio}, " +
                    $"{datos.Direccion.Colonia.IdColonia}, '{datos.Calle}', '{datos.Numero}'");

                return (query > 0);
            }
        }//Update

        public static ML.DatosPersonales GetAll()
        {
            ML.DatosPersonales result = new ML.DatosPersonales();
            using (DL.DrosasDrSecurityContext context = new())
            {
                var query = context.DatosPersonales.FromSqlRaw($"DatosPersonalesGetAll").ToList();

                if (query != null)
                {
                    result.List = new List<ML.DatosPersonales>();
                    foreach (var item in query)
                    {
                        ML.DatosPersonales obj = new ML.DatosPersonales();
                        obj.IdDatosPersonales = item.IdDatosPersonales;
                        obj.Nombre = item.Nombre;
                        obj.PrimerApellido = item.PrimerApellido;
                        obj.SegundoApellido = item.SegundoApellido;
                        obj.FechaNacimiento = item.FechaNacimiento.Value;
                        obj.Sexo = item.Sexo;
                        obj.EstadoNacimiento = new ML.Estado();
                        obj.EstadoNacimiento.IdEstado = item.IdEstadoNacimiento.Value;
                        obj.EstadoNacimiento.Nombre = item.EstadoNacimiento;
                        obj.Telefono = item.Telefono;
                        obj.Celular = item.Celular;
                        obj.Direccion = new ML.Direccion();
                        obj.Direccion.IdDireccion = item.IdDireccion.Value;
                        obj.Direccion.Estado = new ML.Estado();
                        obj.Direccion.Estado.IdEstado = item.IdEstado;
                        obj.Direccion.Estado.Nombre = item.EstadoActual;
                        obj.Direccion.Municipio = new ML.Municipio();
                        obj.Direccion.Municipio.IdMunicipio = item.IdMunicipio;
                        obj.Direccion.Municipio.Nombre = item.Municipio;
                        obj.Direccion.Colonia = new ML.Colonia();
                        obj.Direccion.Colonia.IdColonia = item.IdColonia;
                        obj.Direccion.Colonia.Nombre = item.Colonia;
                        obj.Calle = item.Calle;
                        obj.Numero = item.Numero;

                        result.List.Add(obj);
                    }
                    
                }
            }
            return result;
        }//GetAll

        public static ML.DatosPersonales GetById(int idDatos)
        {
            ML.DatosPersonales obj = new ML.DatosPersonales();
            using (DL.DrosasDrSecurityContext context = new())
            {
                var query = context.DatosPersonales.FromSqlRaw($"DatosPersonalesGetById {idDatos}").AsEnumerable().FirstOrDefault();

                if (query != null)
                {
                    obj.IdDatosPersonales = query.IdDatosPersonales;
                    obj.Nombre = query.Nombre;
                    obj.PrimerApellido = query.PrimerApellido;
                    obj.SegundoApellido = query.SegundoApellido;
                    obj.FechaNacimiento = query.FechaNacimiento.Value;
                    obj.Sexo = query.Sexo;
                    obj.EstadoNacimiento = new ML.Estado();
                    obj.EstadoNacimiento.IdEstado = query.IdEstadoNacimiento.Value;
                    obj.EstadoNacimiento.Nombre = query.EstadoNacimiento;
                    obj.Telefono = query.Telefono;
                    obj.Celular = query.Celular;
                    obj.Direccion = new ML.Direccion();
                    obj.Direccion.IdDireccion = query.IdDireccion.Value;
                    obj.Direccion.Estado = new ML.Estado();
                    obj.Direccion.Estado.IdEstado = query.IdEstado;
                    obj.Direccion.Estado.Nombre = query.EstadoActual;
                    obj.Direccion.Municipio = new ML.Municipio();
                    obj.Direccion.Municipio.IdMunicipio = query.IdMunicipio;
                    obj.Direccion.Municipio.Nombre = query.Municipio;
                    obj.Direccion.Colonia = new ML.Colonia();
                    obj.Direccion.Colonia.IdColonia = query.IdColonia;
                    obj.Direccion.Colonia.Nombre = query.Colonia;
                    obj.Calle = query.Calle;
                    obj.Numero = query.Numero;
                }
            }
            return obj;
        }//GetById

        public static List<ML.Colonia> GetColonias()
        {
            ML.Colonia colonia = new();
            colonia.List = new List<ML.Colonia>();

            using (DL.DrosasDrSecurityContext context = new())
            {
                var query = context.Colonia.FromSqlRaw("SELECT * FROM Colonia").ToList();

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        ML.Colonia obj = new();
                        obj.IdColonia = item.IdColonia;
                        obj.Nombre = item.Nombre;

                        colonia.List.Add(obj);
                    }
                }
            }
            return colonia.List;
        }//Colonia

        public static List<ML.Municipio> GetMunicipios()
        {
            ML.Municipio municipio = new();
            municipio.List = new List<ML.Municipio>();

            using (DL.DrosasDrSecurityContext context = new())
            {
                var query = context.Municipios.FromSqlRaw("SELECT * FROM Municipio").ToList();

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        ML.Municipio obj = new();
                        obj.IdMunicipio = item.IdMunicipio;
                        obj.Nombre = item.Nombre;

                        municipio.List.Add(obj);
                    }
                }
            }
            return municipio.List;
        }//Municipio

        public static List<object> GetEstados()
        {
            ML.Estado estado = new();
            estado.Estados = new List<object>();

            using (DL.DrosasDrSecurityContext context = new())
            {
                var query = context.Estados.FromSqlRaw("SELECT * FROM Estado").ToList();

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        ML.Estado obj = new();
                        obj.IdEstado = item.IdEstado;
                        obj.Nombre = item.Nombre;

                        estado.Estados.Add(obj);
                    }
                }
            }
            return estado.Estados;
        }//Estado
    }
}
