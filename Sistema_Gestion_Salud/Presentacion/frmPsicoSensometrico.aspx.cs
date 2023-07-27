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
    public partial class frmPsicoSensometrico : System.Web.UI.Page
    {
        private ControladorLogica controlador = new ControladorLogica();
        private static readonly ILog logger = LogManager.GetLogger(typeof(frmPsicoSensometrico));
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
                            Session["index_anterior"] = 0;
                            Session["index_ultimo"] = 0;
                            CargarPeriodo(ddlPeriodo);
                            CargarCombosSinParametros(ddlTipoVehiculo, "GS_ObtenerTipoVehiculo", "ID", "DESCRIPCION");
                            CargarCombosSinParametros(ddlCausaContraindicacion, "GS_ObtenerCausaContraIndicacion", "ID_CAUSA", "DESC_CAUSA_CONTR");
                            CargarCombosSinParametros(ddlEstatus, "GS_ObtenerEstadoPSM", "ID", "DESCRIPCION");
                            CargarGrilla();
                            cargarBitacora();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Page_Load - frmPsicoSensometrico", ex);
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

                logger.Error(DateTime.Now + " verificarperfil - frmPsicoSensometrico", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                return false;
            }
        }
        private void CargarPeriodo(DropDownList ddl)
        {
            try
            {
                ddl.Items.Insert(0, new ListItem("Todas los vencimientos", "0"));
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
                logger.Error(DateTime.Now + " CargarCombos - frmPsicoSensometrico ", ex);
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
                    DataSet ds = controlador.Procedimiento_Generico_2_Parametros_Integer("GS_BuscarExamenesPsicosensometricosxAnio", rut, periodo);
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
                    int periodo = 0;
                    DataSet ds = controlador.Procedimiento_Generico_2_Parametros_Integer("GS_BuscarExamenesPsicosensometricosxAnio", rut, periodo);
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
                logger.Error(DateTime.Now + " ddlPeriodo_SelectedIndexChanged - frmPsicoSensometrico", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
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
                logger.Error(DateTime.Now + " CargarCombosSinParametros - frmPsicoSensometrico ", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string ERROR = "NO";
                int id_vehiculo = 0;
                int id_causa_contraindicacion = 0;
                int id_estado_psm = 0;
                string pendientes = txtPendientes.Text;
                int id_usuario = Convert.ToInt32(Session["RUT"].ToString());
                string aux_fecha_control = txtFechaControl.Text.Trim();
                DateTime fecha_control;
                if (txtFechaControl.Text.Length == 0)
                {
                    fecha_control = Convert.ToDateTime("1900-01-01");
                }
                else
                {
                    fecha_control = Convert.ToDateTime(txtFechaControl.Text.Trim());
                }

                string aux_fecha_vencimiento = txtFechaVencimiento.Text.Trim();
                DateTime fecha_vencimiento = Convert.ToDateTime("1900-01-01");
                if (txtFechaVencimiento.Text.Length == 0)
                {
                    ERROR = "SI";
                    lblFechaVencimiento.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    fecha_vencimiento = Convert.ToDateTime(txtFechaVencimiento.Text.Trim());
                    lblFechaVencimiento.ForeColor = System.Drawing.Color.Black;
                }

                string aux_vehiculo = ddlTipoVehiculo.SelectedValue;
                if (aux_vehiculo.Equals("0"))
                {
                    ERROR = "SI";
                    lblTipoVehiculo.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    id_vehiculo = Convert.ToInt32(ddlTipoVehiculo.SelectedValue);
                    lblTipoVehiculo.ForeColor = System.Drawing.Color.Black;
                }

                string aux_causa_contraindicacion = ddlCausaContraindicacion.SelectedValue;
                if (aux_causa_contraindicacion.Equals("0"))
                {
                    ERROR = "SI";
                    lblCausaContraindicacion.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    id_causa_contraindicacion = Convert.ToInt32(ddlCausaContraindicacion.SelectedValue);
                    lblCausaContraindicacion.ForeColor = System.Drawing.Color.Black;
                }

                string aux_estado_psm = ddlEstatus.SelectedValue;
                if (aux_estado_psm.Equals("0"))
                {
                    ERROR = "SI";
                    lblEstado.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    id_estado_psm = Convert.ToInt32(ddlEstatus.SelectedValue);
                    lblEstado.ForeColor = System.Drawing.Color.Black;
                }

                string aux_observacion = txtObservacionControl.Text.Trim();

                if (ERROR.Equals("NO"))
                {

                    int id = controlador.GuardarPsicosensometrico(id_usuario, fecha_control, fecha_vencimiento, id_vehiculo, id_causa_contraindicacion, id_estado_psm, aux_observacion,pendientes);
                    if (id >= 0)
                    {
                        guardarBitacoraPsicoSensometrico();
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgSuccesful('Se han guardado las datos PsicoSensométricos');", true);
                        CargarGrilla();
                        limpiar();
                        if (!Convert.ToInt32(Session["index_ultimo"].ToString()).Equals(0))
                        {
                            gvDatos.Rows[Convert.ToInt32(Session["index_ultimo"].ToString())].BackColor = System.Drawing.Color.Orange;
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Debe ingresar los datos obligatorios','warning');", true);
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " btnGuardar_Click - frmPsicoSensometrico", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        private void limpiar()
        {
            txtFechaVencimiento.Text = "";
            txtDiasRestantes.Text = "";
            txtObservacionControl.Text = "";
            txtPendientes.Text = "";
            ddlPeriodo.SelectedIndex = 0;
            ddlTipoVehiculo.SelectedIndex = 0;
            ddlCausaContraindicacion.SelectedIndex = 0;
            ddlEstatus.SelectedIndex = 0;
            txtFechaControl.Text = "";


        }

        private void guardarBitacoraPsicoSensometrico()
        {
            try
            {
                string idUsuario = Session["RUT"].ToString();

                int idTipoEntrada = 1;
                DateTime fecha = Convert.ToDateTime(txtFechaControl.Text);
                string usuarioComentario = Session["usuario"].ToString();
                string comentario = "";
              
                    comentario = "Estatus PsicoSensométrico: " + ddlEstatus.SelectedItem + " - " + "Causa de Contraindicación: " + ddlCausaContraindicacion.SelectedItem;
                
               
                string subTipo = "Ex. PsicoSensométrico";
                int id = controlador.GuardarComentarioBitacora(fecha, idTipoEntrada, comentario, usuarioComentario, Convert.ToInt32(idUsuario), subTipo);
                if (id > 0)
                {
                    cargarBitacora();
                    limpiarBitacora();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                }

            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " guardarBitacoraPsicoSensometrico - frmPsicoSensometrico", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
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
                logger.Error(DateTime.Now + " gvDatos_PageIndexChanging - frmPsicoSensometrico", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        private void CargarGrilla()
        {
            try
            {
                int idUsuario = Convert.ToInt32(Session["RUT"].ToString());
                DataSet ds = controlador.Procedimiento_Generico("GS_BuscarExamenesPsicosensometricosxIdUsuario", idUsuario);
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
                logger.Error(DateTime.Now + " CargarGrilla - frmPsicoSensometrico", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Seleccionar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvDatos.Rows[index];
                    int idPSM = Convert.ToInt32(Server.HtmlDecode(row.Cells[0].Text));
                    Session["IdPsicosensometrico"] = idPSM;

                    // para cambiar de color la linea
                    if (!Convert.ToInt32(Session["index_anterior"].ToString()).Equals(index))
                    {
                        gvDatos.Rows[Convert.ToInt32(Session["index_anterior"].ToString())].BackColor = System.Drawing.Color.White;
                    }
                    Session["index_anterior"] = index;
                    Session["index_ultimo"] = index;
                    gvDatos.Rows[index].BackColor = System.Drawing.Color.Orange;
                    // fin cambio color linea

                    DataSet ds = controlador.Procedimiento_Generico("GS_BuscarPsicosensometricoxId", idPSM);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlTipoVehiculo.SelectedValue = ds.Tables[0].Rows[0]["ID_Tipo_Vehiculo"].ToString();
                        if (ddlTipoVehiculo.SelectedValue.Equals("1") || ddlTipoVehiculo.SelectedValue.Equals("2"))
                        {
                            txtFechaControl.Enabled = true;
                        }
                        else
                        {
                            txtFechaControl.Enabled = false;
                        }
                        txtFechaControl.Text = ds.Tables[0].Rows[0]["Fecha_Control"].ToString();
                        ddlCausaContraindicacion.SelectedValue = ds.Tables[0].Rows[0]["ID_Causa_Contraindicacion"].ToString();
                        txtFechaVencimiento.Text = ds.Tables[0].Rows[0]["Fecha_Vencimiento"].ToString();
                        txtDiasRestantes.Text = ds.Tables[0].Rows[0]["Dias_Restantes"].ToString();
                        txtPendientes.Text= ds.Tables[0].Rows[0]["Pendientes"].ToString();
                        ddlEstatus.SelectedValue = ds.Tables[0].Rows[0]["ID_Estado_PSM"].ToString();
                        if (ddlEstatus.SelectedValue.Equals("1"))
                        {
                            ddlCausaContraindicacion.Enabled = false;
                        }
                        else
                        {
                            ddlCausaContraindicacion.Enabled = true;
                        }
                        txtObservacionControl.Text = ds.Tables[0].Rows[0]["Observacion"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " gvDatos_RowCommand - frmPsicoSensometrico", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void ddlEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idEstado = Convert.ToInt32(ddlEstatus.SelectedValue);
                if (idEstado.Equals(1))
                {
                    ddlCausaContraindicacion.Enabled = false;
                    ddlCausaContraindicacion.SelectedValue = "19"; // 19 = "No Aplica "

                }
                else
                {
                    ddlCausaContraindicacion.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " ddlEstatus_SelectedIndexChanged - frmPsicoSensometrico", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void ddlTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoVehiculo = Convert.ToInt32(ddlTipoVehiculo.SelectedValue);
                if (idTipoVehiculo.Equals(1) || idTipoVehiculo.Equals(2))
                {
                    txtFechaControl.Enabled = true;
                    txtFechaControl.Text = "";
                    txtFechaVencimiento.Text = "";
                }
                else
                {
                    txtFechaControl.Enabled = false;
                    txtFechaControl.Text = "";
                    txtFechaVencimiento.Text = "";

                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " ddlTipoVehiculo_SelectedIndexChanged - frmPsicoSensometrico", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void txtFechaControl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoVehiculo.SelectedValue.Equals("1") || ddlTipoVehiculo.SelectedValue.Equals("2"))
                {
                    txtFechaControl.Enabled = true;
                    if (txtFechaControl.Text.Length > 0)
                    {
                        DateTime fecha = DateTime.Now;
                        if (ddlTipoVehiculo.SelectedValue.Equals("1"))
                        {
                            fecha = Convert.ToDateTime(txtFechaControl.Text).AddYears(4);
                        }
                        else if (ddlTipoVehiculo.SelectedValue.Equals("2"))
                        {
                            fecha = Convert.ToDateTime(txtFechaControl.Text).AddYears(1);

                        }
                        //string fecha=Convert.ToString(Convert.ToDateTime(txtFechaControl.Text).AddYears(4));
                        string formato = "dd-MM-yyyy";
                        txtFechaVencimiento.Text = fecha.ToString(formato);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " txtFechaControl_TextChanged - frmPsicoSensometrico", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
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
        protected void btnGuardarComentarioBitacora_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtComentarioBitacora.Text.Length > 0)
                {
                    string usuarioComentario = Session["usuario"].ToString();
                    DateTime fecha = DateTime.Today;
                    //TIPO Entrada 1 para Examen Ocupacional , Se debe mostrar la bitacora en todos lados, se mantendra tip1 , pero en subtipo se especifica origen.
                    int idTipoEntrada = 1;
                    string comentario = txtComentarioBitacora.Text;
                    string idUsuario = Session["RUT"].ToString();
                    string subTipo = "Comentario Normal - E.Psico";

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