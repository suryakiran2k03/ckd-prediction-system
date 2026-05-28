using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace diseasePrediction.Receptionist
{
    public partial class frmNewPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)

                txtPatientName.Focus();

            LoadNewPatients();
        }

        //function to load all new patients
        private void LoadNewPatients()
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();

                int serialNo = 1;

                tab = obj.GetAllNewPatients();

                if (tab.Rows.Count > 0)
                {
                    tablePatients.Rows.Clear();

                    tablePatients.BorderStyle = BorderStyle.Double;
                    tablePatients.GridLines = GridLines.Both;
                    tablePatients.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

                    mainrow.BackColor = System.Drawing.Color.SteelBlue;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SerialNo</b>";
                    mainrow.Controls.Add(cell1);

                    TableCell cell21 = new TableCell();
                    cell21.Text = "<b>Patient Id</b>";
                    mainrow.Controls.Add(cell21);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>Name</b>";
                    mainrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Age</b>";
                    mainrow.Controls.Add(cell3);

                    TableCell cell4 = new TableCell();
                    cell4.Text = "<b>Mobile</b>";
                    mainrow.Controls.Add(cell4);

                    TableCell cell41 = new TableCell();
                    cell41.Text = "<b>Address</b>";
                    mainrow.Controls.Add(cell41);

                    TableCell cell5 = new TableCell();
                    cell5.Text = "<b>Edit</b>";
                    mainrow.Controls.Add(cell5);

                    TableCell cell6 = new TableCell();
                    cell6.Text = "<b>Delete</b>";
                    mainrow.Controls.Add(cell6);

                    tablePatients.Controls.Add(mainrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 50;
                        cellSerialNo.Text = serialNo + i + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellId = new TableCell();
                        cellId.Text = tab.Rows[i]["PatientId"].ToString();
                        row.Controls.Add(cellId);

                        TableCell cellUName = new TableCell();
                        cellUName.Width = 150;
                        cellUName.Text = tab.Rows[i]["Name"].ToString();
                        row.Controls.Add(cellUName);

                        TableCell cellAge = new TableCell();
                        cellAge.Width = 100;
                        cellAge.Text = tab.Rows[i]["Age"].ToString();
                        row.Controls.Add(cellAge);

                        TableCell cellMobile = new TableCell();
                        cellMobile.Width = 150;
                        cellMobile.Text = tab.Rows[i]["Mobile"].ToString();
                        row.Controls.Add(cellMobile);

                        TableCell cellAddress = new TableCell();
                        cellAddress.Width = 250;
                        cellAddress.Text = tab.Rows[i]["Address"].ToString();
                        row.Controls.Add(cellAddress);

                        TableCell cell_edit = new TableCell();
                        LinkButton lbtn_edit = new LinkButton();
                        lbtn_edit.ForeColor = System.Drawing.Color.SteelBlue;
                        lbtn_edit.Font.Bold = true;
                        lbtn_edit.Text = "Edit";
                        lbtn_edit.ID = "Edit~" + tab.Rows[i]["PatientId"].ToString();
                        lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                        cell_edit.Controls.Add(lbtn_edit);
                        row.Controls.Add(cell_edit);

                        TableCell cell_delete = new TableCell();
                        LinkButton lbtn_delete = new LinkButton();
                        lbtn_delete.ForeColor = System.Drawing.Color.SteelBlue;
                        lbtn_delete.Font.Bold = true;
                        lbtn_delete.Text = "Delete";

                        lbtn_delete.ID = "Delete~" + tab.Rows[i]["PatientId"].ToString();
                        lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this record?')";
                        lbtn_delete.Click += new EventHandler(lbtn_delete_Click);
                        cell_delete.Controls.Add(lbtn_delete);
                        row.Controls.Add(cell_delete);

                        tablePatients.Controls.Add(row);
                    }
                }
                else
                {
                    tablePatients.Rows.Clear();

                    TableHeaderRow rno = new TableHeaderRow();
                    TableHeaderCell cellno = new TableHeaderCell();
                    cellno.ForeColor = System.Drawing.Color.Red;
                    cellno.Text = "No New Patients Found!!!";

                    rno.Controls.Add(cellno);
                    tablePatients.Controls.Add(rno);
                }
            }
            catch
            {

            }
        }

        //event to delete new patient
        void lbtn_delete_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            try
            {
                obj.DeleteTreatmentByNewPatient(int.Parse(s[1]));
                obj.DeleteNewPatient(int.Parse(s[1]));

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Patient Deleted Successfully')</script>");
                LoadNewPatients();

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!!!')</script>");
            }
        }

        //click event to edit the patient details
        void lbtn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                LinkButton lbtn = (LinkButton)sender;
                string[] s = lbtn.ID.ToString().Split('~');

                Session["pId"] = null;
                Session["pId"] = s[1];

                DataTable tab = new DataTable();
                tab = obj.GetNewPatientById(int.Parse(s[1]));

                if (tab.Rows.Count > 0)
                {
                    txtAddress.Text = tab.Rows[0]["Address"].ToString();
                    txtAge.Text = tab.Rows[0]["Age"].ToString();
                    txtMobile.Text = tab.Rows[0]["Mobile"].ToString();
                    txtPatientName.Text = tab.Rows[0]["Name"].ToString();
                }

                btnSubmit.Text = "Update";
            }
            catch
            {

            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (btnSubmit.Text.Equals("Submit"))
                {
                    obj.InsertNewPatient(int.Parse(txtAge.Text), txtPatientName.Text, txtMobile.Text, txtAddress.Text);

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('New Patient Added Successfully')</script>");
                    txtAddress.Text = txtAge.Text = txtMobile.Text = txtPatientName.Text = string.Empty;
                    LoadNewPatients();

                }
                else if (btnSubmit.Text.Equals("Update"))
                {
                    obj.UpdateNewPatient(int.Parse(txtAge.Text), txtPatientName.Text, txtMobile.Text, txtAddress.Text, int.Parse(Session["pId"].ToString()));

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Patient Updated Successfully')</script>");
                    txtAddress.Text = txtAge.Text = txtMobile.Text = txtPatientName.Text = string.Empty;
                    LoadNewPatients();

                    btnSubmit.Text = "Submit";
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
            }
        }

    }
}