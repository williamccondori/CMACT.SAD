using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMACT.SAD.Web.Utilidades
{
    public class Login
    {
        public static string Usuario()
        {
            HttpSessionStateWrapper loSession = new HttpSessionStateWrapper(HttpContext.Current.Session);

            string loUsuario = string.Empty;

            if (loSession["sadUsuario"] != null)
                loUsuario = loSession["sadUsuario"].ToString();

            return loUsuario;
        }

        public static string Password()
        {
            HttpSessionStateWrapper loSession = new HttpSessionStateWrapper(HttpContext.Current.Session);

            string loPassword = string.Empty;

            if (loSession["sadPassword"] != null)
                loPassword = loSession["sadPassword"].ToString();

            return loPassword;
        }

        public static void EstablecerSesion(string asUsuario, string asPassword)
        {
            HttpSessionStateWrapper loSession = new HttpSessionStateWrapper(HttpContext.Current.Session);
            loSession["sadUsuario"] = asUsuario;
            loSession["sadPassword"] = asPassword;
        }

        public static void CerrarSesion()
        {
            HttpSessionStateWrapper loSession = new HttpSessionStateWrapper(HttpContext.Current.Session);

            if (loSession["sadUsuario"] != null && loSession["sadPassword"] != null)
                LimpiarSesion(loSession);
            else
                LimpiarSesion(loSession);
        }

        private static void LimpiarSesion(HttpSessionStateWrapper aoSession)
        {
            aoSession["sadUsuario"] = string.Empty;
            aoSession["sadPassword"] = string.Empty;
        }
    }
}