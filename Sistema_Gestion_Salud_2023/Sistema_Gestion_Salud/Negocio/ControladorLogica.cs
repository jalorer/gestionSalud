using ControladorPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace Sistema_Gestion_Salud.Negocio
{
    public class ControladorLogica
    {
        private Persistencia p = new Persistencia();
        private EnvioCorreo e = new EnvioCorreo();
        public ControladorLogica() { }
        public DataSet ObtenerUsu(string usuario)
        {
            try
            {
                DataSet dsUsuario = new DataSet();
                dsUsuario = p.ObtenerUsu(usuario);
                return dsUsuario;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerUsuarioPass(string usuario, string clave)
        {
            try
            {
                DataSet dsUsuario = new DataSet();
                dsUsuario = p.ObtenerUsuarioPass(usuario, clave);
                return dsUsuario;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerPermisoPerfil(int perfil, string modulo)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.ObtenerPermisoPerfil(perfil, modulo);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerTipo(int perfil, string modulo)
        {
            try
            {
                DataSet dsTipo = new DataSet();
                dsTipo = p.ObtenerTipo(perfil, modulo);
                return dsTipo;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerMenu(int perfil, string app)
        {
            try
            {
                DataSet dsMenu = new DataSet();
                dsMenu = p.ObtenerMenu(perfil, app);
                return dsMenu;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerUsuarioPermiso(string usuario, int perfil)
        {
            try
            {
                DataSet dsUsuario = new DataSet();
                dsUsuario = p.ObtenerUsuarioPermiso(usuario, perfil);
                return dsUsuario;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerMenuPerfil(string filename, int idPerfil, string modulo)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.ObtenerMenuPerfil(filename, idPerfil, modulo);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }

        public DataSet BuscarDatosTrabajadorxRUT(string rut)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.BuscarDatosTrabajadorxRUT(rut);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet CargarCombosSinParametros(string Procedimiento)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.CargarCombosSinParametros(Procedimiento);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public int GuardarCitaUsuario(int idUsuario, int tipoCita, DateTime fecha, int asistencia)
        {
            try
            {

                int id = p.GuardarCitaUsuario(idUsuario, tipoCita, fecha, asistencia);
                return id;

            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerCitasUsuario(int id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.ObtenerCitasUsuario(id);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);

            }
        }
        public DataSet CargarCombos(string Procedimiento, int parametros)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.CargarCombos(Procedimiento, parametros);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }

        public DataSet Procedimiento_Generico(string Procedimiento, int parametros)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.Procedimiento_Generico(Procedimiento, parametros);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        
        public DataSet Procedimiento_Generico_2_Parametros_Integer(string Procedimiento, int parametro_1, int parametro_2)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.Procedimiento_Generico_2_Parametros_Integer(Procedimiento, parametro_1, parametro_2);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerCitasUsuarioPeriodo(int id, int periodo)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.ObtenerCitasUsuarioPeriodo(id, periodo);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);

            }
        }
        public DataSet ObtenerExamenxCita(int idUsuario, int idCita)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.ObtenerExamenxCita(idUsuario, idCita);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);

            }
        }
        public int GuardarExamenOcupacional(int Id_Cita, int idUsuario, int asistencia, DateTime fechaControl, int estatusExamen, int bateriaExam, int causaContraindicacion)
        {
            try
            {

                int id = p.GuardarExamenOcupacional(Id_Cita, idUsuario, asistencia, fechaControl, estatusExamen, bateriaExam, causaContraindicacion);
                return id;

            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }

        public int GuardarCitaExOcup(int idCita, int idExamen)
        {
            try
            {

                int id = p.GuardarCitaExOcup(idCita, idExamen);
                return id;

            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerResultadosExOcupxCita(int idCita)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.ObtenerResultadosExOcupxCita(idCita);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);

            }
        }
        public int GuardarEliminarParametroAlterado(string tipo, int Id_Cita, int indice)
        {
            try
            {

                int id = p.GuardarEliminarParametroAlterado(tipo, Id_Cita, indice);
                return id;

            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }

        public DataSet BuscarResultadosParametrosAlterados(int idCita)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.BuscarResultadosParametrosAlterados(idCita);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);

            }
        }

        public int GuardarPatologiasCronicas(int usuario, int presenta_pc, int dmri, int hta, int dis, int cardio, string otrasp, string antq, int resistencia)
        {
            try
            {

                int id = p.GuardarPatologiasCronicas(usuario, presenta_pc, dmri, hta, dis, cardio, otrasp, antq, resistencia);
                return id;

            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }

        public int EliminarDocumento(int id)
        {
            try
            {

                int i = p.EliminarDocumento(id);
                return i;

            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }

        public DataSet BuscarDocumento(int idUsuario)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.BuscarDocumento(idUsuario);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public int GuardarDocumento(int idUsuario, string nombreArchivo, string urlArchivo)
        {
            try
            {
                int id = p.GuardarDocumento(idUsuario, nombreArchivo, urlArchivo);
                return id;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public int GuardarControlUsuario(int idExamen, DateTime fechaControl, int AsistenciaControl, int numeroControl)
        {
            try
            {

                int id = p.GuardarControlUsuario(idExamen, fechaControl, AsistenciaControl, numeroControl);
                return id;

            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet BuscarExamenOcupacionalxID_Cita(int idCita)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.BuscarExamenOcupacionalxID_Cita(idCita);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerNumeroControl(int idExamen)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.ObtenerNumeroControl(idExamen);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerControlesUsuario(int id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.ObtenerControlesUsuario(id);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);

            }
        }
        public DataSet VerificarSiExisteControles(int idExamen, int idUsuario)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.VerificarSiExisteControles(idExamen, idUsuario);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);

            }
        }
        public int GuardarComentarioBitacora(DateTime fecha, int idTipoEntrada, string comentario, string idUsuarioComentario, int idUsuario, string subTipo)
        {
            try
            {
                int id = p.GuardarComentarioBitacora(fecha, idTipoEntrada, comentario, idUsuarioComentario, idUsuario, subTipo);
                return id;
            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
        public DataSet ObtenerComentariosBitacora(int idUsuario,int idTipoEntrada)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.ObtenerComentariosBitacora(idUsuario, idTipoEntrada);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);

            }
        }
        public DataSet ObtenerUltimoEstadoExpOcupacional(int idUsuario)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = p.ObtenerUltimoEstadoExpOcupacional(idUsuario);
                return ds;
            }
            catch (InvalidCastException e)
            {
                throw (e);

            }
        }
        public int GuardarPsicosensometrico(int id_usuario, DateTime fecha_control, DateTime fecha_vencimiento, int id_vehiculo, int id_causa_contraindicacion, int id_estado_psm, string aux_observacion,string pendientes)
        {
            try
            {

                int id = p.GuardarPsicosensometrico(id_usuario, fecha_control, fecha_vencimiento, id_vehiculo, id_causa_contraindicacion, id_estado_psm, aux_observacion,pendientes);
                return id;

            }
            catch (InvalidCastException e)
            {
                throw (e);
            }
        }
    }
}