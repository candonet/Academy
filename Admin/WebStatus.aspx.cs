using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class WebStatus : System.Web.UI.Page
{
    private static long GetDirectorySize(string folderPath)
    {
        DirectoryInfo di = new DirectoryInfo(folderPath);
        return di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
    }

    protected void CheckSafe()
    {
        if ((Session["User"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
        else
        {
            (Session["User"]) = (Session["User"]);
        }
    }

    private void MessageBox(string MessageText)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("alert('" + MessageText + "')");
        sb.Append("</script>");
        Page.RegisterStartupScript("show2", sb.ToString());
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
        long CurrentSize = (GetDirectorySize(MapPath("~/")) / 1024);
        long MaximumSize = Convert.ToInt64( GetDiskSpace()) - CurrentSize;
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("CreatePIE(" + CurrentSize.ToString() + "," + MaximumSize.ToString() + ")");
        sb.Append("</script>");
        Page.RegisterStartupScript("LoadChart", sb.ToString());
        Label1.Text = MapPath("~/").ToString() + " " + CurrentSize.ToString();
    }

    protected string GetDiskSpace()
    {
        string CurrentDiskSpace = "0";
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("Select SiteSpace From SiteSetting", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                CurrentDiskSpace = dr[0].ToString();
            }
            con.Close();
            CurrentDiskSpace = (Convert.ToInt64(CurrentDiskSpace) * 1024).ToString();
        }
        catch { return "0"; }
        return CurrentDiskSpace;
    }
}