using log4net;
using Sistema_Gestion_Salud.Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Gestion_Salud.Presentacion
{
    public partial class frmAntecedentes_Trabajador : System.Web.UI.Page
    {
        private ControladorLogica controlador = new ControladorLogica();
        private static readonly ILog logger = LogManager.GetLogger(typeof(frmAntecedentes_Trabajador));
        AppSettingsReader conf = new AppSettingsReader();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
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
                        Session["RUT"] = "16488653";
                        string rut_usuario = Session["RUT"].ToString();
                        Cargar_Datos_Trabajador(rut_usuario);
                        CargarEstados(txtExOcupacional, "GS_BuscarUltimoEstatusExamenOcupacionalxRUT", Convert.ToInt32(rut_usuario));
                        CargarEstados(txtPsicosensometrico, "GS_BuscarUltimoEstatusPsicosensometricoxRUT", Convert.ToInt32(rut_usuario));
                        CargarEstados(txtVigenciaMinsal, "GS_BuscarUltimoVigenciaMinsalxRUT", Convert.ToInt32(rut_usuario));
                    }
                }
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

                logger.Error(DateTime.Now + " verificarperfil - frmAntecedentes_Trabajador", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
                return false;
            }
        }

        private void CargarEstados(TextBox txt, string Procedimiento, int rut_usuario)
        {
            try
            {
                DataSet ds = controlador.CargarCombos(Procedimiento, rut_usuario);
                txt.Text = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt.Text = ds.Tables[0].Rows[0]["ESTATUS"].ToString();
                }

            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " CargarCombos - frmAntecedentes_Trabajador ", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }
        private void Cargar_Datos_Trabajador(string RUT)
        {
            try
            {
                DataSet ds = controlador.BuscarDatosTrabajadorxRUT(RUT);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblRut.Text = "RUT : " + ds.Tables[0].Rows[0]["Rut"].ToString();
                    lblNombre.Text = "NOMBRE :" + ds.Tables[0].Rows[0]["Nombre"].ToString() + " " + ds.Tables[0].Rows[0]["Apellido_Pat"].ToString() + " " + ds.Tables[0].Rows[0]["Apellido_Mat"].ToString();
                    txtNombre.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                    txtApellidoPaterno.Text = ds.Tables[0].Rows[0]["Apellido_Pat"].ToString();
                    txtApellidoMaterno.Text = ds.Tables[0].Rows[0]["Apellido_Mat"].ToString();
                    txtGerencia.Text = ds.Tables[0].Rows[0]["Gerencia"].ToString();
                    txtSuperintendencia.Text = ds.Tables[0].Rows[0]["Superintendencia"].ToString();
                    txtCargo.Text = ds.Tables[0].Rows[0]["Cargo"].ToString();
                    txtTeam.Text = ds.Tables[0].Rows[0]["Team"].ToString();
                    txtMail.Text = ds.Tables[0].Rows[0]["Mail_personal"].ToString();
                    txtFono.Text = ds.Tables[0].Rows[0]["Fono"].ToString();
                    txtFechaIngreso.Text = ds.Tables[0].Rows[0]["Fecha_Ingreso"].ToString();
                   // txtExOcupacional.Text= ds.Tables[0].Rows[0]["DESC_ESTATUS"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('No se encuentra el trabajador','error');", true);
                }
            }
            catch (Exception ex)
            {

                logger.Error(DateTime.Now + " Cargar_Datos_Trabajador - frmAntecedentes_Trabajador", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);

            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/frmBuscarTrabajadores.aspx", false);
        }

        

        protected void imgExamenOcupacional_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                Response.Redirect("~/Presentacion/frmEstatusExamenOcupacional.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void imExamenPsicosensometrico_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                Response.Redirect("~/Presentacion/frmPsicoSensometrico.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}