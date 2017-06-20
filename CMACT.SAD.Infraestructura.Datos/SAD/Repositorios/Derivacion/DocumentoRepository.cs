using CMACT.SAD.Dominio.Logica.SAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Infraestructura.Datos.SAD.Contextos;
using CMACT.SAD.Infraestructura.Datos.Shared;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Dominio.Entidades.SAD;

namespace CMACT.SAD.Infraestructura.Datos.SAD.Repositorios.Derivacion
{
    public class DocumentoRepository : BaseRepository, IDocumentoRepository
    {
        SadContext loContexto;

        public DocumentoRepository(string asUsuario)
        {
            Usuario = asUsuario;
            loContexto = new SadContext();
        }

        public IList<dtoDocumento> ObtenerTodo()
        {
            return EjecutarConsulta(() =>
            {
                ICollection<ceDcDocumento> loEntidad = loContexto.Documento
                    .Include(p => p.TipoDocumentoX)
                    .Include(p => p.DerivacionDocumentoS)
                    .Include(p => p.DerivacionDocumentoS.Select(d => d.EstadoDerivacionX))
                    .Where(p => p.IndicadorEstado == EstadoEntidad.Activo)
                    .ToList();

                return loEntidad.Select(p => new dtoDocumento()
                {
                    Codigo = p.CodigoDocumento,
                    Numero = p.NumeroDocumento,
                    CodigoTipo = p.CodigoTipoDocumento,
                    Asunto = p.DescripcionAsunto,
                    NombreArchivo = p.NombreDocumento,
                    ContenidoArchivo = p.DescripcionContenido,
                    OrganoEmisor = p.DescripcionOrganoEmisor,
                    FechaRegistro = p.FechaRegistro ?? DateTime.Now,
                    UsuarioRegistro = p.CodigoUsuarioRegistro,
                    ObjetoTipoDocumento = new dtoTipoDocumento()
                    {
                        Codigo = p.TipoDocumentoX.CodigoTipoDocumento,
                        Descripcion = p.TipoDocumentoX.DescripcionTipoDocumento
                    },
                    ListaDerivacionDocumento = p.DerivacionDocumentoS.Select(d => new dtoDerivacionDocumento()
                    {
                        CodigoDerivacion = d.CodigoDerivacionDocumento,
                        CodigoDocumento = d.CodigoDocumento,
                        CodigoEstado = d.CodigoEstadoDerivacion,
                        CodigoUsuario = d.CodigoUsuario,
                        NombreUsuario = d.NombreUsuario,
                        NumeroUnidadOrganica = d.NumeroUnidadOrganica,
                        NombreUnidadOrganica = d.NombreUnidadOrganica,
                        Justificacion = d.DescripcionJustificacion,
                        IndicadorDescargar = d.IndicadorDescargar,
                        IndicadorVisualizar = d.IndicadorVisualizar,
                        FechaDerivacion = d.FechaRegistro ?? DateTime.Now,
                        FechaAtencion = d.FechaModifico ?? DateTime.Now,
                        FechaDevolucion = d.FechaModifico ?? DateTime.Now,
                        ObjetoEstadoDerivacion = new dtoEstadoDerivacion()
                        {
                            Codigo = d.EstadoDerivacionX.CodigoEstadoDerivacion,
                            Descripcion = d.EstadoDerivacionX.DescripcionEstadoDerivacion,
                            Indicador = d.EstadoDerivacionX.IndicadorEstadoDerivacion
                        }
                    }).ToList()
                }).ToList();
            });
        }

        public IList<dtoDocumento> BuscarXFecha(dtoBusquedaDocumento aoDto)
        {
            return EjecutarConsulta(() =>
            {
                ICollection<ceDcDocumento> loEntidad = loContexto.Documento
                    .Include(p => p.TipoDocumentoX)
                    .Include(p => p.DerivacionDocumentoS)
                    .Include(p => p.DerivacionDocumentoS.Select(d => d.EstadoDerivacionX))
                    .Where(p => p.IndicadorEstado == EstadoEntidad.Activo)
                    .Where(p => p.FechaRegistro > aoDto.FechaInicio && p.FechaRegistro < aoDto.FechaFin)
                    .ToList();

                return loEntidad.Select(p => new dtoDocumento()
                {
                    Codigo = p.CodigoDocumento,
                    Numero = p.NumeroDocumento,
                    CodigoTipo = p.CodigoTipoDocumento,
                    Asunto = p.DescripcionAsunto,
                    NombreArchivo = p.NombreDocumento,
                    ContenidoArchivo = p.DescripcionContenido,
                    OrganoEmisor = p.DescripcionOrganoEmisor,
                    FechaRegistro = p.FechaRegistro ?? DateTime.Now,
                    UsuarioRegistro = p.CodigoUsuarioRegistro,
                    ObjetoTipoDocumento = new dtoTipoDocumento()
                    {
                        Codigo = p.TipoDocumentoX.CodigoTipoDocumento,
                        Descripcion = p.TipoDocumentoX.DescripcionTipoDocumento
                    },
                    ListaDerivacionDocumento = p.DerivacionDocumentoS.Select(d => new dtoDerivacionDocumento()
                    {
                        CodigoDerivacion = d.CodigoDerivacionDocumento,
                        CodigoDocumento = d.CodigoDocumento,
                        CodigoEstado = d.CodigoEstadoDerivacion,
                        CodigoUsuario = d.CodigoUsuario,
                        NombreUsuario = d.NombreUsuario,
                        NumeroUnidadOrganica = d.NumeroUnidadOrganica,
                        NombreUnidadOrganica = d.NombreUnidadOrganica,
                        Justificacion = d.DescripcionJustificacion,
                        IndicadorDescargar = d.IndicadorDescargar,
                        IndicadorVisualizar = d.IndicadorVisualizar,
                        FechaDerivacion = d.FechaRegistro ?? DateTime.Now,
                        FechaAtencion = d.FechaModifico ?? DateTime.Now,
                        FechaDevolucion = d.FechaModifico ?? DateTime.Now,
                        ObjetoEstadoDerivacion = new dtoEstadoDerivacion()
                        {
                            Codigo = d.EstadoDerivacionX.CodigoEstadoDerivacion,
                            Descripcion = d.EstadoDerivacionX.DescripcionEstadoDerivacion,
                            Indicador = d.EstadoDerivacionX.IndicadorEstadoDerivacion
                        }
                    }).ToList()
                }).ToList();
            });
        }

        public bool Guardar(dtoDocumento aoDto)
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

        public bool Eliminar(int aiCodigo)
        {
            return true;
        }

        private void GuardarNuevo(dtoDocumento aoDto)
        {
            ceDcDocumento loEntidad = new ceDcDocumento(
                aoDto.CodigoTipo
                , aoDto.Numero
                , aoDto.OrganoEmisor
                , aoDto.NombreArchivo
                , aoDto.ContenidoArchivo
                , aoDto.Asunto
                , aoDto.ListaDerivacionDocumento.Select(p => new ceDcDerivacionDocumento(
                    loContexto.EstadoDerivacion
                        .Where(g => g.IndicadorEstadoDerivacion == EstadoDerivacionDocumento.Derivado)
                        .FirstOrDefault().CodigoEstadoDerivacion
                     , p.NumeroUnidadOrganica
                     , p.NombreUnidadOrganica
                     , p.CodigoUsuario
                     , p.NombreUsuario
                     , p.Justificacion
                     , p.IndicadorVisualizar
                     , p.IndicadorDescargar
                     , new PistaAuditoria(Usuario, DateTime.Now))).ToList()
                , new PistaAuditoria(Usuario, DateTime.Now)
            );

            loContexto.Documento.Add(loEntidad);
        }

        private void GuardarModificado(dtoDocumento aoDto)
        {
            if (aoDto.EstadoObjeto == EstadoObjeto.Modificado)
            {
                ceDcDocumento loEntidad = loContexto.Documento
                    .Include(p => p.TipoDocumentoX)
                    .Include(p => p.DerivacionDocumentoS)
                    .Include(p => p.DerivacionDocumentoS.Select(d => d.EstadoDerivacionX))
                    .SingleOrDefault(x => x.CodigoDocumento == aoDto.Codigo);

                loEntidad.Editar(
                    aoDto.CodigoTipo,
                    aoDto.Numero,
                    aoDto.OrganoEmisor,
                    aoDto.NombreArchivo,
                    aoDto.ContenidoArchivo,
                    aoDto.Asunto,
                    new PistaAuditoria(Usuario, DateTime.Now)
                );
            }
        }

        public dtoDocumento ObtenerXCodigo(int aiCodigo)
        {
            return EjecutarConsulta(() =>
            {
                ceDcDocumento loEntidad = loContexto.Documento
                    .Include(p => p.TipoDocumentoX)
                    .Include(p => p.DerivacionDocumentoS)
                    .Include(p => p.DerivacionDocumentoS.Select(d => d.EstadoDerivacionX))
                    .SingleOrDefault(x => x.CodigoDocumento == aiCodigo);

                return new dtoDocumento()
                {
                    Codigo = loEntidad.CodigoDocumento,
                    Numero = loEntidad.NumeroDocumento,
                    CodigoTipo = loEntidad.CodigoTipoDocumento,
                    Asunto = loEntidad.DescripcionAsunto,
                    NombreArchivo = loEntidad.NombreDocumento,
                    ContenidoArchivo = loEntidad.DescripcionContenido,
                    OrganoEmisor = loEntidad.DescripcionOrganoEmisor,
                    FechaRegistro = loEntidad.FechaRegistro ?? DateTime.Now,
                    UsuarioRegistro = loEntidad.CodigoUsuarioRegistro,
                    ObjetoTipoDocumento = new dtoTipoDocumento()
                    {
                        Codigo = loEntidad.TipoDocumentoX.CodigoTipoDocumento,
                        Descripcion = loEntidad.TipoDocumentoX.DescripcionTipoDocumento
                    },
                    ListaDerivacionDocumento = loEntidad.DerivacionDocumentoS.Select(d => new dtoDerivacionDocumento()
                    {
                        CodigoDerivacion = d.CodigoDerivacionDocumento,
                        CodigoDocumento = d.CodigoDocumento,
                        CodigoEstado = d.CodigoEstadoDerivacion,
                        CodigoUsuario = d.CodigoUsuario,
                        NombreUsuario = d.NombreUsuario,
                        NumeroUnidadOrganica = d.NumeroUnidadOrganica,
                        NombreUnidadOrganica = d.NombreUnidadOrganica,
                        Justificacion = d.DescripcionJustificacion,
                        IndicadorDescargar = d.IndicadorDescargar,
                        IndicadorVisualizar = d.IndicadorVisualizar,
                        FechaDerivacion = d.FechaRegistro ?? DateTime.Now,
                        FechaAtencion = d.FechaModifico ?? DateTime.Now,
                        FechaDevolucion = d.FechaModifico ?? DateTime.Now,
                        ObjetoEstadoDerivacion = new dtoEstadoDerivacion()
                        {
                            Codigo = d.EstadoDerivacionX.CodigoEstadoDerivacion,
                            Descripcion = d.EstadoDerivacionX.DescripcionEstadoDerivacion,
                            Indicador = d.EstadoDerivacionX.IndicadorEstadoDerivacion
                        }
                    }).ToList()
                };
            });
        }
    }
}
