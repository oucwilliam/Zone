using System;

public partial class qqZoneHome_WriteLogs : System.Web.UI.Page
{
    static Check Ck = new Check();
    static sqlsentence SQL = new sqlsentence();
    static RegularExpression RE = new RegularExpression();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logs.aspx");
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        string UserName = Convert.ToString(Session["UserName"]);
        string Title = TxtTitle.Text;
        string Contents = Request.Form["content1"];
        DateTime Date = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
        if (Title == null || Contents == null)
            Response.Write("<script>alert('内容不能为空!');</script>");
        else if(Ck.Contents(Title) == false || Ck.Contents(Contents) == false)
            Response.Write("<script>alert('请不要输入非法字符!');</script>");
        else
        {
            string sql = "Insert into Logs values ('" + UserName + "',N'" + Title + "','" + Date + "','" + Contents + "')";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('提交成功！');location='Logs.aspx'</script>");
        }
    }
}