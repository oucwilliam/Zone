using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

public partial class qqZoneHome_Friends : System.Web.UI.Page
{
    static RegularExpression RE = new RegularExpression();
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            DataBindToRepeater(1);
    }
    void DataBindToRepeater(int currentPage)
    {
        string UserName = Convert.ToString(Session["UserName"]);
        string sql = "select * from Friends where UserName = '" + UserName + "'";
        DataTable dt = new DataTable();
        SQL.sqldt(sql, dt);
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 5;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一
        RptFriends.DataSource = pds;
        RptFriends.DataBind();

    }

    protected void RptFriends_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        string sql = "Select * from Friends where id = '" + id + "'";
        DataTable dt = new DataTable();
        SQL.sqldt(sql, dt);
        if (e.CommandName == "Delete")
        {
            sql = "Delete from Friends where id = '" + id + "'";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('删除成功');location='Friends.aspx'</script>");
        }
        if (e.CommandName == "Info")
        {
            Session["FriendName"] = Convert.ToString(dt.Rows[0][2]);
            Response.Write("<script>alert('正在访问您好友的空间，点击确定进入！');location='../FriendqqZone/Home.aspx'</script>");
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

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        string UserName = Convert.ToString(Session["UserName"]);
        string Friends = TxtAdd.Text;
        if ((RE.others.IsMatch(Friends)) == true)
            Response.Write("<script>alert('请不要输入非法字符');</script>");
        else
        {
            string sql = "select * from qqZoneUsers where UserName = N'" + Friends + "'";
            int count = SQL.sqlSelect(sql);
            if (count != 0)
            {
                sql = "Insert into FriendsSure values(N'" + Friends + "', '" + UserName + "')";
                SQL.sqlIDU(sql);
                Response.Write("<script>alert('请求发送成功！请等待对方的确认');location='Friends.aspx'</script>");
            }
            else
                Response.Write("<script>alert('用户名不存在')</script>");
        }
    }

    protected void BtnSure_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sure.aspx");
    }
}