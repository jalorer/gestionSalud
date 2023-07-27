using Controlador;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControladorPersistencia
{
    public class Persistencia
    {
        private Conexion conn = new Conexion();

        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private static readonly ILog logger = LogManager.GetLogger(typeof(Persistencia));

        public Persistencia() { }
        public DataSet ObtenerUsu(string usuario)
        {
            DataSet dsUsuario = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("ObtenerUsu", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@usuario", OleDbType.VarChar);
                adaptador.SelectCommand.Parameters["@usuario"].Value = usuario;
                adaptador.Fill(dsUsuario);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerUsu - Persistencia", ex);
            }
            return dsUsuario;
        }
        public DataSet ObtenerUsuarioPass(string usuario, string clave)
        {
            DataSet dsUsuario = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("ObtenerUsuarioPass", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@usuario", OleDbType.VarChar);
                adaptador.SelectCommand.Parameters["@usuario"].Value = usuario;
                adaptador.SelectCommand.Parameters.Add("@clave", OleDbType.VarChar);
                adaptador.SelectCommand.Parameters["@clave"].Value = clave;

                adaptador.Fill(dsUsuario);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerUsuarioPass - Persistencia", ex);
            }
            return dsUsuario;
        }
        public DataSet ObtenerPermisoPerfil(int perfil, string modulo)
        {
            DataSet dsTipo = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("ObtenerPermisoPerfil", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@modulo", OleDbType.VarChar);
                adaptador.SelectCommand.Parameters["@modulo"].Value = modulo;
                adaptador.SelectCommand.Parameters.Add("@perfil", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@perfil"].Value = perfil;
                adaptador.Fill(dsTipo);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerPermisoPerfil - Persistencia", ex);
            }
            return dsTipo;
        }
        public DataSet ObtenerTipo(int perfil, string modulo)
        {
            DataSet dsTipo = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("ObtenerTipo", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@perfil", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@perfil"].Value = perfil;
                adaptador.SelectCommand.Parameters.Add("@modulo", OleDbType.VarChar);
                adaptador.SelectCommand.Parameters["@modulo"].Value = modulo;
                adaptador.Fill(dsTipo);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerTipo - Persistencia", ex);
            }
            return dsTipo;
        }
        public DataSet ObtenerMenu(int perfil, string app)
        {
            DataSet dsMenu = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("ObtenerMenu", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@perfil", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@perfil"].Value = perfil;
                adaptador.SelectCommand.Parameters.Add("@app", OleDbType.VarChar);
                adaptador.SelectCommand.Parameters["@app"].Value = app;
                adaptador.Fill(dsMenu);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerMenu - Persistencia", ex);
            }
            return dsMenu;
        }
        public DataSet ObtenerUsuarioPermiso(string usuario, int perfil)
        {
            DataSet dsUsuario = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("ObtenerUsuarioPermiso", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@usuario", OleDbType.VarChar);
                adaptador.SelectCommand.Parameters["@usuario"].Value = usuario;
                adaptador.SelectCommand.Parameters.Add("@perfil", OleDbType.VarChar);
                adaptador.SelectCommand.Parameters["@perfil"].Value = perfil;

                adaptador.Fill(dsUsuario);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerUsuarioPermiso - Persistencia", ex);
            }
            return dsUsuario;
        }
        public DataSet ObtenerMenuPerfil(string filename, int idPerfil, string modulo)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("ObtenerMenuPerfil", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@page", OleDbType.VarChar);
                adaptador.SelectCommand.Parameters["@page"].Value = filename;

                adaptador.SelectCommand.Parameters.Add("@perfil", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@perfil"].Value = idPerfil;

                adaptador.SelectCommand.Parameters.Add("@app", OleDbType.VarChar);
                adaptador.SelectCommand.Parameters["@app"].Value = modulo;

                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerMenuPerfil - Persistencia", ex);
            }
            return ds;
        }

        public DataSet BuscarDatosTrabajadorxRUT(string rut)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_BuscarDatosTrabajadorxRUT", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@rut", OleDbType.VarChar);
                adaptador.SelectCommand.Parameters["@rut"].Value = rut;

                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método BuscarDatosTrabajadorxRUT - Persistencia", ex);
            }
            return ds;
        }
        public DataSet CargarCombosSinParametros(string Procedimiento)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter(Procedimiento, conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;

                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método CargarCombos - Persistencia", ex);
            }
            return ds;
        }
        public int GuardarCitaUsuario(int idUsuario, int tipoCita, DateTime fecha, int asistencia)
        {
            try
            {
                comando = new OleDbCommand("GS_GuardarCitaUsuario", conn.getConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idUsuario", OleDbType.Integer);
                comando.Parameters["@idUsuario"].Value = idUsuario;
                comando.Parameters.Add("@tipoCita", OleDbType.Integer);
                comando.Parameters["@tipoCita"].Value = tipoCita;
                comando.Parameters.Add("@fechaCita", OleDbType.Date);
                comando.Parameters["@fechaCita"].Value = fecha;
                comando.Parameters.Add("@asistencia", OleDbType.Integer);
                comando.Parameters["@asistencia"].Value = asistencia;

                int id = Convert.ToInt32(comando.ExecuteScalar());
                conn.cerrar();
                return id;
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " GuardarCitaUsuario - Persistencia", ex);
                return -1;
            }
        }
        public DataSet ObtenerCitasUsuario(int idUsuario)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_ObtenerCitasUsuario", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idUsuario", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idUsuario"].Value = idUsuario;

                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerCitasUsuario - Persistencia", ex);
            }
            return ds;
        }
        public DataSet CargarCombos(string Procedimiento, int idUsuario)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter(Procedimiento, conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idUsuario", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idUsuario"].Value = idUsuario;

                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método CargarCombos - Persistencia", ex);
            }
            return ds;
        }

        public DataSet Procedimiento_Generico(string Procedimiento, int parametros)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter(Procedimiento, conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@parametros", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@parametros"].Value = parametros;

                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método Procedimiento_Generico - Persistencia", ex);
            }
            return ds;
        }
        public DataSet Procedimiento_Generico_2_Parametros_Integer(string Procedimiento, int parametro_1, int parametro_2)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter(Procedimiento, conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@parametro_1", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@parametro_1"].Value = parametro_1;
                adaptador.SelectCommand.Parameters.Add("@parametro_2", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@parametro_2"].Value = parametro_2;

                adaptador.Fill(ds);
                conn.cerrar();
            } 
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método Procedimiento_Generico_2_Parametros_Integer - Persistencia", ex);
            }
            return ds;
        }
        public DataSet ObtenerCitasUsuarioPeriodo(int idUsuario, int periodo)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_ObtenerCitasUsuarioPeriodo", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idUsuario", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idUsuario"].Value = idUsuario;
                adaptador.SelectCommand.Parameters.Add("@periodo", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@periodo"].Value = periodo;
                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerCitasUsuarioPeriodo - Persistencia", ex);
            }
            return ds;
        }
        public DataSet ObtenerExamenxCita(int idUsuario, int idCita)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_ObtenerExamenxCita", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idUsuario", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idUsuario"].Value = idUsuario;
                adaptador.SelectCommand.Parameters.Add("@idCita", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idCita"].Value = idCita;
                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerExamenxCita - Persistencia", ex);
            }
            return ds;
        }
        public int GuardarExamenOcupacional(int Id_Cita, int idUsuario, int asistencia, DateTime fechaControl, int estatusExamen, int bateriaExam, int causaContraindicacion)
        {
            try
            {
                comando = new OleDbCommand("GS_GuardarExamenOcupacional", conn.getConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Id_Cita", OleDbType.Integer);
                comando.Parameters["@Id_Cita"].Value = Id_Cita;
                comando.Parameters.Add("@idUsuario", OleDbType.Integer);
                comando.Parameters["@idUsuario"].Value = idUsuario;
                comando.Parameters.Add("@asistencia", OleDbType.Integer);
                comando.Parameters["@asistencia"].Value = asistencia;
                comando.Parameters.Add("@fechaControl", OleDbType.Date);
                comando.Parameters["@fechaControl"].Value = fechaControl;
                comando.Parameters.Add("@estatusExamen", OleDbType.Integer);
                comando.Parameters["@estatusExamen"].Value = estatusExamen;

                comando.Parameters.Add("@bateriaExam", OleDbType.Integer);
                comando.Parameters["@bateriaExam"].Value = bateriaExam;

                comando.Parameters.Add("@causaContraindicacion", OleDbType.Integer);
                comando.Parameters["@causaContraindicacion"].Value = causaContraindicacion;

                int id = Convert.ToInt32(comando.ExecuteScalar());
                conn.cerrar();
                return id;
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " GuardarExamenOcupacional - Persistencia", ex);
                return -1;
            }
        }

        public int GuardarCitaExOcup(int idCita, int idExamen)
        {
            try
            {
                comando = new OleDbCommand("GS_GuardarCitaExOcup", conn.getConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idCita", OleDbType.Integer);
                comando.Parameters["@idCita"].Value = idCita;
                comando.Parameters.Add("@idExamen", OleDbType.Integer);
                comando.Parameters["@idExamen"].Value = idExamen;

                int id = Convert.ToInt32(comando.ExecuteScalar());
                conn.cerrar();
                return id;
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " GuardarCitaExOcup - Persistencia", ex);
                return -1;
            }
        }
        public DataSet ObtenerResultadosExOcupxCita(int idCita)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_ObtenerResultadosExOcupxCita", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idCita", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idCita"].Value = idCita;
                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerResultadosExOcupxCita - Persistencia", ex);
            }
            return ds;
        }
        public int GuardarEliminarParametroAlterado(string tipo, int Id_Cita, int indice)
        {
            try
            {
                comando = new OleDbCommand("GS_GuardarEliminarParametroAlterado", conn.getConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@tipo", OleDbType.VarChar);
                comando.Parameters["@tipo"].Value = tipo;
                comando.Parameters.Add("@Id_Cita", OleDbType.Integer);
                comando.Parameters["@Id_Cita"].Value = Id_Cita;
                comando.Parameters.Add("@indice", OleDbType.Integer);
                comando.Parameters["@indice"].Value = indice;

                int id = Convert.ToInt32(comando.ExecuteScalar());
                conn.cerrar();
                return id;
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " GuardarEliminarParametroAlterado - Persistencia", ex);
                return -1;
            }
        }
        public DataSet BuscarResultadosParametrosAlterados(int idCita)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_BuscarResultadosParametrosAlteradosxCita", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idCita", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idCita"].Value = idCita;
                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método BuscarResultadosParametrosAlterados - Persistencia", ex);
            }
            return ds;
        }

        public int GuardarPatologiasCronicas(int usuario, int presenta_pc, int dmri, int hta, int dis, int cardio, string otrasp, string antq, int resistencia)
        {
            try
            {
                comando = new OleDbCommand("GS_GuardarPatologiasCronicas", conn.getConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@usuario", OleDbType.Integer);
                comando.Parameters["@usuario"].Value = usuario;
                comando.Parameters.Add("@presenta_pc", OleDbType.Integer);
                comando.Parameters["@presenta_pc"].Value = presenta_pc;
                comando.Parameters.Add("@dmri", OleDbType.Integer);
                comando.Parameters["@dmri"].Value = dmri;
                comando.Parameters.Add("@hta", OleDbType.Integer);
                comando.Parameters["@hta"].Value = hta;
                comando.Parameters.Add("@dis", OleDbType.Integer);
                comando.Parameters["@dis"].Value = dis;
                comando.Parameters.Add("@cardio", OleDbType.Integer);
                comando.Parameters["@cardio"].Value = cardio;
                comando.Parameters.Add("@otrasp", OleDbType.VarChar);
                comando.Parameters["@otrasp"].Value = otrasp;
                comando.Parameters.Add("@antq", OleDbType.VarChar);
                comando.Parameters["@antq"].Value = antq;
                comando.Parameters.Add("@resistencia", OleDbType.VarChar);
                comando.Parameters["@resistencia"].Value = resistencia;
                int id = Convert.ToInt32(comando.ExecuteScalar());
                conn.cerrar();
                return id;
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " GuardarPatologiasCronicas - Persistencia", ex);
                return -1;
            }
        }
        public int EliminarDocumento(int idDoc)
        {
            try
            {

                comando = new OleDbCommand("GS_EliminarDocumento", conn.getConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ID", OleDbType.Integer);
                comando.Parameters["@ID"].Value = idDoc;


                comando.ExecuteScalar();
                int id = 0;
                conn.cerrar();
                return id;

            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " EliminarDocumento - Persistencia", ex);
                return -1;
            }
        }

        public DataSet BuscarDocumento(int idUsuario)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_BuscarDocumento", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idUsuario", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idUsuario"].Value = idUsuario;
                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método BuscarDocumento - Persistencia", ex);
            }
            return ds;
        }
        public int GuardarDocumento(int idUsuario, string nombreArchivo, string urlArchivo)
        {
            try
            {
                comando = new OleDbCommand("GS_GuardarDocumento", conn.getConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idUsuario", OleDbType.Integer);
                comando.Parameters["@idUsuario"].Value = idUsuario;
                comando.Parameters.Add("@nombre_archivo", OleDbType.VarChar);
                comando.Parameters["@nombre_archivo"].Value = nombreArchivo;
                comando.Parameters.Add("@url_archivo", OleDbType.VarChar);
                comando.Parameters["@url_archivo"].Value = urlArchivo;
                int id = Convert.ToInt32(comando.ExecuteScalar());

                conn.cerrar();
                return id;
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " GuardarDocumento - Persistencia", ex);
                return 0;
            }
        }
        public int GuardarControlUsuario(int idExamen, DateTime fechaControl, int AsistenciaControl, int numeroControl)
        {
            try
            {
                comando = new OleDbCommand("GS_GuardarControlUsuario", conn.getConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idExamen", OleDbType.Integer);
                comando.Parameters["@idExamen"].Value = idExamen;
                comando.Parameters.Add("@fechaControl", OleDbType.Date);
                comando.Parameters["@fechaControl"].Value = fechaControl;
                comando.Parameters.Add("@AsistenciaControl", OleDbType.Integer);
                comando.Parameters["@AsistenciaControl"].Value = AsistenciaControl;
                comando.Parameters.Add("@numeroControl", OleDbType.Integer);
                comando.Parameters["@numeroControl"].Value = numeroControl;

                int id = Convert.ToInt32(comando.ExecuteScalar());
                conn.cerrar();
                return id;
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " GuardarControlUsuario - Persistencia", ex);
                return -1;
            }
        }
        public DataSet BuscarExamenOcupacionalxID_Cita(int idCita)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_BuscarExamenOcupacionalxID_Cita", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idCita", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idCita"].Value = idCita;
                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método BuscarExamenOcupacionalxID_Cita - Persistencia", ex);
            }
            return ds;
        }
        public DataSet ObtenerNumeroControl(int idExamen)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_ObtenerNumeroControl", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idExamen", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idExamen"].Value = idExamen;
                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerNumeroControl - Persistencia", ex);
            }
            return ds;
        }
        public DataSet ObtenerControlesUsuario(int idExamen)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_ObtenerControlesUsuario", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idExamen", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idExamen"].Value = idExamen;

                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerControlesUsuario - Persistencia", ex);
            }
            return ds;
        }

        public DataSet VerificarSiExisteControles(int idExamen, int idUsuario)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_VerificarSiExisteControles", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idExamen", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idExamen"].Value = idExamen;
                adaptador.SelectCommand.Parameters.Add("@idUsuario", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idUsuario"].Value = idUsuario;
                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método VerificarSiExisteControles - Persistencia", ex);
            }
            return ds;
        }

        public int GuardarComentarioBitacora(DateTime fecha, int idTipoEntrada, string comentario, string idUsuarioComentario, int idUsuario, string subTipo)
        {
            try
            {
                comando = new OleDbCommand("GS_GuardarComentarioBitacora", conn.getConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@fecha", OleDbType.Date);
                comando.Parameters["@fecha"].Value = fecha;
                comando.Parameters.Add("@idTipoEntrada", OleDbType.Integer);
                comando.Parameters["@idTipoEntrada"].Value = idTipoEntrada;
                comando.Parameters.Add("@comentario", OleDbType.VarChar);
                comando.Parameters["@comentario"].Value = comentario;
                comando.Parameters.Add("@idUsuarioComentario", OleDbType.VarChar);
                comando.Parameters["@idUsuarioComentario"].Value = idUsuarioComentario;
                comando.Parameters.Add("@idUsuario", OleDbType.Integer);
                comando.Parameters["@idUsuario"].Value = idUsuario;
                comando.Parameters.Add("@subTipo", OleDbType.VarChar);
                comando.Parameters["@subTipo"].Value = subTipo;

                int id = Convert.ToInt32(comando.ExecuteScalar());
                conn.cerrar();
                return id;
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " GuardarComentarioBitacora - Persistencia", ex);
                return -1;
            }
        }
        public DataSet ObtenerComentariosBitacora(int idUsuario, int idTipoEntrada)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_ObtenerComentariosBitacora", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idUsuario", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idUsuario"].Value = idUsuario;
                adaptador.SelectCommand.Parameters.Add("@idTipoEntrada", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idTipoEntrada"].Value = idTipoEntrada;
                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerComentariosBitacora - Persistencia", ex);
            }
            return ds;
        }
        public DataSet ObtenerUltimoEstadoExpOcupacional(int idUsuario)
        {
            DataSet ds = new DataSet();
            try
            {
                adaptador = new OleDbDataAdapter("GS_ObtenerUltimoEstadoExpOcupacional", conn.getConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@idUsuario", OleDbType.Integer);
                adaptador.SelectCommand.Parameters["@idUsuario"].Value = idUsuario;
             
                adaptador.Fill(ds);
                conn.cerrar();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método ObtenerUltimoEstadoExpOcupacional - Persistencia", ex);
            }
            return ds;
        }

        public int GuardarPsicosensometrico(int id_usuario, DateTime fecha_control, DateTime fecha_vencimiento, int id_vehiculo, int id_causa_contraindicacion, int id_estado_psm, string aux_observacion,string pendientes)
        {
            try
            {
                comando = new OleDbCommand("GS_GuardarPsicosensometrico", conn.getConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id_usuario", OleDbType.Integer);
                comando.Parameters["@id_usuario"].Value = id_usuario;
                comando.Parameters.Add("@fecha_control", OleDbType.Date);
                comando.Parameters["@fecha_control"].Value = fecha_control;
                comando.Parameters.Add("@fecha_vencimiento", OleDbType.Date);
                comando.Parameters["@fecha_vencimiento"].Value = fecha_vencimiento;
                comando.Parameters.Add("@id_vehiculo", OleDbType.Integer);
                comando.Parameters["@id_vehiculo"].Value = id_vehiculo;
                comando.Parameters.Add("@id_causa_contraindicacion", OleDbType.Integer);
                comando.Parameters["@id_causa_contraindicacion"].Value = id_causa_contraindicacion;
                comando.Parameters.Add("@id_estado_psm", OleDbType.Integer);
                comando.Parameters["@id_estado_psm"].Value = id_estado_psm;
                comando.Parameters.Add("@aux_observacion", OleDbType.VarChar);
                comando.Parameters["@aux_observacion"].Value = aux_observacion;
                comando.Parameters.Add("@pendientes", OleDbType.VarChar);
                comando.Parameters["@pendientes"].Value = pendientes;
                int id = Convert.ToInt32(comando.ExecuteScalar());
                conn.cerrar();
                return id;
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " GuardarPsicosensometrico - Persistencia", ex);
                return -1;
            }
        }
    }
}