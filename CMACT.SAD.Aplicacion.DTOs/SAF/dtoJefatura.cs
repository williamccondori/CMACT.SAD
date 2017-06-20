using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.SAF
{
    public class dtoJefatura
    {
        public string NumeroUnidadOrganica { get; set; }
        public string NombreUnidadOrganica { get; set; }

        public string CodigoEncargado { get; set; }
        public string NombreEncargado { get; set; }

        public bool Estado { get; set; }

        public dtoJefatura()
        {

        }
    }
}
