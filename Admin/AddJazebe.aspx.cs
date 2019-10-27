using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

public partial class Admin_AddJazebe : System.Web.UI.Page
{
    private void LoadCountries()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            SqlDataReader dr = null;
            cmd.CommandText = "SELECT ID,Name FROM Country order by ID";
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList1.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
            LoadCities();
            LoadArea();
        }
        catch (Exception exp)
        {
            con.Close();
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }
    private void LoadArea()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = DropDownList2.Text.Split('-');
            if (Data.Length > 1)
            {
                SqlCommand cmd = new SqlCommand("select ID,Name from Area where CityID =" + Data[0], con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                DropDownList3.Items.Clear();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList3.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());

                    }
                }
                con.Close();
            }
        }
        catch (Exception exp)
        {
            con.Close();
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }
    private void LoadCities()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = DropDownList1.Text.Split('-');
            if (Data.Length > 1)
            {
                SqlCommand cmd = new SqlCommand("select ID,Name from City where CountryID =" + Data[0], con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                DropDownList2.Items.Clear();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList2.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    }
                }
                con.Close();
            }
        }
        catch (Exception exp)
        {
            con.Close();
            Label1.Text = exp.Message;
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
            string v = Request.QueryString["JID"];
            if (v != null)
            {
                v = Decode(v);
                SqlCommand cmd = new SqlCommand("SELECT Title,NBody,KeyW,PicA From Jazebe WHERE ID = " + v.ToString(), con);
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

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
        if (!IsPostBack)
        {
            string v = Request.QueryString["JID"];
            if (v != null) LoadNews();
            LoadCountries();
        }
    }
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        CheckSafe();
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
                string v = Request.QueryString["JID"];
                string[] Data1 = DropDownList1.Text.Split('-');
                string[] Data2 = DropDownList2.Text.Split('-');
                string[] Data3 = DropDownList3.Text.Split('-');
                string Query = "";
                if (v != null)
                {
                    Query = "UPDATE Jazebe Set  JazebeProfile = N'" + SubJ.Text.Trim().Replace(" ", "-") + "-" + v + "' , Country = " + CheckNull(Data1[0], 0) + ", City = " + CheckNull(Data2[0], 0) + ", Area = " + CheckNull(Data3[0], 0) + " , Title = " + CheckNull(SubJ.Text.Trim(), 1) + " , NBody = " + CheckNull(BodyHTML, 1) + " , KeyW = " + CheckNull(Keyword.Text, 1) + " , PicA = " + CheckNull(TextBox2.Text, 1) + " WHERE ID = " + Decode(v);

                }
                else
                {
                    Query = "INSERT INTO Jazebe(Title,NBody,KeyW,PicA,Country,City,Area) VALUES (" + CheckNull(SubJ.Text.Trim(), 1) + "," + CheckNull(BodyHTML, 1) + "," + CheckNull(Keyword.Text, 1) + "," + CheckNull(TextBox2.Text, 1) + "," + CheckNull(Data1[0], 0) + "," + CheckNull(Data2[0], 0) + "," + CheckNull(Data3[0], 0) + ")";
                    Query += "Declare @CurrentID bigint;set @CurrentID = SCOPE_IDENTITY();Update Jazebe Set JazebeProfile = N'" + SubJ.Text.Trim().Replace(" ", "-") + "' + '-' + CONVERT(varchar(10),@CurrentID) WHERE ID = @CurrentID";
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCities();
        LoadArea();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadArea();
    }
}