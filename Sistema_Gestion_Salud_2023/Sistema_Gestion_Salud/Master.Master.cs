using ControladorPersistencia;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_Gestion_Salud.Negocio;

namespace Sistema_Gestion_Salud
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private ControladorLogica controlador = new ControladorLogica();
        private static readonly ILog logger = LogManager.GetLogger(typeof(MasterPage));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    if (Session["nombre"] != null)
                    {

                        lblUsuarioConectado.Text = Session["nombre"].ToString();


                        CargarMenu();
                    }
                }
                else
                {
                    Response.Redirect("~/frmLogin.aspx");
                }
            }
        }

        private void CargarMenu()
        {
            try
            {

                int perfil = Convert.ToInt32(Session["perfil"].ToString());

                //obtener tipo
                DataSet dsTipo = controlador.ObtenerTipo(perfil, "Salud");
                DataSet ds = controlador.ObtenerMenu(perfil, "Salud");

                if (dsTipo.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsTipo.Tables[0].Rows.Count; i++)
                    {
                        if (dsTipo.Tables[0].Rows[i]["TIPO"].ToString().Length > 0)
                        {
                            MenuItem padre = new MenuItem();
                            padre.NavigateUrl = "";
                            padre.Text = dsTipo.Tables[0].Rows[i][1].ToString();
                            MenuInicio.Items.Add(padre);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                {

                                    if (ds.Tables[0].Rows[j]["TIPO"].ToString().Equals(dsTipo.Tables[0].Rows[i]["TIPO"].ToString()))
                                    {
                                        if (ds.Tables[0].Rows[j]["TIPO"].ToString().Equals(ds.Tables[0].Rows[j]["DESCRIPCION"].ToString()))
                                        {
                                            //padre.Target = "_blank";
                                            padre.NavigateUrl = ds.Tables[0].Rows[j][1].ToString();
                                        }
                                        else
                                        {
                                            MenuItem hijo = new MenuItem();
                                            hijo.NavigateUrl = "";
                                            hijo.Text = ds.Tables[0].Rows[j][3].ToString();
                                            hijo.NavigateUrl = ds.Tables[0].Rows[j][1].ToString();
                                            padre.ChildItems.Add(hijo);
                                        }


                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(DateTime.Now + " Método CargarMenu - MasterProyecto_Idea", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"msgerror('Ha ocurrido un error. Favor contactar al Administrador del Sistema','error');", true);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/frmInicio.aspx");
        }
    }
}