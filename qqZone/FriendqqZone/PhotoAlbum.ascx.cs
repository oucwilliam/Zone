﻿/*
 *    PhotoAlbum Control V1.0 
 *    By Timothy Ye 2007.7.6
 *    You can modify it, and republish it.
 *    http://www.xiaozhou.net/cooldog
 */
// 下载于www.51aspx.com
using ImageProcess;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PhotoAlbum : System.Web.UI.UserControl
{
    int PageSize = 12;
    int CurrentPage = 0;
    int PageCount = 0;
    int RecordCount = 0;

    string smallfoldername = String.Empty;
    string bigfoldername = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            smallfoldername = Server.MapPath(ConfigurationManager.AppSettings["SmallPath"]);
            bigfoldername = Server.MapPath(ConfigurationManager.AppSettings["NormalPath"]);
        }
        catch
        {
            smallfoldername = Server.MapPath("..images/william/SmallPics/");
            bigfoldername = Server.MapPath("..images/william/NormalPics/");
        }

        RecordCount = ProcessPhoto();

        //设定PageSize
        int PageSize = 12;

        //第一次请求执行
        if (!Page.IsPostBack)
        {
            CurrentPage = 0;
            ViewState["PageIndex"] = 0;

            lbTotal.Text = "共" + RecordCount.ToString() + "张";

            //计算总共有多少页
            //PageCount = RecordCount / PageSize;
            PageCount = (RecordCount + PageSize - 1) / PageSize;
            //lblPageCount.Text = PageCount.ToString();
            ViewState["PageCount"] = PageCount;

            for (int i = 1; i <= PageCount; i++)
            {
                lstPage.Items.Add(i.ToString());
            }

            ListBind();
        }
    }

    DataSet CreateSource()
    {

        int StartIndex;

        //设定导入的起终地址
        StartIndex = CurrentPage * PageSize;

        //取得大图目录信息
        DirectoryInfo imagesfile = new DirectoryInfo(bigfoldername);
        //取得大图目录所有JPG文件集合
        FileInfo[] fi = imagesfile.GetFiles("*.jpg");

        //取得小图目录信息

        DirectoryInfo Smallimagesfile = new DirectoryInfo(smallfoldername);
        //取得小图目录所有JPG文件集合
        FileInfo[] Sfi = Smallimagesfile.GetFiles("*.jpg");

        //通过hashtable绑定小图路径和大图路径
        DataSet ds = new DataSet();
        DataTable tb = new DataTable();
        ds.Tables.Add(tb);

        DataColumn colSmall = new DataColumn("SmallPhoto");
        DataColumn colNormal = new DataColumn("NormalPhoto");
        DataColumn colName = new DataColumn("Name");
        ds.Tables[0].Columns.Add(colSmall);
        ds.Tables[0].Columns.Add(colNormal);
        ds.Tables[0].Columns.Add(colName);

        if (Sfi.Length - StartIndex < 12)
        {
            for (int i = 0; i < (Sfi.Length - StartIndex); i++)
            {
                DataRow row = ds.Tables[0].NewRow();
                row["SmallPhoto"] = "..images/william/SmallPics/" + Sfi[i + StartIndex].Name;
                row["NormalPhoto"] = "..images/william/NormalPics/" + Sfi[i + StartIndex].Name;
                row["Name"] = Sfi[i + StartIndex].Name;
                ds.Tables[0].Rows.Add(row);
            }
        }
        else
        {
            for (int i = 0; i < PageSize; i++)
            {
                DataRow row = ds.Tables[0].NewRow();
                row["SmallPhoto"] = "../images/william/SmallPics/" + Sfi[i + StartIndex].Name;
                row["NormalPhoto"] = "../images/william/NormalPics/" + Sfi[i + StartIndex].Name;
                row["Name"] = Sfi[i + StartIndex].Name;
                ds.Tables[0].Rows.Add(row);
            }
        }

        return ds;
        // 下载于www.51aspx.com
    }
    public void ListBind()
    {

        this.DataList1.DataSource = CreateSource();
        this.DataList1.DataBind();

        lbnNextPage.Enabled = true;
        lbnPrevPage.Enabled = true;
        if (CurrentPage == ((int)ViewState["PageCount"] - 1)) lbnNextPage.Enabled = false;
        if (CurrentPage == 0) lbnPrevPage.Enabled = false;
        lbCurrentPage.Text = "   第" + (CurrentPage + 1).ToString() + "/" + ViewState["PageCount"].ToString() + "页   ";

    }

    public void Page_OnClick(Object sender, CommandEventArgs e)
    {
        CurrentPage = (int)ViewState["PageIndex"];
        PageCount = (int)ViewState["PageCount"];

        string cmd = e.CommandName;
        //判断cmd，以判定翻页方向
        switch (cmd)
        {
            case "next":
                if (CurrentPage < (PageCount - 1)) CurrentPage++;
                break;
            case "prev":
                if (CurrentPage > 0) CurrentPage--;
                break;
        }

        ViewState["PageIndex"] = CurrentPage;

        ListBind();

    }


    private int ProcessPhoto()
    {
        //生成小图目录
        //DirectoryInfo di_smallforder = Directory.CreateDirectory(smallfoldername);

        //取得大图目录信息
        DirectoryInfo imagesfile = new DirectoryInfo(bigfoldername);
        //取得大图目录所有JPG文件集合
        FileInfo[] fi = imagesfile.GetFiles("*.jpg");


        for (int i = 0; i < fi.Length; i++)
        {
            if (!File.Exists(smallfoldername + "/" + fi[i].Name))
            {
                //生成缩略图文件
                ImageThumbnail.MakeThumbnail(
                                             bigfoldername + "/" + fi[i].Name,
                                             smallfoldername + "/" + fi[i].Name,
                                             150,
                                             110,
                                             "Cut"
                                             );
            }
        }

        return fi.Length;
    }

    protected void lstPage_SelectedIndexChanged1(object sender, EventArgs e)
    {
        CurrentPage = lstPage.SelectedIndex;
        ViewState["PageIndex"] = CurrentPage;
        ListBind();
    }
}
