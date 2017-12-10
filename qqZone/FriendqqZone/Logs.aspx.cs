using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class qqZoneHome_Logs : System.Web.UI.Page
{
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            DataBindToRepeater(1);
    }
    void DataBindToRepeater(int currentPage)
    {
        string FriendName = Convert.ToString(Session["FriendName"]);
        string sql = "select * from Logs where UserName = '" + FriendName + "'";
        DataTable dt = new DataTable();
        SQL.sqldt(sql, dt);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 5;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一
        RptLogs.DataSource = pds;
        RptLogs.DataBind();

    }

    protected void RptLogs_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        string sql = "Select * from Logs where id = '" + id + "'";
        DataTable dt = new DataTable();
        SQL.sqldt(sql, dt);
        if (e.CommandName == "Info")
        {
            string Contents = Convert.ToString(dt.Rows[0][4]);
            string Title = Convert.ToString(dt.Rows[0][2]);
            Session["LogId"] = id;
            Session["Title"] = Title;
            Session["Contents"] = Contents;
            Session.Timeout = 40;
            Response.Redirect("LogsInfo.aspx");
        }
    }

    protected void btnUp_Click(object sender, EventArgs e)
    {
        string nowPage = lbNow.Text;
        int toPage = Convert.ToInt32(nowPage) - 1;
        if (toPage >= 1)
        {
            lbNow.Text = Convert.ToString(toPage);
            DataBindToRepeater(toPage);
        }
    }

    protected void btnDown_Click(object sender, EventArgs e)
    {
        string nowPage = lbNow.Text;
        int toPage = Convert.ToInt32(nowPage) + 1;
        if (toPage <= Convert.ToInt32(lbTotal.Text))
        {
            lbNow.Text = Convert.ToString(toPage);
            DataBindToRepeater(toPage);
        }

    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        lbNow.Text = Convert.ToString(1);
        DataBindToRepeater(1);
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        int total = Convert.ToInt32(lbTotal.Text);
        lbNow.Text = Convert.ToString(total);
        DataBindToRepeater(total);
    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        int AimPage = Convert.ToInt32(txtJump.Text);
        int total = Convert.ToInt32(lbTotal.Text);
        if (AimPage >= total)
        {
            lbNow.Text = Convert.ToString(total);
            DataBindToRepeater(total);
        }
        else if (AimPage < 1)
        {
            lbNow.Text = Convert.ToString(1);
            DataBindToRepeater(1);
        }
        else
        {
            lbNow.Text = Convert.ToString(AimPage);
            DataBindToRepeater(AimPage);
        }
    }
    protected void BtnWrite_Click(object sender, EventArgs e)
    {
        Response.Redirect("WriteLogs.aspx");
    }
}