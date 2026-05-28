using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diseasePrediction.Doctor
{
    public partial class _S5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string filename = "STAGE_5_Diet_Recommedation.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            string aaa = Server.MapPath("~/Files/" + filename);
            Response.TransmitFile(Server.MapPath("~/Doctor/Files/" + filename));
            Response.End();
            //Response.Redirect("~/Doctor/Files/STAGE_5_Diet_Recommedation.pdf");
        }
    }
}