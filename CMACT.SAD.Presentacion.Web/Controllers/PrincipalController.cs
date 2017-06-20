using CMACT.SAD.Aplicacion.DTOs.SAD.Inicio;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Presentacion.Web.Models.Derivacion;
using CMACT.SAD.Presentacion.Web.Models.Inicio;
using CMACT.SAD.Web.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilidades = CMACT.SAD.Web.Utilidades;

namespace CMACT.SAD.Presentacion.Web.Controllers
{
    public class PrincipalController : BaseInicioController
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (string.IsNullOrEmpty(Utilidades.Login.Usuario()) || string.IsNullOrEmpty(Utilidades.Login.Password()))
                return View(new LoginViewModel());
            else
                return RedirectToAction("Inicio", "Principal");
        }

        [HttpPost]
        public ActionResult Login(string asParametros)
        {
            try
            {
                dtoLogin lodto = JsonConvert.DeserializeObject<dtoLogin>(asParametros);

                ResultadoOperacion<bool> loResultado = Post<bool>(
                    JsonConvert.SerializeObject(
                        new EnvioParametros<dtoLogin>(lodto.Usuario, lodto.Password, lodto))
                    , Variables.RutaApi() + "api/Seguridad/ValidarUsuario");

                if (loResultado.Error)
                    throw new Exception(loResultado.Mensaje);

                if (loResultado.Datos)
                    Utilidades.Login.EstablecerSesion(lodto.Usuario, lodto.Password);
                else
                    throw new Exception("Los datos ingresados son inválidos");

                return RedirectToAction("Inicio", "Principal");
            }
            catch (Exception aoExcepcion)
            {
                EstablecerMensajeError(aoExcepcion.Message);
                return View(new LoginViewModel());
            }
        }

        [HttpGet]
        public ActionResult Inicio()
        {
            if (string.IsNullOrEmpty(Utilidades.Login.Usuario()) || string.IsNullOrEmpty(Utilidades.Login.Password()))
            {
                EstablecerMensajeError(ResultadoMensaje.ErrorSesion);
                return RedirectToAction("Login", "Principal");
            }
            else
                return View(new InicioViewModel());
        }

        [HttpGet]
        public ActionResult Error()
        {
            if (string.IsNullOrEmpty(Utilidades.Login.Usuario()) || string.IsNullOrEmpty(Utilidades.Login.Password()))
            {
                EstablecerMensajeError(ResultadoMensaje.ErrorSesion);
                return RedirectToAction("Login", "Principal");
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Cerrar()
        {
            Utilidades.Login.CerrarSesion();
            return RedirectToAction("Login", "Principal");
        }
    }
}