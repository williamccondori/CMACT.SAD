using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Presentacion.Web.Models.Configuracion;
using CMACT.SAD.Web.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMACT.SAD.Presentacion.Web.Controllers
{
    public class ConfiguracionController : BaseController
    {

        /*******************************************

        ACCIONES
        --------------------------------------------

        ********************************************/

        public ActionResult Inicio()
        {
            return View(new InicioViewModel());
        }

        /*******************************************

        API
        --------------------------------------------

        ********************************************/

        /*************
        TIPO DOCUMENTO
        *************/

        [HttpPost]
        public object GuardarTipoDocumento(dtoTipoDocumento aoDto)
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<bool>(
                    JsonConvert.SerializeObject(new EnvioParametros<dtoTipoDocumento>(Login.Usuario(), Login.Password(), aoDto))
                    , Variables.RutaApi() + "api/TipoDocumento/Guardar");
            }), JsonRequestBehavior.AllowGet);
        }
    }
}