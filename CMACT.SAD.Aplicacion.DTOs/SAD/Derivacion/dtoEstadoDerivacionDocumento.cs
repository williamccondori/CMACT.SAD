using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion
{
    public class dtoEstadoDerivacion
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Indicador { get; set; }

        public dtoEstadoDerivacion()
        {

        }
    }

    public enum EstadoDerivacionDocumentoOperacion
    {
        Todos
    }


    public class EstadoDerivacionDocumento
    {
        public static string Derivado = "D";
        public static string Leido = "L";
        public static string Aceptado = "A";
        public static string Devuelto = "R";
    }
}
