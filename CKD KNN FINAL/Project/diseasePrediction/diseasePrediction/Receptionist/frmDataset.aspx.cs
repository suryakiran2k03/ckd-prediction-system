using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace diseasePrediction.Receptionist
{
    public partial class frmDataset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/frmLogin.aspx");
            }
            else
            {               
                LoadTrainingDataset();
            }

        }

        //function to load all patients
        private void LoadTrainingDataset()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetTrainingDataset();

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

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>Name</b>";
                mainrow.Controls.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>Age</b>";
                mainrow.Controls.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "<b>BP</b>";
                mainrow.Controls.Add(cell4);

                TableCell cell5 = new TableCell();
                cell5.Text = "<b>SpecificGravity</b>";
                mainrow.Controls.Add(cell5);

                TableCell cell6 = new TableCell();
                cell6.Text = "<b>Albumin</b>";
                mainrow.Controls.Add(cell6);

                TableCell cell7 = new TableCell();
                cell7.Text = "<b>Sugar</b>";
                mainrow.Controls.Add(cell7);

                TableCell cell8 = new TableCell();
                cell8.Text = "<b>RedBloodCells</b>";
                mainrow.Controls.Add(cell8);

                TableCell cell9 = new TableCell();
                cell9.Text = "<b>PusCell</b>";
                mainrow.Controls.Add(cell9);

                TableCell cell10 = new TableCell();
                cell10.Text = "<b>PusCellClumps</b>";
                mainrow.Controls.Add(cell10);

                TableCell cell101 = new TableCell();
                cell101.Text = "<b>Bacteria</b>";
                mainrow.Controls.Add(cell101);

                TableCell cell1011 = new TableCell();
                cell1011.Text = "<b>BloodGlucoseRandom</b>";
                mainrow.Controls.Add(cell1011);

                TableCell cell1012 = new TableCell();
                cell1012.Text = "<b>BloodUrea</b>";
                mainrow.Controls.Add(cell1012);

                TableCell cell1013 = new TableCell();
                cell1013.Text = "<b>SerumCreatinine</b>";
                mainrow.Controls.Add(cell1013);

                TableCell cell1014 = new TableCell();
                cell1014.Text = "<b>Sodium</b>";
                mainrow.Controls.Add(cell1014);

                TableCell cell1015 = new TableCell();
                cell1015.Text = "<b>Potassium</b>";
                mainrow.Controls.Add(cell1015);

                TableCell cell1016 = new TableCell();
                cell1016.Text = "<b>Hemoglobin</b>";
                mainrow.Controls.Add(cell1016);

                TableCell cell1017 = new TableCell();
                cell1017.Text = "<b>PackedCellVolume</b>";
                mainrow.Controls.Add(cell1017);

                TableCell cell1018 = new TableCell();
                cell1018.Text = "<b>WhiteBloodCellCount</b>";
                mainrow.Controls.Add(cell1018);

                TableCell cell1019 = new TableCell();
                cell1019.Text = "<b>RedBloodCellCount</b>";
                mainrow.Controls.Add(cell1019);

                TableCell cell10110 = new TableCell();
                cell10110.Text = "<b>Hypertension</b>";
                mainrow.Controls.Add(cell10110);

                TableCell cell10111 = new TableCell();
                cell10111.Text = "<b>DiabetesMellitus</b>";
                mainrow.Controls.Add(cell10111);

                TableCell cell10112 = new TableCell();
                cell10112.Text = "<b>CoronaryArteryDisease</b>";
                mainrow.Controls.Add(cell10112);

                TableCell cell101121 = new TableCell();
                cell101121.Text = "<b>Appetite</b>";
                mainrow.Controls.Add(cell101121);

                TableCell cell101122 = new TableCell();
                cell101122.Text = "<b>PedalEdema</b>";
                mainrow.Controls.Add(cell101122);

                TableCell cell101123 = new TableCell();
                cell101123.Text = "<b>Anemia</b>";
                mainrow.Controls.Add(cell101123);

                TableCell cell10113 = new TableCell();
                cell10113.Text = "<b>Result</b>";
                mainrow.Controls.Add(cell10113);

                TableCell cell11 = new TableCell();
                cell11.Text = "<b>Edit</b>";
                mainrow.Controls.Add(cell11);

                TableCell cell12 = new TableCell();
                cell12.Text = "<b>Delete</b>";
                mainrow.Controls.Add(cell12);
                               
                tablePatients.Controls.Add(mainrow);

                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    TableRow row = new TableRow();

                    TableCell cellName = new TableCell();                    
                    cellName.Text = tab.Rows[i]["Name"].ToString();
                    row.Controls.Add(cellName);

                    TableCell cellAge = new TableCell();                   
                    cellAge.Text = tab.Rows[i]["Age"].ToString();
                    row.Controls.Add(cellAge);

                    TableCell cellBP = new TableCell();
                    cellBP.Text = tab.Rows[i]["BP"].ToString();
                    row.Controls.Add(cellBP);

                    TableCell cellSpecificGravity = new TableCell();
                    cellSpecificGravity.Text = tab.Rows[i]["SpecificGravity"].ToString();
                    row.Controls.Add(cellSpecificGravity);

                    TableCell cellAlbumin = new TableCell();
                    cellAlbumin.Text = tab.Rows[i]["Albumin"].ToString();
                    row.Controls.Add(cellAlbumin);

                    TableCell cellSugar = new TableCell();
                    cellSugar.Text = tab.Rows[i]["Sugar"].ToString();
                    row.Controls.Add(cellSugar);

                    TableCell cellRedBloodCells = new TableCell();
                    cellRedBloodCells.Text = tab.Rows[i]["RedBloodCells"].ToString();
                    row.Controls.Add(cellRedBloodCells);

                    TableCell cellPusCell = new TableCell();
                    cellPusCell.Text = tab.Rows[i]["PusCell"].ToString();
                    row.Controls.Add(cellPusCell);

                    TableCell cellPusCellClumps = new TableCell();
                    cellPusCellClumps.Text = tab.Rows[i]["PusCellClumps"].ToString();
                    row.Controls.Add(cellPusCellClumps);

                    TableCell cellBacteria = new TableCell();
                    cellBacteria.Text = tab.Rows[i]["Bacteria"].ToString();
                    row.Controls.Add(cellBacteria);

                    TableCell cellBloodGlucoseRandom = new TableCell();
                    cellBloodGlucoseRandom.Text = tab.Rows[i]["BloodGlucoseRandom"].ToString();
                    row.Controls.Add(cellBloodGlucoseRandom);

                    TableCell cellBloodUrea = new TableCell();
                    cellBloodUrea.Text = tab.Rows[i]["BloodUrea"].ToString();
                    row.Controls.Add(cellBloodUrea);
                    
                    TableCell cellSerumCreatinine = new TableCell();
                    cellSerumCreatinine.Text = tab.Rows[i]["SerumCreatinine"].ToString();
                    row.Controls.Add(cellSerumCreatinine);

                    TableCell cellSodium = new TableCell();
                    cellSodium.Text = tab.Rows[i]["Sodium"].ToString();
                    row.Controls.Add(cellSodium);

                    TableCell cellPotassium = new TableCell();
                    cellPotassium.Text = tab.Rows[i]["Potassium"].ToString();
                    row.Controls.Add(cellPotassium);

                    TableCell cellHemoglobin = new TableCell();
                    cellHemoglobin.Text = tab.Rows[i]["Hemoglobin"].ToString();
                    row.Controls.Add(cellHemoglobin);
                    
                    TableCell cellPackedCellVolume = new TableCell();
                    cellPackedCellVolume.Text = tab.Rows[i]["PackedCellVolume"].ToString();
                    row.Controls.Add(cellPackedCellVolume);

                    TableCell cellWhiteBloodCellCount = new TableCell();
                    cellWhiteBloodCellCount.Text = tab.Rows[i]["WhiteBloodCellCount"].ToString();
                    row.Controls.Add(cellWhiteBloodCellCount);

                    TableCell cellRedBloodCellCount = new TableCell();
                    cellRedBloodCellCount.Text = tab.Rows[i]["RedBloodCellCount"].ToString();
                    row.Controls.Add(cellRedBloodCellCount);

                    TableCell cellHypertension = new TableCell();
                    cellHypertension.Text = tab.Rows[i]["Hypertension"].ToString();
                    row.Controls.Add(cellHypertension);
                    
                    TableCell cellDiabetesMellitus = new TableCell();
                    cellDiabetesMellitus.Text = tab.Rows[i]["DiabetesMellitus"].ToString();
                    row.Controls.Add(cellDiabetesMellitus);

                    TableCell cellCoronaryArteryDisease = new TableCell();
                    cellCoronaryArteryDisease.Text = tab.Rows[i]["CoronaryArteryDisease"].ToString();
                    row.Controls.Add(cellCoronaryArteryDisease);
                    
                    TableCell cellAppetite = new TableCell();
                    cellAppetite.Text = tab.Rows[i]["Appetite"].ToString();
                    row.Controls.Add(cellAppetite);
                    
                    TableCell cellPedalEdema = new TableCell();
                    cellPedalEdema.Text = tab.Rows[i]["PedalEdema"].ToString();
                    row.Controls.Add(cellPedalEdema);

                    TableCell cellAnemia = new TableCell();
                    cellAnemia.Text = tab.Rows[i]["Anemia"].ToString();
                    row.Controls.Add(cellAnemia);

                    TableCell cellResult = new TableCell();
                    cellResult.Text = tab.Rows[i]["Result"].ToString();
                    row.Controls.Add(cellResult);
                                    
                   
                    TableCell cell_edit = new TableCell();
                    LinkButton lbtn_edit = new LinkButton();
                    lbtn_edit.ForeColor = System.Drawing.Color.SteelBlue;
                    lbtn_edit.Text = "Edit";
                    lbtn_edit.Font.Bold = true;
                    lbtn_edit.ID = "Edit~" + tab.Rows[i]["PatientId"].ToString();
                    lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                    cell_edit.Controls.Add(lbtn_edit);
                    row.Controls.Add(cell_edit);

                    TableCell cell_delete = new TableCell();
                    LinkButton lbtn_delete = new LinkButton();
                    lbtn_delete.ForeColor = System.Drawing.Color.SteelBlue;
                    lbtn_delete.Text = "Delete";
                    lbtn_delete.Font.Bold = true;
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
                tablePatients.GridLines = GridLines.None;
                tablePatients.BorderStyle = BorderStyle.None;

                TableHeaderRow rno = new TableHeaderRow();
                TableHeaderCell cellno = new TableHeaderCell();
                cellno.ForeColor = System.Drawing.Color.Red;
                cellno.Text = "No Training Dataset Found!!!";

                rno.Controls.Add(cellno);
                tablePatients.Controls.Add(rno);
            }
        }

        //event to delete patient
        void lbtn_delete_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            try
            {
                obj.DeleteTrainingData(int.Parse(s[1].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Record Deleted Successfully!!!')</script>");
                LoadTrainingDataset();

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!!!')</script>");
            }
        }

        //click event to edit the patient details
        void lbtn_edit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            Session["Id"] = null;
            Session["Id"] = s[1];

            DataTable tab = new DataTable();
            tab = obj.GetTrainingDataById(int.Parse(s[1]));

            if (tab.Rows.Count > 0)
            {
                txtPatientName.Text = tab.Rows[0]["Name"].ToString();

                txtAge.Text = tab.Rows[0]["Age"].ToString();
                txtBP.Text = tab.Rows[0]["BP"].ToString();
                txtSpecificGravity.Text = tab.Rows[0]["SpecificGravity"].ToString();
                txtAlbumin.Text = tab.Rows[0]["Albumin"].ToString();
                txtSugar.Text = tab.Rows[0]["Sugar"].ToString();
                txtRedBloodCells.Text = tab.Rows[0]["RedBloodCells"].ToString();

                txtPusCell.Text = tab.Rows[0]["PusCell"].ToString();
                txtPusCellClumps.Text = tab.Rows[0]["PusCellClumps"].ToString();
                txtBacteria.Text = tab.Rows[0]["Bacteria"].ToString();
                txtBloodGlucoseRandom.Text = tab.Rows[0]["BloodGlucoseRandom"].ToString();
                txtBloodUrea.Text = tab.Rows[0]["BloodUrea"].ToString();
                txtSerumCreatinine.Text = tab.Rows[0]["SerumCreatinine"].ToString();
                txtSodium.Text = tab.Rows[0]["Sodium"].ToString();

                txtPotassium.Text = tab.Rows[0]["Potassium"].ToString();
                txtHemoglobin.Text = tab.Rows[0]["Hemoglobin"].ToString();
                txtPackedCellVolume.Text = tab.Rows[0]["PackedCellVolume"].ToString();
                txtWhiteBloodCellCount.Text = tab.Rows[0]["WhiteBloodCellCount"].ToString();
                txtRedBloodCellCount.Text = tab.Rows[0]["RedBloodCellCount"].ToString();
                txtHypertension.Text = tab.Rows[0]["Hypertension"].ToString();
                txtDiabetesMellitus.Text = tab.Rows[0]["DiabetesMellitus"].ToString();
                txtCoronaryArteryDisease.Text = tab.Rows[0]["CoronaryArteryDisease"].ToString();
                txtAppetite.Text = tab.Rows[0]["Appetite"].ToString();
                txtPedalEdema.Text = tab.Rows[0]["PedalEdema"].ToString();
                txtAnemia.Text = tab.Rows[0]["Anemia"].ToString();

                txtResult.Text = tab.Rows[0]["Result"].ToString();                
            }

            btnSubmit.Text = "Update";
        }

        //function to clear the textbox contents
        private void ClearTxtboxes()
        {
           txtAge.Text=txtAlbumin.Text=txtAnemia.Text=txtAppetite.Text=txtBacteria.Text=
            txtBloodGlucoseRandom.Text=txtBloodUrea.Text=txtBP.Text=txtCoronaryArteryDisease.Text=
            txtDiabetesMellitus.Text=txtHemoglobin.Text=txtHypertension.Text=txtPackedCellVolume.Text=
            txtPatientName.Text=txtPedalEdema.Text=txtPotassium.Text=txtPusCell.Text=txtPusCellClumps.Text=
            txtRedBloodCellCount.Text=txtRedBloodCells.Text=txtResult.Text=txtSerumCreatinine.Text=
            txtSodium.Text=txtSpecificGravity.Text=txtSugar.Text= txtWhiteBloodCellCount.Text= string.Empty;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            if (btnSubmit.Text.Equals("Submit"))
            {
                try
                {
                    obj.InsertTrainingData(txtPatientName.Text, int.Parse(txtAge.Text), double.Parse(txtBP.Text),
                        double.Parse(txtSpecificGravity.Text), double.Parse(txtAlbumin.Text), double.Parse(txtSugar.Text), double.Parse(txtRedBloodCells.Text),
                        double.Parse(txtPusCell.Text), double.Parse(txtPusCellClumps.Text), double.Parse(txtBacteria.Text), double.Parse(txtBloodGlucoseRandom.Text),
                        double.Parse(txtBloodUrea.Text), double.Parse(txtSerumCreatinine.Text), double.Parse(txtSodium.Text), double.Parse(txtPotassium.Text),
                        double.Parse(txtHemoglobin.Text), double.Parse(txtPackedCellVolume.Text), double.Parse(txtWhiteBloodCellCount.Text), double.Parse(txtRedBloodCellCount.Text),
                        double.Parse(txtHypertension.Text), double.Parse(txtDiabetesMellitus.Text), double.Parse(txtCoronaryArteryDisease.Text),
                        double.Parse(txtAppetite.Text), double.Parse(txtPedalEdema.Text), double.Parse(txtAnemia.Text),
                        int.Parse(txtResult.Text));

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Data Added Successfully!!!')</script>");
                    ClearTxtboxes();
                    LoadTrainingDataset();
                }
                catch
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
                }
            }
            else if (btnSubmit.Text.Equals("Update"))
            {

                obj.UpdateTrainingData(txtPatientName.Text, int.Parse(txtAge.Text), double.Parse(txtBP.Text),
                        double.Parse(txtSpecificGravity.Text), double.Parse(txtAlbumin.Text), double.Parse(txtSugar.Text), double.Parse(txtRedBloodCells.Text),
                        double.Parse(txtPusCell.Text), double.Parse(txtPusCellClumps.Text), double.Parse(txtBacteria.Text), double.Parse(txtBloodGlucoseRandom.Text),
                        double.Parse(txtBloodUrea.Text), double.Parse(txtSerumCreatinine.Text), double.Parse(txtSodium.Text), double.Parse(txtPotassium.Text),
                        double.Parse(txtHemoglobin.Text), double.Parse(txtPackedCellVolume.Text), double.Parse(txtWhiteBloodCellCount.Text), double.Parse(txtRedBloodCellCount.Text),
                        double.Parse(txtHypertension.Text), double.Parse(txtDiabetesMellitus.Text), double.Parse(txtCoronaryArteryDisease.Text),
                        double.Parse(txtAppetite.Text), double.Parse(txtPedalEdema.Text), double.Parse(txtAnemia.Text),
                        int.Parse(txtResult.Text), int.Parse(Session["Id"].ToString()));


                btnSubmit.Text = "Submit";
                ClearTxtboxes();
                LoadTrainingDataset();
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Data Updated Successfully!!!')</script>");
            }
        }
               
    }
}