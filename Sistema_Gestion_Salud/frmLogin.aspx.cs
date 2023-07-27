using ControladorPersistencia;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_Gestion_Salud.Negocio;

namespace Sistema_Gestion_Salud
{
    public partial class frmLogin : System.Web.UI.Page
    {
        private ControladorLogica controlador = new ControladorLogica();
        private static readonly ILog logger = LogManager.GetLogger(typeof(frmLogin));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                Session["usuario"] = null;
                Session["perfil"] = null;
                Session["nombre"] = null;
                Session["perfilNombre"] = null;
                Session["perfilModulo"] = null;
                FailureText.Visible = false;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                AppSettingsReader conf = new AppSettingsReader();
                string username = UserName.Text.Trim();
                string pwd = Password.Text.Trim();
                //CheckBox ch = (CheckBox)Login1.FindControl("chCompañia");
                if (chCompañia.Checked)
                {
                    string strPath = conf.GetValue("LDAP", System.Type.GetType("System.String")).ToString();
                    string strDomain = "quadra";
                    string domainAndUsername = strDomain + @"\" + username;



                    //DirectoryEntry entry = new DirectoryEntry(strPath, "consulta_ldap", "Sgscmop2023!", AuthenticationTypes.Secure);
                    DirectoryEntry entry = new DirectoryEntry(strPath, username, pwd, AuthenticationTypes.Secure);
                    DirectorySearcher search = new DirectorySearcher(entry);
                    search.Filter = "(SAMAccountName=" + username + ")";
                    search.PropertiesToLoad.Add("cn");
                    try
                    {
                        SearchResult result = search.FindOne();

                        if (result != null)
                        {

                            DataSet dsUsuario = controlador.ObtenerUsu(username);
                            if (dsUsuario.Tables[0].Rows.Count > 0)
                            {
                                entry = result.GetDirectoryEntry();
                                Session["nombre"] = entry.Properties["displayname"][0].ToString();
                                Session["usuario"] = username;
                                Session["perfil"] = dsUsuario.Tables[0].Rows[0]["ID"].ToString();
                                Session["perfilNombre"] = dsUsuario.Tables[0].Rows[0]["PERFIL_NOMBRE"].ToString();
                                Session["perfilModulo"] = dsUsuario.Tables[0].Rows[0]["MODULO"].ToString();
                                Session["IDUsuarioConectado"] = dsUsuario.Tables[0].Rows[0]["ID_USUARIO"].ToString();
                                Response.Redirect("Presentacion/frmInicio.aspx", false);

                            }
                            else
                            {
                                FailureText.Visible = true;
                                FailureText.Text = "No registra acceso a Sistema";
                            }
                        }
                        else
                        {
                            FailureText.Visible = true;
                            FailureText.Text = "Acceso incorrecto para Cuenta / Password ingresado";
                        }

                    }
                    catch (Exception ex)
                    {
                        FailureText.Visible = true;
                        FailureText.Text = "Acceso incorrecto para Cuenta / Password ingresado";
                        logger.Error(DateTime.Now + " LoginButton_Click - frmLogin", ex);
                    }
                }
                else
                {
                    //usuario que no tiene cuenta de dominio
                    DataSet dsUsuario = controlador.ObtenerUsuarioPass(username, pwd);
                    if (dsUsuario.Tables[0].Rows.Count > 0)
                    {
                        Session["nombre"] = dsUsuario.Tables[0].Rows[0]["NOMBRE"].ToString();
                        Session["usuario"] = username;
                        Session["perfil"] = dsUsuario.Tables[0].Rows[0]["ID"].ToString();
                        Session["perfilNombre"] = dsUsuario.Tables[0].Rows[0]["PERFIL_NOMBRE"].ToString();
                        Session["perfilModulo"] = dsUsuario.Tables[0].Rows[0]["MODULO"].ToString();
                        Session["IDUsuarioConectado"] = dsUsuario.Tables[0].Rows[0]["ID_USUARIO"].ToString();
                        Response.Redirect("Presentacion/frmInicio.aspx");
                    }
                    else
                    {
                        FailureText.Visible = true;
                        FailureText.Text = "No registra acceso a Sistema";
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " LoginButton_Click - frmLogin", ex);
            }
        }
    }
}