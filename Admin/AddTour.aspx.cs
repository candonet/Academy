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

public partial class Admin_AddTour : System.Web.UI.Page
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
    int MTC = 2;
    protected void Page_PreRender(object sender, EventArgs e)
    {
        try
        {
            //string CurrentPointer = Session["Pointer"].ToString();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<script type='text/javascript'>");
            //sb.Append("MoveToN(" + CurrentPointer + ")");
            //sb.Append("</script>");
            //Random r = new Random();
            //MTC = r.Next(1, 1000);

            //ClientScript.RegisterStartupScript(this.GetType(), "JSScript", sb.ToString()); 
            //Page.RegisterStartupScript("MoveTT" + MTC.ToString(), sb.ToString());
            FillGridView();
        }
        catch { }
    }
    protected void FillGridView()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data1 = DropDownList8.Text.Split('-');
            string[] Data2 = DropDownList12.Text.Split('-');
            string[] Data3 = DropDownList13.Text.Split('-');
            string[] Data4 = DropDownList14.Text.Split('-');
            bool flg = false;
            string myQu = "";
            if (Data1.Length > 1)
            {
                flg = true;
                myQu += " UserID = " + Data1[0] + " AND ";
            }
            if (Data2.Length > 1)
            {
                flg = true;
                myQu += " TourCatID = " + Data2[0] + " AND ";
            }
            if (Data3.Length > 1)
            {
                flg = true;
                myQu += " keshvar = " + Data3[0] + " AND ";
            }
            if (Data4.Length > 1)
            {
                flg = true;
                myQu += " shahr = " + Data4[0] + " AND ";
            }
            if (flg == true)
                myQu = " WHERE " + myQu.Substring(1, myQu.Length - 5);
            SqlCommand cmd = new SqlCommand("select ID,Nam,(select nam From AgencyDetail WHERE UserID = TourBase.UserID) as Agency,(select TourCat From TourCat WHERE ID = TourBase.TourCatID) as Kind,modat,tarikh2 FROM TourBase" + myQu + " Order By ID DESC", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView3.DataSource = ds.Tables[0].DefaultView;
            GridView3.DataBind();
        }
        catch (Exception exp)
        {
            MessageBox(exp.Message);
        }
    }

    protected void LoadAgencyList()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select userid,nam from AgencyDetail", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList8.Items.Clear();
            DropDownList8.Items.Add("نامشخص");
            DropDownList15.Items.Clear();
            DropDownList15.Items.Add("نامشخص");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList8.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList15.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            con.Close();
        }
    }

    protected void LoadTourCat()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select ID,TourCat from TourCat", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList12.Items.Clear();
            DropDownList12.Items.Add("نامشخص");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList12.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            con.Close();
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
            DropDownList13.Items.Clear();
            DropDownList13.Items.Add("نامشخص");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList13.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
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
        if (DropDownList13.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                DropDownList14.Items.Clear();
                DropDownList14.Items.Add("نامشخص");
                string[] Data = DropDownList13.Text.Split('-');
                SqlCommand cmd = new SqlCommand("select ID,Name from City where CountryID =" + Data[0], con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList14.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    }
                }
                con.Close();

            }
            catch (Exception exp)
            {
                Label2.Text = exp.Message;
                Label2.ForeColor = Color.Red;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
        if (!IsPostBack)
        {
            LoadLists();
            TableHotel.Visible = false;
            distnationTitle.Visible = false;
            TableBe.Visible = false;
            HotelTitle.Visible = false;
            AdsTable.Visible = false;
            Session["TourID"] = null;
            sl1.Visible = true;
            sl4.Visible = true;
            sl2.Visible = false;
            sl3.Visible = false;
            sln11.Visible = false;
            sln12.Visible = false;
            sln13.Visible = false;
            sln14.Visible = false;
            sln21.Visible = false;
            sln22.Visible = false;
            sln23.Visible = false;
            sln24.Visible = false;
            sln31.Visible = false;
            sln32.Visible = false;
            sln33.Visible = false;
            sln34.Visible = false;
            sln41.Visible = false;
            sln42.Visible = false;
            sln43.Visible = false;
            sln44.Visible = false;
            LoadAgencyList();
            LoadTourCat();
            Loadkeshvar();
        }
        
    }

    private void LoadLists()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT ID,Nam From TourBase order by Id ", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList2.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
                if (DropDownList2.Items.Count > 0)
                {
                    DropDownList2.SelectedIndex = 0;
                }
            }
            con.Close();
            cmd.CommandText = "SELECT ID,Name FROM Country order by ID";
            con.Open();
            dr = null;
            dr = cmd.ExecuteReader();
            DropDownList3.Items.Clear();
            DropDownList33.Items.Clear();
            DropDownList34.Items.Clear();
            DropDownList35.Items.Clear();
            DropDownList36.Items.Clear();
            DropDownList3.Items.Add("نامشخص");
            DropDownList33.Items.Add("نامشخص");
            DropDownList34.Items.Add("نامشخص");
            DropDownList35.Items.Add("نامشخص");
            DropDownList36.Items.Add("نامشخص");

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList3.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList33.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList34.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList35.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList36.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
            dr = null;
            cmd.CommandText = "SELECT ID,TourCat from TourCat order by ID";
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList5.Items.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                    DropDownList5.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
            }
            con.Close();
            //LoadCities();
            //LoadArea();
        }
        catch (Exception exp)
        {
            Label2.Text = exp.Message;
            Label2.ForeColor = Color.Red;
        }
    }

    protected void LoadHotelSforCountries(object dropList,string CountryID)
    {
        var drop = (dropList as DropDownList);
        drop.Items.Clear();
        drop.Items.Add("");
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT ID,Title From Hotel Where Country = " + CountryID + " order by Id ", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    drop.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            MessageBox(exp.Message);
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
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (DropDownList3.Text != "نامشخص" && TextBox1.Text.Trim() != "" && TextBox2.Text.Trim() != "" && TextBox8.Text.Trim() != "" && TextBox4.Text.Trim() != "" && TextBox5.Text.Trim() != "" && CityName.Text.Trim() != "" && TextBox3.Text.Trim() != "" && TextBox7.Text.Trim() != "")
        {
            if (DropDownList15.Text != "نامشخص")
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    string StartDate = "";
                    string EndDate = "";
                    string[] DateC = TextBox3.Text.Split('/');
                    if (DateC[1].Length < 2) DateC[1] = "0" + DateC[1];
                    if (DateC[2].Length < 2) DateC[2] = "0" + DateC[2];
                    StartDate = DateC[0] + "/" + DateC[1] + "/" + DateC[2];
                    DateC = TextBox7.Text.Split('/');
                    if (DateC[1].Length < 2) DateC[1] = "0" + DateC[1];
                    if (DateC[2].Length < 2) DateC[2] = "0" + DateC[2];
                    EndDate = DateC[0] + "/" + DateC[1] + "/" + DateC[2];
                    string[] Data1 = null;
                    string[] Data2 = null;
                    string[] Data3 = null;
                    string[] Data4 = null;
                    string[] Data5 = null;
                    if (DropDownList3.Text != "نامشخص") Data1 = DropDownList3.Text.Split('-');
                    else Data1 = new string[1];
                    if (DropDownList1.Text != "نامشخص") Data2 = DropDownList1.Text.Split('-');
                    else Data2 = new string[1];
                    if (DropDownList4.Text != "نامشخص") Data3 = DropDownList4.Text.Split('-');
                    else Data3 = new string[1];
                    if (DropDownList5.Text != "نامشخص") Data4 = DropDownList5.Text.Split('-');
                    else Data4 = new string[1];
                    if (DropDownList15.Text != "نامشخص") Data5 = DropDownList15.Text.Split('-');
                    string N1 = "", N2 = "", N3 = "";
                    N1 = TextBox4.Text.Replace("\n", "<br/>");
                    N2 = TextBox5.Text.Replace("\n", "<br/>");
                    N3 = TextBox6.Text.Replace("\n", "<br/>");
                    string Loks = "0", Ofr = "0";
                    if (DropDownList10.Text == "بله") Ofr = "1";
                    if (DropDownList11.Text == "بله") Loks = "1";
                    string Vals = CheckNull(TextBox1.Text, 1) + " , " + CheckNull(Data1[0], 0) + " , " + CheckNull(Data2[0], 0) + " , " + CheckNull(Data3[0], 0) + " , ";
                    Vals += CheckNull(CityName.Text, 1) + " , " + CheckNull(TextBox8.Text, 1) + " , " + CheckNull(TextBox2.Text, 1) + " , " + CheckNull(StartDate, 1) + " , " + CheckNull(EndDate, 1) + " , " + CheckNull(N1, 1) + " , " + CheckNull(N2, 1) + " , " + CheckNull(N3, 1);
                    Vals += " , " + CheckNull(Data5[0], 0) + " , " + CheckNull(Data4[0], 0) + " , " + CheckNull(KeyWord.Text, 1) + " , " + CheckNull(Loks, 0) + " , " + CheckNull(Ofr, 0) + ");Declare @CurrentID bigint;set @CurrentID = SCOPE_IDENTITY();Update TourBase Set TourProfile = N'" + TextBox1.Text.Replace(" ", "-") + "' + '-' + CONVERT(varchar(10),@CurrentID) WHERE ID = @CurrentID";
                    string MyQu = "insert into TourBase(Nam,keshvar,shahr,nahie,az,modat,kind,tarikh1,tarikh2,madarek,khadamat,tozihat,UserID,TourCatID,KeyW,Loks,Offer) values (" + Vals;
                    SqlCommand cmd = new SqlCommand(MyQu, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DropDownList2.Items.Clear();
                    Label2.Text = "تور با موفقیت اضافه شد";
                    Label2.ForeColor = Color.Green;
                    LoadLists();
                }
                catch (Exception exp)
                {
                    Label2.Text = exp.Message;
                    Label2.ForeColor = Color.Red;
                }
            }
            else
            {
                Label2.Text = "لطفا آژانس مورد نظر را انتخاب کنید";
                Label2.ForeColor = Color.Red;
            }
        }
        else
        {
            Label2.Text = "لطفا مقادیر را کامل پر کنید";
            Label2.ForeColor = Color.Red;
        }
    }
    protected void Button4_Click1(object sender, EventArgs e)
    {
        if (DropDownList3.Text != "نامشخص" && TextBox1.Text.Trim() != "" && TextBox2.Text.Trim() != "" && TextBox8.Text.Trim() != "" && TextBox4.Text.Trim() != "" && TextBox5.Text.Trim() != "" && CityName.Text.Trim() != "" && TextBox3.Text.Trim() != "" && TextBox7.Text.Trim() != "")
        {
            if (DropDownList15.Text.Trim() != "نامشخص")
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    string StartDate = "";
                    string EndDate = "";
                    string[] DateC = TextBox3.Text.Split('/');
                    if (DateC[1].Length < 2) DateC[1] = "0" + DateC[1];
                    if (DateC[2].Length < 2) DateC[2] = "0" + DateC[2];
                    StartDate = DateC[0] + "/" + DateC[1] + "/" + DateC[2];
                    DateC = TextBox7.Text.Split('/');
                    if (DateC[1].Length < 2) DateC[1] = "0" + DateC[1];
                    if (DateC[2].Length < 2) DateC[2] = "0" + DateC[2];
                    EndDate = DateC[0] + "/" + DateC[1] + "/" + DateC[2];
                    string[] Data1 = null;
                    string[] Data2 = null;
                    string[] Data3 = null;
                    string[] Data4 = null;
                    string[] Data5 = null;
                    if (DropDownList3.Text != "نامشخص") Data1 = DropDownList3.Text.Split('-');
                    else Data1 = new string[1];
                    if (DropDownList1.Text != "نامشخص") Data2 = DropDownList1.Text.Split('-');
                    else Data2 = new string[1];
                    if (DropDownList4.Text != "نامشخص") Data3 = DropDownList4.Text.Split('-');
                    else Data3 = new string[1];
                    if (DropDownList5.Text != "نامشخص") Data4 = DropDownList5.Text.Split('-');
                    else Data4 = new string[1];
                    if (DropDownList15.Text != "نامشخص") Data5 = DropDownList15.Text.Split('-');
                    string UserOwner = Session["UserID"].ToString();
                    if (DropDownList15.Text != "نامشخص") UserOwner = Data5[0];
                    string Loks = "0", Ofr = "0";
                    if (DropDownList10.Text == "بله") Ofr = "1";
                    if (DropDownList11.Text == "بله") Loks = "1";
                    string N1 = "", N2 = "", N3 = "";
                    N1 = TextBox4.Text.Replace("\n", "<br/>");
                    N2 = TextBox5.Text.Replace("\n", "<br/>");
                    N3 = TextBox6.Text.Replace("\n", "<br/>");
                    string Vals = "Update TourBase Set TourProfile = N'" + TextBox1.Text.Trim().Replace(" ", "-") + "-" + Session["TourID"].ToString() + "' , Nam =" + CheckNull(TextBox1.Text, 1) + " , keshvar = " + CheckNull(Data1[0], 0) + " , shahr=" + CheckNull(Data2[0], 0) + " , nahie = " + CheckNull(Data3[0], 0);
                    Vals += " , UserID = " + CheckNull(Data5[0], 0) + " , az = " + CheckNull(CityName.Text, 1) + " , modat = " + CheckNull(TextBox8.Text, 1) + " , kind = " + CheckNull(TextBox2.Text, 1) + " , tarikh1 = " + CheckNull(StartDate, 1);
                    Vals += " , tarikh2 = " + CheckNull(EndDate, 1) + " , madarek =" + CheckNull(N1, 1) + " , khadamat = " + CheckNull(N2, 1) + " , tozihat = " + CheckNull(N3, 1);
                    Vals += " , TourCatID =" + CheckNull(Data4[0], 0) + " , KeyW =" + CheckNull(KeyWord.Text, 1) + " , Loks =" + CheckNull(Loks, 0) + " , Offer =" + CheckNull(Ofr, 0) + " WHERE ID = " + Session["TourID"];
                    string MyQu = Vals;
                    SqlCommand cmd = new SqlCommand(MyQu, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DropDownList2.Items.Clear();
                    Label2.Text = "تور با موفقیت ویرایش شد";
                    Label2.ForeColor = Color.Green;
                    LoadLists();
                    Button4.Enabled = false;
                    Button5.Enabled = false;
                    Button3.Enabled = true;
                }
                catch (Exception exp)
                {
                    Label2.Text = exp.Message;
                    Label2.ForeColor = Color.Red;
                }
            }
            else
            {
                Label2.Text = "لطفا آژانس مورد نظر را انتخاب کنید";
                Label2.ForeColor = Color.Red;
            }
        }
        else
        {
            Label2.Text = "لطفا مقادیر را کامل پر کنید";
            Label2.ForeColor = Color.Red;
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data1 = DropDownList2.Text.Split('-');
            string MyQu = "";
            MyQu += " ; Delete From TourHotel WHERE TourID = " + Session["TourID"].ToString();
            MyQu += " ; Delete From BeTB WHERE TourID = " + Session["TourID"].ToString();
            MyQu += " ; DELETE FROM TourBase WHERE ID = " + Session["TourID"].ToString();
            SqlCommand cmd = new SqlCommand(MyQu, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            DropDownList2.Items.Clear();
            Label2.Text = "تور با موفقیت حذف شد";
            Label2.ForeColor = Color.Green;
            LoadLists();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button3.Enabled = true;
        }
        catch (Exception exp)
        {
            Label2.Text = exp.Message;
            Label2.ForeColor = Color.Red;
        }
    }
    protected void Button1_Click2(object sender, EventArgs e)
    {
        CurrentCity.Text = DropDownList2.Text;
        ShowCountryItem();
        Button4.Enabled = true;
        Button5.Enabled = true;
        Button3.Enabled = false;
    }

    private void ShowCountryItem()
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            //string[] Data = DropDownList2.Text.Split('-');
            SqlCommand cmd = new SqlCommand("select Nam,keshvar,shahr,nahie,az,modat,kind,tarikh1,tarikh2,madarek,khadamat,tozihat,ID,TourCatID,ADS,TourICO,Loks,Offer,KeyW,UserID from TourBase where id =" + Session["TourID"].ToString(), con);
            SqlDataReader dr = null;
            Session["TiID"] = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                TextBox1.Text = dr[0].ToString();
                SetCountry(dr[1].ToString());
                LoadCities();
                SetCity(dr[2].ToString());
                LoadArea();
                SetArea(dr[3].ToString());
                CityName.Text = dr[4].ToString();
                TextBox8.Text = dr[5].ToString();
                TextBox2.Text = dr[6].ToString();
                TextBox3.Text = dr[7].ToString();
                TextBox7.Text = dr[8].ToString();
                TextBox4.Text = dr[9].ToString().Replace("<br/>", "\n");
                TextBox5.Text = dr[10].ToString().Replace("<br/>", "\n");
                TextBox6.Text = dr[11].ToString().Replace("<br/>", "\n");
                //Session["TourID"] = dr[12].ToString();
                SetCat(dr[13].ToString());
                TextBox9.Text = dr[15].ToString();
                string AdsSTS = dr[14].ToString();
                if (AdsSTS == "True") DropDownList7.SelectedIndex = 1;
                else DropDownList7.SelectedIndex = 0;
                if (dr["Loks"].ToString() == "True") DropDownList11.SelectedIndex = 0;
                else DropDownList11.SelectedIndex = 1;
                if (dr["Offer"].ToString() == "True") DropDownList10.SelectedIndex = 0;
                else DropDownList10.SelectedIndex = 1;
                KeyWord.Text = dr["KeyW"].ToString();
                FindAgency(dr["UserID"].ToString());
            }
            con.Close();
            TableHotel.Visible = true;
            HotelTitle.Visible = true;
            distnationTitle.Visible = true;
            TableBe.Visible = true;
            AdsTable.Visible = true;
            loadHotels();
        }
        catch (Exception exp)
        {
            Label2.Text = exp.Message;
            Label2.ForeColor = Color.Red;
        }
    }

    protected void loadHotels()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            bool flg = false;
            string myQu = "";
            if (DropDownList3.Text != "" && DropDownList3.Text != "نامشخص")
            {
                string[] Data = DropDownList3.Text.Split('-');
                myQu = "Country = " + Data[0].ToString() + " AND ";
                flg = true;
            }
            if (DropDownList1.Text != "" && DropDownList1.Text != "نامشخص")
            {
                string[] Data = DropDownList1.Text.Split('-');
                myQu += "City = " + Data[0].ToString() + " AND ";
                flg = true;
            }
            if (DropDownList4.Text != "" && DropDownList4.Text != "نامشخص")
            {
                string[] Data = DropDownList4.Text.Split('-');
                myQu += "Area = " + Data[0].ToString() + " AND ";
                flg = true;
            }
            if (flg == true)
                myQu = " WHERE " + myQu.Substring(0,myQu.Length-5);
            SqlCommand cmd = new SqlCommand("select ID,Title from Hotel " + myQu + " order by ID", con);
            SqlDataReader dr = null;
            DropDownList6.Items.Clear();
            DropDownList6.Items.Add("");
            DropDownList21.Items.Clear();
            DropDownList21.Items.Add("");
            DropDownList24.Items.Clear();
            DropDownList24.Items.Add("");
            DropDownList27.Items.Clear();
            DropDownList27.Items.Add("");
            DropDownList30.Items.Clear();
            DropDownList30.Items.Add("");
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    DropDownList6.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList21.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList24.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList27.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList30.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
        }
        catch { con.Close(); }
    }

    protected void SetCat(string ID)
    {
        CheckSafe();
        DropDownList5.SelectedIndex = -1;
        for (int i = 0; i < DropDownList5.Items.Count; i++)
        {
            string[] SS = DropDownList5.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                DropDownList5.SelectedIndex = i;
                break;
            }
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
    protected void SetHotel(string ID)
    {
        CheckSafe();
        DropDownList6.SelectedIndex = -1;
        for (int i = 0; i < DropDownList6.Items.Count; i++)
        {
            string[] SS = DropDownList6.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                DropDownList6.SelectedIndex = i;
                break;
            }
        }
    }
    protected void SetHotel2(string ID)
    {
        CheckSafe();
        DropDownList21.SelectedIndex = -1;
        for (int i = 0; i < DropDownList21.Items.Count; i++)
        {
            string[] SS = DropDownList21.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                DropDownList21.SelectedIndex = i;
                break;
            }
        }
    }
    protected void SetHotel3(string ID)
    {
        CheckSafe();
        DropDownList24.SelectedIndex = -1;
        for (int i = 0; i < DropDownList24.Items.Count; i++)
        {
            string[] SS = DropDownList24.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                DropDownList24.SelectedIndex = i;
                break;
            }
        }
    }
    protected void SetHotel4(string ID)
    {
        CheckSafe();
        DropDownList27.SelectedIndex = -1;
        for (int i = 0; i < DropDownList27.Items.Count; i++)
        {
            string[] SS = DropDownList27.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                DropDownList27.SelectedIndex = i;
                break;
            }
        }
    }
    protected void SetHotel5(string ID)
    {
        CheckSafe();
        DropDownList30.SelectedIndex = -1;
        for (int i = 0; i < DropDownList30.Items.Count; i++)
        {
            string[] SS = DropDownList30.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                DropDownList30.SelectedIndex = i;
                break;
            }
        }
    }
    private string FindCountry(string inputID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = DropDownList2.Text.Split('-');
            SqlCommand cmd = new SqlCommand("select Name from Country where id =" + inputID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            string returnValue = "";
            if (dr.HasRows)
            {
                dr.Read();
                returnValue = dr[0].ToString();
            }
            con.Close();
            return returnValue;
        }
        catch (Exception exp)
        {
            Label2.Text = exp.Message;
            Label2.ForeColor = Color.Red;
            return "Error on GetCountryID";
        }
    }
    private string FindCity(string inputID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = DropDownList2.Text.Split('-');
            SqlCommand cmd = new SqlCommand("select Name from City where id =" + inputID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            string returnValue = "";
            if (dr.HasRows)
            {
                dr.Read();
                returnValue = dr[0].ToString();
            }
            con.Close();
            return returnValue;
        }
        catch (Exception exp)
        {
            Label2.Text = exp.Message;
            Label2.ForeColor = Color.Red;
            return "Error on GetCityID";
        }
    }
    private void FindAgency(string inputID)
    {
        CheckSafe();
        //DropDownList15.SelectedIndex = -1;
        for (int i = 1; i < DropDownList15.Items.Count; i++)
        {
            string[] SS = DropDownList15.Items[i].Text.Split('-');
            if (inputID.Trim() == SS[0].Trim())
            {
                DropDownList15.SelectedIndex = i;
                break;
            }
        }
    }
    private string FindArea(string inputID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = DropDownList2.Text.Split('-');
            SqlCommand cmd = new SqlCommand("select Name from Area where id =" + inputID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            string returnValue = "";
            if (dr.HasRows)
            {
                dr.Read();
                returnValue = dr[0].ToString();
            }
            con.Close();
            return returnValue;
        }
        catch (Exception exp)
        {
            Label2.Text = exp.Message;
            Label2.ForeColor = Color.Red;
            return "Error on GetAreaID";
        }
    }


    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.Text.Trim() != "نامشخص")
        {
            LoadCities();
            DropDownList4.Items.Clear();
            DropDownList4.Items.Add("نامشخص");
        }
        else
        {
            DropDownList4.Items.Clear();
            DropDownList4.Items.Add("نامشخص");
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("نامشخص");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text.Trim() != "نامشخص")
        {
            LoadArea();
        }
    }
    private void LoadCities()
    {
        DropDownList1.Items.Clear();
        if (DropDownList3.Text.Trim() != "" && DropDownList3.Text.Trim() != "نامشخص")
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
                DropDownList1.Items.Add("نامشخص");
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
                Label2.Text = exp.Message;
                Label2.ForeColor = Color.Red;
            }
        }
    }
    private void LoadArea()
    {
        DropDownList4.Items.Clear();
        if (DropDownList1.Text.Trim() != "" && DropDownList1.Text.Trim() != "نامشخص")
        {
            if (DropDownList1.Text.Trim() != "")
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    string[] Data = DropDownList1.Text.Split('-');
                    SqlCommand cmd = new SqlCommand("select ID,Name from Area where CityID =" + Data[0], con);
                    SqlDataReader dr = null;
                    con.Open();
                    dr = cmd.ExecuteReader();
                    DropDownList4.Items.Add("نامشخص");
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
                    Label2.Text = exp.Message;
                    Label2.ForeColor = Color.Red;
                }
            }
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand("DELETE FROM TourHotel where ID =" + ID, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.Session["TiID"] = null;
            MessageBox("حذف با موفقیت انجام شد");
        }
        catch (Exception exp)
        {
            Label3.Text = exp.Message;
            Label3.ForeColor = Color.Red;
        }
    }
    private void LoadHotel()
    {

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        e.Cancel = true;
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            sl1.Visible = false;
            sl2.Visible = false;
            sl3.Visible = false;
            sl4.Visible = false;
            sln11.Visible = false;
            sln12.Visible = false;
            sln13.Visible = false;
            sln14.Visible = false;
            sln21.Visible = false;
            sln22.Visible = false;
            sln23.Visible = false;
            sln24.Visible = false;
            sln31.Visible = false;
            sln32.Visible = false;
            sln33.Visible = false;
            sln34.Visible = false;
            sln41.Visible = false;
            sln42.Visible = false;
            sln43.Visible = false;
            sln44.Visible = false;
            DropDownList6.Text = "";
            DropDownList21.Text = "";
            DropDownList24.Text = "";
            DropDownList27.Text = "";
            DropDownList30.Text = "";

            string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand("select HotelID,qeimat1,qeimat2,qeimat3,qeimat4,tozihat,HotelName,HotelStar,Qeimat1P,Qeimat2P,Qeimat3P,Qeimat4P,Qeimat1Pv,Qeimat2Pv,Qeimat3Pv,Qeimat4Pv,HotelKhademat,HotelID2,HotelName2,HotelStar2,HotelKhademat2,HotelID3,HotelName3,HotelStar3,HotelKhademat3,HotelID4,HotelName4,HotelStar4,HotelKhademat4,HotelID5,HotelName5,HotelStar5,HotelKhademat5 from TourHotel where id =" + ID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            Session["TiID"] = ID;
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    SetHotel(dr[0].ToString());
                    sl1.Visible = true;
                    sl4.Visible = true;
                    sl2.Visible = false;
                    sl3.Visible = false;
                }
                else
                {
                    sl1.Visible = false;
                    sl4.Visible = false;
                    sl2.Visible = true;
                    sl3.Visible = true;
                    HotelName.Text = dr[6].ToString();
                    DropDownList9.Text = dr[7].ToString();
                }
                if (dr["HotelID2"].ToString() != "")
                {
                    SetHotel2(dr["HotelID2"].ToString());
                    sln11.Visible = true;
                    sln12.Visible = false;
                    sln13.Visible = false;
                    sln14.Visible = true;
                }
                else if(dr["HotelName2"].ToString() != "")
                {
                    sln11.Visible = false;
                    sln12.Visible = true;
                    sln13.Visible = true;
                    sln14.Visible = true;
                    HotelName2.Text = dr["HotelName2"].ToString();
                    DropDownList22.Text = dr["HotelStar2"].ToString();
                }
                if (dr["HotelID3"].ToString() != "")
                {
                    SetHotel3(dr["HotelID3"].ToString());
                    sln21.Visible = true;
                    sln22.Visible = false;
                    sln23.Visible = false;
                    sln24.Visible = true;
                }
                else if (dr["HotelName3"].ToString() != "")
                {
                    sln21.Visible = false;
                    sln22.Visible = true;
                    sln23.Visible = true;
                    sln24.Visible = true;
                    HotelName3.Text = dr["HotelName3"].ToString();
                    DropDownList25.Text = dr["HotelStar3"].ToString();
                }
                if (dr["HotelID4"].ToString() != "")
                {
                    SetHotel4(dr["HotelID4"].ToString());
                    sln31.Visible = true;
                    sln32.Visible = false;
                    sln33.Visible = false;
                    sln34.Visible = true;
                }
                else if (dr["HotelName4"].ToString() != "")
                {
                    sln31.Visible = false;
                    sln32.Visible = true;
                    sln33.Visible = true;
                    sln34.Visible = true;
                    HotelName4.Text = dr["HotelName4"].ToString();
                    DropDownList28.Text = dr["HotelStar4"].ToString();
                }
                if (dr["HotelID5"].ToString() != "")
                {
                    SetHotel5(dr["HotelID5"].ToString());
                    sln41.Visible = true;
                    sln42.Visible = false;
                    sln43.Visible = false;
                    sln44.Visible = true;
                }
                else if (dr["HotelName5"].ToString() != "")
                {
                    sln41.Visible = false;
                    sln42.Visible = true;
                    sln43.Visible = true;
                    sln44.Visible = true;
                    HotelName5.Text = dr["HotelName5"].ToString();
                    DropDownList31.Text = dr["HotelStar5"].ToString();
                }
                Qeimat1.Text = dr[1].ToString();
                Qeimat2.Text = dr[2].ToString();
                Qeimat3.Text = dr[3].ToString();
                Qeimat4.Text = dr[4].ToString();
                Tozihat.Text = dr[5].ToString().Replace("<br/>", "\n");
                Qeimat1P.Text = dr[8].ToString();
                Qeimat2P.Text = dr[9].ToString();
                Qeimat3P.Text = dr[10].ToString();
                Qeimat4P.Text = dr[11].ToString();
                DropDownList17.Text = dr[12].ToString();
                DropDownList18.Text = dr[13].ToString();
                DropDownList19.Text = dr[14].ToString();
                DropDownList20.Text = dr[15].ToString();
                DropDownList16.Text = dr[16].ToString();
                if(dr["HotelKhademat2"].ToString() != "") DropDownList23.Text = dr["HotelKhademat2"].ToString();
                if (dr["HotelKhademat3"].ToString() != "") DropDownList26.Text = dr["HotelKhademat3"].ToString();
                if (dr["HotelKhademat4"].ToString() != "") DropDownList29.Text = dr["HotelKhademat4"].ToString();
                if (dr["HotelKhademat5"].ToString() != "") DropDownList32.Text = dr["HotelKhademat5"].ToString();
            }
            con.Close();
            Button8.Enabled = true;
            Button7.Enabled = false;
        }
        catch (Exception exp)
        {
            Label3.Text = exp.Message;
            Label3.ForeColor = Color.Red;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        if ((Qeimat1.Text.Trim() != "" || Qeimat1P.Text.Trim() != "") && (Qeimat2.Text != "" || Qeimat2P.Text.Trim() != "") && (Qeimat3.Text != "" || Qeimat3P.Text.Trim() != "") && (Qeimat4.Text != "" || Qeimat4P.Text.Trim() != ""))
        {
            if ((sl1.Visible == true && DropDownList6.Text != "") || (sl1.Visible == false && HotelName.Text.Trim() != ""))
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    string N1 = "";
                    string MyQu = "";
                    N1 = Tozihat.Text.Replace("\n", "<br/>");
                    long CurrentID = 0;
                    if (sl1.Visible == true)
                    {
                        string[] Data = DropDownList6.Text.Split('-');
                        string Vals = CheckNull(Data[0], 0) + " , " + CheckNull(Qeimat1.Text.Replace(",",""), 1) + " , ";
                        Vals += CheckNull(Qeimat2.Text.Replace(",", ""), 1) + " , " + CheckNull(Qeimat3.Text.Replace(",", ""), 1) + " , " + CheckNull(Qeimat4.Text.Replace(",", ""), 1) + " , " + CheckNull(N1, 1) + " , " + Session["TourID"] + " , '" + DropDownList16.Text + "' , " + CheckNull(Qeimat1P.Text.Trim().Replace(",", ""), 1) + " , " + CheckNull(Qeimat2P.Text.Trim().Replace(",", ""), 1) + " , " + CheckNull(Qeimat3P.Text.Trim().Replace(",", ""), 1) + " , " + CheckNull(Qeimat4P.Text.Trim().Replace(",", ""), 1) + " , " + CheckNull(DropDownList17.Text, 1) + " , " + CheckNull(DropDownList18.Text, 1) + " , " + CheckNull(DropDownList19.Text, 1) + " , " + CheckNull(DropDownList20.Text, 1) + ") ; SELECT SCOPE_IDENTITY();";
                        MyQu = "insert into TourHotel (HotelID,qeimat1,qeimat2,qeimat3,qeimat4,tozihat,TourID,HotelKhademat,Qeimat1P,Qeimat2P,Qeimat3P,Qeimat4P,Qeimat1Pv,Qeimat2Pv,Qeimat3Pv,Qeimat4Pv) values(" + Vals;
                    }
                    else
                    {
                        string Vals = CheckNull(HotelName.Text, 1) + " , " + CheckNull(Qeimat1.Text.Replace(",", ""), 1) + " , ";
                        Vals += CheckNull(Qeimat2.Text.Replace(",", ""), 1) + " , " + CheckNull(Qeimat3.Text.Replace(",", ""), 1) + " , " + CheckNull(Qeimat4.Text.Replace(",", ""), 1) + " , " + CheckNull(N1, 1) + " , " + Session["TourID"] + " , " + DropDownList9.Text + " , '" + DropDownList16.Text + "' , " + CheckNull(Qeimat1P.Text.Trim().Replace(",", ""), 1) + " , " + CheckNull(Qeimat2P.Text.Trim().Replace(",", ""), 1) + " , " + CheckNull(Qeimat3P.Text.Trim().Replace(",", ""), 1) + " , " + CheckNull(Qeimat4P.Text.Trim().Replace(",", ""), 1) + " , " + CheckNull(DropDownList17.Text, 1) + " , " + CheckNull(DropDownList18.Text, 1) + " , " + CheckNull(DropDownList19.Text, 1) + " , " + CheckNull(DropDownList20.Text, 1) + "); SELECT SCOPE_IDENTITY();";
                        MyQu = "insert into TourHotel (HotelName,qeimat1,qeimat2,qeimat3,qeimat4,tozihat,TourID,HotelStar,HotelKhademat,Qeimat1P,Qeimat2P,Qeimat3P,Qeimat4P,Qeimat1Pv,Qeimat2Pv,Qeimat3Pv,Qeimat4Pv) values(" + Vals;
                    }
                    SqlCommand cmd = new SqlCommand(MyQu, con);
                    con.Open();
                    CurrentID = Convert.ToInt64(cmd.ExecuteScalar());
                    con.Close();
                    MyQu="";
                    if (sln11.Visible == true && DropDownList21.Text != "")
                    {
                        string[] Data = DropDownList21.Text.Split('-');
                        MyQu += " HotelID2 = " + Data[0].ToString() + " , HotelKhademat2 = " + CheckNull(DropDownList23.Text, 1) + " , ";
                    }
                    else if (sln12.Visible == true && HotelName2.Text.Trim() != "")
                    {
                        MyQu += " HotelName2 = " + CheckNull(HotelName2.Text, 1) + " , HotelStar2 = " + DropDownList22.Text + " , HotelKhademat2 = " + CheckNull(DropDownList23.Text, 1) + " , ";
                    }
                    if (sln21.Visible == true && DropDownList24.Text != "")
                    {
                        string[] Data = DropDownList24.Text.Split('-');
                        MyQu += " HotelID3 = " + Data[0].ToString() + " , HotelKhademat3 = " + CheckNull(DropDownList26.Text, 1) + " , ";
                    }
                    else if (sln22.Visible == true && HotelName3.Text.Trim() != "")
                    {
                        MyQu += " HotelName3 = " + CheckNull(HotelName3.Text, 1) + " , HotelStar3 = " + DropDownList25.Text + " , HotelKhademat3 = " + CheckNull(DropDownList26.Text, 1) + " , ";
                    }
                    if (sln31.Visible == true && DropDownList27.Text != "")
                    {
                        string[] Data = DropDownList27.Text.Split('-');
                        MyQu += " HotelID4 = " + Data[0].ToString() + " , HotelKhademat4 = " + CheckNull(DropDownList29.Text, 1) + " , ";
                    }
                    else if (sln32.Visible == true && HotelName4.Text.Trim() != "")
                    {
                        MyQu += " HotelName4 = " + CheckNull(HotelName4.Text, 1) + " , HotelStar4 = " + DropDownList28.Text + " , HotelKhademat4 = " + CheckNull(DropDownList29.Text, 1) + " , ";
                    }
                    if (sln41.Visible == true && DropDownList30.Text != "")
                    {
                        string[] Data = DropDownList30.Text.Split('-');
                        MyQu += " HotelID5 = " + Data[0].ToString() + " , HotelKhademat5 = " + CheckNull(DropDownList32.Text, 1) + " , ";
                    }
                    else if (sln42.Visible == true && HotelName5.Text.Trim() != "")
                    {
                        MyQu += " HotelName5 = " + CheckNull(HotelName5.Text, 1) + " , HotelStar5 = " + DropDownList31.Text + " , HotelKhademat5 = " + CheckNull(DropDownList32.Text, 1) + " , ";
                    }
                    if (MyQu.Trim() != "")
                    {
                        MyQu = "Update TourHotel Set " + MyQu.Substring(0, MyQu.Length - 2) + " WHERE ID = " + CurrentID.ToString();
                        cmd.CommandText = MyQu;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    Label3.Text = "هتل با موفقیت اضافه شد";
                    Label3.ForeColor = Color.Green;
                    GridView1.DataBind();
                    Qeimat1.Text = "";
                    Qeimat2.Text = "";
                    Qeimat3.Text = "";
                    Qeimat4.Text = "";
                    Tozihat.Text = "";
                    Qeimat1P.Text = "";
                    Qeimat2P.Text = "";
                    Qeimat3P.Text = "";
                    Qeimat4P.Text = "";
                    HotelName.Text = "";
                    HotelName2.Text = "";
                    HotelName3.Text = "";
                    HotelName4.Text = "";
                    sln11.Visible = false;
                    sln12.Visible = false;
                    sln13.Visible = false;
                    sln14.Visible = false;

                    sln21.Visible = false;
                    sln22.Visible = false;
                    sln23.Visible = false;
                    sln24.Visible = false;

                    sln31.Visible = false;
                    sln32.Visible = false;
                    sln33.Visible = false;
                    sln34.Visible = false;

                    sln41.Visible = false;
                    sln42.Visible = false;
                    sln43.Visible = false;
                    sln44.Visible = false;

                }
                catch (Exception exp)
                {
                    Label3.Text = exp.Message;
                    Label3.ForeColor = Color.Red;
                }
            }
            else
            {
                Label3.Text = "لطفا مقادیر را کامل وارد کنید";
                Label3.ForeColor = Color.Red;
            }
        }
        else
        {
            Label3.Text = "لطفا مقادیر را کامل وارد کنید";
            Label3.ForeColor = Color.Red;
        }
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        if ((Qeimat1.Text.Trim() != "" || Qeimat1P.Text.Trim() != "") && (Qeimat2.Text != "" || Qeimat2P.Text.Trim() != "") && (Qeimat3.Text != "" || Qeimat3P.Text.Trim() != "") && (Qeimat4.Text != "" || Qeimat4P.Text.Trim() != ""))
        {
            if ((sl1.Visible == true && DropDownList6.Text != "") || (sl1.Visible == false && HotelName.Text.Trim() != ""))
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    string N1 = "";
                    N1 = Tozihat.Text.Replace("\n", "<br/>");
                    string Vals = "";
                    if (sl1.Visible == true)
                    {
                        string[] Data = DropDownList6.Text.Split('-');
                        Vals = "Update TourHotel Set HotelKhademat = '" + DropDownList16.Text + "' , hotelID =" + CheckNull(Data[0], 0) + " , qeimat1=" + CheckNull(Qeimat1.Text.Replace(",", ""), 1);
                        Vals += " , Qeimat1P = " + CheckNull(Qeimat1P.Text.Trim().Replace(",", ""), 1) + " , Qeimat2P = " + CheckNull(Qeimat2P.Text.Trim().Replace(",", ""), 1) + " , Qeimat3P = " + CheckNull(Qeimat3P.Text.Trim().Replace(",", ""), 1) + " , Qeimat4P = " + CheckNull(Qeimat4P.Text.Trim().Replace(",", ""), 1);
                        Vals += " , Qeimat1Pv = " + CheckNull(DropDownList17.Text.Trim(), 1) + " , Qeimat2Pv = " + CheckNull(DropDownList18.Text.Trim(), 1) + " , Qeimat3Pv = " + CheckNull(DropDownList19.Text.Trim(), 1) + " , Qeimat4Pv = " + CheckNull(DropDownList20.Text.Trim(), 1);
                        Vals += " , qeimat2 = " + CheckNull(Qeimat2.Text.Replace(",", ""), 1) + " , qeimat3 = " + CheckNull(Qeimat3.Text.Replace(",", ""), 1) + " , qeimat4 = " + CheckNull(Qeimat4.Text.Replace(",", ""), 1) + " , tozihat = " + CheckNull(N1, 1) + " WHERE  ID = " + Session["TiID"];
                    }
                    else
                    {
                        Vals = "Update TourHotel Set HotelKhademat = '" + DropDownList16.Text + "' , HotelID = NULL , HotelName =" + CheckNull(HotelName.Text, 1) + " , qeimat1=" + CheckNull(Qeimat1.Text.Replace(",", ""), 1);
                        Vals += " , Qeimat1P = " + CheckNull(Qeimat1P.Text.Trim().Replace(",", ""), 1) + " , Qeimat2P = " + CheckNull(Qeimat2P.Text.Trim().Replace(",", ""), 1) + " , Qeimat3P = " + CheckNull(Qeimat3P.Text.Trim().Replace(",", ""), 1) + " , Qeimat4P = " + CheckNull(Qeimat4P.Text.Trim().Replace(",", ""), 1);
                        Vals += " , Qeimat1Pv = " + CheckNull(DropDownList17.Text.Trim(), 1) + " , Qeimat2Pv = " + CheckNull(DropDownList18.Text.Trim(), 1) + " , Qeimat3Pv = " + CheckNull(DropDownList19.Text.Trim(), 1) + " , Qeimat4Pv = " + CheckNull(DropDownList20.Text.Trim(), 1);
                        Vals += " , qeimat2 = " + CheckNull(Qeimat2.Text.Replace(",", ""), 1) + " , qeimat3 = " + CheckNull(Qeimat3.Text.Replace(",", ""), 1) + " , qeimat4 = " + CheckNull(Qeimat4.Text.Replace(",", ""), 1) + " , tozihat = " + CheckNull(N1, 1) + " , HotelStar = " + CheckNull(DropDownList9.Text, 1) + " WHERE  ID = " + Session["TiID"];
                    }
                    string MyQu = Vals;
                    SqlCommand cmd = new SqlCommand(MyQu, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MyQu = "";
                    if (sln11.Visible == true && DropDownList21.Text != "")
                    {
                        string[] Data = DropDownList21.Text.Split('-');
                        MyQu += " HotelID2 = " + Data[0].ToString() + " , HotelKhademat2 = " + CheckNull(DropDownList23.Text, 1) + " , ";
                    }
                    else if (sln12.Visible == true && HotelName2.Text.Trim() != "")
                    {
                        MyQu += " HotelName2 = " + CheckNull(HotelName2.Text, 1) + " , HotelStar2 = " + DropDownList22.Text + " , HotelKhademat2 = " + CheckNull(DropDownList23.Text, 1) + " , ";
                    }
                    if (sln21.Visible == true && DropDownList24.Text != "")
                    {
                        string[] Data = DropDownList24.Text.Split('-');
                        MyQu += " HotelID3 = " + Data[0].ToString() + " , HotelKhademat3 = " + CheckNull(DropDownList26.Text, 1) + " , ";
                    }
                    else if (sln22.Visible == true && HotelName3.Text.Trim() != "")
                    {
                        MyQu += " HotelName3 = " + CheckNull(HotelName3.Text, 1) + " , HotelStar3 = " + DropDownList25.Text + " , HotelKhademat3 = " + CheckNull(DropDownList26.Text, 1) + " , ";
                    }
                    if (sln31.Visible == true && DropDownList27.Text != "")
                    {
                        string[] Data = DropDownList27.Text.Split('-');
                        MyQu += " HotelID4 = " + Data[0].ToString() + " , HotelKhademat4 = " + CheckNull(DropDownList29.Text, 1) + " , ";
                    }
                    else if (sln32.Visible == true && HotelName4.Text.Trim() != "")
                    {
                        MyQu += " HotelName4 = " + CheckNull(HotelName4.Text, 1) + " , HotelStar4 = " + DropDownList28.Text + " , HotelKhademat4 = " + CheckNull(DropDownList29.Text, 1) + " , ";
                    }
                    if (sln41.Visible == true && DropDownList30.Text != "")
                    {
                        string[] Data = DropDownList30.Text.Split('-');
                        MyQu += " HotelID5 = " + Data[0].ToString() + " , HotelKhademat5 = " + CheckNull(DropDownList32.Text, 1) + " , ";
                    }
                    else if (sln42.Visible == true && HotelName5.Text.Trim() != "")
                    {
                        MyQu += " HotelName5 = " + CheckNull(HotelName5.Text, 1) + " , HotelStar5 = " + DropDownList31.Text + " , HotelKhademat5 = " + CheckNull(DropDownList32.Text, 1) + " , ";
                    }
                    if (MyQu.Trim() != "")
                    {
                        MyQu = "Update TourHotel Set " + MyQu.Substring(0, MyQu.Length - 2) + " WHERE ID = " + Session["TiID"];
                        cmd.CommandText = MyQu;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    Label3.Text = "هتل تور با موفقیت ویرایش شد";
                    Label3.ForeColor = Color.Green;
                    GridView1.DataBind();
                    Button8.Enabled = false;
                    Button7.Enabled = true;
                    Qeimat1.Text = "";
                    Qeimat2.Text = "";
                    Qeimat3.Text = "";
                    Qeimat4.Text = "";
                    Tozihat.Text = "";
                    Qeimat1P.Text = "";
                    Qeimat2P.Text = "";
                    Qeimat3P.Text = "";
                    Qeimat4P.Text = "";
                    HotelName.Text = "";
                    HotelName2.Text = "";
                    HotelName3.Text = "";
                    HotelName4.Text = "";
                    sln11.Visible = false;
                    sln12.Visible = false;
                    sln13.Visible = false;
                    sln14.Visible = false;

                    sln21.Visible = false;
                    sln22.Visible = false;
                    sln23.Visible = false;
                    sln24.Visible = false;

                    sln31.Visible = false;
                    sln32.Visible = false;
                    sln33.Visible = false;
                    sln34.Visible = false;

                    sln41.Visible = false;
                    sln42.Visible = false;
                    sln43.Visible = false;
                    sln44.Visible = false;
                }
                catch (Exception exp)
                {
                    Label3.Text = exp.Message;
                    Label3.ForeColor = Color.Red;
                }
            }
            else
            {
                Label3.Text = "لطفا مقادیر را کامل وارد کنید";
                Label3.ForeColor = Color.Red;
            }
        }
        else
        {
            Label3.Text = "لطفا مقادیر را کامل وارد کنید";
            Label3.ForeColor = Color.Red;
        }
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string ID = GridView2.DataKeys[e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand("DELETE FROM beTB where ID =" + ID, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.Session["beID"] = null;
            MessageBox("حذف با موفقیت انجام شد");
        }
        catch (Exception exp)
        {
            Label4.Text = exp.Message;
            Label4.ForeColor = Color.Red;
        }
    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        e.Cancel = true;
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string ID = GridView2.DataKeys[e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand("select nam,modat,tozihat from beTB where id =" + ID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            Session["beID"] = ID;
            while (dr.Read())
            {
                Distn.Text = dr[0].ToString();
                modateq.Text = dr[1].ToString();
                Tozzih.Text = dr[2].ToString().Replace("<br/>", "\n");
            }
            con.Close();
            Button10.Enabled = true;
            Button9.Enabled = false;
        }
        catch (Exception exp)
        {
            Label4.Text = exp.Message;
            Label4.ForeColor = Color.Red;
        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        if (modateq.Text.Trim() != "" && Distn.Text.Trim() != "" )
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string N1 = "";
                N1 = Tozzih.Text.Replace("\n", "<br/>");
                string Vals = CheckNull(Distn.Text, 1) + " , " + CheckNull(modateq.Text, 1) + " , " + CheckNull(N1, 1);
                Vals += " , " + Session["TourID"] + ")";
                string MyQu = "insert into beTB (nam,modat,tozihat,TourID) values(" + Vals;
                SqlCommand cmd = new SqlCommand(MyQu, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label4.Text = "مقصد با موفقیت اضافه شد";
                Label4.ForeColor = Color.Green;
                GridView2.DataBind();
            }
            catch (Exception exp)
            {
                Label4.Text = exp.Message;
                Label4.ForeColor = Color.Red;
            }
        }
        else
        {
            Label4.Text = "لطفا مقادیر را کامل پر کنید";
            Label4.ForeColor = Color.Red;
        }
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        if (modateq.Text.Trim() != "" && Distn.Text.Trim() != "" )
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string N1 = "";
                N1 = Tozzih.Text.Replace("\n", "<br/>");
                string Vals = "Update beTB Set nam =" + CheckNull(Distn.Text, 1) + " , modat = " + CheckNull(modateq.Text, 1) + " , tozihat=" + CheckNull(N1, 1) + " WHERE  ID = " + Session["beID"];
                string MyQu = Vals;
                SqlCommand cmd = new SqlCommand(MyQu, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label4.Text = "مقصد با موفقیت ویرایش شد";
                Label4.ForeColor = Color.Green;
                GridView2.DataBind();
                Button10.Enabled = false;
                Button9.Enabled = true;
                Distn.Text = "";
                modateq.Text = "";
                Tozzih.Text = "";
            }
            catch (Exception exp)
            {
                Label4.Text = exp.Message;
                Label4.ForeColor = Color.Red;
            }
        }
        else
        {
            Label4.Text = "لطفا مقادیر را کامل پر کنید";
            Label4.ForeColor = Color.Red;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox9.Text.Trim() != "" || FileUpload1.HasFile)
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
                    TextBox9.Text = "/IMG/" + time;
                    FileUpload1.SaveAs(p);
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                    img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                    img1.Save(MapPath("~/IMG/th/") + time);
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string Query = "";
                Query = "UPDATE TourBase Set TourICO = " + CheckNull(TextBox9.Text.Trim(), 1) + " , ADS = " + CheckNull(DropDownList7.SelectedIndex.ToString(), 0) + " WHERE ID = " + Session["TourID"].ToString();
                cmd.CommandText = Query;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "عملیات با موفقیت انجام شد";
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
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        sl1.Visible = false;
        sl4.Visible = false;
        sl2.Visible = true;
        sl3.Visible = true;
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        sl1.Visible = true;
        sl4.Visible = true;
        sl2.Visible = false;
        sl3.Visible = false;
    }
    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Session["TourID"] = GridView3.Rows[e.RowIndex].Cells[0].Text.ToString();
        ShowCountryItem();
        Button4.Enabled = true;
        Button5.Enabled = true;
        Button3.Enabled = false;
        //TextBox tbox = this.Form1.FindControl("TextBox1") as TextBox;
        //Session["Pointer"] = "1000";
    //    StringBuilder sb = new StringBuilder();
    //    sb.Append("<script type='text/javascript'>");
    //    sb.Append("MoveToN(1000)");
    //    sb.Append("</script>");
    //    Random r = new Random();
    //    MTC = r.Next(1, 1000);

    //    ClientScript.RegisterStartupScript(this.GetType(), "JSScript", sb.ToString()); 
    }
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView3_PageIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        FillGridView();
    }
    protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList13_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadShahr();
    }
    protected string FixDate(string InputValue)
    {
        string returnValue = "";
        string[] Data = InputValue.Split('/');
        string sal = Data[0];
        string mah = Data[1];
        string roz = Data[2];
        if (mah.Length == 1) mah = "0" + Data[1];
        if (roz.Length == 1) roz = "0" + Data[2];
        returnValue = Data[0] + "/" + mah + "/" + roz;
        return returnValue;
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
        int sal = pc.GetYear(dt);
        int mah = pc.GetMonth(dt);
        int roz = pc.GetDayOfMonth(dt);
        string M, R;
        if (mah < 10) M = "0" + mah.ToString();
        else M = mah.ToString();
        if (roz < 10) R = "0" + roz.ToString();
        else R = roz.ToString();
        string CurrentDate = sal.ToString() + M + R;
        //e.Row.Cells[5].Text = FixDate(e.Row.Cells[5].Text);
        if (e.Row.RowIndex != -1)
        {
            if (Convert.ToInt32(FixDate(e.Row.Cells[6].Text).Replace("/","")) < Convert.ToInt32(CurrentDate))
            {
                e.Row.Cells[6].Text = "به اتمام رسیده";
                e.Row.Cells[6].CssClass = "TaedNashode";
            }
            else
            {
                e.Row.Cells[6].Text = "فعال";
                e.Row.Cells[6].CssClass = "TaedShode";
            }
        }
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        if (sln11.Visible == false && sln14.Visible==false)
        {
            sln11.Visible = true;
            sln14.Visible = true;
        }
        else if (sln21.Visible == false && sln24.Visible==false)
        {
            sln21.Visible = true;
            sln24.Visible = true;
        }
        else if (sln31.Visible == false && sln34.Visible == false)
        {
            sln31.Visible = true;
            sln34.Visible = true;
        }
        else if (sln41.Visible == false && sln44.Visible == false)
        {
            sln41.Visible = true;
            sln44.Visible = true;
        }
        else
        {
            Label3.Text = "امکان درج هتل های بیشتر مقدور نمی باشد";
            Label3.ForeColor = Color.Red;
        }

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        sln11.Visible = false;
        sln12.Visible = true;
        sln13.Visible = true;
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        sln21.Visible = false;
        sln22.Visible = true;
        sln23.Visible = true;
    }
    protected void Button19_Click(object sender, EventArgs e)
    {
        sln31.Visible = false;
        sln32.Visible = true;
        sln33.Visible = true;
    }
    protected void Button22_Click(object sender, EventArgs e)
    {
        sln41.Visible = false;
        sln42.Visible = true;
        sln43.Visible = true;
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        sln11.Visible = true;
        sln12.Visible = false;
        sln13.Visible = false;
    }
    protected void Button18_Click(object sender, EventArgs e)
    {
        sln21.Visible = true;
        sln22.Visible = false;
        sln23.Visible = false;
    }
    protected void Button21_Click(object sender, EventArgs e)
    {
        sln31.Visible = true;
        sln32.Visible = false;
        sln33.Visible = false;
    }
    protected void Button24_Click(object sender, EventArgs e)
    {
        sln41.Visible = true;
        sln42.Visible = false;
        sln43.Visible = false;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells.Count > 1)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string HotelLists = e.Row.Cells[1].Text.Trim();
                if (e.Row.Cells[2].Text.Trim() != "" && e.Row.Cells[2].Text.Trim() != "&nbsp;") HotelLists += "<br />" + e.Row.Cells[2].Text.Trim();
                if (e.Row.Cells[3].Text.Trim() != "" && e.Row.Cells[3].Text.Trim() != "&nbsp;") HotelLists += "<br />" + e.Row.Cells[3].Text.Trim();
                if (e.Row.Cells[4].Text.Trim() != "" && e.Row.Cells[4].Text.Trim() != "&nbsp;") HotelLists += "<br />" + e.Row.Cells[4].Text.Trim();
                if (e.Row.Cells[5].Text.Trim() != "" && e.Row.Cells[5].Text.Trim() != "&nbsp;") HotelLists += "<br />" + e.Row.Cells[5].Text.Trim();
                string decodedText = HttpUtility.HtmlDecode(HotelLists);
                e.Row.Cells[1].Text = decodedText;
                decodedText = HttpUtility.HtmlDecode(e.Row.Cells[11].Text).Replace("-", " ");
                e.Row.Cells[11].Text = decodedText;
            }
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
        }
    }
    protected void DropDownList33_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList33.Text.Trim() != "" && DropDownList33.Text.Trim() != "نامشخص")
        {
            string[] Data = DropDownList33.Text.Split('-');
            LoadHotelSforCountries(DropDownList21, Data[0]);
        }
    }
    protected void DropDownList34_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList34.Text.Trim() != "" && DropDownList34.Text.Trim() != "نامشخص")
        {
            string[] Data = DropDownList34.Text.Split('-');
            LoadHotelSforCountries(DropDownList24, Data[0]);
        }
    }
    protected void DropDownList35_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList35.Text.Trim() != "" && DropDownList35.Text.Trim() != "نامشخص")
        {
            string[] Data = DropDownList35.Text.Split('-');
            LoadHotelSforCountries(DropDownList27, Data[0]);
        }
    }
    protected void DropDownList36_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList36.Text.Trim() != "" && DropDownList36.Text.Trim() != "نامشخص")
        {
            string[] Data = DropDownList36.Text.Split('-');
            LoadHotelSforCountries(DropDownList30, Data[0]);
        }
    }
}