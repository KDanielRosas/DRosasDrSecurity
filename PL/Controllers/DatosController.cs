using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class DatosController : Controller
    {
        public IActionResult Index()
        {
            ML.DatosPersonales datosPersonales = new ML.DatosPersonales();
            datosPersonales.EstadoNacimiento = new ML.Estado();
            datosPersonales.EstadoNacimiento.Estados = new List<object>();
            datosPersonales.EstadoNacimiento.Estados = BL.DatosPersonales.EstadoGetAll();
            //BL.DatosPersonales.GenerarCURP(datosPersonales);
            return View(datosPersonales);
        }

        public JsonResult GenerarCURP(ML.DatosPersonales datos)
        {
            return Json(BL.DatosPersonales.GenerarCURP(datos));
        }
    }
}
