using CMACT.SAD.Dominio.Entidades.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Dominio.Entidades.SAD
{
    public class ceDcEstadoDerivacion : BaseEntidad
    {
        public int CodigoEstadoDerivacion { get; set; }
        public string DescripcionEstadoDerivacion { get; set; }
        public string IndicadorEstadoDerivacion { get; set; }

        public ceDcEstadoDerivacion()
        {

        }
    }
}
