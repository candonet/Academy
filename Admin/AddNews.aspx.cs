using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

public partial class Admin_AddNews : System.Web.UI.Page
{
    protected void CheckSafe()
    {
        if ((Session["User"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
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

    private void LoadCat()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT ID,CatName From NewsCat order by Id ", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList1.Items.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList1.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
                if (DropDownList1.Items.Count > 0)
                {
                    DropDownList1.SelectedIndex = 0;
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if ((Session["User"]) != null)
        {
            if (!IsPostBack)
            {
                string v = Request.QueryString["NewsID"];
                if (v != null) LoadNews();
                LoadCat();
            }
        }
        else
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (SubJ.Text.Trim() != "" && TextBox1.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (FileUpload1.HasFile)
                {
                    string p = MapPath("~/IMG/");
                    p += time;
                    TextBox2.Text = "/IMG/" + time;
                    FileUpload1.SaveAs(p);
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                    img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                    img1.Save(MapPath("~/IMG/th/") + time);
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string BodyHTML = TextBox1.Text.Replace("\n", "<br>");
                string v = Request.QueryString["NewsID"];
                string[] Data = DropDownList1.Text.Split('-');
                string STS = "0";
                if (DropDownList2.Text == "نمایش") STS = "1";
                string Query = "";
                if (v != null)
                {
                    string NewsProfile = HttpUtility.HtmlEncode(SubJ.Text.Trim().Replace(" ", "-") + "-" + v);
                    Query = "UPDATE News Set DSource = N'" + DSource.Text.Trim() + "' , SubT = N'" + Sub2.Text.Trim() + "' , NewsProfile = N'" + NewsProfile + "' , STS = " + STS + " , CatID = " + CheckNull(Data[0], 0) + " , Title = " + CheckNull(SubJ.Text.Trim(), 1) + " , NBody = " + CheckNull(BodyHTML, 1) + " , KeyW = " + CheckNull(Keyword.Text, 1) + " , PicA = " + CheckNull(TextBox2.Text, 1) + " WHERE ID = " + Decode(v);
                }
                else
                {
                    Query = "INSERT INTO News(Title,NBody,KeyW,PicA,CatID,STS,UserID,DSource,SubT) VALUES (" + CheckNull(SubJ.Text.Trim(), 1) + "," + CheckNull(BodyHTML, 1) + "," + CheckNull(Keyword.Text, 1) + "," + CheckNull(TextBox2.Text, 1) + "," + CheckNull(Data[0], 0) + "," + STS + "," + CheckNull(Session["UserID"].ToString(), 0) + ",N'" + DSource.Text.Trim() + "',N'"+ Sub2.Text.Trim() + "')";
                    Query += "Declare @CurrentID bigint;set @CurrentID = SCOPE_IDENTITY();Update News Set NewsProfile = dbo.CreateURL(N'" + SubJ.Text.Trim().Replace(" ", "-") + "') + '-' + CONVERT(varchar(10),@CurrentID) WHERE ID = @CurrentID";
                }
                cmd.CommandText = Query;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.ForeColor = Color.Green;
                if (v != null)
                    Label1.Text = "خبر با موفقیت بروز رسانی شد";
                else
                    Label1.Text = "خبر با موفقیت ثبت شد";
                if (v == null)
                {
                    Button1.Visible = false;
                    Button1.Enabled = false;
                }
                LoadNews();
            }
            catch (Exception exp)
            {
                Label1.Text = exp.Message;
                Label1.ForeColor = Color.Red;
            }
        }
        else
        {
            Label1.Text = "لطفا مقادیر را درست وارد کنید";
            Label1.ForeColor = Color.Red;
        }
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

    protected void LoadNews()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string v = Request.QueryString["NewsID"];
            if (v != null)
            {
                v = Decode(v);
                SqlCommand cmd = new SqlCommand("SELECT Title,NBody,KeyW,PicA From News WHERE ID = " + v.ToString(), con);
                SqlDataReader dr = null;
                con.Open();
                string NN = "";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        SubJ.Text = dr[0].ToString();
                        TextBox1.Text = dr[1].ToString().Replace("<br>", "\n");
                        Keyword.Text = dr[2].ToString();
                        TextBox2.Text = dr[3].ToString();
                    }
                }
                con.Close();
                Button1.Text = "بروز رسانی";

            }
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }

    }
}