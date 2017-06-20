using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.DTOs.SAF;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Presentacion.Web.Models.Derivacion;
using CMACT.SAD.Web.Utilidades;
using CMACT.SAD.Web.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CMACT.SAD.Presentacion.Web.Controllers
{
    public class DerivacionController : BaseController
    {

        /*******************************************

        ACCIONES
        --------------------------------------------

        ********************************************/

        [HttpGet]
        public ActionResult Inicio()
        {
            return View(new InicioViewModel());
        }

        [HttpGet]
        public ActionResult Gestion()
        {
            return View(new GestionViewModel());
        }

        [HttpPost]
        public ActionResult Gestion(string asParametros, HttpPostedFileBase aoArchivo)
        {
            try
            {
                if (aoArchivo == null)
                    throw new Exception(ResultadoMensaje.DocumentoIncorrecto);

                BinaryReader loArchivoBinario = new BinaryReader(aoArchivo.InputStream);

                dtoDocumento lodto = JsonConvert.DeserializeObject<dtoDocumento>(asParametros);
                lodto.NombreArchivo = aoArchivo.FileName;
                lodto.ContenidoArchivo = loArchivoBinario.ReadBytes(aoArchivo.ContentLength);

                ResultadoOperacion<bool> loResultado = Post<bool>(
                    JsonConvert.SerializeObject(
                        new EnvioParametros<dtoDocumento>(Login.Usuario(), Login.Password(), lodto))
                    , Variables.RutaApi() + "api/Documento/Guardar");

                if (loResultado.Error)
                    throw new Exception(loResultado.Mensaje);

                EstablecerMensajeCorrecto(ResultadoMensaje.Correcto);
            }
            catch (Exception aoExcepcion)
            {
                EstablecerMensajeError(aoExcepcion.Message);
            }

            return View(new GestionViewModel());
        }

        [HttpGet]
        public ActionResult Estado()
        {
            return View(new EstadoViewModel());
        }

        [HttpGet]
        public ActionResult Entrante()
        {
            return View(new EntranteViewModel());
        }

        [HttpPost]
        public FileResult Descargar(int aiCodigo)
        {
            ResultadoOperacion<dtoDocumento> loResultado = Post<dtoDocumento>(
                JsonConvert.SerializeObject(new EnvioParametros<int>(Login.Usuario(), Login.Password(), aiCodigo))
                , Variables.RutaApi() + "api/Documento/ObtenerXCodigo");

            return File(loResultado.Datos.ContenidoArchivo, "application/pdf", loResultado.Datos.NombreArchivo);
        }

        /*******************************************

        API
        --------------------------------------------

        ********************************************/

        /********
        DOCUMENTO
        ********/

        [HttpPost]
        public object ObtenerDocumento()
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<List<dtoDocumento>>(
                    JsonConvert.SerializeObject(new EnvioParametros<string>(Login.Usuario(), Login.Password()))
                    , Variables.RutaApi() + "api/Documento/ObtenerTodos");
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object BuscarDocumento(dtoBusquedaDocumento aoDto)
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<List<dtoDocumento>>(
                    JsonConvert.SerializeObject(new EnvioParametros<dtoBusquedaDocumento>(Login.Usuario(), Login.Password(), aoDto))
                    , Variables.RutaApi() + "api/Documento/BuscarXFecha");
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object ObtenerDocumentoXUsuario()
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<List<dtoDocumento>>(
                    JsonConvert.SerializeObject(new EnvioParametros<string>(Login.Usuario(), Login.Password()))
                    , Variables.RutaApi() + "api/Documento/ObtenerTodosXUsuario");
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object BuscarDocumentoXUsuario(dtoBusquedaDocumento aoDto)
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<List<dtoDocumento>>(
                    JsonConvert.SerializeObject(new EnvioParametros<dtoBusquedaDocumento>(Login.Usuario(), Login.Password(), aoDto))
                    , Variables.RutaApi() + "api/Documento/BuscarXFechaXUsuario");
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object GuardarDocumento(dtoDocumento aoDto)
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<bool>(
                    JsonConvert.SerializeObject(new EnvioParametros<dtoDocumento>(Login.Usuario(), Login.Password(), aoDto))
                    , Variables.RutaApi() + "api/Documento/Guardar");
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object EliminarDocumento(int aoCodigo)
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<bool>(
                    JsonConvert.SerializeObject(new EnvioParametros<int>(Login.Usuario(), Login.Password(), aoCodigo))
                    , Variables.RutaApi() + "api/Documento/EliminarDocumento");
            }), JsonRequestBehavior.AllowGet);
        }

        /*************
        TIPO DOCUMENTO
        *************/

        [HttpPost]
        public object ObtenerTipoDocumento()
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<List<dtoTipoDocumento>>(
                    JsonConvert.SerializeObject(new EnvioParametros<string>(Login.Usuario(), Login.Password()))
                    , Variables.RutaApi() + "api/TipoDocumento/ObtenerTodos");
            }), JsonRequestBehavior.AllowGet);
        }

        /*******************
        DERIVACION DOCUMENTO
        *******************/

        [HttpPost]
        public object LeerDocumento(dtoDerivacionDocumento aoDto)
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<bool>(
                    JsonConvert.SerializeObject(new EnvioParametros<dtoDerivacionDocumento>(Login.Usuario(), Login.Password(), aoDto))
                    , Variables.RutaApi() + "api/DerivacionDocumento/Leer");
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object AceptarDocumento(dtoDerivacionDocumento aoDto)
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<bool>(
                    JsonConvert.SerializeObject(new EnvioParametros<dtoDerivacionDocumento>(Login.Usuario(), Login.Password(), aoDto))
                    , Variables.RutaApi() + "api/DerivacionDocumento/Aceptar");
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object DevolverDocumento(dtoDerivacionDocumento aoDto)
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<bool>(
                    JsonConvert.SerializeObject(new EnvioParametros<dtoDerivacionDocumento>(Login.Usuario(), Login.Password(), aoDto))
                    , Variables.RutaApi() + "api/DerivacionDocumento/Devolver");
            }), JsonRequestBehavior.AllowGet);
        }

        /**************************
        ESTADO DERIVACION DOCUMENTO
        **************************/

        [HttpPost]
        public object ObtenerEstadoDerivacion()
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<List<dtoEstadoDerivacion>>(
                    JsonConvert.SerializeObject(new EnvioParametros<string>(Login.Usuario(), Login.Password()))
                    , Variables.RutaApi() + "api/EstadoDerivacionDocumento/ObtenerTodos");
            }), JsonRequestBehavior.AllowGet);
        }

        /********
        JEFATURAS
        ********/

        [HttpPost]
        public object ObtenerJefatura()
        {
            return Json(EjecutarPeticion(() =>
            {
                return Post<List<dtoJefatura>>(
                    JsonConvert.SerializeObject(new EnvioParametros<string>(Login.Usuario(), Login.Password()))
                    , Variables.RutaApi() + "api/Jefatura/ObtenerTodos");
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Reporte(string asParametros)
        {
            dtoReporteDerivacion loDto = JsonConvert.DeserializeObject<dtoReporteDerivacion>(asParametros);
            
            if (string.IsNullOrEmpty(loDto.UsuarioSecretaria))
                loDto.UsuarioSecretaria = "%25";

            if (string.IsNullOrEmpty(loDto.EstadoDocumento))
                loDto.EstadoDocumento = "%25";

            Dictionary<string, string> loParametros = new Dictionary<string, string>();
            loParametros.Add("ADT_FECHA_INICIO", loDto.FechaInicio.Value.ToShortDateString());
            loParametros.Add("ADT_FECHA_FIN", loDto.FechaFin.Value.ToShortDateString());
            loParametros.Add("AVCH_USUARIO", loDto.UsuarioSecretaria);
            loParametros.Add("AVCH_ESTADO", loDto.EstadoDocumento);
            string lsRuta = new FormateadorRutaServidorReportes("ADC_DC_001", "SAD")
                                    .ObtenerRuta(loParametros, true, false);
            return Redirect(lsRuta);
        }
    }
}