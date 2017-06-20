using CMACT.SAD.Dominio.Logica.SAD;
using CMACT.SAD.Infraestructura.Datos.SAD.Contextos;
using CMACT.SAD.Infraestructura.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Dominio.Entidades.SAD;

namespace CMACT.SAD.Infraestructura.Datos.SAD.Repositorios.Derivacion
{
    public class TipoDocumentoRepository : BaseRepository, ITipoDocumentoRepository
    {
        SadContext loContexto;

        public TipoDocumentoRepository(string asUsuario)
        {
            Usuario = asUsuario;
            loContexto = new SadContext();
        }

        public bool Eliminar(int aiCodigo)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(dtoTipoDocumento aoDto)
        {
            return EjecutarConsulta(() =>
            {
                if (aoDto.EstadoObjeto == EstadoObjeto.Nuevo)
                    GuardarNuevo(aoDto);
                else if (aoDto.EstadoObjeto == EstadoObjeto.Modificado)
                    GuardarModificado(aoDto);
                else
                    throw new Exception(ResultadoMensaje.OperacionIncorrecta);

                loContexto.GuardarCambios();

                return true;
            });
        }

        public IList<dtoTipoDocumento> ObtenerTodo()
        {
            return EjecutarConsulta(() =>
            {
                ICollection<ceDcTipoDocumento> loEntidad = loContexto.TipoDocumento
                    .Where(p=> p.IndicadorEstado == EstadoEntidad.Activo)
                    .ToList();

                return loEntidad.Select(p => new dtoTipoDocumento()
                {
                    Codigo = p.CodigoTipoDocumento,
                    Descripcion = p.DescripcionTipoDocumento
                }).ToList();
            });
        }

        private void GuardarNuevo(dtoTipoDocumento aoDto)
        {
            ceDcTipoDocumento loEntidad = new ceDcTipoDocumento(
                aoDto.Descripcion
                , new PistaAuditoria(Usuario, DateTime.Now)
                );

            loContexto.TipoDocumento.Add(loEntidad);
        }

        private void GuardarModificado(dtoTipoDocumento aoDto)
        {
            if (aoDto.EstadoObjeto == EstadoObjeto.Modificado)
            {
                ceDcTipoDocumento loEntidad = loContexto.TipoDocumento.Find(aoDto.Codigo);

                loEntidad.Editar(
                    aoDto.Descripcion,
                    new PistaAuditoria(Usuario, DateTime.Now)
                );
            }
        }
    }
}