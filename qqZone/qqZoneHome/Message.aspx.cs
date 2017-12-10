using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class qqZoneHome_Message : System.Web.UI.Page
{
    static Check CK = new Check();
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string UserName = Convert.ToString(Session["UserName"]);
            string sql = "select * from Message where UserName = '" + UserName + "' and MessageId = '0'";
            DataTable dt = new DataTable();
            SQL.sqldt(sql, dt);
            RptCategory.DataSource = dt;
            RptCategory.DataBind();
        }
    }

    protected void RptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //找到外层Repeater的数据项
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取外层Repeater的数据项的ID
            int Id = Convert.ToInt32(rowv["id"]);
            //找到对应ID下的Book
            string sql = "select * from Message where MessageId ='" + Id + "'";
            DataTable dt = new DataTable();
            SQL.sqldt(sql, dt);
            //找到内嵌Repeater
            Repeater rept = (Repeater)e.Item.FindControl("RptMessage");
            //数据绑定
            rept.DataSource = dt;
            rept.DataBind();
        }
    }

   

    protected void RptCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Comment")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            Session["id"] = id;
            TextBox TxtNewComment = (TextBox)e.Item.FindControl("TxtNewComment2");
            TxtNewComment.Visible = true;
            Button BtnSave = (Button)e.Item.FindControl("BtnSave2");
            BtnSave.Visible = true;
        }
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        string Message = TxtMessage.Text;
        
        if(CK.IsNull(Message) == true)
            Response.Write("<script>alert('内容不能为空');</script>");
        else if (CK.Contents(Message) == false)
            Response.Write("<script>alert('请不要输入非法字符');</script>");
        else
        {
            string UserName = Convert.ToString(Session["UserName"]);
            string sql = "Insert into Message values ('0',N'" + UserName + "','" + UserName + "','" + Message + "')";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('留言成功！');location='Message.aspx'</script>");
        }
    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"]);
        string UserName = Convert.ToString(Session["UserName"]);
        string NewComment = Convert.ToString(Request.Form["TxtNewComment2.Text"]);
        if (CK.IsNull(NewComment) == true)
            Response.Write("<script>alert('内容不能为空');</script>");
        else if (CK.Contents(NewComment) == false)
            Response.Write("<script>alert('请不要输入非法字符');</script>");
        else
        {
            string sql = "Insert into Message values ('" + id + "',N'" + UserName + "','" + UserName + "','" + NewComment + "')";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('评论成功！');</script>");
        }
    }

   
}