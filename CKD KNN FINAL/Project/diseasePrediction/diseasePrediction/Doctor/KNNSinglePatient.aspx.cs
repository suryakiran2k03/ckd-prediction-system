using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace diseasePrediction.Doctor
{
    public partial class KNNSinglePatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                _KNNAlgorithm();
            }
            catch
            {

            }
        }

        //function which contains binning coding
        private void binningMethod()
        {
            try
            {

                BLL obj = new BLL();
                DataTable tabDataset = new DataTable();

                tabDataset.Rows.Clear();
                //fetch the training dataset 
                tabDataset = obj.GetTrainingDataset();

                if (tabDataset.Rows.Count > 0)
                {
                    //code of binning method
                    for (int i = 0; i < tabDataset.Rows.Count; i++)
                    {
                        string s = tabDataset.Rows[i]["Age"] + "," + tabDataset.Rows[i]["BP"] +
                            "," + tabDataset.Rows[i]["SpecificGravity"] + "," + tabDataset.Rows[i]["Albumin"] +
                            "," + tabDataset.Rows[i]["Sugar"] + "," + tabDataset.Rows[i]["RedBloodCells"] +
                            "," + tabDataset.Rows[i]["PusCell"] + "," +

                             tabDataset.Rows[i]["PusCellClumps"] + "," + tabDataset.Rows[i]["Bacteria"] +
                            "," + tabDataset.Rows[i]["BloodGlucoseRandom"] + "," + tabDataset.Rows[i]["BloodUrea"] +
                            "," + tabDataset.Rows[i]["SerumCreatinine"] + "," + tabDataset.Rows[i]["Sodium"] +
                            "," + tabDataset.Rows[i]["Potassium"]

                            + "," +

                             tabDataset.Rows[i]["Hemoglobin"] + "," + tabDataset.Rows[i]["PackedCellVolume"] +
                            "," + tabDataset.Rows[i]["WhiteBloodCellCount"] + "," + tabDataset.Rows[i]["RedBloodCellCount"] +
                            "," + tabDataset.Rows[i]["Hypertension"] + "," + tabDataset.Rows[i]["DiabetesMellitus"] +
                            "," + tabDataset.Rows[i]["CoronaryArteryDisease"]
                             + "," +

                             tabDataset.Rows[i]["Appetite"] + "," + tabDataset.Rows[i]["PedalEdema"] +
                            "," + tabDataset.Rows[i]["Anemia"]
                            ;

                        string[] parameter = s.Split(',');

                        for (int j = 0; j < parameter.Length; j++)
                        {
                            if (parameter[j].Equals("") || parameter.Equals("?"))
                            {
                                for (int k = 0; k < tabDataset.Rows.Count; k++)
                                {
                                    int id = 0;
                                    Random r = new Random();

                                    for (int x = 1; x <= 2; x++)
                                    {
                                        id = r.Next(9);
                                    }

                                    //setting value for ? and null value
                                    string _value = tabDataset.Rows[id][parameter[j]].ToString();
                                }
                            }

                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Dataset Not Found!!!')</script>");
                }
            }
            catch
            {

            }
        }

        //function which contains the algorithm steps
        private void _KNNAlgorithm()
        {
            BLL obj = new BLL();
            string _output = null;

            ArrayList _Distance = new ArrayList();
            ArrayList _PatientId = new ArrayList();

            ArrayList classify = new ArrayList();

            //getting patient parameters
            //DataTable tab = new DataTable();
            //tab = obj.GetTestingDataById(patId);


            //classify.Add(tab.Rows[0]["Name"].ToString());
            classify.Add(txtAge.Text);
            classify.Add(txtBP.Text);
            classify.Add(txtSpecificGravity.Text);
            classify.Add(txtAlbumin.Text);
            classify.Add(txtSugar.Text);

            classify.Add(txtRedBloodCells.Text);
            classify.Add(txtPusCell.Text);
            classify.Add(txtPusCellClumps.Text);
            classify.Add(txtBacteria.Text);
            classify.Add(txtBloodGlucoseRandom.Text);

            classify.Add(txtBloodUrea.Text);
            classify.Add(txtSerumCreatinine.Text);
            classify.Add(txtSodium.Text);
            classify.Add(txtPotassium.Text);
            classify.Add(txtHemoglobin.Text);

            classify.Add(txtPackedCellVolume.Text);
            classify.Add(txtWhiteBloodCellCount.Text);
            classify.Add(txtRedBloodCellCount.Text);
            classify.Add(txtHypertension.Text);
            classify.Add(txtDiabetesMellitus.Text);

            classify.Add(txtCoronaryArteryDisease.Text);
            classify.Add(txtAppetite.Text);
            classify.Add(txtPedalEdema.Text);
            classify.Add(txtAnemia.Text);

            //fetching training dataset
            DataTable tabTrainingDataset = new DataTable();
            tabTrainingDataset = GetTrainingDataset();


            int m = 3;
            _Distance.Clear();
            _PatientId.Clear();

            //finding the distance between the objects
            for (int i = 0; i < tabTrainingDataset.Rows.Count; i++)
            {
                double _val = 0.0;

                for (int j = 0; j < classify.Count; j++)
                {
                    _val += Math.Pow(double.Parse(tabTrainingDataset.Rows[i][j + 1].ToString()) - double.Parse(classify[j].ToString()), 2);
                }

                _val = Math.Sqrt(_val);

                _Distance.Add(Math.Round(_val, 1));
                _PatientId.Add(tabTrainingDataset.Rows[i]["PatientId"].ToString());
            }

            ArrayList temp = new ArrayList();
            ArrayList arrayPatients = new ArrayList();

            ArrayList arrayExists = new ArrayList();
            int d = 0;

            temp.Clear();
            arrayExists.Clear();
            arrayPatients.Clear();

            for (int x = 0; x < _Distance.Count; x++)
            {
                temp.Add(_Distance[x]);
            }

            temp.Sort();

            for (int y = 0; y < m; y++)
            {
                d = 0;

                for (int z = 0; z < _Distance.Count; z++)
                {
                    if (_Distance[z].Equals(temp[y]))
                    {
                        if (d == 0 && !arrayExists.Contains(_PatientId[z]))
                        {
                            arrayPatients.Add(_PatientId[z]);

                            arrayExists.Add(_PatientId[z]);

                            ++d;

                        }
                    }
                }
            }

            if (arrayPatients.Count > 0)
            {
                int cnt;

                ArrayList arrayCnt = new ArrayList();
                ArrayList arrayOutcome = new ArrayList();

                ArrayList s = new ArrayList();

                //get possible outcomes
                s.Add("0");
                s.Add("1");


                arrayCnt.Clear();
                arrayOutcome.Clear();

                for (int i = 0; i < s.Count; i++)
                {
                    cnt = 0;

                    for (int j = 0; j < arrayPatients.Count; j++)
                    {
                        DataTable tabpatientOutcome = new DataTable();
                        tabpatientOutcome = obj.GetTrainingDataById(int.Parse(arrayPatients[j].ToString()));

                        if (tabpatientOutcome.Rows[0]["Result"].ToString().Equals(s[i].ToString()))
                        {
                            ++cnt;
                        }
                    }

                    arrayCnt.Add(cnt);
                    arrayOutcome.Add(s[i].ToString());
                }

                ArrayList temp1 = new ArrayList();

                temp1.Clear();
                for (int x = 0; x < arrayCnt.Count; x++)
                {
                    temp1.Add(arrayCnt[x]);
                }

                temp1.Sort();
                temp1.Reverse();

                for (int y = 0; y < arrayCnt.Count; y++)
                {
                    if (arrayCnt[y].Equals(temp1[0]))
                    {

                        _output = s[y].ToString();

                        if (_output.Equals("1"))
                        {
                            _output = "YES";
                            btnStage.Visible = true;
                        }
                        else
                        {
                            _output = "NO";
                            btnStage.Visible = false;
                        }

                        lblResult.ForeColor = System.Drawing.Color.Green;
                        lblResult.Text = "Output: " + _output;

                        return;

                    }
                }

            }
            else
            {

            }


        }

        //function to load training data set
        public DataTable GetTrainingDataset()
        {
            BLL obj = new BLL();

            DataTable tabNewAttributes = new DataTable();
            DataTable tabAttributes = new DataTable();

            tabAttributes = obj.GetAllParameters();

            if (tabAttributes.Rows.Count > 0)
            {
                tabNewAttributes.Columns.Add("PatientId");

                for (int i = 0; i < tabAttributes.Rows.Count; i++)
                {
                    tabNewAttributes.Columns.Add(tabAttributes.Rows[i]["Parameter"].ToString());
                }

                tabNewAttributes.Columns.Add("Result");
            }

            DataTable tab = new DataTable();
            tab = obj.GetTrainingDataset();

            if (tab.Rows.Count > 0)
            {
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    DataRow row = tabNewAttributes.NewRow();

                    row[tabNewAttributes.Columns[0].ToString()] = tab.Rows[i]["PatientId"].ToString();

                    row[tabNewAttributes.Columns[1].ToString()] = tab.Rows[i]["Age"].ToString();
                    row[tabNewAttributes.Columns[2].ToString()] = tab.Rows[i]["BP"].ToString();
                    row[tabNewAttributes.Columns[3].ToString()] = tab.Rows[i]["SpecificGravity"].ToString();
                    row[tabNewAttributes.Columns[4].ToString()] = tab.Rows[i]["Albumin"].ToString();
                    row[tabNewAttributes.Columns[5].ToString()] = tab.Rows[i]["Sugar"].ToString();

                    row[tabNewAttributes.Columns[6].ToString()] = tab.Rows[i]["RedBloodCells"].ToString();
                    row[tabNewAttributes.Columns[7].ToString()] = tab.Rows[i]["PusCell"].ToString();
                    row[tabNewAttributes.Columns[8].ToString()] = tab.Rows[i]["PusCellClumps"].ToString();
                    row[tabNewAttributes.Columns[9].ToString()] = tab.Rows[i]["Bacteria"].ToString();
                    row[tabNewAttributes.Columns[10].ToString()] = tab.Rows[i]["BloodGlucoseRandom"].ToString();

                    row[tabNewAttributes.Columns[11].ToString()] = tab.Rows[i]["BloodUrea"].ToString();
                    row[tabNewAttributes.Columns[12].ToString()] = tab.Rows[i]["SerumCreatinine"].ToString();
                    row[tabNewAttributes.Columns[13].ToString()] = tab.Rows[i]["Sodium"].ToString();
                    row[tabNewAttributes.Columns[14].ToString()] = tab.Rows[i]["Potassium"].ToString();
                    row[tabNewAttributes.Columns[15].ToString()] = tab.Rows[i]["Hemoglobin"].ToString();

                    row[tabNewAttributes.Columns[16].ToString()] = tab.Rows[i]["PackedCellVolume"].ToString();
                    row[tabNewAttributes.Columns[17].ToString()] = tab.Rows[i]["WhiteBloodCellCount"].ToString();
                    row[tabNewAttributes.Columns[18].ToString()] = tab.Rows[i]["RedBloodCellCount"].ToString();
                    row[tabNewAttributes.Columns[19].ToString()] = tab.Rows[i]["Hypertension"].ToString();
                    row[tabNewAttributes.Columns[20].ToString()] = tab.Rows[i]["DiabetesMellitus"].ToString();

                    row[tabNewAttributes.Columns[21].ToString()] = tab.Rows[i]["CoronaryArteryDisease"].ToString();
                    row[tabNewAttributes.Columns[22].ToString()] = tab.Rows[i]["Appetite"].ToString();
                    row[tabNewAttributes.Columns[23].ToString()] = tab.Rows[i]["PedalEdema"].ToString();
                    row[tabNewAttributes.Columns[24].ToString()] = tab.Rows[i]["Anemia"].ToString();


                    row[tabNewAttributes.Columns[25].ToString()] = tab.Rows[i]["Result"].ToString();

                    tabNewAttributes.Rows.Add(row);


                }
            }

            return tabNewAttributes;
        }

        protected void btnStage_Click(object sender, EventArgs e)
        {
            Response.Redirect("_StagePrediction.aspx");
        }

       
        
    }
}