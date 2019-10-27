using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class test : System.Web.UI.Page
{
    protected void HSlide()
    {
        StringBuilder st = new StringBuilder();
        st.Append("<div class='background-items divNav' ><div class='crsl-items divNav' data-navigation='navbtns'><div class='crsl-wrap divNav'>");
        string childItems = getHSlideItems();
        st.Append(childItems);
        st.Append("</div><!-- @end .crsl-wrap --></div><!-- @end .crsl-items --></div>");
        w2.InnerHtml = st.ToString();
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
        string CurrentDate = sal.ToString() + M  + R;
        return CurrentDate;
    }
    protected string getHSlideItems()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT URL,ImageURL,TextSlide,CommentSlide,KeyWordSeo from HorSlideShow", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            StringBuilder st = new StringBuilder();
            int i = 1;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    st.Append("<div class='crsl-item divNav' id='block" + i.ToString() + "' onMouseOver='View1(this.id)' onMouseOut='View2(this.id)'><a href='" + dr[0].ToString() + "'><div class='thumbnail divNav' >");
                    st.Append("<img src='" + dr[1].ToString() + "' alt='" + dr[4].ToString() + "' style='pointer-events:none;'><span class='postdate divNav' id='block" + i.ToString() + "1'>" + dr[2].ToString() + "<br><p id='block" + i.ToString() + "2' class='comment'>" + dr[3].ToString() + "</p></span></div></a></div>");
                    i++;
                }
            }
            con.Close();
            return st.ToString(); ;
        }
        catch { return ""; }
        finally
        {
            con.Close();
        }
        return "";
    }

    protected void LogoutUser()
    {
        string v = Request.QueryString["action"];
        if (v != null)
        {
            if (v == "logout")
            {
                Session.Clear();
                Response.Redirect("~/");
            }
        }
        else
        {
            //TitleTour.InnerHtml = "خطا";
            //BodyTour.InnerHtml = "صفحه مورد نظر یافت نشد";
        }
    }
    protected void LoadNews()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Top 10 NewsProfile,Title,replace(PicA,'/IMG/','/IMG/th/') as PicA,SUBSTRING(NBody, 1, 220) as TinyMatn From News order by id desc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ListView1.DataSource = ds.Tables[0].DefaultView;
            ListView1.DataBind();
        }
        catch (Exception exp)
        {

        }
        finally
        {
            con.Close();
        }
    }
    protected void LoadJazebe()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Top 10 JazebeProfile,Title,replace(PicA,'/IMG/','/IMG/th/') as PicA,SUBSTRING(NBody, 1, 220) as TinyMatn From Jazebe order by id desc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ListView2.DataSource = ds.Tables[0].DefaultView;
            ListView2.DataBind();
        }
        catch (Exception exp)
        {

        }
        finally
        {
            con.Close();
        }
    }

    protected void FillDataGrid1()
    {
    
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string myQu = "TourCatID = 1";
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                SqlCommand cmd = new SqlCommand("select top 30 TourBase.nam , modat , tarikh1,tarikh2,kind,AgencyDetail.nam,TourBase.ID,(select MIN(CAST(LEFT(qeimat1, Patindex('%[^-.0-9]%', qeimat1 + 'x') - 1) AS Float)) from TourHotel Where TourID = TourBase.ID) as AB3,TourProfile,Qeimat1P,Qeimat1Pv From TourBase,AgencyDetail,TourHotel WHERE AgencyDetail.UserID = TourBase.UserID AND " + myQu + " AND TourHotel.ID in (select top 1 ID from TourHotel where TourBase.ID=TourHotel.TourID) and Tarikh2 > '" + GetCDATE() + "' order by TourBase.ID desc", con);
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
                //dt.Columns.Add
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
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (GridView1.Rows.Count == 0)
                {
                    tb2.Attributes.Add("class", "MMM");
                }
            }
            catch (Exception exp)
            {
                

            }
            finally
            {
                con.Close();
            }
        
    }
    protected void FillDataGrid2()
    {

        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string myQu = "TourCatID = 2";

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            SqlCommand cmd = new SqlCommand("select top 30 TourBase.nam , modat , tarikh1,tarikh2,kind,AgencyDetail.nam,TourBase.ID,(select MIN(CAST(LEFT(qeimat1, Patindex('%[^-.0-9]%', qeimat1 + 'x') - 1) AS Float)) from TourHotel Where TourID = TourBase.ID) as AB3,TourProfile,Qeimat1P,Qeimat1Pv From TourBase,AgencyDetail,TourHotel WHERE AgencyDetail.UserID = TourBase.UserID AND " + myQu + " AND TourHotel.ID in (select top 1 ID from TourHotel where TourBase.ID=TourHotel.TourID) and Tarikh2 > '" + GetCDATE() + "' order by TourBase.ID desc", con);
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
            GridView2.DataSource = dt;
            GridView2.DataBind();
            if (GridView2.Rows.Count == 0)
            {
                tb3.Attributes.Add("class", "MMM");
            }
        }
        catch (Exception exp)
        {


        }
        finally
        {
            con.Close();
        }

    }
    protected void FillDataGrid3()
    {

        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            SqlCommand cmd = new SqlCommand("select top 30 TourBase.nam , modat , tarikh1,tarikh2,kind,AgencyDetail.nam,TourBase.ID,(select MIN(CAST(LEFT(qeimat1, Patindex('%[^-.0-9]%', qeimat1 + 'x') - 1) AS Float)) from TourHotel Where TourID = TourBase.ID) as AB3,TourProfile,Qeimat1P,Qeimat1Pv From TourBase,AgencyDetail,TourHotel WHERE Loks = 1 AND AgencyDetail.UserID = TourBase.UserID AND TourHotel.ID in (select top 1 ID from TourHotel where TourBase.ID=TourHotel.TourID) and Tarikh2 > '" + GetCDATE() + "' order by TourBase.ID desc", con);
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
            GridView3.DataSource = dt;
            GridView3.DataBind();
            if (GridView3.Rows.Count == 0)
            {
                tb4.Attributes.Add("class", "MMM");
            }
        }
        catch (Exception exp)
        {


        }
        finally
        {
            con.Close();
        }

    }
    protected void FillDataGrid4()
    {

        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {


            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            SqlCommand cmd = new SqlCommand("select top 30 TourBase.nam , modat , tarikh1,tarikh2,kind,AgencyDetail.nam,TourBase.ID,(select MIN(CAST(LEFT(qeimat1, Patindex('%[^-.0-9]%', qeimat1 + 'x') - 1) AS Float)) from TourHotel Where TourID = TourBase.ID) as AB3,TourProfile,Qeimat1P,Qeimat1Pv From TourBase,AgencyDetail,TourHotel WHERE Offer = 1 AND AgencyDetail.UserID = TourBase.UserID AND TourHotel.ID in (select top 1 ID from TourHotel where TourBase.ID=TourHotel.TourID) and Tarikh2 > '" + GetCDATE() + "' order by TourBase.ID desc", con);
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
            GridView4.DataSource = dt;
            GridView4.DataBind();
            if (GridView4.Rows.Count == 0)
            {
                tb5.Attributes.Add("class", "MMM");
            }
        }
        catch (Exception exp)
        {
            OfferDar.Visible = false;
        }
        finally
        {
            con.Close();
        }

    }
    protected void FillDataGrid5()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            SqlCommand cmd = new SqlCommand("select top 30 TourBase.nam , modat , tarikh1,tarikh2,kind,AgencyDetail.nam,TourBase.ID,(select MIN(CAST(LEFT(qeimat1, Patindex('%[^-.0-9]%', qeimat1 + 'x') - 1) AS Float)) from TourHotel Where TourID = TourBase.ID) as AB3,TourProfile,Qeimat1P,Qeimat1Pv From TourBase,AgencyDetail,TourHotel WHERE (TourBase.TourCatID = 4 OR TourBase.TourCatID = 5) AND AgencyDetail.UserID = TourBase.UserID AND TourHotel.ID in (select top 1 ID from TourHotel where TourBase.ID=TourHotel.TourID) and Tarikh2 > '" + GetCDATE() + "' order by TourBase.ID desc", con);
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
            GridView5.DataSource = dt;
            GridView5.DataBind();
            if (GridView5.Rows.Count == 0)
            {
                tb1.Attributes.Add("class", "MMM");
            }
        }
        catch (Exception exp)
        {

        }
        finally
        {
            con.Close();
        }
    }

    protected string getMonthName(string InputData)
    {
        string returValue="";
        string[] Data = InputData.Split('/');
        if (Data.Length == 3)
        {
            string Mah = Data[1].ToString();
            if (Mah == "01" || Mah == "1")
                returValue = Data[2] + " فروردین " + Data[0];
            else if(Mah == "02" || Mah == "2")
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
    protected void Page_Load(object sender, EventArgs e)
    {
        HSlide();
        if (!IsPostBack)
        {
            FillDataGrid1();
            FillDataGrid2();
            FillDataGrid3();
            FillDataGrid4();
            FillDataGrid5();
            LoadNews();
            LogoutUser();
            LoadJazebe();
            LoadSlides();
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("ClickTour()");
            sb.Append("</script>");
            Page.RegisterStartupScript("UpdateTour", sb.ToString());
        }
        GetTitle();
    }

    protected void LoadSlides()
    {
        HtmlGenericControl divMaster2 = (HtmlGenericControl)this.Master.FindControl("HorSlide");
        divMaster2.Visible = false;
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 1", con);
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
                    //if (dr[1].ToString() == "False")
                    //{
                    //    HtmlGenericControl divMaster2 = (HtmlGenericControl)this.Master.FindControl("HorSlide");
                    //    divMaster2.Visible = false;
                    //}
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
    protected void GetTitle()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT SiteTitle,SlideInterval,SiteDesc,SiteKey FROM SiteSetting WHERE ID = 1", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            int i = 1;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    sb.Append("<script type='text/javascript'>");
                    sb.Append("Slide2SS('" + dr[1].ToString() + "')");
                    sb.Append("</script>");
                    Page.RegisterStartupScript("Slide123" , sb.ToString());
                    this.Title = dr[0].ToString();
                    Header.Description = dr["SiteDesc"].ToString();
                    Header.Keywords = dr["SiteKey"].ToString();
                }
            }
            con.Close();

        }
        catch { }
        finally
        {
            con.Close();
        }
    }
    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].CssClass = "MMM";
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
        if (e.Row.RowIndex != -1)
        {
            e.Row.CssClass = "ItemList";
            e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='hand';this.style.backgroundColor='#ffccff';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#ffffff';";
            //e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(GridView5, "Select$" + e.Row.RowIndex.ToString()));
        }
        else
        {
            e.Row.CssClass = "LabelHeader";
        }
        if (e.Row.RowIndex != -1)
        {
            string[] tdate = e.Row.Cells[11].Text.Split('/');
            if (tdate[1].Length == 1) tdate[1] = "0" + tdate[1];
            if (tdate[2].Length == 1) tdate[2] = "0" + tdate[2];
            if (Convert.ToInt32(tdate[0] + tdate[1] + tdate[2]) >= Convert.ToInt32(GetCDATE2()))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    long n;
                    bool isNumeric = long.TryParse(e.Row.Cells[2].Text, out n);
                    if (isNumeric == true)
                        if (e.Row.Cells[2].Text != "0")
                            e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[2].Text)) + " تومان";
                        else
                        {
                            isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                            if (isNumeric == true)
                                e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                        }
                    else
                    {
                        isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                        if (isNumeric == true)
                            e.Row.Cells[1].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                    }
                }
            }
            else
                e.Row.Visible = false;
        }
    }

    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Page.Response.Redirect("/Tours/" + GridView1.SelectedRow.Cells[7].Text.ToString());
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Page.Response.Redirect("/Tours/" + GridView2.SelectedRow.Cells[7].Text.ToString());
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].CssClass = "MMM";
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
        if (e.Row.RowIndex != -1)
        {
            e.Row.CssClass = "ItemList";
            e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='hand';this.style.backgroundColor='#ffccff';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
            //e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(GridView5, "Select$" + e.Row.RowIndex.ToString()));
        }
        else
        {
            e.Row.CssClass = "LabelHeader";
        }
        if (e.Row.RowIndex != -1)
        {
            string[] tdate = e.Row.Cells[11].Text.Split('/');
            if (tdate[1].Length == 1) tdate[1] = "0" + tdate[1];
            if (tdate[2].Length == 1) tdate[2] = "0" + tdate[2];
            if (Convert.ToInt32(tdate[0] + tdate[1] + tdate[2]) >= Convert.ToInt32(GetCDATE2()))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    long n;
                    bool isNumeric = long.TryParse(e.Row.Cells[2].Text, out n);
                    if (isNumeric == true)
                        if (e.Row.Cells[2].Text != "0")
                            e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[2].Text)) + " تومان";
                        else
                        {
                            isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                            if (isNumeric == true)
                                e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                        }
                    else
                    {
                        isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                        if (isNumeric == true)
                            e.Row.Cells[1].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                    }
                }
            }
            else
                e.Row.Visible = false;
        }
    }
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        Page.Response.Redirect("/Tours/" + GridView3.SelectedRow.Cells[7].Text.ToString());
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].CssClass = "MMM";
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
        if (e.Row.RowIndex != -1)
        {
            e.Row.CssClass = "ItemList";
            e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='hand';this.style.backgroundColor='#ffccff';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
            //e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(GridView5, "Select$" + e.Row.RowIndex.ToString()));
        }
        else
        {
            e.Row.CssClass = "LabelHeader";
        }
        if (e.Row.RowIndex != -1)
        {
            string[] tdate = e.Row.Cells[11].Text.Split('/');
            if (tdate[1].Length == 1) tdate[1] = "0" + tdate[1];
            if (tdate[2].Length == 1) tdate[2] = "0" + tdate[2];
            if (Convert.ToInt32(tdate[0] + tdate[1] + tdate[2]) >= Convert.ToInt32(GetCDATE2()))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    long n;
                    bool isNumeric = long.TryParse(e.Row.Cells[2].Text, out n);
                    if (isNumeric == true)
                        if (e.Row.Cells[2].Text != "0")
                            e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[2].Text)) + " تومان";
                        else
                        {
                            isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                            if (isNumeric == true)
                                e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                        }
                    else
                    {
                        isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                        if (isNumeric == true)
                            e.Row.Cells[1].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                    }
                }
            }
            else
                e.Row.Visible = false;
        }
    }
    protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
    {
        Page.Response.Redirect("/Tours/" + GridView4.SelectedRow.Cells[7].Text.ToString());
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].CssClass = "MMM";
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
        if (e.Row.RowIndex != -1)
        {
            e.Row.CssClass = "ItemList";
            e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='hand';this.style.backgroundColor='#ffccff';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
            //e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(GridView5, "Select$" + e.Row.RowIndex.ToString()));
        }
        else
        {
            e.Row.CssClass = "LabelHeader";
        }
        if (e.Row.RowIndex != -1)
        {
            string[] tdate = e.Row.Cells[11].Text.Split('/');
            if (tdate[1].Length == 1) tdate[1] = "0" + tdate[1];
            if (tdate[2].Length == 1) tdate[2] = "0" + tdate[2];
            if (Convert.ToInt32(tdate[0] + tdate[1] + tdate[2]) >= Convert.ToInt32(GetCDATE2()))
            {
                
                
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    long n;
                    bool isNumeric = long.TryParse(e.Row.Cells[2].Text, out n);
                    if (isNumeric == true)
                        if (e.Row.Cells[2].Text != "0")
                            e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[2].Text)) + " تومان";
                        else
                        {
                            isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                            if (isNumeric == true)
                                e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                        }
                    else
                    {
                        isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                        if (isNumeric == true)
                            e.Row.Cells[1].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                    }
                }
            }
            else
                e.Row.Visible = false;
        }
    }
    protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
    {
        Page.Response.Redirect("/Tours/" + GridView5.SelectedRow.Cells[7].Text.ToString());
    }
    protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].CssClass = "MMM";
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
        if (e.Row.RowIndex != -1)
        {
            e.Row.CssClass = "ItemList";
            e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='hand';this.style.backgroundColor='#ffccff';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
            //e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(GridView5, "Select$" + e.Row.RowIndex.ToString()));
        }
        else
        {
            e.Row.CssClass = "LabelHeader";
        }
        if (e.Row.RowIndex != -1)
        {
            string[] tdate = e.Row.Cells[11].Text.Split('/');
            if (tdate[1].Length == 1) tdate[1] = "0" + tdate[1];
            if (tdate[2].Length == 1) tdate[2] = "0" + tdate[2];
            if (Convert.ToInt32(tdate[0] + tdate[1] + tdate[2]) >= Convert.ToInt32(GetCDATE2()))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    long n;
                    bool isNumeric = long.TryParse(e.Row.Cells[2].Text, out n);
                    if (isNumeric == true)
                        if (e.Row.Cells[2].Text != "0")
                            e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[2].Text)) + " تومان";
                        else
                        {
                            isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                            if (isNumeric == true)
                                e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                        }
                    else
                    {
                        isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                        if (isNumeric == true)
                            e.Row.Cells[1].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                    }
                }
            }
            else
                e.Row.Visible = false;
        }
        
    }
    protected void GridView3_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

    }
    protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DataPager1_PreRender(object sender, EventArgs e)
    {
        LoadNews();
    }
    protected void DataPager2_PreRender(object sender, EventArgs e)
    {
        if(!IsPostBack)
        LoadJazebe();
    }
}