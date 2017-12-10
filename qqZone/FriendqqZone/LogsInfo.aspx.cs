using System;

public partial class qqZoneHome_LogsInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Contents"] == null || Session["Title"] == null)
        {
            Response.Redirect("Logs.aspx");
        }
        else
        {
            string Contents = Convert.ToString(Session["Contents"]);
            string Title = Convert.ToString(Session["Title"]);
            LabTitle.Text = Title;
            LabContents.Text = Contents;
        }
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logs.aspx");
    }
}