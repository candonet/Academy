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

public partial class ViewTour : System.Web.UI.Page
{
    protected void LoadSlides()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 10", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr[0].ToString() == "False")
                    {
                        //HtmlControl divMaster1 = (HtmlControl)this.FindControl("page1");
                        //divMaster1.Visible = false;
                        //page11.Visible = false;
                        //page11.InnerHtml = "";
                        content.Visible = false;
                        content.InnerHtml = "";
                    }
                    if (dr[1].ToString() == "False")
                    {
                        
                        HorSlide.Visible=false;
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
    protected string GetCurrentDate()
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
        return (sal.ToString() + "/" + M + "/" + R).ToString();
    }
    protected string GetCurrentTime()
    {
        int H = DateTime.Now.Hour;
        int M1 = DateTime.Now.Minute;
        string HH = H.ToString();
        string MM = M1.ToString();
        if (H < 10) HH = "0" + HH;
        if (M1 < 10) MM = "0" + MM;
        string Saat = (HH + ":" + MM).ToString();
        return Saat;
    }
    protected void LoadTour()
    {
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 4) v = HttpUtility.UrlDecode(NNN[4]);
        else v = Request.QueryString["TourID"];
        if (v != null && v.Trim() != "" )
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("select Nam,ID,UserID,KeyW From TourBase WHERE TourProfile Like N'" + v + "'", con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                string UserID = "";
                bool flg = false;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TitleTour.InnerHtml = dr[0].ToString();
                        UserID = dr[2].ToString();
                        flg = true;
                        this.MetaKeywords = dr[3].ToString();
                    }
                }
                con.Close();
                if (flg == true)
                {
                    string CurrentTourID = GetTourID();
                    SqlDataSource1.SelectCommand = "SELECT [nam], [modat], [tozihat] FROM [beTB] WHERE ([TourID] = " + CurrentTourID + ")";
                    SqlDataSource2.SelectCommand = "EXEC ViewTour " + CurrentTourID;
                    SqlDataSource1.DataBind();
                    SqlDataSource2.DataBind();
                    GridView1.DataBind();
                    GridView2.DataBind();
                    LoadTourInfo(UserID);
                    this.Title = TitleTour.InnerHtml;
                }
                else
                {
                    CommentSection.Visible = false;
                    this.Title = "خطا";
                    TitleTour.InnerHtml = "خطا";
                    BodyTour.InnerHtml = "متاسفانه تور مورد نظر یافت نشد";
                    CommentSection.Visible = false;
                }
            }
            catch (Exception exp)
            {
                CommentSection.Visible = false;
                this.Title = "خطا";
                TitleTour.InnerHtml = "خطا";
            }
            finally
            {
                con.Close();
            }
        }
        else
        {
            CommentSection.Visible = false;
            this.Title = "خطا";
            TitleTour.InnerHtml = "خطا";
            BodyTour.InnerHtml = "صفحه مورد نظر یافت نشد";
        }
    }
    protected void LoadTourInfo(string UserID)
    {
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 4) v = HttpUtility.UrlDecode(NNN[4]);
        else v = Request.QueryString["TourID"];
        if (v != null && v.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("select tarikh1,tarikh2,kind,modat,az,madarek,khadamat,tozihat,ID From TourBase Where TourProfile like N'" + v + "'", con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Label4.Text = "تاریخ شروع تور : " + dr[0].ToString();
                    Label6.Text = "تاریخ پایان تور : " + dr[1].ToString();
                    Label3.Text = "نوع سفر : " + dr[2].ToString();
                    Label5.Text = "مدت اقامت : " + dr[3].ToString();
                    Label7.Text = dr[4].ToString() + " به ";
                    lb1.Text = dr[4].ToString();
                    lb2.Text = dr[2].ToString();
                    lb3.Text = dr[0].ToString() + " الی " + dr[1].ToString();
                    lb4.Text = dr[5].ToString();
                    lb5.Text = dr[6].ToString();
                    lb6.Text = dr[7].ToString();
                    v = dr["ID"].ToString();
                }
                con.Close();
                dr = null;
                cmd.CommandText = " SELECT nam from beTB where TourID = " + v;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Label7.Text += dr[0].ToString() + " به ";
                }
                Label7.Text = Label7.Text.Substring(0, Label7.Text.Length - 4);
                con.Close();
                cmd.CommandText = "select nam,site,email,tel,faq from AgencyDetail where UserID = " + UserID;
                dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Label8.Text = "نام آژانس : " + dr[0].ToString();
                    Label9.Text =  "وبسایت : " + dr[1].ToString();
                    Label10.Text = "ایمیل : " + dr[2].ToString();
                    Label11.Text = "شماره تماس : " + dr[3].ToString();
                    Label12.Text = "شماره فکس : " + dr[4].ToString();
                }
                con.Close();
                
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
    protected void LoadKeyWords()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT SlideInterval FROM SiteSetting WHERE ID = 1", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            StringBuilder st = new StringBuilder();
            int i = 1;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type='text/javascript'>");
                    sb.Append("SlideShowStart('" + dr[0].ToString() + "')");
                    sb.Append("</script>");
                    Page.RegisterStartupScript("Slide", sb.ToString());
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

    protected void SetEmailName()
    {
        try
        {
            TextBox2.Text = Session["EsmFamil"].ToString();
            TextBox3.Text = Session["UserEmail"].ToString();
        }
        catch { }
    }

    protected void LoadADS()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
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
            SqlCommand cmd = new SqlCommand("select ImageADR,URL,KeyW FROM AdsTour WHERE EndDate >= '" + CurrentDate + "' order by ID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList2.DataSource = ds.Tables[0].DefaultView;
            DataList2.DataBind();
        }
        catch (Exception exp)
        {

        }
        finally
        {
            con.Close();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetEmailName();
            ShowSlide();
            HSlide();
            LoadTour();
            LoadKeyWords();
            LoadComments();
            LoadSlides();
            LoadADS();
        }
    }
    protected void HSlide()
    {
        StringBuilder st = new StringBuilder();
        st.Append("<div class='background-items divNav' ><div class='crsl-items divNav' data-navigation='navbtns'><div class='crsl-wrap divNav'>");
        string childItems = getHSlideItems();
        st.Append(childItems);
        st.Append("</div><!-- @end .crsl-wrap --></div><!-- @end .crsl-items --></div>");
        w.InnerHtml = st.ToString();
    }

    protected void ShowSlide()
    {
        StringBuilder st = new StringBuilder();
        st.Append("<div class='border_box'><div class='box_skitter box_skitter_large'><ul>");
        string childItems = getSlideItems();
        st.Append(childItems);
        st.Append("</ul></div></div>");
        content.InnerHtml = st.ToString();
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

    protected string getSlideItems()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT URL,ImageURL,CssClass,TextSlide from SlideShow", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            StringBuilder st = new StringBuilder();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    st.Append("<li><a href='" + dr[0].ToString() + "'><img src='" + dr[1].ToString() + "' class='" + dr[2].ToString() + "' /></a><div class='label_text'><p>" + dr[3].ToString() + "</p></div></li>");
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
    protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label HotelName1 = ((Label)e.Row.FindControl("HotelName1"));
            Label HotelName2 = ((Label)e.Row.FindControl("HotelName2"));
            Label HotelName3 = ((Label)e.Row.FindControl("HotelName3"));
            Label HotelName4 = ((Label)e.Row.FindControl("HotelName4"));
            Label HotelName5 = ((Label)e.Row.FindControl("HotelName5"));
            Label Esm2 = ((Label)e.Row.FindControl("Esm2"));
            Label Esm3 = ((Label)e.Row.FindControl("Esm3"));
            Label Esm4 = ((Label)e.Row.FindControl("Esm4"));
            Label Esm5 = ((Label)e.Row.FindControl("Esm5"));
            Label KHDM2 = ((Label)e.Row.FindControl("KHDM2"));
            Label KHDM3 = ((Label)e.Row.FindControl("KHDM3"));
            Label KHDM4 = ((Label)e.Row.FindControl("KHDM4"));
            Label KHDM5 = ((Label)e.Row.FindControl("KHDM5"));
            Label Setare2 = ((Label)e.Row.FindControl("Setare2"));
            Label Setare3 = ((Label)e.Row.FindControl("Setare3"));
            Label Setare4 = ((Label)e.Row.FindControl("Setare4"));
            Label Setare5 = ((Label)e.Row.FindControl("Setare5"));
            Label Emt2 = ((Label)e.Row.FindControl("Emt2"));
            Label Emt3 = ((Label)e.Row.FindControl("Emt3"));
            Label Emt4 = ((Label)e.Row.FindControl("Emt4"));
            Label Emt5 = ((Label)e.Row.FindControl("Emt5"));
            Label q1 = ((Label)e.Row.FindControl("q1"));
            Label q2 = ((Label)e.Row.FindControl("q2"));
            Label q3 = ((Label)e.Row.FindControl("q3"));
            Label q4 = ((Label)e.Row.FindControl("q4"));
            Label q1p = ((Label)e.Row.FindControl("q1p"));
            Label q2p = ((Label)e.Row.FindControl("q2p"));
            Label q3p = ((Label)e.Row.FindControl("q3p"));
            Label q4p = ((Label)e.Row.FindControl("q4p"));
            int Stars = Convert.ToInt16(e.Row.Cells[2].Text);
            string Resault="";
            for (int i = 0; i < Stars; i++)
            {
                Resault += "<img src='/images/star.ico' style='padding-bottom:5px;'/>";
            }
            string HotelS = "";
            string KHDM = "";
            string EMT = e.Row.Cells[1].Text.Trim();
            if(HotelName1.Text.Trim() != "")
                e.Row.Cells[0].Text = "<a href='/Hotels/" + HotelName1.Text.Trim() + "' style='padding-bottom:5px;' >" + HotelName1.Text.Trim().Replace("-", " ") + "</a>";
            HotelS = e.Row.Cells[0].Text;
            KHDM = e.Row.Cells[3].Text;
            if (Esm2.Text.Trim() != "" && Esm2.Text.Trim() != "&nbsp;")
            {

                if (HotelName2.Text.Trim() != "" && HotelName2.Text.Trim() != "&nbsp;")
                {
                    HotelS += "<br/>" + "<a href='/Hotels/" + HotelName2.Text.Trim() + "' style='padding-bottom:5px;' >" + HotelName2.Text.Trim().Replace("-", " ") + "</a>";
                }
                else
                {
                    HotelS += "<br/>" + Esm2.Text.Trim();
                }
                KHDM += "<br/>" + KHDM2.Text.Trim();
                Resault += "<br/>";
                for (int i = 0; i < Convert.ToInt16(Setare2.Text.Trim()); i++)
                {
                    Resault += "<img src='/images/star.ico' style='padding-bottom:5px;' />";
                }
                EMT += "<br/>" + Emt2.Text.Trim();
            }
            if (Esm3.Text.Trim() != "" && Esm3.Text.Trim() != "&nbsp;")
            {

                if (HotelName3.Text.Trim() != "" && HotelName3.Text.Trim() != "&nbsp;")
                {
                    HotelS += "<br/>" + "<a href='/Hotels/" + HotelName3.Text.Trim() + "' style='padding-bottom:5px;' >" + HotelName3.Text.Trim().Replace("-", " ") + "</a>";
                }
                else
                {
                    HotelS += "<br/>" + Esm3.Text.Trim();
                }
                KHDM += "<br/>" + KHDM3.Text.Trim();
                Resault += "<br/>";
                for (int i = 0; i < Convert.ToInt16(Setare3.Text.Trim()); i++)
                {
                    Resault += "<img src='/images/star.ico' style='padding-bottom:5px;' />";
                }
                EMT += "<br/>" + Emt3.Text.Trim();
            }
            if (Esm4.Text.Trim() != "" && Esm4.Text.Trim() != "&nbsp;")
            {

                if (HotelName4.Text.Trim() != "" && HotelName4.Text.Trim() != "&nbsp;")
                {
                    HotelS += "<br/>" + "<a href='/Hotels/" + HotelName4.Text.Trim() + "' style='padding-bottom:5px;' >" + HotelName4.Text.Trim().Replace("-", " ") + "</a>";
                }
                else
                {
                    HotelS += "<br/>" + Esm4.Text.Trim();
                }
                KHDM += "<br/>" + KHDM4.Text.Trim();
                Resault += "<br/>";
                for (int i = 0; i < Convert.ToInt16(Setare4.Text.Trim()); i++)
                {
                    Resault += "<img src='/images/star.ico' style='padding-bottom:5px;' />";
                }
                EMT += "<br/>" + Emt4.Text.Trim();
            }
            if (Esm5.Text.Trim() != "" && Esm5.Text.Trim() != "&nbsp;")
            {

                if (HotelName5.Text.Trim() != "" && HotelName5.Text.Trim() != "&nbsp;")
                {
                    HotelS += "<br/>" + "<a href='/Hotels/" + HotelName5.Text.Trim() + "' style='padding-bottom:5px;' >" + HotelName5.Text.Trim().Replace("-", " ") + "</a>";
                }
                else
                {
                    HotelS += "<br/>" + Esm5.Text.Trim();
                }
                KHDM += "<br/>" + KHDM5.Text.Trim();
                Resault += "<br/>";
                for (int i = 0; i < Convert.ToInt16(Setare5.Text.Trim()); i++)
                {
                    Resault += "<img src='/images/star.ico' style='padding-bottom:5px;' />";
                }
                EMT += "<br/>" + Emt5.Text.Trim();
            }
            HotelS = HttpUtility.HtmlDecode(HotelS);
            e.Row.Cells[0].Text = HotelS;
            KHDM = HttpUtility.HtmlDecode(KHDM);
            e.Row.Cells[3].Text = KHDM;
            Resault = HttpUtility.HtmlDecode(Resault);
            e.Row.Cells[2].Text = Resault;
            EMT = HttpUtility.HtmlDecode(EMT);
            e.Row.Cells[1].Text = EMT;
            string decodedText = HttpUtility.HtmlDecode(e.Row.Cells[8].Text);
            e.Row.Cells[8].Text = decodedText;
            bool flg1=false,flg2=false;
            string QeimatResult = "";
            long n1;
            bool isNumeric = long.TryParse(e.Row.Cells[4].Text, out n1);
            if (isNumeric == true)
            {
                flg1 = true;
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[4].Text)) + " تومان ";
            }
            if (q1.Text.Trim() != "")
            {
                flg2 = true;
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(q1.Text)) + " " + q1p.Text;
            }
            if(flg1 == true && flg2 == true)
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[4].Text)) + " تومان " + " + " + string.Format("{0:#,##0}", decimal.Parse(q1.Text)) + " " + q1p.Text;
            e.Row.Cells[4].Text = QeimatResult;
            flg1 = false; flg2 = false;
            QeimatResult = e.Row.Cells[5].Text;
            long n2;
            isNumeric = long.TryParse(e.Row.Cells[5].Text, out n2);
            if (isNumeric == true)
            {
                flg1 = true;
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[5].Text)) + " تومان ";
            }
            if (q2.Text.Trim() != "")
            {
                flg2 = true;
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(q2.Text)) + " " + q2p.Text;
            }
            if (flg1 == true && flg2 == true)
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[5].Text)) + " تومان " + " + " + string.Format("{0:#,##0}", decimal.Parse(q2.Text)) + " " + q2p.Text;
            e.Row.Cells[5].Text = QeimatResult;
            flg1 = false; flg2 = false;
            QeimatResult = e.Row.Cells[6].Text;
            long n3;
            isNumeric = long.TryParse(e.Row.Cells[6].Text, out n3);
            if (isNumeric == true)
            {
                flg1 = true;
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[6].Text)) + " تومان ";
            }
            if (q3.Text.Trim() != "")
            {
                flg2 = true;
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(q3.Text)) + " " + q3p.Text;
            }
            if (flg1 == true && flg2 == true)
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[6].Text)) + " تومان " + " + " + string.Format("{0:#,##0}", decimal.Parse(q3.Text)) + " " + q3p.Text;
            e.Row.Cells[6].Text = QeimatResult;
            flg1 = false; flg2 = false;
            QeimatResult = e.Row.Cells[7].Text;
            long n4;
            isNumeric = long.TryParse(e.Row.Cells[7].Text, out n4);
            if (isNumeric == true)
            {
                flg1 = true;
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[7].Text)) + " تومان ";
            }
            if (q4.Text.Trim() != "")
            {
                flg2 = true;
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(q4.Text)) + " " + q4p.Text;
            }
            if (flg1 == true && flg2 == true)
                QeimatResult = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[7].Text)) + " تومان " + " + " + string.Format("{0:#,##0}", decimal.Parse(q4.Text)) + " " + q4p.Text;
            e.Row.Cells[7].Text = QeimatResult;
            flg1 = false; flg2 = false;
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
    private void MessageBox(string MessageText)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("alert('" + MessageText + "')");
        sb.Append("</script>");
        Page.RegisterStartupScript("show2", sb.ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 4) v = HttpUtility.UrlDecode(NNN[4]);
        else v = Request.QueryString["TourID"];
        if (v != null && v.Trim() != "")
        {
            if (TextBox2.Text.Trim() != "" && TextBox3.Text.Trim() != "" && TextBox5.Text.Trim() != "" && TextBox3.Text.IndexOf('@') > 1)
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    string myQu = "";
                    string MSG = TextBox5.Text.Replace("\n", "<br />");
                    string TourID = GetTourID();
                    myQu = "INSERT INTO TourComment(Nam,Website,Email,MSG,PostDate,PostTime,TourID,STS) VALUES (" + CheckNull(TextBox2.Text, 1) + " , " + CheckNull(TextBox4.Text, 1) + " , " + CheckNull(TextBox3.Text, 1) + " , " + CheckNull(MSG, 1) + " , " + CheckNull(GetCurrentDate(), 1) + " , " + CheckNull(GetCurrentTime(), 1) +  " , " + TourID + ", 0 )";
                    SqlCommand cmd = new SqlCommand(myQu, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox("نظر شما با موفقیت ثبت شد و پس از تایید ادمین به نمایش خواهد در آمد");
                }
                catch { con.Close(); }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox("لطفا مقادیر را درست وارد کنید");
            }
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

    protected string GetTourID()
    {
        string ReturnValue = "0";
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 4) v = HttpUtility.UrlDecode(NNN[4]);
        if (v != null && v.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string mQu = "";
                mQu = "SELECT ID From TourBase Where TourProfile Like N'" + v + "'";
                SqlCommand cmd = new SqlCommand(mQu, con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    ReturnValue = dr[0].ToString();
                }
                con.Close();
            }
            catch (Exception exp)
            {
                con.Close();
                return "0";
            }
            finally
            {
                con.Close();
            }
        }
        return ReturnValue;
    }
    protected void LoadComments()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string v = GetTourID();
            string mQu = "";
            if (v != null)
            {
                mQu = "SELECT Nam,MSG,(PostDate + ' ساعت ' + PostTime) as Vaqt from TourComment WHERE STS = 1 AND TourID = " + Decode(v);
                SqlCommand cmd = new SqlCommand(mQu, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ListView1.DataSource = ds.Tables[0].DefaultView;
                ListView1.DataBind();
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string decodedText = HttpUtility.HtmlDecode(e.Row.Cells[2].Text);
            e.Row.Cells[2].Text = decodedText;
        }
    }
    protected void GridView2_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
    {
        e.Cancel = true;
    }
} 