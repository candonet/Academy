using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class test : System.Web.UI.Page
{
    public string TourCatID = "";
    public string CountryID = "";
    public string CityID = "";
    public string AreaID = "";
    protected string LoadMyQueries()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            var NN = Request.Url.AbsoluteUri.ToString();
            string[] NNN = NN.Split('/');
            string v = "";
            if (NNN.Length > 3)
                for (int i = 3; i < NNN.Length; i++)
                    v += "/" + HttpUtility.UrlDecode(NNN[i]);
            SqlCommand cmd = new SqlCommand("select URL FROM MenuList WHERE MenuProfile like N'" + v + "'", con);
            SqlDataReader dr = null;
            con.Open();
            string CurrentURL = "";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                CurrentURL = dr[0].ToString();
            }
            con.Close();
            return NNN[0] + "//" + NNN[2] + "?" + CurrentURL;
        }
        catch (Exception exp)
        {
            return "";
        }
        finally
        {
            con.Close();
        }
    }
    protected void LoadSlides()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 9", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr[0].ToString() == "False")
                    {
                        HtmlGenericControl divMaster1 = (HtmlGenericControl)this.Master.FindControl("page1");
                        divMaster1.Visible = false;
                    }
                    if (dr[1].ToString() == "False")
                    {
                        HtmlGenericControl divMaster2 = (HtmlGenericControl)this.Master.FindControl("HorSlide");
                        divMaster2.Visible = false;
                    }
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {

        }
        finally
        {
            con.Close();
        }
    }

    protected string GetCountryName(string CountryIDn)
    {
        string ReturnValue = "";
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Name From Country WHERE ID = " + CountryIDn, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            bool flg = false;
            if (dr.HasRows)
            {
                dr.Read();
                ReturnValue = dr[0].ToString();
            }
        }
        catch { }
        finally
        {
            con.Close();
        }
        return ReturnValue;
    }
    protected string GetCityName(string CityIDn)
    {
        string ReturnValue = "";
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Name From City WHERE ID = " + CityIDn, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            bool flg = false;
            if (dr.HasRows)
            {
                dr.Read();
                ReturnValue = dr[0].ToString();
            }
        }
        catch { }
        finally
        {
            con.Close();
        }
        return ReturnValue;
    }
    protected string GetAreaName(string AreaIDn)
    {
        string ReturnValue = "";
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Name From Area WHERE ID = " + AreaIDn, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            bool flg = false;
            if (dr.HasRows)
            {
                dr.Read();
                ReturnValue = dr[0].ToString();
            }
        }
        catch { }
        finally
        {
            con.Close();
        }
        return ReturnValue;
    }
    protected string GetTourName(string TourCatIDn)
    {
        string ReturnValue = "";
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select TourCat.TourCat From TourCat WHERE ID = " + TourCatIDn, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            bool flg = false;
            if (dr.HasRows)
            {
                dr.Read();
                ReturnValue = dr[0].ToString();
            }
        }
        catch { }
        finally
        {
            con.Close();
        }
        return ReturnValue;
    }
    protected void LoadTour(string CurrentURL)
    {
        Uri myUri = new Uri(CurrentURL.Trim());
        string TourCatID = HttpUtility.ParseQueryString(myUri.Query).Get("TourCat");
        string CountryID = HttpUtility.ParseQueryString(myUri.Query).Get("Country");
        string CityID = HttpUtility.ParseQueryString(myUri.Query).Get("City");
        string AreaID = HttpUtility.ParseQueryString(myUri.Query).Get("Area");
        if ((TourCatID != null && TourCatID != "") || (CountryID != "" && CountryID != "") || (CityID != "" && CityID != "") || (AreaID != "" && AreaID != ""))
        {
            try
            {
                bool flg = false;
                string TourCatName = GetTourName(TourCatID);
                string CountryName = GetCountryName(CountryID);
                string CityName = GetCityName(CityID);
                string AreaName = GetAreaName(AreaID);
                string ChoosenTitle = "";
                
                
                
                if (TourCatName.Trim() != "") { ChoosenTitle = TourCatName; }
                if (CountryName.Trim() != "") ChoosenTitle += " » " + " تور " + CountryName;
                if (CityName.Trim() != "") ChoosenTitle += " » " + " تور " + CityName;
                if (AreaName.Trim() != "") ChoosenTitle += " » " + " تور " + AreaName;
                if (ChoosenTitle.Trim() != "")
                {
                    //if (flg == false)
                    //{
                    //    this.Title = "تور های " + ChoosenTitle;
                    //    TitleTour.InnerHtml = "تور های " + ChoosenTitle;
                    //}
                    //else
                    //{
                        this.Title = ChoosenTitle;
                        TitleTour.InnerHtml = ChoosenTitle;
                    //}
                }
                else
                {
                    TitleTour.InnerHtml = "خطا";
                    BodyTour.InnerHtml = "متاسفانه تور مورد نظر یافت نشد";
                }
            }
            catch (Exception exp)
            {
                TitleTour.InnerHtml = "خطا";

            }
        }
        else
        {
            TitleTour.InnerHtml = "خطا";
            BodyTour.InnerHtml = "صفحه مورد نظر یافت نشد";
        }
    }

    protected void az(string CurrentURL)
    {
        Uri myUri = new Uri(CurrentURL);
        string TourCatID = HttpUtility.ParseQueryString(myUri.Query).Get("TourCat");
        string CountryID = HttpUtility.ParseQueryString(myUri.Query).Get("Country");
        string CityID = HttpUtility.ParseQueryString(myUri.Query).Get("City");
        string AreaID = HttpUtility.ParseQueryString(myUri.Query).Get("Area");
        //string TourCatID = Request.QueryString["TourCat"];
        //string CountryID = Request.QueryString["Country"];
        //string CityID = Request.QueryString["City"];
        //string AreaID = Request.QueryString["Area"];
        if (TourCatID != null)
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string myQu = "TourCatID =" + TourCatID;
                if (CountryID != null && CountryID != "")
                    myQu += " AND keshvar = " + CountryID;
                if (CityID != null && CityID != "")
                    myQu += " AND tourbase.shahr = " + CityID;
                if (AreaID != null && AreaID != "")
                    myQu += " AND nahie = " + AreaID;
                SqlCommand cmd = new SqlCommand("select az from TourBase where " + myQu + " Group by az", con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("تمام شهرها");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList1.Items.Add(dr[0].ToString());
                    }
                }
                con.Close();
            }
            catch (Exception exp)
            {

            }
            finally
            {
                con.Close();
            }
        }
        else
        {

        }
    }

    protected void Modat(string CurrentURL)
    {
        Uri myUri = new Uri(CurrentURL);
        string TourCatID = HttpUtility.ParseQueryString(myUri.Query).Get("TourCat");
        string CountryID = HttpUtility.ParseQueryString(myUri.Query).Get("Country");
        string CityID = HttpUtility.ParseQueryString(myUri.Query).Get("City");
        string AreaID = HttpUtility.ParseQueryString(myUri.Query).Get("Area");
        //string TourCatID = Request.QueryString["TourCat"];
        //string CountryID = Request.QueryString["Country"];
        //string CityID = Request.QueryString["City"];
        //string AreaID = Request.QueryString["Area"];
        if (TourCatID != null)
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string myQu = "TourCatID =" + TourCatID;
                if (CountryID != null && CountryID != "")
                    myQu += " AND keshvar = " + CountryID;
                if (CityID != null && CityID != "")
                    myQu += " AND tourbase.shahr = " + CityID;
                if (AreaID != null && AreaID != "")
                    myQu += " AND nahie = " + AreaID;
                SqlCommand cmd = new SqlCommand("select modat from TourBase where " + myQu + " Group by modat", con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                DropDownList3.Items.Clear();
                DropDownList3.Items.Add("تمامی موارد");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList3.Items.Add(dr[0].ToString());
                    }
                }
                con.Close();
            }
            catch (Exception exp)
            {

            }
            finally
            {
                con.Close();
            }
        }
        else
        {

        }
    }

    protected void LoadAgencies(string CurrentURL)
    {
        Uri myUri = new Uri(CurrentURL);
        string TourCatID = HttpUtility.ParseQueryString(myUri.Query).Get("TourCat");
        string CountryID = HttpUtility.ParseQueryString(myUri.Query).Get("Country");
        string CityID = HttpUtility.ParseQueryString(myUri.Query).Get("City");
        string AreaID = HttpUtility.ParseQueryString(myUri.Query).Get("Area");
        //string TourCatID = Request.QueryString["TourCat"];
        //string CountryID = Request.QueryString["Country"];
        //string CityID = Request.QueryString["City"];
        //string AreaID = Request.QueryString["Area"];
        if (TourCatID != null)
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string myQu = "TourCatID =" + TourCatID;
                if (CountryID != null && CountryID != "")
                    myQu += " AND keshvar = " + CountryID;
                if (CityID != null && CityID != "")
                    myQu += " AND tourbase.shahr = " + CityID;
                if (AreaID != null && AreaID != "")
                    myQu += " AND nahie = " + AreaID;
                SqlCommand cmd = new SqlCommand("select nam from AgencyDetail,Members where  Members.ID = AgencyDetail.UserID and Members.ID in (select UserID from TourBase where " + myQu + ")", con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add("تمام آژانس ها");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList2.Items.Add(dr[0].ToString());
                    }
                }
                con.Close();
            }
            catch (Exception exp)
            {

            }
            finally
            {
                con.Close();
            }
        }
        else
        {

        }
    }
    protected string GetUserID(string inputValue)
    {
        string returnValue = "";
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Members.ID from Members,AgencyDetail where AgencyDetail.UserID = Members.ID and AgencyDetail.nam like N'"+ inputValue + "'", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                returnValue = dr[0].ToString();
            }
            con.Close();
        }
        catch { con.Close(); return "0"; }
        finally
        {
            con.Close();
        }
        return returnValue;
    }

    protected void FillDataGrid(string CurrentURL)
    {
        Uri myUri = new Uri(CurrentURL);
        string TourCatID = HttpUtility.ParseQueryString(myUri.Query).Get("TourCat");
        string CountryID = HttpUtility.ParseQueryString(myUri.Query).Get("Country");
        string CityID = HttpUtility.ParseQueryString(myUri.Query).Get("City");
        string AreaID = HttpUtility.ParseQueryString(myUri.Query).Get("Area");
        //string TourCatID = Request.QueryString["TourCat"];
        //string CountryID = Request.QueryString["Country"];
        //string CityID = Request.QueryString["City"];
        //string AreaID = Request.QueryString["Area"];
        if (TourCatID != null)
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string myQu = "TourCatID =" + TourCatID;
                if (CountryID != null && CountryID != "")
                    myQu += " AND keshvar = " + CountryID;
                if (CityID != null && CityID != "")
                    myQu += " AND tourbase.shahr = " + CityID;
                if (AreaID != null && AreaID != "")
                    myQu += " AND nahie = " + AreaID;
                if (DropDownList1.Text.Trim() != "تمام شهرها" && DropDownList1.Text.Trim() != "")
                    myQu += " AND az like N'" + DropDownList1.Text.Trim() + "'";
                if (DropDownList3.Text.Trim() != "تمامی موارد" && DropDownList3.Text.Trim() != "")
                    myQu += " AND modat like N'" + DropDownList3.Text.Trim() + "'";
                if (DropDownList2.Text.Trim() != "تمام آژانس ها" && DropDownList2.Text.Trim() != "")
                {
                    string AgencyID = GetUserID(DropDownList2.Text);
                    myQu += " AND TourBase.UserID = " + AgencyID ;
                }
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                SqlCommand cmd = new SqlCommand("select TourBase.nam , modat , tarikh1,tarikh2,kind,AgencyDetail.nam,TourBase.ID,(select MIN(CAST(LEFT(qeimat1, Patindex('%[^-.0-9]%', qeimat1 + 'x') - 1) AS Float)) from TourHotel Where TourID = TourBase.ID) as AB3,TourProfile,Qeimat1P,Qeimat1Pv From TourBase,AgencyDetail,TourHotel WHERE AgencyDetail.UserID = TourBase.UserID AND " + myQu + " AND TourHotel.ID in (select top 1 ID from TourHotel where TourBase.ID=TourHotel.TourID) and Tarikh2 > '" + GetCDATE() + "' order by TourBase.ID desc", con);
                dt.Columns.Add("عنوان", typeof(string));
                dt.Columns.Add("قیمت از", typeof(string));
                dt.Columns.Add("مدت اقامت", typeof(string));
                dt.Columns.Add("تاریخ", typeof(string));
                dt.Columns.Add("نوع سفر", typeof(string));
                dt.Columns.Add("آژانس", typeof(string));
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("TourProfile", typeof(string));
                dt.Columns.Add("qeimat1p", typeof(string));
                dt.Columns.Add("qeimat1pv", typeof(string));
                dt.Columns.Add("Tarikh2", typeof(string));
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DataRow NewRow = dt.NewRow();
                        NewRow[0] = dr[0].ToString();
                        NewRow[2] = dr[1].ToString();
                        NewRow[3] = getMonthName(dr[2].ToString()) + " الی " + getMonthName(dr[3].ToString());
                        NewRow[4] = dr[4].ToString();
                        NewRow[5] = dr[5].ToString();
                        NewRow[6] = dr[6].ToString();
                        NewRow[1] = dr[7].ToString();
                        NewRow[7] = dr[8].ToString();
                        NewRow[8] = dr[9].ToString();
                        NewRow[9] = dr[10].ToString();
                        NewRow[10] = dr[3].ToString();
                        dt.Rows.Add(NewRow);
                    }
                }
                con.Close();
                LoadTour(CurrentURL);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (GridView1.Rows.Count == 0)
                {
                    BodyTour.InnerHtml = "متاسفانه هیچ تور در این بخش ثبت نشده<br>";
                }
            }
            catch (Exception exp)
            {
                TitleTour.InnerHtml = "خطا";
                BodyTour.InnerHtml = exp.Message;
            }
            finally
            {
                con.Close();
            }
        }
        else
        {
            TitleTour.InnerHtml = "خطا";
            BodyTour.InnerHtml = "صفحه مورد نظر یافت نشد";
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string NNN = "";
            NNN = LoadMyQueries();
            LoadTour(NNN);
            FillDataGrid(NNN);
            az(NNN);
            LoadAgencies(NNN);
            Modat(NNN);
            LoadSlides();
            
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
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void SqlDataSource1_Selecting1(object sender, SqlDataSourceSelectingEventArgs e)
    {


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        if (e.Row.RowIndex != -1)
        {
            e.Row.CssClass = "ItemList";
            e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='hand';this.style.backgroundColor='#ffccff';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
            e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(GridView1, "Select$" + e.Row.RowIndex.ToString()));


        }
        else
        {
            e.Row.CssClass = "LabelHeader";
        }
        if (e.Row.RowIndex != -1)
        {
            string[] tdate = e.Row.Cells[10].Text.Split('/');
            if (tdate[1].Length == 1) tdate[1] = "0" + tdate[1];
            if (tdate[2].Length == 1) tdate[2] = "0" + tdate[2];
            if (Convert.ToInt32(tdate[0] + tdate[1] + tdate[2]) >= Convert.ToInt32(GetCDATE2()))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    long n;
                    bool isNumeric = long.TryParse(e.Row.Cells[1].Text, out n);
                    if (isNumeric == true)
                        if (e.Row.Cells[1].Text != "0")
                            e.Row.Cells[1].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[1].Text)) + " تومان";
                        else
                        {
                            isNumeric = long.TryParse(e.Row.Cells[8].Text, out n);
                            if (isNumeric == true)
                                e.Row.Cells[1].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[8].Text)) + " " + e.Row.Cells[9].Text;
                        }
                    else
                    {
                        isNumeric = long.TryParse(e.Row.Cells[8].Text, out n);
                        if (isNumeric == true)
                            e.Row.Cells[1].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[8].Text)) + " " + e.Row.Cells[9].Text;
                    }
                }
            }
            else
                e.Row.Visible = false;
        }
    }

    protected string GetCDATE()
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
        string CurrentDate = sal.ToString() + "/" + M + "/" + R;
        return CurrentDate;
    }
    protected string GetCDATE2()
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
        return CurrentDate;
    }

    protected string getMonthName(string InputData)
    {
        string returValue = "";
        string[] Data = InputData.Split('/');
        if (Data.Length == 3)
        {
            string Mah = Data[1].ToString();
            if (Mah == "01" || Mah == "1")
                returValue = Data[2] + " فروردین " + Data[0];
            else if (Mah == "02" || Mah == "2")
                returValue = Data[2] + " اردیبهشت " + Data[0];
            else if (Mah == "03" || Mah == "3")
                returValue = Data[2] + " خرداد " + Data[0];
            else if (Mah == "04" || Mah == "4")
                returValue = Data[2] + " تیر " + Data[0];
            else if (Mah == "05" || Mah == "5")
                returValue = Data[2] + " مرداد " + Data[0];
            else if (Mah == "06" || Mah == "6")
                returValue = Data[2] + " شهریور " + Data[0];
            else if (Mah == "07" || Mah == "7")
                returValue = Data[2] + " مهر " + Data[0];
            else if (Mah == "08" || Mah == "8")
                returValue = Data[2] + " آبان " + Data[0];
            else if (Mah == "09" || Mah == "9")
                returValue = Data[2] + " آذر " + Data[0];
            else if (Mah == "10" || Mah == "1")
                returValue = Data[2] + " دی " + Data[0];
            else if (Mah == "11" || Mah == "1")
                returValue = Data[2] + " بهمن " + Data[0];
            else if (Mah == "12" || Mah == "1")
                returValue = Data[2] + " اسفند " + Data[0];
        }
        else
            returValue = InputData;
        return returValue;
    }

    protected void OpenLink(string IDD)
    {
        MessageBox(IDD);
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Page.Response.Redirect("/Tours/" + GridView1.SelectedRow.Cells[7].Text.ToString());
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string NNN = LoadMyQueries();
        FillDataGrid(NNN);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string NNN = LoadMyQueries();
        FillDataGrid(NNN);
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        string NNN = LoadMyQueries();
        FillDataGrid(NNN);
    }
}