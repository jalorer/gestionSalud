using log4net;
using Sistema_Gestion_Salud.Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Gestion_Salud.Presentacion
{
    public partial class frmEstatusExamenOcupacional : System.Web.UI.Page
    {
        private ControladorLogica controlador = new ControladorLogica();
        private static readonly ILog logger = LogManager.GetLogger(typeof(frmEstatusExamenOcupacional));
        AppSettingsReader conf = new AppSettingsReader();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            try
            {
                if (Session["usuario"] != null && Session["perfil"] != null)
                {

                    string usuario = Session["usuario"].ToString();

                    int perfil = Convert.ToInt32(Session["perfil"].ToString());

                    string currentPageFileName = new FileInfo(this.Request.Url.LocalPath).Name;
                    bool perfilvalido = verificarperfil(currentPageFileName, perfil, "Salud");
                    DataSet ds = controlador.ObtenerUsuarioPermiso(usuario, perfil);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        Response.Redirect("~/frmLogin.aspx");
                    }
                    else if (!perfilvalido)
                    {
                        Response.Redirect("~/frmLogin.aspx");
                    }
                    else
                    {
                        if (!IsPostBack)
                        {
                            Random random = new Random();
                            CargarCombosSinParametros(ddlAsistenciaCita, "GS_ObtenerEstadosAsistencia", "ID_ASIST", "DESC_ASIST");
                            CargarCombosSinParametros(ddlAControl, "GS_ObtenerEstadosAsistencia", "ID_ASIST", "DESC_ASIST");
                            //CargarCombos(ddlPeriodo, "GS_ObtenerPeriodoEOxUsuario", Convert.ToInt32(Session["RUT"].ToString()), "PERIODO", "PERIODO");
                            CargarPeriodo(ddlPeriodo);
                            CargarCombosSinParametros(ddlContraIndicacion, "GS_ObtenerCausaContraIndicacion", "ID_CAUSA", "DESC_CAUSA_CONTR");
                            CargarCombosSinParametrosCKL(chkParamAlterado, "GS_ObtenerParamAlterado", "ID_PARAM_ALTER", "DESC_PARAM_ALTER");
                            CargarCombosSinParametros(ddlBateria, "GS_ObtenerBaterias", "ID_BATERIAS", "DESC_BAT");
                            CargarCombosSinParametros(ddlEstatusExOcup, "GS_ObtenerEstatusExOcup", "ID_ESTATUS", "DESC_ESTATUS");
                            CargarCombosSinParametros(ddlPatologiaCronica, "GS_ObtenerEstadoSiNo", "ID", "DETALLE");
                            CargarCombosSinParametros(ddlDiabetes, "GS_ObtenerEstadoSiNo", "ID", "DETALLE");
                            CargarCombosSinParametros(ddlResistenciaInsulina, "GS_ObtenerEstadoSiNo", "ID", "DETALLE");

                            CargarCombosSinParametros(ddlHta, "GS_ObtenerEstadoSiNo", "ID", "DETALLE");
                            CargarCombosSinParametros(ddlDislipidemia, "GS_ObtenerEstadoSiNo", "ID", "DETALLE");
                            CargarCombosSinParametros(ddlCardiopatia, "GS_ObtenerEstadoSiNo", "ID", "DETALLE");
                            CargarCitas();

                            CargarDocumentos();
                            OcultarExpOcup();
                            cargarBitacora();
                            this.txtOtrasPatologias.Attributes.Add("maxLength", txtOtrasPatologias.MaxLength.ToString());
                            this.txtAntecedentesQuirurgicos.Attributes.Add("maxLength", txtAntecedentesQuirurgicos.MaxLength.ToString());
                            //this.txtComentarioControl.Attributes.Add("maxLength", txtComentarioControl.MaxLength.ToString());
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Page_Load - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }



        private void OcultarExpOcup()
        {
            ExamenOcupacionalId.Visible = false;
            divExOcup.Visible = false;
            divControles.Visible = false;
            divbtnPcronicas.Visible = false;
            divPatologiasCronicas.Visible = false;
            divTituloDatosPatologias.Visible = false;
            //Cambio solicitado nino 08-06-2023
            txtFechaControl.Enabled = false;
        }

        private void CargarPeriodo(DropDownList ddl)
        {
            try
            {
                ddl.Items.Insert(0, new ListItem("Todas las citas", "0"));
                ddl.Items.Insert(1, new ListItem("2020", "2020"));
                ddl.Items.Insert(2, new ListItem("2021", "2021"));
                ddl.Items.Insert(3, new ListItem("2022", "2022"));
                ddl.Items.Insert(4, new ListItem("2023", "2023"));
                ddl.Items.Insert(5, new ListItem("2024", "2024"));
                ddl.Items.Insert(6, new ListItem("2025", "2025"));
                ddl.Items.Insert(7, new ListItem("2026", "2026"));
                ddl.Items.Insert(8, new ListItem("2027", "2027"));
                ddl.Items.Insert(9, new ListItem("2028", "2028"));
                ddl.Items.Insert(10, new ListItem("2029", "2029"));
                ddl.Items.Insert(11, new ListItem("2030", "2030"));

            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " CargarCombos - frmEstatusExamenOcupacional ", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        private void CargarCombos(DropDownList ddl, string Procedimiento, int parametros, string ID, string DETALLE)
        {
            try
            {
                ddl.DataSource = null;
                ddl.DataBind();
                DataSet ds = controlador.CargarCombos(Procedimiento, parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddl.DataSource = ds.Tables[0];
                    ddl.DataValueField = ID;
                    ddl.DataTextField = DETALLE;
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Seleccione", "0"));
                }

            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " CargarCombos - frmEstatusExamenOcupacional ", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        private void Visibilidad_Controles()
        {
            int estatusExamen = Convert.ToInt32(ddlEstatusExOcup.SelectedValue);
            int presentaPC = Convert.ToInt32(ddlPatologiaCronica.SelectedValue);
            if (estatusExamen == 2 || estatusExamen == 3 || presentaPC == 1)
            {
                divControles.Visible = true;
            }
            else
            {
                divControles.Visible = false;
            }
        }
        private void cargarControles(int idExamen)
        {
            try
            {
                int idUsuario = Convert.ToInt32(Session["RUT"].ToString());
                DataSet ds = controlador.ObtenerControlesUsuario(idExamen);
                DataSet dsExisteControles = controlador.VerificarSiExisteControles(idExamen, idUsuario);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMensajeControles.Visible = false;
                    gvControles.Visible = true;
                    Session["gridPrincipalControles"] = ds.Tables[0].DefaultView;
                    gvControles.DataSource = ds.Tables[0];
                    gvControles.DataBind();
                    Session["crReporteControles"] = ds.Tables[0];
                }
                else
                {
                    lblMensajeControles.Visible = true;
                    gvControles.Visible = false;
                    //divControles.Visible = false;
                    Session["crReporteControles"] = "";
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " cargarControles - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        private void CargarCitas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(Session["RUT"].ToString());
                DataSet ds = controlador.ObtenerCitasUsuario(idUsuario);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMensaje.Visible = false;
                    gvDatos.Visible = true;
                    Session["gridPrincipal"] = ds.Tables[0].DefaultView;
                    gvDatos.DataSource = ds.Tables[0];
                    gvDatos.DataBind();
                    Session["crReporte"] = ds.Tables[0];
                }
                else
                {
                    lblMensaje.Visible = true;
                    gvDatos.Visible = false;
                    Session["crReporte"] = "";
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " CargarCitas - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        private bool verificarperfil(string filename, int idPerfil, string modulo)
        {
            try
            {
                DataSet ds = controlador.ObtenerMenuPerfil(filename, idPerfil, modulo);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                logger.Error(DateTime.Now + " verificarperfil - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                return false;
            }
        }
        private void CargarCombosSinParametros(DropDownList ddl, string Procedimiento, string ID, string DETALLE)
        {
            try
            {
                ddl.DataSource = null;
                ddl.DataBind();
                DataSet ds = controlador.CargarCombosSinParametros(Procedimiento);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddl.DataSource = ds.Tables[0];
                    ddl.DataValueField = ID;
                    ddl.DataTextField = DETALLE;
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Seleccione", "0"));
                }

            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " CargarCombosSinParametros - frmEstatusExamenOcupacional ", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        private void CargarCombosSinParametrosCKL(CheckBoxList ddl, string Procedimiento, string ID, string DETALLE)
        {
            try
            {
                ddl.DataSource = null;
                ddl.DataBind();
                DataSet ds = controlador.CargarCombosSinParametros(Procedimiento);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddl.DataSource = ds.Tables[0];
                    ddl.DataValueField = ID;
                    ddl.DataTextField = DETALLE;
                    ddl.DataBind();
                }

            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " CargarCombosSinParametros - frmEstatusExamenOcupacional ", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }



        private void LimpiarCitas()
        {

            ddlAsistenciaCita.SelectedIndex = 0;
            txtFechaCita.Text = "";
        }

        protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataView data = (DataView)Session["gridPrincipal"];
                if (data.Count > 0)
                {
                    gvDatos.DataSource = data;
                    gvDatos.PageIndex = e.NewPageIndex;
                    ViewState["gridPrincipal"] = e.NewPageIndex;
                    gvDatos.DataBind();
                }
                else
                {
                    gvDatos.Visible = false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " gvDatos_PageIndexChanging - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPeriodo.SelectedIndex > 0)
                {
                    int rut = Convert.ToInt32(Session["RUT"].ToString());
                    int periodo = Convert.ToInt32(ddlPeriodo.SelectedValue);
                    DataSet ds = controlador.ObtenerCitasUsuarioPeriodo(rut, periodo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvDatos.DataSource = ds;
                        gvDatos.DataBind();
                        Session["gridPrincipal"] = ds.Tables[0].DefaultView;
                    }
                    else
                    {
                        gvDatos.DataSource = null;
                        gvDatos.DataBind();
                        Session["gridPrincipal"] = ds.Tables[0].DefaultView;
                    }
                }
                else
                {
                    int rut = Convert.ToInt32(Session["RUT"].ToString());
                    int periodo = Convert.ToInt32(ddlPeriodo.SelectedValue);
                    DataSet ds = controlador.ObtenerCitasUsuarioPeriodo(rut, periodo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvDatos.DataSource = ds;
                        gvDatos.DataBind();
                        Session["gridPrincipal"] = ds.Tables[0].DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " ddlPeriodo_SelectedIndexChanged - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }



        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ddlContraIndicacion.Enabled = true;
                if (e.CommandName == "Seleccionar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvDatos.Rows[index];
                    string idCita = Server.HtmlDecode(row.Cells[0].Text);
                    Session["idCita"] = idCita;




                    int rut = Convert.ToInt32(Session["RUT"].ToString());
                    DataSet ds = controlador.ObtenerExamenxCita(rut, Convert.ToInt32(idCita));
                    lblFechaDesplegar.Text = "Fecha Cita: " + row.Cells[1].Text;
                    divExOcup.Visible = false;
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        OcultarExpOcup();
                        ModalPopupAgregarExpOcup.Show();
                    }
                    else
                    {
                        //Cargar la data existente.
                        MostrarExamenesOcupacionales(Convert.ToInt32(idCita));
                        divbtnPcronicas.Visible = true;
                        divPatologiasCronicas.Visible = true;
                        divTituloDatosPatologias.Visible = true;
                        CargarPatologiasCronicas(Convert.ToInt32(Session["RUT"].ToString()));
                        Visibilidad_Controles();
                        DataSet dsExamen = controlador.BuscarExamenOcupacionalxID_Cita(Convert.ToInt32(Session["idCita"].ToString()));
                        Session["ID_Examen"] = Convert.ToInt32(dsExamen.Tables[0].Rows[0]["ID_Examen"].ToString());
                        if (dsExamen.Tables[0].Rows.Count > 0)
                        {
                            cargarControles(Convert.ToInt32(dsExamen.Tables[0].Rows[0]["ID_Examen"].ToString()));
                        }
                        //divControles.Visible = true;
                        //divPatologiasCronicas.Visible = true;
                        //divbtnPcronicas.Visible = true;
                        //divPatologiasCronicas.Visible = false;
                        //divTituloDatosPatologias.Visible = true;

                    }
                }

                if (e.CommandName == "Eliminar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvDatos.Rows[index];
                    string idCita = Server.HtmlDecode(row.Cells[0].Text);
                    DataSet dsE = controlador.Procedimiento_Generico("GS_EliminarCitaxID_Cita", Convert.ToInt32(idCita));
                    if (dsE.Tables[0].Rows.Count > 0)
                    {
                        CargarCitas();
                        LimpiarCitas();
                        divExOcup.Visible = false;

                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgSuccesful('Se eliminó la cita correctamente');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " gvDatos_RowCommand - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        private void MostrarExamenesOcupacionales(int idCita)
        {
            try
            {
                ExamenOcupacionalId.Visible = true;
                divExOcup.Visible = true;
                DataSet ds = controlador.ObtenerResultadosExOcupxCita(idCita);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlBateria.SelectedValue = ds.Tables[0].Rows[0]["ID_BATERIAS"].ToString();
                    ddlEstatusExOcup.SelectedValue = ds.Tables[0].Rows[0]["ID_ESTATUS"].ToString();

                    //cambio nino 08-06-2023
                    int IdEstado = Convert.ToInt32(ddlEstatusExOcup.SelectedValue);

                    if (IdEstado.Equals(1) || IdEstado.Equals(2))
                    {
                        txtFechaControl.Enabled = true;
                    }
                    else
                    {
                        txtFechaControl.Enabled = false;
                        txtFechaControl.Text = "";
                    }


                    ddlContraIndicacion.SelectedValue = ds.Tables[0].Rows[0]["ID_CAUSA"].ToString();
                    if (ddlContraIndicacion.SelectedValue.Equals("0"))
                    {
                        ddlContraIndicacion.Enabled = false;
                    }
                    else
                    {
                        ddlContraIndicacion.Enabled = true;
                    }

                    string fechaControl = Convert.ToString(ds.Tables[0].Rows[0]["Fecha_Control"].ToString());
                    if (fechaControl.Equals("1900-01-01"))
                    {
                        txtFechaControl.Text = "";
                    }
                    else
                    {
                        txtFechaControl.Text = fechaControl;
                    }

                    BuscarParametrosAlterados(idCita);
                }

            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " MostrarExamenesOcupacionales - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        protected void BuscarParametrosAlterados(int idCita)
        {
            try
            {
                DataSet dsPA = controlador.BuscarResultadosParametrosAlterados(idCita);

                if (dsPA.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < chkParamAlterado.Items.Count; i++)
                    {
                        chkParamAlterado.Items[i].Selected = false;
                    }
                    foreach (DataRow dr in dsPA.Tables[0].Rows)
                    {
                        string desc = dr[1].ToString();

                        for (int i = 0; i < chkParamAlterado.Items.Count; i++)
                        {
                            string param = chkParamAlterado.Items[i].Value;
                            if (param.Equals(desc))
                            {
                                chkParamAlterado.Items[i].Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < chkParamAlterado.Items.Count; i++)
                    {
                        chkParamAlterado.Items[i].Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " BuscarParametrosAlterados - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        protected void btnCrearExamenesOcupacionales_Click(object sender, EventArgs e)
        {
            try
            {
                ExamenOcupacionalId.Visible = true;
                divExOcup.Visible = true;
                divbtnPcronicas.Visible = true;
                divPatologiasCronicas.Visible = true;
                divTituloDatosPatologias.Visible = true;
                limpiarExamenes();
                BuscarParametrosAlterados(0);
                limpiarPatologiasCronicas();
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " btnCrearExamenesOcupacionales_Click - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        private void limpiarPatologiasCronicas()
        {
            try
            {
                ddlPatologiaCronica.SelectedValue = "0";
                ddlDiabetes.SelectedValue = "0";
                ddlHta.SelectedValue = "0";
                ddlDislipidemia.SelectedValue = "0";
                ddlCardiopatia.SelectedValue = "0";
                ddlResistenciaInsulina.SelectedValue = "0";
                txtOtrasPatologias.Text = "";
                txtAntecedentesQuirurgicos.Text = "";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void limpiarExamenes()
        {
            try
            {
                ddlBateria.SelectedIndex = 0;
                //txtFechaGaGe.Text = "";
                ddlEstatusExOcup.SelectedIndex = 0;
                ddlContraIndicacion.SelectedIndex = 0;
                //ddlParamAlterado.SelectedIndex = 0;
                txtFechaControl.Text = "";


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnGuardarExOcup_Click(object sender, EventArgs e)
        {
            try
            {
                string ERROR = "NO";
                int Id_Cita = Convert.ToInt32(Session["idCita"].ToString());
                int bateria = Convert.ToInt32(ddlBateria.SelectedValue);
                int estatusExOcup = Convert.ToInt32(ddlEstatusExOcup.SelectedValue);
                int contraindicacion = Convert.ToInt32(ddlContraIndicacion.SelectedValue);

                if (!estatusExOcup.Equals(1) && contraindicacion.Equals(0))
                {
                    ERROR = "SI";
                }

                if (estatusExOcup.Equals(0))
                {
                    ERROR = "SI";
                }
                //int paramAlterado = Convert.ToInt32(ddlParamAlterado.SelectedValue);
                DateTime fechaControl;
                if (txtFechaControl.Text.Length == 0)
                {
                    fechaControl = Convert.ToDateTime("1900-01-01");
                }
                else
                {
                    fechaControl = Convert.ToDateTime(txtFechaControl.Text.Trim());
                }
                //Parámetros adicionales
                //Asistencia 1 : SI Asiste, se entiende que si puede ingresar datos es porque asistió?
                int rut = Convert.ToInt32(Session["RUT"].ToString());

                if (ERROR.Equals("NO"))
                {
                    string idUsuario = Session["RUT"].ToString();
                    DataSet dsUltimoEOcupacional = controlador.ObtenerUltimoEstadoExpOcupacional(Convert.ToInt32(idUsuario));
                    int ultimoEstado = 0;
                    int estatusddl = Convert.ToInt32(ddlEstatusExOcup.SelectedValue);
                    string Subtipo = "";
                    if (dsUltimoEOcupacional.Tables[0].Rows.Count > 0)
                    {
                        ultimoEstado = Convert.ToInt32(dsUltimoEOcupacional.Tables[0].Rows[0]["Estatus_Examen"].ToString());

                    }
                    int id = controlador.GuardarExamenOcupacional(Id_Cita, rut, 1, fechaControl, estatusExOcup, bateria, contraindicacion);

                    if (id >= 0)
                    {
                        Subtipo = estatusddl < ultimoEstado ? "Mejoró Condición" : "Condición no ha cambiado";

                        if (!id.Equals(0))
                        {
                            int ExOcup = controlador.GuardarCitaExOcup(Convert.ToInt32(Session["idCita"].ToString()), id);
                        }
                        // guarda o elimina un parametro alterado
                        for (int i = 0; i <= (chkParamAlterado.Items.Count - 1); i++)
                        {
                            int indice = Convert.ToInt32(chkParamAlterado.Items[i].Value);
                            bool estado = chkParamAlterado.Items[i].Selected;
                            if (estado)
                            {
                                int result = controlador.GuardarEliminarParametroAlterado("guardar", Id_Cita, indice);
                            }
                            else
                            {
                                int result = controlador.GuardarEliminarParametroAlterado("eliminar", Id_Cita, indice);
                            }
                        }

                        CargarCitas();
                        Visibilidad_Controles();
                        cargarControles(Convert.ToInt32(Session["ID_Examen"].ToString()));
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgSuccesful('Se ha guardado el examen ocupacional asociado');", true);
                        guardarBitacoraExamenesOcupacional(Subtipo);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Debe ingresar ESTATUS O CONTRAINDICACIÓN','warning');", true);
                }


            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " btnGuardarExOcup_Click - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }



        protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                ImageButton imgSeleccion = (ImageButton)e.Row.FindControl("imgSeleccionar");
                ImageButton imgEliminar = (ImageButton)e.Row.FindControl("imgEliminar");


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int idCita = Convert.ToInt32(e.Row.Cells[0].Text);
                    string cita = e.Row.Cells[2].Text;
                    if (cita.Equals("SI Asiste"))
                    {
                        imgSeleccion.Visible = true;
                        // Control de boton eliminar : caso que "SI Asiste" y no tiene Examenes Ocupacionales se puede eliminar
                        DataSet dsEO = controlador.Procedimiento_Generico("GS_BuscarExamenOcupacionalxID_Cita", idCita);
                        if (dsEO.Tables[0].Rows.Count > 0)
                        {
                            imgEliminar.Visible = false;
                        }
                        else
                        {
                            imgEliminar.Visible = true;
                        }
                    }
                    else
                    {
                        imgSeleccion.Visible = false;
                        imgEliminar.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " gvDatos_RowDataBound - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void ddlEstatusExOcup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int IdEstado = Convert.ToInt32(ddlEstatusExOcup.SelectedValue);
                if (IdEstado.Equals(1))
                {
                    ddlContraIndicacion.SelectedValue = "0";
                    ddlContraIndicacion.Enabled = false;
                }
                else
                {
                    ddlContraIndicacion.Enabled = true;
                }

                if (IdEstado.Equals(1) || IdEstado.Equals(2))
                {
                    txtFechaControl.Enabled = true;
                }
                else
                {
                    txtFechaControl.Enabled = false;
                    txtFechaControl.Text = "";
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " ddlEstatusExOcup_SelectedIndexChanged - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void btnGuardarPatologiasCronicas_Click(object sender, EventArgs e)
        {
            try
            {
                // Estados : 1=SI, 2=NO

                int presenta_pc = Convert.ToInt32(ddlPatologiaCronica.SelectedValue);
                int diabetes = Convert.ToInt32(ddlDiabetes.SelectedValue);
                int hta = Convert.ToInt32(ddlHta.SelectedValue);
                int dis = Convert.ToInt32(ddlDislipidemia.SelectedValue);
                int cardio = Convert.ToInt32(ddlCardiopatia.SelectedValue);
                int resistencia = Convert.ToInt32(ddlResistenciaInsulina.SelectedValue);
                string otrasp = txtOtrasPatologias.Text;
                string antq = txtAntecedentesQuirurgicos.Text;
                int usuario = Convert.ToInt32(Session["RUT"].ToString());
                if (presenta_pc.Equals(2))
                {
                    presenta_pc = 2;
                    diabetes = 2;
                    hta = 2;
                    dis = 2;
                    cardio = 2;
                    resistencia = 2;
                }
                if (presenta_pc.Equals(0))
                {
                    presenta_pc = 0;
                    diabetes = 0;
                    hta = 0;
                    dis = 0;
                    cardio = 0;
                    resistencia = 0;
                }


                if (presenta_pc.Equals(1) && diabetes.Equals(0) && hta.Equals(0) && dis.Equals(0) && cardio.Equals(0) && resistencia.Equals(0))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Debe ingresar alguna Patología Crónica','error');", true);
                }
                else
                {
                    int id = controlador.GuardarPatologiasCronicas(usuario, presenta_pc, diabetes, hta, dis, cardio, otrasp, antq, resistencia);
                    if (id >= 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgSuccesful('Se han guardado las Patologías Crónicas');", true);
                        CargarPatologiasCronicas(Convert.ToInt32(Session["RUT"].ToString()));
                        Visibilidad_Controles();
                        cargarControles(Convert.ToInt32(Session["ID_Examen"].ToString()));
                        guardarBitacoraPatologiaCronicas();
                        //cargarControles(idExamen);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " btnGuardarPatologiasCronicas_Click - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }



        protected void ddlPatologiaCronica_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string valor = ddlPatologiaCronica.SelectedItem.Text;
                if (valor.Equals("NO"))
                {
                    Despliegue_PatologiasCronicas(false);
                }
                else
                {
                    Despliegue_PatologiasCronicas(true);
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " ddlPatologiaCronica_SelectedIndexChanged - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        protected void Despliegue_PatologiasCronicas(bool estado)
        {
            Label6.Visible = estado;
            Label7.Visible = estado;
            Label8.Visible = estado;
            Label9.Visible = estado;
            ddlDiabetes.Visible = estado;
            ddlHta.Visible = estado;
            ddlDislipidemia.Visible = estado;
            ddlCardiopatia.Visible = estado;
            txtOtrasPatologias.Visible = estado;
            txtAntecedentesQuirurgicos.Visible = estado;
            Label10.Visible = estado;
            Label12.Visible = estado;
            Label2.Visible = estado;
            ddlResistenciaInsulina.Visible = estado;

        }

        private void CargarPatologiasCronicas(int usuario)
        {
            try
            {
                DataSet ds = controlador.Procedimiento_Generico("GS_BuscarPatologiasCronicasxUsuario", usuario);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Despliegue_PatologiasCronicas(true);
                    ddlPatologiaCronica.SelectedValue = ds.Tables[0].Rows[0]["Presenta_PC"].ToString();
                    ddlDiabetes.SelectedValue = ds.Tables[0].Rows[0]["Diabetes_mielitus"].ToString();
                    ddlResistenciaInsulina.SelectedValue = ds.Tables[0].Rows[0]["Resistencia_Insulina"].ToString();
                    ddlHta.SelectedValue = ds.Tables[0].Rows[0]["HTA"].ToString();
                    ddlDislipidemia.SelectedValue = ds.Tables[0].Rows[0]["Dislipidemia"].ToString();
                    ddlCardiopatia.SelectedValue = ds.Tables[0].Rows[0]["Cardiopatia"].ToString();
                    txtOtrasPatologias.Text = ds.Tables[0].Rows[0]["Otras_Pat"].ToString();
                    txtAntecedentesQuirurgicos.Text = ds.Tables[0].Rows[0]["Antec_qx"].ToString();
                    if (ds.Tables[0].Rows[0]["Presenta_PC"].ToString().Equals("0"))
                    {
                        Despliegue_PatologiasCronicas(false);
                    }
                }
                else
                {
                    Despliegue_PatologiasCronicas(false);
                    ddlPatologiaCronica.SelectedValue = "0";
                    ddlDiabetes.SelectedValue = "0";
                    ddlHta.SelectedValue = "0";
                    ddlDislipidemia.SelectedValue = "0";
                    ddlCardiopatia.SelectedValue = "0";
                    txtOtrasPatologias.Text = "";
                    txtAntecedentesQuirurgicos.Text = "";
                    ddlResistenciaInsulina.SelectedValue = "0";
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " CargarPatologiasCronicas - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        protected void fileDocumento_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            try
            {
                string fileNametoupload = Server.MapPath("../Documentos/");
                string fileExtension = System.IO.Path.GetExtension(e.FileName).ToLower().Replace(".", "");
                string nombreArch = Regex.Replace(e.FileName.ToString(), "[^0-9A-Za-z]", "_", RegexOptions.None);

                string fecha = DateTime.Now.ToString().Replace('/', '_').Replace(':', '_');

                if (nombreArch.ToLower().Contains(fileExtension))
                {
                    nombreArch = nombreArch.ToLower().Replace(fileExtension, "");
                    nombreArch = nombreArch + "_" + fecha + "." + fileExtension;
                }

                fileDocumento.SaveAs(fileNametoupload + nombreArch);
                string rutas = fileNametoupload + nombreArch;
                Session["RutaInforme"] = rutas;
                Session["NombreArchivo"] = nombreArch;
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " AjaxFileUploadProat_UploadComplete - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void gvAnexos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Descargar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvAnexos.Rows[index];
                    string URL = Server.HtmlDecode(row.Cells[2].Text);
                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "window.open('./frmFileDownload.aspx?ifile=" + HttpUtility.UrlEncode(URL) + "');", true);
                }
                if (e.CommandName == "Eliminar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvAnexos.Rows[index];
                    string idDocumento = Server.HtmlDecode(row.Cells[1].Text);
                    Session["idDocEliminar"] = Convert.ToInt32(idDocumento);
                    ModalPopupEliminarArchivo.Show();
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " gvAnexos_RowCommand - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void btnConfirmarEliminacionArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idDocEliminar"] != null)
                {
                    int idEliminar = controlador.EliminarDocumento(Convert.ToInt32(Session["idDocEliminar"].ToString()));
                    if (idEliminar.Equals(0))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgSuccesful('Se eliminó el archivo solicitado');", true);
                        CargarDocumentos();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " btnConfirmarEliminacionArchivo_Click - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        private void CargarDocumentos()
        {
            try
            {
                int idUsuario = Convert.ToInt32(Session["RUT"].ToString());
                if (!idUsuario.Equals(0))
                {

                    DataSet dsDoc = controlador.BuscarDocumento(idUsuario);
                    if (dsDoc.Tables[0].Rows.Count > 0)
                    {
                        Session["gridDocumentos"] = dsDoc.Tables[0].DefaultView;
                        gvAnexos.DataSource = dsDoc.Tables[0];
                        gvAnexos.DataBind();
                        lblMensajeDocumentos.Visible = false;
                        gvAnexos.Visible = true;

                    }
                    else
                    {
                        lblMensajeDocumentos.Visible = true;
                        gvAnexos.Visible = false;
                    }


                }
            }
            catch (Exception ex)
            {

                logger.Error(DateTime.Now + " CargarDocumentos - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);

            }
        }

        protected void btnCarga_Click(object sender, EventArgs e)
        {
            try
            {

                int idUsuario = Convert.ToInt32(Session["RUT"].ToString());
                if (!idUsuario.Equals(0))
                {
                    int id = controlador.GuardarDocumento(idUsuario, Session["NombreArchivo"].ToString(), Session["RutaInforme"].ToString());
                    if (id > 0)
                    {
                        DataSet dsDoc = controlador.BuscarDocumento(idUsuario);
                        if (dsDoc.Tables[0].Rows.Count > 0)
                        {
                            Session["gridDocumentos"] = dsDoc.Tables[0].DefaultView;
                            gvAnexos.DataSource = dsDoc.Tables[0];
                            gvAnexos.DataBind();
                            lblMensajeDocumentos.Visible = false;
                            gvAnexos.Visible = true;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgSuccesful('Se ha guardado el documento asociado');", true);
                        }
                        else
                        {
                            lblMensajeDocumentos.Visible = true;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " btnCarga_Click - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void gvAnexos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnGuardarControl_Click(object sender, EventArgs e)
        {
            try
            {
                string ERROR_INGRESO = "NO";
                string fecha = txtFControl.Text.Trim();
                int tipoAsistencia = Convert.ToInt32(ddlAControl.SelectedValue);
                if (tipoAsistencia.Equals(0))
                {
                    lblAControl.ForeColor = System.Drawing.Color.Red;
                    ERROR_INGRESO = "SI";
                }
                else
                {
                    lblAControl.ForeColor = System.Drawing.Color.Black;

                }
                if (fecha.Length == 0)
                {
                    lblFControl.ForeColor = System.Drawing.Color.Red;
                    ERROR_INGRESO = "SI";
                }
                else
                {
                    lblFControl.ForeColor = System.Drawing.Color.Black;
                }
                DateTime fechaControl;
                if (ERROR_INGRESO.Equals("SI"))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Debe ingresar todos los datos','error');", true);
                }
                else
                {
                    string rut = Session["RUT"].ToString();
                    /*
                     MTR_TIPO_CITA -> 1 Para Examen Ocupacional
                     */

                    //Lógica para obtener el N de Control.
                    DataSet dsExamen = controlador.BuscarExamenOcupacionalxID_Cita(Convert.ToInt32(Session["idCita"].ToString()));
                    if (dsExamen.Tables[0].Rows.Count > 0)
                    {
                        //Modificación solicitada nino, obtener numero de control ya no tiene lógica alguna. 

                        DataSet dsNumeroControl = controlador.ObtenerNumeroControl(Convert.ToInt32(dsExamen.Tables[0].Rows[0]["ID_Examen"].ToString()));
                        int numeroControl = dsNumeroControl.Tables[0].Rows.Count ;
                        //if (dsNumeroControl.Tables[0].Rows.Count > 0)
                        //{
                        //    numeroControl = Convert.ToInt32(dsNumeroControl.Tables[0].Rows[0]["Numero_Control"].ToString());
                        //}
                        //if (tipoAsistencia == 1)
                        //{
                        //    numeroControl++;

                        //    fechaControl = Convert.ToDateTime(txtFControl.Text.Trim());
                        //    int idExamen = Convert.ToInt32(dsExamen.Tables[0].Rows[0]["ID_Examen"].ToString());
                        //    int id = controlador.GuardarControlUsuario(idExamen, fechaControl, tipoAsistencia, numeroControl);
                        //    if (id > 0)
                        //    {
                        //        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgSuccesful('Se guardó el control asociado');", true);
                        //        cargarControles(idExamen);
                        //        LimpiarControles();

                        //    }
                        //    else
                        //    {
                        //        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                        //    }
                        //}
                        //else
                        //{

                            //numeroControl = 0;
                            fechaControl = Convert.ToDateTime(txtFControl.Text.Trim());
                            int idExamen = Convert.ToInt32(dsExamen.Tables[0].Rows[0]["ID_Examen"].ToString());
                            int id = controlador.GuardarControlUsuario(idExamen, fechaControl, tipoAsistencia, numeroControl);
                            if (id > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgSuccesful('Se guardó el control asociado');", true);
                                cargarControles(idExamen);

                                //LimpiarCitas();

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                            }
                        //}
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " btnGuardarControl_Click - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        private void LimpiarControles()
        {
            ddlAControl.SelectedIndex = 0;
            txtFControl.Text = "";
        }

        protected void btnGuardarActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string ERROR_INGRESO = "NO";
                string fecha = txtFechaCita.Text.Trim();
                int tipoAsistencia = Convert.ToInt32(ddlAsistenciaCita.SelectedValue);
                if (tipoAsistencia.Equals(0))
                {
                    lblAsistenciaCita.ForeColor = System.Drawing.Color.Red;
                    ERROR_INGRESO = "SI";
                }
                else
                {
                    lblAsistenciaCita.ForeColor = System.Drawing.Color.Black;

                }
                if (fecha.Length == 0)
                {
                    lblFechaCita.ForeColor = System.Drawing.Color.Red;
                    ERROR_INGRESO = "SI";
                }
                else
                {
                    lblFechaCita.ForeColor = System.Drawing.Color.Black;
                }
                DateTime fechaCita;
                if (ERROR_INGRESO.Equals("SI"))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Debe ingresar todos los datos','error');", true);
                }
                else
                {
                    string rut = Session["RUT"].ToString();
                    /*
                     MTR_TIPO_CITA -> 1 Para Examen Ocupacional
                     */
                    fechaCita = Convert.ToDateTime(txtFechaCita.Text.Trim());
                    int id = controlador.GuardarCitaUsuario(Convert.ToInt32(rut), 1, fechaCita, Convert.ToInt32(ddlAsistenciaCita.SelectedValue));
                    if (id > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgSuccesful('Se guardó la cita asociada');", true);
                        CargarCitas();
                        LimpiarCitas();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " btnGuardarActualizar_Click - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }


        private void guardarBitacoraPatologiaCronicas()
        {
            try
            {
                string idUsuario = Session["RUT"].ToString();

                int idTipoEntrada = 1;
                DateTime fecha = DateTime.Today;
                string usuarioComentario = Session["usuario"].ToString();
                string comentario = "";
                int presenta_pc = Convert.ToInt32(ddlPatologiaCronica.SelectedValue);
                if (presenta_pc.Equals(1))
                {
                    comentario = "Diabetes Militus: " + ddlDiabetes.SelectedItem + " - " + "HTA: " + ddlHta.SelectedItem + " - " + " Dislipidemia: " + ddlDislipidemia.SelectedItem + " - " + "Cardiopatía: " + ddlCardiopatia.SelectedItem + " - " + "Resistencia Insulina: " + ddlResistenciaInsulina.SelectedItem;
                }
                else
                {
                    comentario = "Sin Patologías Crónicas";
                }
                string subTipo = "Patologías Crónicas";
                int id = controlador.GuardarComentarioBitacora(fecha, idTipoEntrada, comentario, usuarioComentario, Convert.ToInt32(idUsuario), subTipo);
                if (id > 0)
                {
                    cargarBitacora();
                    //limpiarBitacora();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                }

            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " guardarBitacoraPatologiaCronicas - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }



        private void guardarBitacoraExamenesOcupacional(string subTipo)
        {
            try
            {
                string idUsuario = Session["RUT"].ToString();

                int idTipoEntrada = 1;
                DateTime fecha = DateTime.Today;
                string usuarioComentario = Session["usuario"].ToString();
                string comentario = "";
                if (Convert.ToInt32(ddlContraIndicacion.SelectedValue) == 0)
                {
                    comentario = "Estatus Examen: " + ddlEstatusExOcup.SelectedItem;

                }
                else
                {

                    comentario = "Estatus Examen: " + ddlEstatusExOcup.SelectedItem + " - " + "Contraindicación: " + ddlContraIndicacion.SelectedItem;
                }
                int id = controlador.GuardarComentarioBitacora(fecha, idTipoEntrada, comentario, usuarioComentario, Convert.ToInt32(idUsuario), subTipo);
                if (id > 0)
                {
                    cargarBitacora();
                    //limpiarBitacora();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                }





            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " guardarBitacoraExamenesOcupacional - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        protected void btnGuardarComentarioBitacora_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtComentarioBitacora.Text.Length > 0)
                {
                    string usuarioComentario = Session["usuario"].ToString();
                    DateTime fecha = DateTime.Today;
                    //TIPO Entrada 1 para Examen Ocupacional
                    int idTipoEntrada = 1;
                    string comentario = txtComentarioBitacora.Text;
                    string idUsuario = Session["RUT"].ToString();
                    string subTipo = "Comentario Normal";

                    int id = controlador.GuardarComentarioBitacora(fecha, idTipoEntrada, comentario, usuarioComentario, Convert.ToInt32(idUsuario), subTipo);
                    if (id > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgSuccesful('Se guardó el comentario en bitácora');", true);
                        cargarBitacora();
                        limpiarBitacora();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Debe ingresar un comentario','error');", true);
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " btnGuardarComentarioBitacora_Click - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        private void limpiarBitacora()
        {
            txtComentarioBitacora.Text = "";
        }

        private void cargarBitacora()
        {
            try
            {
                int idUsuario = Convert.ToInt32(Session["RUT"].ToString());
                if (!idUsuario.Equals(0))
                {

                    DataSet dsB = controlador.ObtenerComentariosBitacora(idUsuario, 1); // tipoEntrada para Examen Ocupacional = 1 
                    if (dsB.Tables[0].Rows.Count > 0)
                    {
                        Session["gridBitacora"] = dsB.Tables[0].DefaultView;
                        gvBitacora.DataSource = dsB.Tables[0];
                        gvBitacora.DataBind();
                        lblMensajeBitacora.Visible = false;
                        gvBitacora.Visible = true;

                    }
                    else
                    {
                        lblMensajeBitacora.Visible = true;
                        gvBitacora.Visible = false;
                    }


                }
            }
            catch (Exception ex)
            {

                logger.Error(DateTime.Now + " CargarDocumentos - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);

            }
        }

        protected void gvControles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataView data = (DataView)Session["gridPrincipalControles"];
                if (data.Count > 0)
                {
                    gvControles.DataSource = data;
                    gvControles.PageIndex = e.NewPageIndex;
                    ViewState["gridPrincipalControles"] = e.NewPageIndex;
                    gvControles.DataBind();
                }
                else
                {
                    gvControles.Visible = false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " gvControles_PageIndexChanging - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void gvBitacora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataView data = (DataView)Session["gridBitacora"];
                if (data.Count > 0)
                {
                    gvBitacora.DataSource = data;
                    gvBitacora.PageIndex = e.NewPageIndex;
                    ViewState["gridBitacora"] = e.NewPageIndex;
                    gvBitacora.DataBind();
                }
                else
                {
                    gvBitacora.Visible = false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " gvBitacora_PageIndexChanging - frmEstatusExamenOcupacional", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
    }
}