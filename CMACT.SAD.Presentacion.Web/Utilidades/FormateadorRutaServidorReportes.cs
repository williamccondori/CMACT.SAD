using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using CMACT.SAD.Web.Utilidades;

namespace CMACT.SAD.Web.Utils
{

    public class FormateadorRutaServidorReportes
    {
        string isSeccionRutaReporte = string.Empty;
        string isSeccionRutaServidorReportes = string.Empty;
 
        public FormateadorRutaServidorReportes(string asNombreReporte
                                              ,params string[] alstCarpetasServidorReporte)
        {
            foreach (var loCarpetaServidorReporte in alstCarpetasServidorReporte)
            {
                isSeccionRutaReporte += HttpUtility.UrlEncode("/" + loCarpetaServidorReporte);
            }
 
            isSeccionRutaReporte += HttpUtility.UrlEncode("/" + asNombreReporte);
 
        }
 
        public string ObtenerRuta(Dictionary<string,string> alstParametros
                                ,bool abSeCargaAutomaticamente
                                , bool abToolBarVisible)
        {
            string lsRutaReporte = ObtenerSeccionRutaServidorReportes();
            lsRutaReporte += isSeccionRutaReporte;
            lsRutaReporte = CargarOpcionesReporte(abSeCargaAutomaticamente, abToolBarVisible, lsRutaReporte);
 
            lsRutaReporte += ObtenerSeccionRutaParametros(alstParametros);
            
            return lsRutaReporte;
        }
 
        private static string CargarOpcionesReporte(bool abSeCargaAutomaticamente, bool abToolBarVisible, string lsRutaReporte)
        {
            if (abSeCargaAutomaticamente)
            {
                lsRutaReporte += "?rs:Command=Render";
            }
            if (!abToolBarVisible)
            {
                lsRutaReporte += "&rc:Parameters=false";
            }
            return lsRutaReporte += "&rc:Zoom=Page+Width";
        }
 
        private static string ObtenerSeccionRutaParametros(Dictionary<string, string> alstParametros)
        {
            string lsRutaParametros = string.Empty;
 
            foreach (var loParametro in alstParametros)
            {
                lsRutaParametros += "&" + loParametro.Key + "=" + loParametro.Value;    
            }
 
            return lsRutaParametros;
        }
 
        private string ObtenerSeccionRutaServidorReportes()
        {
            if(string.IsNullOrEmpty(isSeccionRutaServidorReportes))
            {
                try
                {
                    isSeccionRutaServidorReportes = Variables.RutaReporte();
                }
                catch(Exception loExecpcion)
                {
                    throw new Exception(loExecpcion.Message);
                }
            }
 
            return isSeccionRutaServidorReportes.TrimEnd('/') + "/Reports_SQLEXPRESS/report";
        }
 
        public void EstablecerSeccionRutaServidorReportes(string asSeccionRutaServidorReportes)
        {
            isSeccionRutaServidorReportes = asSeccionRutaServidorReportes;
        }
    } 



}