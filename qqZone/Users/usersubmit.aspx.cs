using System;
using System.Web;

public partial class usersubmit : System.Web.UI.Page
{
    static Check us = new Check();
    static sqlsentence SQL = new sqlsentence();
    static RegularExpression RE = new RegularExpression();
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtn_yzm.ImageUrl = "/ImageCode.aspx";
    }

    protected void Page_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        if (ex is HttpRequestValidationException)
        {
            Response.Write("<script>alert('请您输入合法字符串。');location='qqZoneHome.aspx'</script>");
            Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。
        }
        else
        {
            Response.Write("<script>alert('请您不要乱来！');location='qqZoneHome.aspx'</script>");
            Server.ClearError();
        }
    }

    protected void BtnUserSubmit_Click(object sender, EventArgs e)
    {
        string UserName = txtUserName.Text;
        string UserPassword = txtUserPassword.Text;
        string CheckPassword = txtCheckPassword.Text;
        string UserPhone = txtPhone.Text;
        string Name = txtName.Text;
        string IdCard = txtIdCard.Text;
        if ((RE.others.IsMatch(UserName) || RE.others.IsMatch(UserPassword)) == true)
            Response.Write("<script>alert('请不要输入非法字符');</script>");
        else
        {
            int Flag = us.SubmitCheckUser(UserName, UserPassword, CheckPassword, UserPhone, IdCard);
            if (Flag == 1)
                Response.Write("<script>alert('请不要输入空字符');</script>");
            if (Flag == 2)
                Response.Write("<script>alert('请输入5-11位的用户名');</script>");
            if (Flag == 3)
                Response.Write("<script>alert('请输入5-11位的密码');</script>");
            if (Flag == 4)
                Response.Write("<script>alert('两次密码不匹配');</script>");
            if ((Flag == 5||RE.nonumber.IsMatch(UserPhone)) == true)
                Response.Write("<script>alert('请输入正确的电话号码');</script>");
            if (Flag == 6)
                Response.Write("<script>alert('请输入正确的身份证');</script>");
            if (Flag == 7)
            {
                string sql = "select id from qqZoneUsers where username = N'" + UserName + "'";
                int count = SQL.sqlSelect(sql);
                if (count == 0)
                {
                    string code = tbx_yzm.Text.ToUpper();
                    HttpCookie htco = Request.Cookies["ImageV"];
                    string scode = htco.Value.ToString();
                    if (code != scode)
                        Response.Write("<script>alert('验证码输入不正确！')</script>");
                    else
                    {
                        sql = "Insert into qqZoneUsers values (N'" + UserName + "','" + UserPassword + "','" + UserPhone + "','" + Name + "','" + IdCard + "')";
                        SQL.sqlIDU(sql);
                        sql = "Insert into Introduction values (N'" + UserName + "')";
                        SQL.sqlIDU(sql);
                        Response.Write("<script>alert('注册成功！');location='userlogin.aspx'</script>");
                    }
                }
                else
                    Response.Write("<script>alert('用户名已存在')</script>");
            }
        }  
    }
    protected void BackHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("qqZoneHome.aspx");
    }
}