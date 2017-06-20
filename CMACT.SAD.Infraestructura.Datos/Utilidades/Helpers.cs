using CMACT.SAD.Aplicacion.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Infraestructura.Datos.Utilidades
{
    public class Helpers
    {
        public static EntityState ConvertirAEntityState(EstadoObjeto estadoObjeto)
        {
            switch (estadoObjeto)
            {
                case EstadoObjeto.SinCambios:
                    return EntityState.Unchanged;
                case EstadoObjeto.Nuevo:
                    return EntityState.Added;
                case EstadoObjeto.Modificado:
                    return EntityState.Modified;
                case EstadoObjeto.Borrado:
                    return EntityState.Modified;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}
