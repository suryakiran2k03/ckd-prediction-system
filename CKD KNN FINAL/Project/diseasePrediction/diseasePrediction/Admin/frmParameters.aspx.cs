using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace diseasePrediction.Admin
{
    public partial class frmParameters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/frmLogin.aspx");
            }
            else
            {               
                LoadParameters();
            }     
        }

        //function to load all parameters
        private void LoadParameters()
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();

                int serialNo = 1;

                tab = obj.GetAllParameters();

                if (tab.Rows.Count > 0)
                {
                    tableParameters.Rows.Clear();

                    tableParameters.BorderStyle = BorderStyle.Double;
                    tableParameters.GridLines = GridLines.Both;
                    tableParameters.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

                    mainrow.BackColor = System.Drawing.Color.SteelBlue;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SerialNo</b>";
                    mainrow.Controls.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>Parameter</b>";
                    mainrow.Controls.Add(cell2);

                   
                    tableParameters.Controls.Add(mainrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 50;
                        cellSerialNo.Text = serialNo + i + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellType = new TableCell();
                        cellType.Width = 250;
                        cellType.Text = tab.Rows[i]["Parameter"].ToString();
                        row.Controls.Add(cellType);

                        

                        tableParameters.Controls.Add(row);
                    }
                }
                else
                {
                    tableParameters.Rows.Clear();

                    tableParameters.BorderStyle = BorderStyle.None;
                    tableParameters.GridLines = GridLines.None;

                    TableHeaderRow rno = new TableHeaderRow();
                    TableHeaderCell cellno = new TableHeaderCell();
                    cellno.ForeColor = System.Drawing.Color.Red;
                    cellno.Text = "No Parameters Found!!!";

                    rno.Controls.Add(cellno);
                    tableParameters.Controls.Add(rno);
                }
            }
            catch
            {

            }
        }

      
    }
}