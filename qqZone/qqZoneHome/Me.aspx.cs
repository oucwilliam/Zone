using System;
using System.Data;

public partial class qqZoneHome_Me : System.Web.UI.Page
{
    static Check Ck = new Check();
    static sqlsentence SQL = new sqlsentence();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Name"] == null)
                Response.Redirect("../Users/userlogin.aspx");
            else
            {
                LabName.Text = Convert.ToString(Session["Name"]);
                string UserName = Convert.ToString(Session["UserName"]);
                string sql = "Select * from Introduction where UserName = '" + UserName + "'";
                DataTable dt = new DataTable();
                SQL.sqldt(sql, dt);
                char Sex = Convert.ToChar(dt.Rows[0][2]);
                int Age = Convert.ToInt32(dt.Rows[0][3]);
                string Blood = Convert.ToString(dt.Rows[0][4]);
                string Constellation = Convert.ToString(dt.Rows[0][5]);
                string Occupation = Convert.ToString(dt.Rows[0][6]);
                DateTime Birthday = Convert.ToDateTime(dt.Rows[0][7]);
                TxtBirthday.Text = Birthday.ToShortDateString();
                TxtAge.Text = Age.ToString();
                TxtConstellation.Text = Constellation;
                TxtOccupation.Text = Occupation;
                if (Sex == 'M')
                    RBtnMan.Checked = true;
                if (Sex == 'F')
                    RBtnWoman.Checked = true;
                DdlBlood.Text = Blood;
            }
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string UserName = Convert.ToString(Session["UserName"]);
        char Sex = new char();
        if (RBtnMan.Checked == true)
            Sex = 'M';
        else if (RBtnWoman.Checked == true)
            Sex = 'F';
        else
            Sex = ' ';
        int Age = Convert.ToInt32(Request.Form["TxtAge.Text"]);
        string Blood = Convert.ToString(Request.Form["DdlBlood.Text"]);
        string Constellation = Convert.ToString(Request.Form["TxtConstellation.Text"]);
        string Occupation = Convert.ToString(Request.Form["TxtOccupation.Text"]);
        if (Ck.Contents(Age.ToString()) == false || Ck.Contents(Constellation) == false || Ck.Contents(Occupation) == false)
            Response.Write("<script>alert('请不要输入非法字符!');</script>");
        else
        {
            string sql = "update Introduction set Sex = '" + Sex + "',Age = '" + Age + "',Blood = '" + Blood + "',Constellation = N'" + Constellation + "',Occupation = '" + Occupation + "' where UserName = '" + UserName + "'";
            SQL.sqlIDU(sql);
            Response.Write("<script>alert('保存成功');</script>");
        }
    }
}