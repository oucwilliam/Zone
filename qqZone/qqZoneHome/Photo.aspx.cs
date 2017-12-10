using System;
using System.Web;

public partial class qqZoneHome_Photo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        string UserName = Convert.ToString(Session["UserName"]);
        string id = Convert.ToString(Session["UserId"]);
        HttpPostedFile hpf = this.FileName.PostedFile;
        string fileType = hpf.FileName.Substring(this.FileName.PostedFile.FileName.LastIndexOf(".") + 1).ToString(); //get the type
        if (fileType != "jpg" && fileType != "png")
        {
            Response.Write("<script>alert('上传图片类型错误!')</script>");
        }
        else if (hpf.ContentLength < 1024 || hpf.ContentLength > 1048576)
        {
            Response.Write("<script>alert('上传图片不得小于1K或不得大于1M!')</script>");
        }
        // 取得上传的文件对象
        else
        {
            // 文件名
            string fileName = id + "Pic" + id + "." + fileType;
            // 取得服务器站点根目录的绝对路径
            string serverPath = Server.MapPath("~/images/" + UserName + "");
            // 保存文件
            hpf.SaveAs(serverPath + fileName);
            Response.Write("<script>alert('上传成功');</script>");
        }
    }

    protected void BtnUL_Click(object sender, EventArgs e)
    {
        UL.Visible = true;
    }
}