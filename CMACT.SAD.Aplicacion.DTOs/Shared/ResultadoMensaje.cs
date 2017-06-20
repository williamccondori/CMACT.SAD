using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.Shared
{
    public class ResultadoMensaje
    {
        public static string OperacionIncorrecta = "La operación seleccionada no es váida o no existe";
        public static string JefaturaIncorrecta = "Debe seleccionar una o más jefaturas.";
        public static string DocumentoIncorrecto = "Debe seleccionar un archivo válido.";
        public static string Correcto = "Se han guardado los cambios";
        public static string ErrorSesion = "Su sesión a expirado, ingrese sus credenciales nuevamente para continuar";
    }
}
