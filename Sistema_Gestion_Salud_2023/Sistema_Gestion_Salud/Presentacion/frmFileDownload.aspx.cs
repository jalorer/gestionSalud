using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

namespace Sistema_Gestion_Salud.Presentacion
{
    public partial class frmFileDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string output = Page.Request.QueryString.Get("ifile");
                string iUrl = HttpUtility.UrlDecode(output);
                string extensionfile = Path.GetExtension(iUrl);
                FileInfo file = new FileInfo(iUrl);
                if (file.Exists)
                {
                    var fi = new FileInfo(iUrl);
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + fi.Name);
                    Response.WriteFile(iUrl);
                    Response.End();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}