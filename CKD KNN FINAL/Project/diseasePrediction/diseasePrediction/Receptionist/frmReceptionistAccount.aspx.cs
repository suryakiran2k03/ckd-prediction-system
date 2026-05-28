using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace diseasePrediction.Receptionist
{
    public partial class frmReceptionistAccount : System.Web.UI.Page
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
                if (!this.IsPostBack)

                    txtOldPassword.Focus();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();
                tab.Rows.Clear();

                tab = obj.GetUserById(Session["StaffId"].ToString());
                string oldPassword = tab.Rows[0]["Password"].ToString();

                if (txtOldPassword.Text.Equals(oldPassword))
                {
                    obj.UpdateUserPassword(txtNewPassword.Text, Session["StaffId"].ToString());
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Receptionist Password changed successfully')</script>");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Receptionist Old password incorrect')</script>");
                }
            }
            catch
            {

            }
        }

    }
}