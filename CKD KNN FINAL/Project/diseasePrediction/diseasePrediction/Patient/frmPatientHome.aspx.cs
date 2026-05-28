using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace diseasePrediction.Patient
{
    public partial class frmPatientHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PatientId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/frmLogin.aspx");
            }
            else
            {
                LoadTreatment();
            }
        }


        //function to display treatment details
        private void LoadTreatment()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetTreatmentByPatientId(int.Parse(Session["PatientId"].ToString()));

            if (tab.Rows.Count > 0)
            {
                int serialNO = 1;

                tableTreatment.Rows.Clear();

                tableTreatment.BorderStyle = BorderStyle.Double;
                tableTreatment.GridLines = GridLines.Both;
                tableTreatment.BorderColor = System.Drawing.Color.DarkGray;

                TableRow mainrow = new TableRow();
                mainrow.Height = 30;
                mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

                mainrow.BackColor = System.Drawing.Color.SteelBlue;

                TableCell cell1 = new TableCell();
                cell1.Text = "<b>SLNo</b>";
                mainrow.Controls.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>Disease Name</b>";
                mainrow.Controls.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>Treatment Details</b>";
                mainrow.Controls.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "<b>LasteUpdated</b>";
                mainrow.Controls.Add(cell4);

                
                tableTreatment.Controls.Add(mainrow);

                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    TableRow row = new TableRow();

                    TableCell cellSerialNo = new TableCell();
                    cellSerialNo.Width = 50;
                    cellSerialNo.Text = i + serialNO + ".";
                    row.Controls.Add(cellSerialNo);

                    TableCell cellDisease = new TableCell();
                    cellDisease.Width = 150;

                    cellDisease.Text = "Kidney Disease";
                    row.Controls.Add(cellDisease);

                    TableCell cellTreatment = new TableCell();
                    cellTreatment.Width = 450;
                    cellTreatment.Text = tab.Rows[i]["TreatmentDetails"].ToString();
                    row.Controls.Add(cellTreatment);

                    TableCell cellDate = new TableCell();
                    cellDate.Width = 100;
                    string[] s = tab.Rows[i]["LastUpdated"].ToString().Split(' ');
                    cellDate.Text = s[0];
                    row.Controls.Add(cellDate);
                    

                    tableTreatment.Controls.Add(row);
                }
            }
            else
            {
                tableTreatment.Rows.Clear();
                tableTreatment.GridLines = GridLines.None;
                tableTreatment.BorderStyle = BorderStyle.None;

                TableHeaderRow rno = new TableHeaderRow();
                TableHeaderCell cellno = new TableHeaderCell();
                cellno.ForeColor = System.Drawing.Color.Red;
                cellno.Text = "No Treatment Details Found!!!";

                rno.Controls.Add(cellno);
                tableTreatment.Controls.Add(rno);
            }
        }
    }
}