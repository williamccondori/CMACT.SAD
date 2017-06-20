using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Dominio.Entidades.SAD;
using CMACT.SAD.Dominio.Logica.SAD;
using CMACT.SAD.Infraestructura.Datos.SAD.Contextos;
using CMACT.SAD.Infraestructura.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Infraestructura.Datos.SAD.Repositorios.Derivacion
{
    public class DerivacionDocumentoRepository : BaseRepository, IDerivacionDocumentoRepository
    {
        SadContext loContexto;

        public DerivacionDocumentoRepository(string asUsuario)
        {
            Usuario = asUsuario;
            loContexto = new SadContext();
        }

        public bool CambiarEstado(dtoDerivacionDocumento aoDto)
        {
            if (aoDto.EstadoObjeto == EstadoObjeto.Modificado)
            {
                ceDcDerivacionDocumento loEntidad = loContexto.DerivacionDocumento.Find(aoDto.CodigoDerivacion);

                loEntidad.Editar(
                    aoDto.CodigoEstado,
                    aoDto.Justificacion,
                    new PistaAuditoria(Usuario, DateTime.Now)
                );

                loContexto.GuardarCambios();
            }
            return true;
        }
    }
}
