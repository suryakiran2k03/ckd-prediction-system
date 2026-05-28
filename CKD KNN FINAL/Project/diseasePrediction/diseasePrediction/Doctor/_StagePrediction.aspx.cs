using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diseasePrediction.Doctor
{
    public partial class _StagePrediction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["name"]==null)
                {
                    txtName.Focus();
                }
                else
                {
                    txtName.Text = Request.QueryString["name"].ToString();
                    TextBox1.Text = Request.QueryString["age"].ToString();
                    TextBox3.Text = Request.QueryString["sc"].ToString();
                }
            }
            catch
            {

            }
        }

        protected void btnAlgorithm1_Click(object sender, EventArgs e)
        {
            GRF();
        }

        //function to find GRF
        private void GRF()
        {
            double _A = 0;
            double _B = 0;
            double _C = 0;

            if (DropDownListGender.SelectedValue.Equals("Male"))
            {
                if (float.Parse(TextBox3.Text) <= 0.9)
                {
                    _A = 141;
                    _B = 0.9;
                    _C = -0.411;
                }
                else
                {
                    _A = 141;
                    _B = 0.9;
                    _C = -1.209;
                }
            }
            else
            {
                if (float.Parse(TextBox3.Text) <= 0.7)
                {
                    _A = 144;
                    _B = 0.7;
                    _C = -0.329;
                }
                else
                {
                    _A = 144;
                    _B = 0.9;
                    _C = -1.209;
                }
            }

            double _GRF = 0;
            _GRF = _A * (Math.Pow(double.Parse(TextBox3.Text) / _B, _C)) * Math.Pow(0.993, double.Parse(TextBox1.Text));

            lblGRF.ForeColor = System.Drawing.Color.Red;
            lblGRF.Text = "GFR: " + _GRF.ToString();

            if (_GRF >= 90)
            {
                lblOutput.Text = "Output: Stage1";
            }
            else if (_GRF >= 68 && _GRF <= 89)
            {
                lblOutput.Text = "Output: Stage2";
            }
            else if (_GRF >= 30 && _GRF <= 59)
            {
                lblOutput.Text = "Output: Stage3";
            }
            else if (_GRF >= 15 && _GRF <= 29)
            {
                lblOutput.Text = "Output: Stage4";
            }
            else if (_GRF < 15)
            {
                lblOutput.Text = "Output: Stage5";
               
            }
        }

        protected void lbtnDiet_Click(object sender, EventArgs e)
        {
            double _A = 0;
            double _B = 0;
            double _C = 0;

            if (DropDownListGender.SelectedValue.Equals("Male"))
            {
                if (float.Parse(TextBox3.Text) <= 0.9)
                {
                    _A = 141;
                    _B = 0.9;
                    _C = -0.411;
                }
                else
                {
                    _A = 141;
                    _B = 0.9;
                    _C = -1.209;
                }
            }
            else
            {
                if (float.Parse(TextBox3.Text) <= 0.7)
                {
                    _A = 144;
                    _B = 0.7;
                    _C = -0.329;
                }
                else
                {
                    _A = 144;
                    _B = 0.9;
                    _C = -1.209;
                }
            }

            double _GRF = 0;
            _GRF = _A * (Math.Pow(double.Parse(TextBox3.Text) / _B, _C)) * Math.Pow(0.993, double.Parse(TextBox1.Text));

            lblGRF.ForeColor = System.Drawing.Color.Red;
            lblGRF.Text = "GFR: " + _GRF.ToString();

            if (_GRF >= 90)
            {
                Response.Redirect("_S1.aspx");
            }
            else if (_GRF >= 68 && _GRF <= 89)
            {
                Response.Redirect("_S2.aspx");
            }
            else if (_GRF >= 30 && _GRF <= 59)
            {
                Response.Redirect("_S3.aspx");
            }
            else if (_GRF >= 15 && _GRF <= 29)
            {
                Response.Redirect("_S4.aspx");
            }
            else if (_GRF < 15)
            {
                Response.Redirect("_S5.aspx");

            }
        }

    }
}