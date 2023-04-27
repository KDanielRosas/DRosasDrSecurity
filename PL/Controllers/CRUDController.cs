using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class CRUDController : Controller
    {
        public ActionResult GetAll()
        {           
            return View(BL.CRUD.GetAll());
        }

        [HttpGet]
        public ActionResult Form(int? idDatos)
        {
            ML.Estado estado = new(); 
            estado.Estados = BL.CRUD.GetEstados();
            ML.Municipio municipio = new();
            municipio.List = BL.CRUD.GetMunicipios();
            ML.Colonia colonia = new();
            colonia.List = BL.CRUD.GetColonias();
            ML.DatosPersonales datos = new ML.DatosPersonales();
            datos.EstadoNacimiento = new ML.Estado();
            datos.EstadoNacimiento.Estados = BL.CRUD.GetEstados();
            datos.Direccion = new ML.Direccion();
            datos.Direccion.Estado = new ML.Estado();
            datos.Direccion.Estado.Estados = estado.Estados;
            datos.Direccion.Municipio = new ML.Municipio();
            datos.Direccion.Municipio.List = municipio.List;
            datos.Direccion.Colonia = new ML.Colonia();
            datos.Direccion.Colonia.List = colonia.List;
            if (idDatos == null)
            {
                //form vacio
                return View(datos);
            }
            else
            {
                datos = BL.CRUD.GetById(idDatos.Value);
                datos.EstadoNacimiento.Estados = BL.CRUD.GetEstados();
                datos.Direccion.Estado.Estados = BL.CRUD.GetEstados();
                datos.Direccion.Municipio.List = BL.CRUD.GetMunicipios();
                datos.Direccion.Colonia.List = BL.CRUD.GetColonias();
                return View(datos);
            }       
        }

        [HttpPost]
        public ActionResult Form(ML.DatosPersonales datos)
        {
            if (datos.IdDatosPersonales == 0)
            {
                if (BL.CRUD.Add(datos))
                {
                    ViewBag.Message = "Registro exitoso";
                }
                else
                {
                    ViewBag.Message = "Error al registrar";
                }
                return View("Modal");
            }
            else
            {
                if (BL.CRUD.Update(datos))
                {
                    ViewBag.Message = "Registro actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = "Error al actualizar";
                }
                return View("Modal");
            }            
        }//Form post

        public ActionResult Delete (int idDatos)
        {
            if (BL.CRUD.Delete(idDatos))
            {
                ViewBag.Message = "Registro eliminado";
            }
            else
            {
                ViewBag.Message = "Error al eliminar";
            }
            return View("Modal");
        }
    }
}
