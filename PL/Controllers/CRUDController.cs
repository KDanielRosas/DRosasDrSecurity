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
        public ActionResult Form()
        {
            ML.Estado estado = BL.CRUD.GetEstados();
            ML.Municipio municipio = BL.CRUD.GetMunicipios();
            ML.Colonia colonia = BL.CRUD.GetColonias();
            ML.DatosPersonales datos = new ML.DatosPersonales();
            datos.EstadoNacimiento = new ML.Estado();
            datos.EstadoNacimiento = BL.CRUD.GetEstados();
            datos.Direccion = new ML.Direccion();
            datos.Direccion.Estado = new ML.Estado();
            datos.Direccion.Estado = estado;
            datos.Direccion.Municipio = new ML.Municipio();
            datos.Direccion.Municipio = municipio;
            datos.Direccion.Colonia = new ML.Colonia();
            datos.Direccion.Colonia = colonia;

            return View(datos);
        }
    }
}
