using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diseasePrediction.Patient
{
    public partial class _DietRecc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string filename = "STAGE_1_Diet_Recommedation.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            string aaa = Server.MapPath("~/Files/" + filename);
            Response.TransmitFile(Server.MapPath("~/Patient/Files/" + filename));
            Response.End();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string filename = "STAGE_2_Diet_Recommedation.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            string aaa = Server.MapPath("~/Files/" + filename);
            Response.TransmitFile(Server.MapPath("~/Patient/Files/" + filename));
            Response.End();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string filename = "STAGE_3_Diet_Recommedation.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            string aaa = Server.MapPath("~/Files/" + filename);
            Response.TransmitFile(Server.MapPath("~/Patient/Files/" + filename));
            Response.End();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            string filename = "STAGE_4_Diet_Recommedation.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            string aaa = Server.MapPath("~/Files/" + filename);
            Response.TransmitFile(Server.MapPath("~/Patient/Files/" + filename));
            Response.End();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            string filename = "STAGE_5_Diet_Recommedation.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            string aaa = Server.MapPath("~/Files/" + filename);
            Response.TransmitFile(Server.MapPath("~/Patient/Files/" + filename));
            Response.End();
        }
    }
}