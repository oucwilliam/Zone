using System;

public partial class qqZoneHome_ChangeLogs : System.Web.UI.Page
{
    static Check Ck = new Check();
    static sqlsentence SQL = new sqlsentence();
    static RegularExpression RE = new RegularExpression();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Contents"] == null || Session["Title"] == null)
            {
                Response.Redirect("Logs.aspx");
            }
            else
            {
                string Contents = Convert.ToString(Session["Contents"]);
                string Title = Convert.ToString(Session["Title"]);
                TxtTitle.Text = Title;
                content1.InnerText = Contents;
            }
        }
    }


    protected void BtnChange_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["LogId"]);
        string NewTitle = Request.Form["TxtTitle"].ToString();
        string NewContents = Request.Form["content1"];
        DateTime Date = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
        if (NewTitle == null || NewContents == null)
            Response.Write("<script>alert('内容不能为空');</script>");
        else if (Ck.Contents(NewTitle) == false || Ck.Contents(NewContents) == false)
            Response.Write("<script>alert('请不要输入非法字符');</script>");
        else
        {
            string sql = "update Logs set Title = N'" + NewTitle + "' , Contents = N'" + NewContents + "' , Date = '" + Date + "' where  id = '" + id + "'";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('编辑成功！');location='Logs.aspx'</script>");
        }
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logs.aspx");
    }
}