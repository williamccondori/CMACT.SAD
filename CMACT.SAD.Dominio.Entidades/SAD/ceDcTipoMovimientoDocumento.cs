using CMACT.SAD.Dominio.Entidades.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Dominio.Entidades.SAD
{
    public class ceDcTipoMovimientoDocumento : BaseEntidad
    {
        public int CodigoTipoMovimientoDocumento { get; set; }
        public string DescripcionTipoMovimientoDocumento { get; set; }

        public ceDcTipoMovimientoDocumento()
        {

        }
    }
}
