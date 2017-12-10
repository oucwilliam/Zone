using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class qqZoneHome_Sure : System.Web.UI.Page
{
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string UserName = Convert.ToString(Session["UserName"]);
            string sql = "select * from FriendsSure where UserName = '" + UserName + "'";
            DataTable dt = new DataTable();
            SQL.sqldt(sql, dt);
            //把查询出的数据放入datatable
            rptList.DataSource = dt;
            rptList.DataBind();
        }
    }

    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Agree")
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string sql = "Select * from FriendsSure where id = " + Id + "";
            DataTable mdt = new DataTable();
            SQL.sqldt(sql, mdt);
            string Friends = Convert.ToString(mdt.Rows[0][2]);
            string UserName = Convert.ToString(Session["UserName"]);
            sql = "Insert into Friends values(N'" + Friends + "', '" + UserName + "')";
            SQL.sqlIDU(sql);
            sql = "Insert into Friends values(N'" + UserName + "', '" + Friends + "')";
            SQL.sqlIDU(sql);
            sql = "Delete from FriendsSure where id = " + Id + "";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('处理成功');location='Friends.aspx'</script>");
        }
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Friends.aspx");
    }
}