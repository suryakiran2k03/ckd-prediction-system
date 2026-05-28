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
    public partial class Compare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CompareAlgorithms();
        }
                
        private void f1_Naivebayes()
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                BLL obj = new BLL();
                DataTable tabTestingDataset = new DataTable();
                tabTestingDataset = obj.GetTestingDataset();

                DataTable tabTrainingDataset = new DataTable();
                tabTrainingDataset = GetTrainingDataset();

                if (tabTestingDataset.Rows.Count > 0 && tabTrainingDataset.Rows.Count > 0)
                {
                    Table1.Rows.Clear();

                    Table1.BorderStyle = BorderStyle.Double;
                    Table1.GridLines = GridLines.Both;
                    Table1.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

                    mainrow.BackColor = System.Drawing.Color.SteelBlue;

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>PatientName</b>";
                    mainrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Prediction</b>";
                    mainrow.Controls.Add(cell3);

                    Table1.Controls.Add(mainrow);

                    for (int i = 0; i < tabTestingDataset.Rows.Count; i++)
                    {
                        DataTable tabPat = new DataTable();
                        tabPat = obj.GetTestingDataById(int.Parse(tabTestingDataset.Rows[i]["PatientId"].ToString()));

                        string _Output = Naive_Bayes(int.Parse(tabTestingDataset.Rows[i]["PatientId"].ToString()));

                        TableRow row = new TableRow();

                        TableCell cellName = new TableCell();
                        cellName.Width = 150;
                        cellName.Text = tabPat.Rows[0]["Name"].ToString();
                        row.Controls.Add(cellName);

                        TableCell cellResult = new TableCell();
                        cellResult.Width = 150;
                        cellResult.Text = _Output;
                        row.Controls.Add(cellResult);

                        Table1.Controls.Add(row);
                    }

                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _timeNB = elapsedMs.ToString();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Testing/Training Dataset Not Found!!!')</script>");
                }
            }
            catch
            {

            }
        }

        double pi;
        int nc, n;
        double result;
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();
        double _outcomeCntNB = 0;
        double _outcomeTPNB = 0;
        double _outcomeFPNB = 0;
        double _outcomeFNNB = 0;

        double _outcomeCntKNN = 0;
        double _outcomeTPKNN = 0;
        double _outcomeFPKNN = 0;
        double _outcomeFNKNN = 0;
        string _timeNB, _timeKNN;

        double _KNNTP = 0;
        double _KNNTN = 0;
        double _KNNFP = 0;
        double _KNNFN = 0;

        double _NBTP = 0;
        double _NBTN = 0;
        double _NBFP = 0;
        double _NBFN = 0;

        //function which contains the naive bayes algorithm steps
        private string Naive_Bayes(int patId)
        {
            BLL obj = new BLL();
            ArrayList s = new ArrayList();
            string _output = null;

            //get possible outcomes
            s.Add("0");
            s.Add("1");

            ArrayList parameters = new ArrayList();
            DataTable tabParameter = new DataTable();

            tabParameter = obj.GetAllParameters();

            //value of m and p
            int m = tabParameter.Rows.Count;
            double numer = 1.0;
            double dino = double.Parse(s.Count.ToString());
            double p = numer / dino;

            if (tabParameter.Rows.Count > 0)
            {
                //storing parameter names into arraylist (parameters)
                for (int i = 0; i < tabParameter.Rows.Count; i++)
                {
                    parameters.Add(tabParameter.Rows[i]["Parameter"].ToString());
                }
            }

            ArrayList classify = new ArrayList();

            //getting patient parameters
            DataTable tab = new DataTable();
            tab = obj.GetTestingDataById(patId);

            if (tab.Rows.Count > 0)
            {
                //storing current patient parameters into arraylist (classify)
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    //classify.Add(tab.Rows[0]["Name"].ToString());
                    classify.Add(tab.Rows[0]["Age"].ToString());
                    classify.Add(tab.Rows[0]["BP"].ToString());
                    classify.Add(tab.Rows[0]["SpecificGravity"].ToString());
                    classify.Add(tab.Rows[0]["Albumin"].ToString());
                    classify.Add(tab.Rows[0]["Sugar"].ToString());

                    classify.Add(tab.Rows[0]["RedBloodCells"].ToString());
                    classify.Add(tab.Rows[0]["PusCell"].ToString());
                    classify.Add(tab.Rows[0]["PusCellClumps"].ToString());
                    classify.Add(tab.Rows[0]["Bacteria"].ToString());
                    classify.Add(tab.Rows[0]["BloodGlucoseRandom"].ToString());

                    classify.Add(tab.Rows[0]["BloodUrea"].ToString());
                    classify.Add(tab.Rows[0]["SerumCreatinine"].ToString());
                    classify.Add(tab.Rows[0]["Sodium"].ToString());
                    classify.Add(tab.Rows[0]["Potassium"].ToString());
                    classify.Add(tab.Rows[0]["Hemoglobin"].ToString());

                    classify.Add(tab.Rows[0]["PackedCellVolume"].ToString());
                    classify.Add(tab.Rows[0]["WhiteBloodCellCount"].ToString());
                    classify.Add(tab.Rows[0]["RedBloodCellCount"].ToString());
                    classify.Add(tab.Rows[0]["Hypertension"].ToString());
                    classify.Add(tab.Rows[0]["DiabetesMellitus"].ToString());

                    classify.Add(tab.Rows[0]["CoronaryArteryDisease"].ToString());
                    classify.Add(tab.Rows[0]["Appetite"].ToString());
                    classify.Add(tab.Rows[0]["PedalEdema"].ToString());
                    classify.Add(tab.Rows[0]["Anemia"].ToString());
                   

                }

                //fetching training dataset
                DataTable tabTrainingSet = new DataTable();
                tabTrainingSet = GetTrainingDataset();

                output.Clear();


                for (int i = 0; i < s.Count; i++)
                {
                    mul.Clear();

                    for (int j = 0; j < parameters.Count; j++)
                    {
                        n = 0;
                        nc = 0;

                        for (int d = 0; d < tabTrainingSet.Rows.Count; d++)
                        {
                            if (tabTrainingSet.Rows[d][j + 1].ToString().Equals(classify[j]))
                            {
                                ++n;

                                if (tabTrainingSet.Rows[d][m + 1].ToString().Equals(s[i]))

                                    ++nc;
                            }
                        }

                        double x = m * p;
                        double y = n + m;
                        double z = nc + x;

                        pi = z / y;
                        mul.Add(Math.Abs(pi));
                    }

                    double mulres = 1.0;

                    for (int z = 0; z < mul.Count; z++)
                    {
                        mulres *= double.Parse(mul[z].ToString());
                    }

                    result = mulres * p;
                    output.Add(Math.Abs(result));
                }

                //prediction
                ArrayList list1 = new ArrayList();

                for (int x = 0; x < s.Count; x++)
                {
                    list1.Add(output[x]);
                }

                list1.Sort();
                list1.Reverse();

                for (int y = 0; y < s.Count; y++)
                {
                    if (output[y].Equals(list1[0]))
                    {
                        _output = s[y].ToString();

                        if (_output.Equals("1"))
                        {
                            _output = "CKD";
                        }
                        else
                        {
                            _output = "NOT CKD";
                        }

                        DataTable tabActualData = new DataTable();
                        tabActualData = obj.GetActualPatientDataById(patId);

                        if (tabActualData.Rows[0]["Result"].ToString().Equals(s[y].ToString()))
                        {
                            ++_outcomeCntNB;
                            ++_outcomeTPNB;                            
                        }
                        else
                        {
                            if (_output.Equals("CKD"))
                            {
                                ++_outcomeFPNB;
                            }
                            else
                            {
                                ++_outcomeFNNB;
                            }                           
                        }

                        //confusion matrix
                        if (tabActualData.Rows[0]["Result"].ToString().Equals("1"))
                        {
                            if (tabActualData.Rows[0]["Result"].ToString().Equals(s[y].ToString()))
                            {
                                ++_NBTP;
                            }
                            else
                            {
                                ++_NBTN;
                            }
                        }
                        else 
                        {
                            if (tabActualData.Rows[0]["Result"].ToString().Equals(s[y].ToString()))
                            {
                                ++_NBFP;
                            }
                            else
                            {
                                ++_NBFN;
                            }
                        }

                        return _output;
                    }
                }
            }
            else
            {

            }

            return _output;
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
                
        private void f2_KNN()
        {
            try
            {
                BLL obj = new BLL();

                var watch = System.Diagnostics.Stopwatch.StartNew();
                // the code that you want to measure comes here

                DataTable tabTestingDataset = new DataTable();
                tabTestingDataset = obj.GetTestingDataset();

                DataTable tabTrainingDataset = new DataTable();
                tabTrainingDataset = GetTrainingDataset();

                if (tabTestingDataset.Rows.Count > 0 && tabTrainingDataset.Rows.Count > 0)
                {
                    Table2.Rows.Clear();

                    Table2.BorderStyle = BorderStyle.Double;
                    Table2.GridLines = GridLines.Both;
                    Table2.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

                    mainrow.BackColor = System.Drawing.Color.SteelBlue;

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>PatientName</b>";
                    mainrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Prediction</b>";
                    mainrow.Controls.Add(cell3);

                    Table2.Controls.Add(mainrow);

                    for (int i = 0; i < tabTestingDataset.Rows.Count; i++)
                    {
                        DataTable tabPat = new DataTable();
                        tabPat = obj.GetTestingDataById(int.Parse(tabTestingDataset.Rows[i]["PatientId"].ToString()));

                        string _Output = KNN(int.Parse(tabTestingDataset.Rows[i]["PatientId"].ToString()));

                        TableRow row = new TableRow();

                        TableCell cellName = new TableCell();
                        cellName.Width = 150;
                        cellName.Text = tabPat.Rows[0]["Name"].ToString();
                        row.Controls.Add(cellName);

                        TableCell cellResult = new TableCell();
                        cellResult.Width = 150;
                        cellResult.Text = _Output;
                        row.Controls.Add(cellResult);

                        Table2.Controls.Add(row);
                    }

                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _timeKNN = elapsedMs.ToString();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Testing/Training Dataset Not Found!!!')</script>");
                }
            }
            catch
            {

            }
        }
       
        //function which contains the KNN algorithm steps
        private string KNN(int patId)
        {
            BLL obj = new BLL();
            string _output = null;

            ArrayList _Distance = new ArrayList();
            ArrayList _PatientId = new ArrayList();

            DataTable tabTrainingDataset = new DataTable();
            tabTrainingDataset = GetTrainingDataset();

            ArrayList classify = new ArrayList();

            DataTable tab = new DataTable();
            tab = obj.GetTestingDataById(patId);

            if (tab.Rows.Count > 0)
            {
                classify.Clear();

                //storing current patient parameters into arraylist (classify)
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    //classify.Add(tab.Rows[0]["Name"].ToString());
                    classify.Add(tab.Rows[0]["Age"].ToString());
                    classify.Add(tab.Rows[0]["BP"].ToString());
                    classify.Add(tab.Rows[0]["SpecificGravity"].ToString());
                    classify.Add(tab.Rows[0]["Albumin"].ToString());
                    classify.Add(tab.Rows[0]["Sugar"].ToString());

                    classify.Add(tab.Rows[0]["RedBloodCells"].ToString());
                    classify.Add(tab.Rows[0]["PusCell"].ToString());
                    classify.Add(tab.Rows[0]["PusCellClumps"].ToString());
                    classify.Add(tab.Rows[0]["Bacteria"].ToString());
                    classify.Add(tab.Rows[0]["BloodGlucoseRandom"].ToString());

                    classify.Add(tab.Rows[0]["BloodUrea"].ToString());
                    classify.Add(tab.Rows[0]["SerumCreatinine"].ToString());
                    classify.Add(tab.Rows[0]["Sodium"].ToString());
                    classify.Add(tab.Rows[0]["Potassium"].ToString());
                    classify.Add(tab.Rows[0]["Hemoglobin"].ToString());

                    classify.Add(tab.Rows[0]["PackedCellVolume"].ToString());
                    classify.Add(tab.Rows[0]["WhiteBloodCellCount"].ToString());
                    classify.Add(tab.Rows[0]["RedBloodCellCount"].ToString());
                    classify.Add(tab.Rows[0]["Hypertension"].ToString());
                    classify.Add(tab.Rows[0]["DiabetesMellitus"].ToString());

                    classify.Add(tab.Rows[0]["CoronaryArteryDisease"].ToString());
                    classify.Add(tab.Rows[0]["Appetite"].ToString());
                    classify.Add(tab.Rows[0]["PedalEdema"].ToString());
                    classify.Add(tab.Rows[0]["Anemia"].ToString());
                   

                }

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
                            _output = arrayOutcome[y].ToString();

                            if (_output.Equals("1"))
                            {
                                _output = "CKD";
                            }
                            else
                            {
                                _output = "NOT CKD";
                            }

                            DataTable tabActualData = new DataTable();
                            tabActualData = obj.GetActualPatientDataById(patId);

                            if (tabActualData.Rows[0]["Result"].ToString().Equals(s[y].ToString()))
                            {
                                ++_outcomeCntKNN;
                                ++_outcomeTPKNN;
                            }
                            else
                            {
                                if (_output.Equals("CKD"))
                                {
                                    ++_outcomeFPKNN;
                                }
                                else
                                {
                                    ++_outcomeFNKNN;
                                }
                            }

                            //confusion matrix
                        if (tabActualData.Rows[0]["Result"].ToString().Equals("1"))
                        {
                            if (tabActualData.Rows[0]["Result"].ToString().Equals(s[y].ToString()))
                            {
                                ++_KNNTP;
                            }
                            else
                            {
                                ++_KNNTN;
                            }
                        }
                        else 
                        {
                            if (tabActualData.Rows[0]["Result"].ToString().Equals(s[y].ToString()))
                            {
                                ++_KNNFP;
                            }
                            else
                            {
                                ++_KNNFN;
                            }
                        }

                            return _output;
                        }
                    }
                }
            }
            else
            {

            }

            return _output;
        }                       

        private void CompareAlgorithms()
        {
            f1_Naivebayes();
            f2_KNN();

            BLL obj = new BLL();
            int _ActualCnt = obj.GetActualCnt();

            Table3.Rows.Clear();

            Table3.BorderStyle = BorderStyle.Double;
            Table3.GridLines = GridLines.Both;
            Table3.BorderColor = System.Drawing.Color.DarkGray;

            //mainrow
            TableRow mainrow = new TableRow();
            mainrow.Height = 30;
            mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

            mainrow.BackColor = System.Drawing.Color.SteelBlue;

            TableCell cell1 = new TableCell();
            cell1.Width = 350;
            cell1.Text = "<b>Constraint</b>";
            mainrow.Controls.Add(cell1);

            TableCell cell2 = new TableCell();
            cell2.Width = 200;
            cell2.Text = "<b>Naive Bayes</b>";
            mainrow.Controls.Add(cell2);

            TableCell cell3 = new TableCell();
            cell3.Width = 200;
            cell3.Text = "<b>KNN</b>";
            mainrow.Controls.Add(cell3);

            Table3.Controls.Add(mainrow);

            //1st row
            TableRow row1 = new TableRow();

            TableCell cellAcc = new TableCell();
            cellAcc.Text = "<b>Accuracy</b>";
            row1.Controls.Add(cellAcc);

            TableCell cellAccNB = new TableCell();
            cellAccNB.Font.Bold = true;
            //cal
            double _percentageNB = (_outcomeCntNB / _ActualCnt) * 100;
            cellAccNB.Text = _percentageNB.ToString() + "%";
            row1.Controls.Add(cellAccNB);

            TableCell cellAccKNN = new TableCell();
            cellAccKNN.Font.Bold = true;
            double _percentageKNN = (_outcomeCntKNN / _ActualCnt) * 100;
            cellAccKNN.Text = _percentageKNN.ToString() + "%";
            row1.Controls.Add(cellAccKNN);

            Table3.Controls.Add(row1);

            //2nd row           
            TableRow row2 = new TableRow();

            TableCell cellTime = new TableCell();
            cellTime.Text = "<b>Time (milli secs)</b>";
            row2.Controls.Add(cellTime);

            TableCell cellTimeNB = new TableCell();
            cellTimeNB.Font.Bold = true;
            cellTimeNB.Text = _timeNB;
            row2.Controls.Add(cellTimeNB);

            TableCell cellTimeKNN = new TableCell();
            cellTimeKNN.Font.Bold = true;
            cellTimeKNN.Text = _timeKNN;
            row2.Controls.Add(cellTimeKNN);

            Table3.Controls.Add(row2);

            //3rd row           
            //TableRow row3 = new TableRow();

            //TableCell cellCorrect = new TableCell();
            //cellCorrect.Text = "<b>Precision</b>";
            //row3.Controls.Add(cellCorrect);

            //TableCell cellCorrectNB = new TableCell();
            //cellCorrectNB.Font.Bold = true;
            //double _precisionNB = 0;
            //_precisionNB = (_outcomeTPNB / _outcomeTPNB) + _outcomeFPNB;
            //_precisionNB = 1 - (_precisionNB / 100);
            //cellCorrectNB.Text = _precisionNB.ToString();
            //row3.Controls.Add(cellCorrectNB);

            //TableCell cellCorrectKNN = new TableCell();
            //cellCorrectKNN.Font.Bold = true;
            //double _precisionKNN = 0;          
            //_precisionKNN = (_outcomeTPKNN / _outcomeTPKNN) + _outcomeFPKNN;
            //_precisionKNN = 1 - (_precisionKNN / 100);
            //cellCorrectKNN.Text = _precisionKNN.ToString();
            //row3.Controls.Add(cellCorrectKNN);

            //Table3.Controls.Add(row3);

            ////4th row           
            //TableRow row4 = new TableRow();

            //TableCell cellInCorrect = new TableCell();
            //cellInCorrect.Text = "<b>Recall</b>";
            //row4.Controls.Add(cellInCorrect);

            //TableCell cellInCorrectNB = new TableCell();
            //cellInCorrectNB.Font.Bold = true;
            //double _RecallNB = 0;
            //_RecallNB = (_outcomeTPNB / _outcomeTPNB) + _outcomeFNNB;
            //_RecallNB = 1 - (_RecallNB / 100);
            //cellInCorrectNB.Text = _RecallNB.ToString();
            //row4.Controls.Add(cellInCorrectNB);

            //TableCell cellInCorrectKNN = new TableCell();
            //cellInCorrectKNN.Font.Bold = true;
            //double _RecallKNN = 0;
            //_RecallKNN = (_outcomeTPKNN / _outcomeTPKNN) + _outcomeFNKNN;
            //_RecallKNN = 1 - (_RecallKNN / 100);
            //cellInCorrectKNN.Text = _RecallKNN.ToString();
            //row4.Controls.Add(cellInCorrectKNN);

            //Table3.Controls.Add(row4);
            ////f1 measure
            ////5th row           
            //TableRow row5 = new TableRow();

            //TableCell cellInCorrectrow5 = new TableCell();
            //cellInCorrectrow5.Text = "<b>FMeasure</b>";
            //row5.Controls.Add(cellInCorrectrow5);

            //TableCell cellInCorrectNBrow5 = new TableCell();
            //cellInCorrectNB.Font.Bold = true;
            //double _FmeasureNB = 0;
            //_FmeasureNB = (_RecallNB * _precisionNB) / (_RecallNB + _precisionNB);
            //_FmeasureNB = 2 * (_FmeasureNB / 100);
            //cellInCorrectNBrow5.Text = _FmeasureNB.ToString();
            //row5.Controls.Add(cellInCorrectNBrow5);

            //TableCell cellInCorrectKNNrow5 = new TableCell();
            //cellInCorrectKNN.Font.Bold = true;
            //double _FmeasureKNN = 0;
            //_FmeasureKNN = (_RecallKNN * _precisionKNN) / (_RecallKNN + _precisionKNN);
            //_FmeasureKNN = 2 * (_FmeasureKNN / 100);
            //cellInCorrectKNNrow5.Text = _FmeasureKNN.ToString();
            //row5.Controls.Add(cellInCorrectKNNrow5);

            //Table3.Controls.Add(row5);
            Label1.Text = Label2.Text = string.Empty;

            _NBTP = (_NBTP / 71) * 100;
            _NBTN = (_NBTN / 71) * 100;
            _NBFP = (_NBFP / 71) * 100;
            _NBFN = (_NBFN / 71) * 100;

            _KNNTP = (_KNNTP / 71) * 100;
            _KNNTN = (_KNNTN / 71) * 100;
            _KNNFP = (_KNNFP / 71) * 100;
            _KNNFN = (_KNNFN / 71) * 100;

            Label1.Text = "TP= " + Math.Round(_NBTP, 2) + "%, TN= " + Math.Round(_NBTN, 2) + "%, FP= " + Math.Round(_NBFP, 2) + "%, FN= " + Math.Round(_NBFN, 2) + "%";
            Label2.Text = "TP= " + Math.Round(_KNNTP, 2) + "%, TN= " + Math.Round(_KNNTN, 2) + "%, FP= " + Math.Round(_KNNFP, 2) + "%, FN= " + Math.Round(_KNNFN, 2) + "%";

            //Table4.GridLines = GridLines.Both;
            //Table4.BorderWidth = 10;
            //Table4.BorderStyle = BorderStyle.Double;

            //TableHeaderRow cmNBrow1 = new TableHeaderRow();

            //TableHeaderCell cmNBrow1cell1 = new TableHeaderCell();
            //cmNBrow1cell1.Width = 76;
            //cmNBrow1cell1.BackColor = System.Drawing.Color.DarkGreen;
            //cmNBrow1cell1.Text = "76.06";
            //cmNBrow1.Controls.Add(cmNBrow1cell1);

            //TableHeaderCell cmNBrow1cell2 = new TableHeaderCell();
            //cmNBrow1cell2.Width = 1;
            //cmNBrow1cell2.BackColor = System.Drawing.Color.DarkGoldenrod;
            //cmNBrow1cell2.Text = "0";
            //cmNBrow1.Controls.Add(cmNBrow1cell2);

            //TableHeaderRow cmNBrow2 = new TableHeaderRow();

            //TableHeaderCell cmNBrow2cell1 = new TableHeaderCell();
            //cmNBrow2cell1.Width = 16;
            //cmNBrow2cell1.BackColor = System.Drawing.Color.DarkBlue;
            //cmNBrow2cell1.Text = "15.49";
            //cmNBrow2.Controls.Add(cmNBrow2cell1);

            //TableHeaderCell cmNBrow2cell2 = new TableHeaderCell();
            //cmNBrow2cell2.Width = 8;
            //cmNBrow2cell2.BackColor = System.Drawing.Color.DarkOrange;
            //cmNBrow2cell2.Text = "8.45";
            //cmNBrow2.Controls.Add(cmNBrow2cell2);

            //Table4.Controls.Add(cmNBrow1);
            //Table4.Controls.Add(cmNBrow2);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("_CMNB.aspx?NB_TP={0}&NB_TN={1}&NB_FP={2}&NB_FN={3}", Math.Round(_NBTP, 2), Math.Round(_NBTN, 2), Math.Round(_NBFP, 2), Math.Round(_NBFN, 2)));
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("_CMKNN.aspx?KNN_TP={0}&KNN_TN={1}&KNN_FP={2}&KNN_FN={3}", Math.Round(_KNNTP, 2), Math.Round(_KNNTN, 2), Math.Round(_KNNFP, 2), Math.Round(_KNNFN, 2)));
        }
               
    }
}