using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

public partial class Admin_AddPage : System.Web.UI.Page
{
    private void MessageBox(string MessageText)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("alert('" + MessageText + "')");
        sb.Append("</script>");
        Page.RegisterStartupScript("show2", sb.ToString());
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
            Session["User"] = Session["User"];
            Session["UserID"] = Session["UserID"];
            Session["TourID"] = Session["TourID"];
            Session["TiID"] = Session["TiID"];
            Session["beID"] = Session["beID"];
        }
    }

    public static string CheckNull(object InputValue, int i)
    {
        if (i == 1)
        {
            if (string.IsNullOrEmpty((string)InputValue) == true)
                return "NULL";
            else if ((string)InputValue == string.Empty)
                return "NULL";
            else return "N'" + (string)InputValue.ToString() + "'";
        }
        else
        {
            if (string.IsNullOrEmpty((string)InputValue) == true)
                return "NULL";
            else if ((string)InputValue == string.Empty)
                return "NULL";
            else return (string)InputValue.ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
        if(!IsPostBack)
        LoadPage();
    }
    public static string Decode(string input)
    {
        string ex = "";
        if (string.IsNullOrEmpty(input)) return "0";
        for (int i = 0; i < input.Length; i++)
        {

            try
            {
                string b = Convert.ToInt64(input.Substring(i, 1)).ToString();
                ex += b;
            }
            catch { }
        }
        if (string.IsNullOrEmpty(ex)) return "0";

        return ex;
    }
    protected void LoadPage()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string v = Request.QueryString["PageID"];
            if (v != null)
            {
                v = Decode(v);
                SqlCommand cmd = new SqlCommand("SELECT Title,PageHTML,KeyWord From Page WHERE ID = " + v.ToString(), con);
                SqlDataReader dr = null;
                con.Open();
                string NN = "";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        SubJ.Text = dr[0].ToString();
                        editor.Text = Server.HtmlDecode(dr[1].ToString());
                        Keyword.Text = dr[2].ToString();
                        Button1.Text = "بروز رسانی";
                    }
                }
                con.Close();
            }
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (SubJ.Text.Trim() != "" && editor.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {   
                string v = Request.QueryString["PageID"];
                string myQ = "";
                SubJ.Text= SubJ.Text.Replace("ي", "ی");
                SubJ.Text=SubJ.Text.Replace("ك","ک");
                if(Button1.Text == "بروز رسانی")
                {
                    myQ = "UPDATE Page Set PageProfile = dbo.CreateURL(N'" + SubJ.Text.Trim() + "') + '-" + v + "' , Title = " + CheckNull(SubJ.Text, 1) + " , PageHTML = " + CheckNull(Server.HtmlEncode(editor.Text.Trim()), 1) + " , KeyWord = " + CheckNull(Keyword.Text.Trim(), 1) + " WHERE ID = " + v;
                }
                else
                {
                    myQ = "insert into page(Title,PageHTML,Active,KeyWord) VALUES (" + CheckNull(SubJ.Text, 1) + " , " + CheckNull(Server.HtmlEncode(editor.Text.Trim()), 1) + " , 1 , " + CheckNull(Keyword.Text, 1) + " );";
                    myQ += "Declare @CurrentID bigint;set @CurrentID = SCOPE_IDENTITY();Update page Set PageProfile = dbo.CreateURL(N'" + SubJ.Text.Trim() + "') + '-' + CONVERT(varchar(10),@CurrentID) WHERE ID = @CurrentID";
                }
                SqlCommand cmd = new SqlCommand(myQ, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "صفحه با موفقیت بروز رسانی شد";
                Label1.ForeColor = Color.Green;
                if (Button1.Text != "بروز رسانی")
                    Response.Redirect("~/Admin/ManagePage.aspx");
            }
            catch (Exception exp)
            {
                Label1.Text = exp.Message;
                Label1.ForeColor = Color.Red;
            }
        }
        else
        {
            Label1.Text = "لطفا مقادیر را کامل وارد کنید";
            Label1.ForeColor = Color.Red;
        }
    }
}