using System;
using System.Web.UI;

public partial class qqZoneHome_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.DataBind();
        }
        string username = Session["UserName"].ToString();
        if (Session["UserName"] == null)
        {
            Response.Redirect("userlogin.aspx");
        }
        else
        {
            LabName.Text = username;
        }
    }

    protected void BtnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Users/userchangepassword.aspx");
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("../Users/userlogin.aspx");
    }

}