using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Data;
using System.IO;

public partial class Admin_AddHotel : System.Web.UI.Page
{
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
        if ((Session["Member"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
        else
        {
            (Session["User"]) = (Session["User"]);
        }
    }

    private void LoadLists()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT ID,Name FROM Country order by ID", con);
            SqlDataReader dr = null;
            con.Open();
            dr = null;
            DropDownList3.Items.Clear();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList3.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
            LoadCities();
            LoadArea();
        }
        catch (Exception exp)
        {
            Label1.Text = "country :" + exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }

    private void LoadCities()
    {
        DropDownList1.Items.Clear();
        if (DropDownList3.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data = DropDownList3.Text.Split('-');
                SqlCommand cmd = new SqlCommand("select ID,Name from City where CountryID =" + Data[0], con);
                SqlDataReader dr = null;
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

            }
            catch (Exception exp)
            {
                Label1.Text = "city :" + exp.Message;
                Label1.ForeColor = Color.Red;
            }
        }
    }
    private void LoadArea()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        DropDownList4.Items.Clear();
        if (DropDownList1.Text.Trim() != "")
        {
            try
            {
                string[] Data = DropDownList1.Text.Split('-');
                SqlCommand cmd = new SqlCommand("select ID,Name from Area where CityID =" + Data[0], con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList4.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());

                    }
                }
                con.Close();

            }
            catch (Exception exp)
            {
                Label1.Text = "area :" + exp.Message;
                Label1.ForeColor = Color.Red;
            }
        }
    }
    protected void LoadAksList(int ListNumb)
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select * from  (select Row_Number() over (order by ID) as RowIndex, * from HotelImage where HotelID = " + Session["HotelID"].ToString()  +") as Sub  Where Sub.RowIndex > " + ((ListNumb - 1) * 10) + " and Sub.RowIndex <= " + ((ListNumb) * 10) + " order by ID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList1.DataSource = ds.Tables[0].DefaultView;
            DataList1.DataBind();

        }
        catch (Exception exp)
        {
            Label5.Text = "2خطا در ارتباط با دیتابیس برای فراخوانی عکس ها";
            Label5.ForeColor = Color.Red;
        }
    }

    protected void FillPageRepeater()
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Count(ID) FROM HotelImage where HotelID =" + Session["HotelID"].ToString(), con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    LoadNumb(dr[0].ToString());
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label5.Text = "1خطا در ارتباط با دیتابیس برای فراخوانی عکس ها";
            Label5.ForeColor = Color.Red;
        }
        finally { con.Close(); }
    }

    protected void LoadNumb(string CountNumb)
    {
        decimal C = Convert.ToDecimal(CountNumb);
        C = C / 10;
        C = Math.Ceiling(C);
        int n = (int)C;
        DataTable dt = new DataTable();
        dt.Columns.Add("PageNumb", typeof(string));
        for (int i = 1; i <= n; i++)
        {
            dt.Rows.Add(i.ToString());
        }
        DataList2.DataSource = dt;
        DataList2.DataBind();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        CheckSafe();
        if (!IsPostBack)
        {
            LoadLists();
            if (Session["HotelID"] != null)
            {
                Session["PageNumb"] = 1;
                LoadAksList(1);
                FillPageRepeater();
            }
        }
    }
    protected void Loadkeshvar()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select ID,Name from Country", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("نامشخص");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList2.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            con.Close();
        }
    }

    private void LoadShahr()
    {
        if (DropDownList2.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                DropDownList6.Items.Clear();
                DropDownList6.Items.Add("نامشخص");
                string[] Data = DropDownList2.Text.Split('-');
                SqlCommand cmd = new SqlCommand("select ID,Name from City where CountryID =" + Data[0], con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList6.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    }
                }
                con.Close();

            }
            catch (Exception exp)
            {
                //Label2.Text = exp.Message;
                //Label2.ForeColor = Color.Red;
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
        if (!IsPostBack)
        {
            CheckAllow();
            LoadLists();
            Session["HotelID"] = null;
            Session["PageNumb"] = 1;
            HeaderImages.Visible = false;
            ImageTable.Visible = false;
            TakmiLTable.Visible = false;
            Loadkeshvar();
            LoadShahr();
        }
    }

    protected void CheckAllow()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select CHotel from AgencyDetail WHERE UserID = " + Session["UserID"].ToString(), con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            bool flg = false;
            if (dr.HasRows)
            {
                dr.Read();
                if (dr[0].ToString() == "False") flg = true;
            }
            con.Close();
            if (flg == true) Form1.InnerHtml = "متاسفانه شما مجوز تعریف هتل را ندارید";
        }
        catch (Exception exp)
        {

        }
    }

    private void LoadHotelInfoList()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select ID,Nam from InfoHotel Order by ID", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList10.Items.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList10.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());

                }
            }
            con.Close();

        }
        catch (Exception exp)
        {
            MessageBox(exp.Message);
            //Label1.Text = "city :" + exp.Message;
            //Label1.ForeColor = Color.Red;
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            e.Cancel = true;
            string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand("DELETE FROM Hotel where ID =" + ID, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Session["HotelID"] = null;
            GridView1.DataBind();
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        ShowHotelInfo(ID);
        MenuInsert.Enabled = false;
        MenuInsert2.Enabled = true;
        Button2.Enabled = true;
    }

    private void ShowHotelInfo(string HotelID)
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {

            SqlCommand cmd = new SqlCommand("select title,tozihat,country,city,area,Setare,AboutHotel,IconImage,KeyWord,HotelProfile from hotel where id = " + HotelID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                HotelName.Text = dr[0].ToString();
                Tozihat.Text = dr[1].ToString().Replace("<br/>", "\n");
                SetCountry(dr[2].ToString());
                LoadCities();
                SetCity(dr[3].ToString());
                LoadArea();
                SetArea(dr[4].ToString());
                SetSetare(dr[5].ToString());
                TextBox1.Text = dr[6].ToString().Replace("<br/>", "\n");
                TextBox3.Text = dr[7].ToString();
                Session["HotelID"] = HotelID;
                KeyWord.Text = dr["KeyWord"].ToString();
                HotelProfile.Text = dr["HotelProfile"].ToString().Replace("-", " ");
            }
            con.Close();
            LoadAksList(1);
            FillPageRepeater();
            ImageTable.Visible = true;
            HeaderImages.Visible = true;
            TakmiLTable.Visible = true;
            LoadHotelInfoList();
            LoadTakmili();
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }
    protected void SetCountry(string ID)
    {
        CheckSafe();
        DropDownList3.SelectedIndex = -1;
        for (int i = 0; i < DropDownList3.Items.Count; i++)
        {
            string[] SS = DropDownList3.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                DropDownList3.SelectedIndex = i;
                break;
            }
        }
    }

    protected void SetCity(string ID)
    {
        CheckSafe();
        DropDownList1.SelectedIndex = -1;
        for (int i = 0; i < DropDownList1.Items.Count; i++)
        {
            string[] SS = DropDownList1.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                DropDownList1.SelectedIndex = i;
                break;
            }
        }
    }

    protected void SetArea(string ID)
    {
        CheckSafe();
        DropDownList4.SelectedIndex = -1;
        for (int i = 0; i < DropDownList4.Items.Count; i++)
        {
            string[] SS = DropDownList4.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                DropDownList4.SelectedIndex = i;
                break;
            }
        }
    }
    
    protected void SetSetare(string ItemID)
    {
        CheckSafe();
        DropDownList5.SelectedIndex = -1;
        for (int i = 0; i < DropDownList5.Items.Count; i++)
        {
            if (ItemID.Trim() == DropDownList5.Items[i].Text.Trim())
            {
                DropDownList5.SelectedIndex = i;
                break;
            }
        }
    }
    protected bool CheckProfileValid()
    {
        bool flg = false;
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT ID from Hotel where HotelProfile like N'" + HotelProfile.Text.Replace(" ", "-") + "'", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                flg = true;
            }
            con.Close();
        }
        catch { }
        return flg;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "" && (TextBox3.Text.Trim() != "" || FileUpload2.HasFile) && HotelName.Text.Trim() != "" && Tozihat.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data1 = DropDownList3.Text.Split('-');
                string[] Data2 = DropDownList1.Text.Split('-');
                string[] Data3 = DropDownList4.Text.Split('-');
                string N1 = "", N2 = "", N3 = "";
                N1 = Tozihat.Text.Replace("\n", "<br/>");
                N2 = TextBox1.Text.Replace("\n", "<br/>");
                N3 = HotelProfile.Text.Replace(" ", "-");
                SqlCommand cmd = new SqlCommand("", con);
                if (FileUpload1.HasFile)
                {
                    string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                    string p = MapPath("~/IMG/");
                    p += time;
                    TextBox3.Text = "/IMG/" + time;
                    FileUpload1.SaveAs(p);
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                    img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                    img1.Save(MapPath("~/IMG/th/") + time);
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string Vals = CheckNull(HotelName.Text, 1) + " , " + CheckNull(N1, 1) + " , " + CheckNull(Data1[0], 0) + " , " + CheckNull(Data2[0], 0) + " , " + CheckNull(Data3[0], 0) + " , " + CheckNull(DropDownList5.Text, 0) + " , " + CheckNull(N2, 1) + " , " + CheckNull(TextBox3.Text, 1) + " , " + Session["UserID"].ToString() + " , " + CheckNull(KeyWord.Text, 1) + " , " + CheckNull(N3, 1) + " ) ";
                string MyQu = "insert into Hotel(title,tozihat,country,city,area,Setare,AboutHotel,IconImage,OwnerID,KeyWord,HotelProfile) values (" + Vals;
                cmd.CommandText = MyQu;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "تور با موفقیت اضافه شد";
                Label1.ForeColor = Color.Green;
                GridView1.DataBind();
                LoadLists();
            }
            catch (Exception exp)
            {
                Label1.Text = exp.Message;
                Label1.ForeColor = Color.Red;
            }
        }
        else
        {
            Label1.Text = "لطفا مقادیر مورد نظر را وارد کنید";
            Label1.ForeColor = Color.Red;
        }
    }
    protected void MenuInsert2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "" && (TextBox3.Text.Trim() != "" || FileUpload2.HasFile) && HotelName.Text.Trim() != "" && Tozihat.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("", con);
                if (FileUpload1.HasFile)
                {
                    string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                    string p = MapPath("~/IMG/");
                    p += time;
                    TextBox3.Text = "/IMG/" + time;
                    FileUpload1.SaveAs(p);
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                    img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                    img1.Save(MapPath("~/IMG/th/") + time);
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string[] Data1 = DropDownList3.Text.Split('-');
                string[] Data2 = DropDownList1.Text.Split('-');
                string[] Data3 = DropDownList4.Text.Split('-');
                string N1 = "", N2 = "", N3 = "";
                N1 = Tozihat.Text.Replace("\n", "<br/>");
                N2 = TextBox1.Text.Replace("\n", "<br/>");
                N3 = HotelProfile.Text.Replace(" ", "-");
                string Vals = "Update Hotel Set HotelProfile = " + CheckNull(N3, 1) + " , KeyWord = " + CheckNull(KeyWord.Text, 1) + " , Setare = " + CheckNull(DropDownList5.Text, 0) + ", AboutHotel= " + CheckNull(N2, 1) + " , IconImage= " + CheckNull(TextBox3.Text.Trim(), 1) + ", title =" + CheckNull(HotelName.Text, 1) + " , tozihat = " + CheckNull(N1, 1) + " , country=" + CheckNull(Data1[0], 0) + " , city = " + CheckNull(Data2[0], 0);
                Vals += " , area = " + CheckNull(Data3[0], 1) + " WHERE ID = " + Session["HotelID"];
                string MyQu = Vals;
                cmd.CommandText = MyQu;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "تور با موفقیت ویرایش شد";
                Label1.ForeColor = Color.Green;
                HotelName.Text = "";
                Tozihat.Text = "";
                LoadLists();
                MenuInsert.Enabled = true;
                MenuInsert2.Enabled = false;
                Button2.Enabled = false;
                Session["HotelID"] = null;
                HeaderImages.Visible = false;
                ImageTable.Visible = false;
                Button2.Enabled = false;
                TakmiLTable.Visible = false;
                TextBox1.Text = "";
                TextBox3.Text = "";
            }
            catch (Exception exp)
            {
                Label1.Text = exp.Message;
                Label1.ForeColor = Color.Red;
            }
        }
        else
        {
            Label1.Text = "لطفا مقادیر مورد نظر را وارد کنید";
            Label1.ForeColor = Color.Red;
        }
    }
    protected void MenuInsert3_Click(object sender, EventArgs e)
    {

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCities();
        LoadArea();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        LoadArea();
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "1.jpg";
                string p = MapPath("~/IMG/");
                p += time;
                FileUpload1.SaveAs(p);
                System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                img1.Save(MapPath("~/IMG/th/") + time);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "'); INSERT INTO HotelImage(HotelID,ImageAddress,KeyW) VALUES (" + Session["HotelID"] + " , " + CheckNull(time, 1) + " , " + CheckNull(KeyW1.Text, 1) + ");";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    int bb = int.Parse(Session["PageNumb"].ToString());
                    LoadAksList(bb);

                }
                catch (Exception exp)
                {
                    Label5.Text = "خطا در اتصال با دیتابیس";
                    Label5.ForeColor = Color.Red;
                }
                Label5.Text = "";
                //Label6.Text = "<blink>فایل با موفقیت آپلود شد</blink>" + "<br/><a href='../IMG/" + time + "' style='text-decoration:none' /> لینک فایل</a>";
                Label5.ForeColor = Color.Green;
            }
            catch
            {
                Label5.Text = "این عکس در حال حاضر در دیتابیس قرار دارد";
                Label5.ForeColor = Color.Red;
            }
        }
        if (FileUpload6.HasFile)
        {
            try
            {
                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "2.jpg";
                string p = MapPath("~/IMG/");
                p += time;
                FileUpload6.SaveAs(p);
                System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                img1.Save(MapPath("~/IMG/th/") + time);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "'); INSERT INTO HotelImage(HotelID,ImageAddress,KeyW) VALUES (" + Session["HotelID"] + " , " + CheckNull(time, 1) + " , " + CheckNull(KeyW5.Text, 1) + ");";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    int bb = int.Parse(Session["PageNumb"].ToString());
                    LoadAksList(bb);

                }
                catch (Exception exp)
                {
                    Label5.Text = "خطا در اتصال با دیتابیس";
                    Label5.ForeColor = Color.Red;
                }
                Label5.Text = "";
                //Label6.Text = "<blink>فایل با موفقیت آپلود شد</blink>" + "<br/><a href='../IMG/" + time + "' style='text-decoration:none' /> لینک فایل</a>";
                Label5.ForeColor = Color.Green;
            }
            catch
            {
                Label5.Text = "این عکس در حال حاضر در دیتابیس قرار دارد";
                Label5.ForeColor = Color.Red;
            }
        }
        if (FileUpload3.HasFile)
        {
            try
            {
                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "3.jpg";
                string p = MapPath("~/IMG/");
                p += time;
                FileUpload3.SaveAs(p);
                System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                img1.Save(MapPath("~/IMG/th/") + time);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "'); INSERT INTO HotelImage(HotelID,ImageAddress,KeyW) VALUES (" + Session["HotelID"] + " , " + CheckNull(time, 1) + " , " + CheckNull(KeyW2.Text, 1) + ");";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    int bb = int.Parse(Session["PageNumb"].ToString());
                    LoadAksList(bb);

                }
                catch (Exception exp)
                {
                    Label5.Text = "خطا در اتصال با دیتابیس";
                    Label5.ForeColor = Color.Red;
                }
                Label5.Text = "";
                //Label6.Text = "<blink>فایل با موفقیت آپلود شد</blink>" + "<br/><a href='../IMG/" + time + "' style='text-decoration:none' /> لینک فایل</a>";
                Label5.ForeColor = Color.Green;
            }
            catch
            {
                Label5.Text = "این عکس در حال حاضر در دیتابیس قرار دارد";
                Label5.ForeColor = Color.Red;
            }
        }
        if (FileUpload4.HasFile)
        {
            try
            {
                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "4.jpg";
                string p = MapPath("~/IMG/");
                p += time;
                FileUpload4.SaveAs(p);
                System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                img1.Save(MapPath("~/IMG/th/") + time);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "'); INSERT INTO HotelImage(HotelID,ImageAddress,KeyW) VALUES (" + Session["HotelID"] + " , " + CheckNull(time, 1) + " , " + CheckNull(KeyW3.Text, 1) + ");";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    int bb = int.Parse(Session["PageNumb"].ToString());
                    LoadAksList(bb);

                }
                catch (Exception exp)
                {
                    Label5.Text = "خطا در اتصال با دیتابیس";
                    Label5.ForeColor = Color.Red;
                }
                Label5.Text = "";
                //Label6.Text = "<blink>فایل با موفقیت آپلود شد</blink>" + "<br/><a href='../IMG/" + time + "' style='text-decoration:none' /> لینک فایل</a>";
                Label5.ForeColor = Color.Green;
            }
            catch
            {
                Label5.Text = "این عکس در حال حاضر در دیتابیس قرار دارد";
                Label5.ForeColor = Color.Red;
            }
        }
        if (FileUpload5.HasFile)
        {
            try
            {
                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "5.jpg";
                string p = MapPath("~/IMG/");
                p += time;
                FileUpload5.SaveAs(p);
                System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                img1.Save(MapPath("~/IMG/th/") + time);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "'); INSERT INTO HotelImage(HotelID,ImageAddress,KeyW) VALUES (" + Session["HotelID"] + " , " + CheckNull(time, 1) + " , " + CheckNull(KeyW4.Text, 1) + ");";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    int bb = int.Parse(Session["PageNumb"].ToString());
                    LoadAksList(bb);

                }
                catch (Exception exp)
                {
                    Label5.Text = "خطا در اتصال با دیتابیس";
                    Label5.ForeColor = Color.Red;
                }
                Label5.Text = "";
                //Label6.Text = "<blink>فایل با موفقیت آپلود شد</blink>" + "<br/><a href='../IMG/" + time + "' style='text-decoration:none' /> لینک فایل</a>";
                Label5.ForeColor = Color.Green;
            }
            catch
            {
                Label5.Text = "این عکس در حال حاضر در دیتابیس قرار دارد";
                Label5.ForeColor = Color.Red;
            }
        }
    }

    protected void DeleteImageByName(string ImageName)
    {
        string ImageAddress = MapPath("~/IMG/") + ImageName;
        string ImagethAddress = MapPath("~/IMG/th/") + ImageName;
        if (File.Exists(ImageAddress))
        {
            System.IO.File.Delete(ImageAddress);
            System.IO.File.Delete(ImagethAddress);
        }
    }

    protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        string ImageID = ((Label)e.Item.FindControl("Label3")).Text;
        string ImageName = ((Label)e.Item.FindControl("Label4")).Text;
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            DeleteImageByName(ImageName);
            SqlCommand cmd = new SqlCommand("DELETE FROM Aks WHERE AksA like N'" + ImageName + "' ; DELETE FROM HotelImage WHERE ID = " + ImageID, con);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
            Label5.Text = "عکس با موفقیت حذف شد";
            Label5.ForeColor = Color.Green;
            int bb = int.Parse(Session["PageNumb"].ToString());
            LoadAksList(bb);

        }
        catch (Exception exp)
        {
            Label5.Text = exp.Message;
            Label5.ForeColor = Color.Red;
        }
    }
    protected void DataList2_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        string ImageID = ((LinkButton)e.Item.FindControl("LinkButton1")).Text;
        Session["PageNumb"] = ImageID;
        LoadAksList(Convert.ToInt16(ImageID));
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MenuInsert2.Enabled = false;
        MenuInsert.Enabled = true;
        LoadLists();
        Session["HotelID"] = null;
        HeaderImages.Visible = false;
        ImageTable.Visible = false;
        Button2.Enabled = false;
        TakmiLTable.Visible = false;
        TextBox3.Text="";
        DropDownList5.SelectedIndex=0;
        Tozihat.Text="";
        TextBox1.Text = "";
        HotelName.Text = "";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = DropDownList10.Text.Split('-');
            SqlCommand cmd = new SqlCommand("INSERT INTO HotelDetail(Nam,HotelID) VALUES("+ CheckNull(Data[0].ToString().Trim(),0) + " , " + Session["HotelID"].ToString() + " )",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GridView2.DataBind();
        }
        catch (Exception exp)
        {
            MessageBox(exp.Message);
        }
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string ID = GridView2.DataKeys[e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand("DELETE FROM HotelDetail where ID =" + ID, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GridView2.DataBind();
        }
        catch (Exception exp)
        {
            MessageBox(exp.Message);
        }
    }
    protected void LoadTakmili()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT Room,Address,Tel,Site,SiteFilter FROM takmiliHotel WHERE HotelID = " + Session["HotelID"].ToString(), con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txt1.Text = dr[0].ToString();
                    txt4.Text = dr[1].ToString();
                    txt2.Text = dr[2].ToString();
                    txt3.Text = dr[3].ToString();
                    if (dr[4].ToString() == "True") DropDownList7.SelectedIndex = 0;
                    else DropDownList7.SelectedIndex = 1;
                }
            }
            con.Close();

        }
        catch (Exception exp)
        {
            Label7.Text = "خطا " + exp.Message;
            Label7.ForeColor = Color.Red;
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string SiteSTS = "0";
            if (DropDownList7.Text.Trim() == "فعال") SiteSTS = "1";
            SqlCommand cmd = new SqlCommand("UPDATE takmiliHotel Set SiteFilter = " + SiteSTS + " , Room = " + CheckNull(txt1.Text, 0) + " ,Address= " + CheckNull(txt4.Text, 1) + ",Tel=" + CheckNull(txt2.Text, 1) + ",Site= " + CheckNull(txt3.Text, 1) + " WHERE HotelID = " + Session["HotelID"].ToString(), con);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
            if (n == 0)
            {
                cmd.CommandText = "INSERT INTO takmiliHotel(Room,Address,Tel,Site,HotelID,SiteFilter) VALUES ( " + CheckNull(txt1.Text, 0) + " , " + CheckNull(txt4.Text, 1) + "," + CheckNull(txt2.Text, 1) + "," + CheckNull(txt3.Text, 1) + ", " + Session["HotelID"].ToString() + " , " + SiteSTS + ")";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Label7.ForeColor = Color.Green;
            Label7.Text = "عملیات با موفقیت انجام شد";
        }
        catch (Exception exp)
        {
            Label7.Text = "خطا " + exp.Message;
            Label7.ForeColor = Color.Red;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            if (e.Row.Cells[2].Text == "False")
            {
                e.Row.Cells[2].Text = "تایید نشده";
                e.Row.Cells[2].CssClass = "TaedNashode";
            }
            else
            {
                e.Row.Cells[2].Text = "تایید شده";
                e.Row.Cells[2].CssClass = "TaedShode";
            }
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadShahr();
        if (DropDownList2.Text != "نامشخص")
        {
            string[] Data = DropDownList2.Text.Split('-');
            SqlDataSource1.SelectCommand = "SELECT [ID], [Title],[Active] FROM [Hotel] WHERE [Country] = " + Data[0] + " AND [OwnerID] = " + Session["UserID"].ToString();
            GridView1.DataBind();
        }
        else
        {
            SqlDataSource1.SelectCommand = "SELECT [ID], [Title],[Active] FROM [Hotel] WHERE [OwnerID] = " + Session["UserID"].ToString();
            GridView1.DataBind();
        }
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList6.Text != "نامشخص")
        {
            string[] Data = DropDownList2.Text.Split('-');
            string[] Data2 = DropDownList6.Text.Split('-');
            SqlDataSource1.SelectCommand = "SELECT [ID], [Title],[Active] FROM [Hotel] WHERE [Country] = " + Data[0] + " AND [City] = " + Data2[0] + " AND [OwnerID] = " + Session["UserID"].ToString();
            GridView1.DataBind();
        }
        else
        {
            if (DropDownList2.Text != "نامشخص")
            {
                string[] Data = DropDownList2.Text.Split('-');
                SqlDataSource1.SelectCommand = "SELECT [ID], [Title],[Active] FROM [Hotel] WHERE [Country] = " + Data[0] + " AND [OwnerID] = " + Session["UserID"].ToString();
            }
            else
            {
                SqlDataSource1.SelectCommand = "SELECT [ID], [Title],[Active] FROM [Hotel] WHERE [OwnerID] = " + Session["UserID"].ToString();
            }
            GridView1.DataBind();
        }
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        if (SearchHotel.Text.Trim() != "")
        {
            SqlDataSource1.SelectCommand = "SELECT [ID], [Title],[Active] FROM [Hotel] WHERE [OwnerID] = " + Session["UserID"].ToString() + " AND [Title] like N'%" + SearchHotel.Text.Trim().ToLower() + "%'";
            GridView1.DataBind();
        }
        else
        {
            SqlDataSource1.SelectCommand = "SELECT [ID], [Title],[Active] FROM [Hotel] WHERE [OwnerID] = " + Session["UserID"].ToString();
            GridView1.DataBind();
        }
    }
}