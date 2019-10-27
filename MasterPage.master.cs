using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        CheckForLogin();
    }

    public DataTable DataT = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowSlide();
        HSlide();
        if (!IsPostBack)
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string LastQu = "SELECT ID,ParentID,MenuName,MenuProfile From MenuList where status = 1 order by SO";
            SqlDataAdapter dp = new SqlDataAdapter(LastQu, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dp);
            dp.FillSchema(DataT, SchemaType.Source);
            dp.Fill(DataT);
            showMenus2();
            //LoadNewsLeft();
            TourVizheLeft();
            LoadADS();
            
        }
        
        LoadKeyWords();
        
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
            SqlCommand cmd = new SqlCommand("select ImageADR,URL,KeyW FROM Ads WHERE EndDate >= '" + CurrentDate + "' order by ID", con);
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

    protected void LoadNewsLeft()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select TOP 5 NewsProfile,Title FROM News order by ID desc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList1.DataSource = ds.Tables[0].DefaultView;
            DataList1.DataBind();
        }
        catch (Exception exp)
        {

        }
        finally
        {
            con.Close();
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

    protected void TourVizheLeft()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select top 12 TourBase.Nam as Title,TourBase.Kind,(select top 1 TourHotel.qeimat1 from TourHotel where TourHotel.TourID=TourBase.ID) as Qeimat,AgencyDetail.nam,TourBase.TourICO,TourBase.TourProfile From TourBase,AgencyDetail WHERE TourBase.ADS=1 AND TourBase.UserID = AgencyDetail.UserID and  convert(varchar(10), cast(Tarikh2 as date), 111) > '" + GetCDATE() + "' order by TourBase.ID desc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList3.DataSource = ds.Tables[0].DefaultView;
            DataList3.DataBind();
            if (ds.Tables[0].Rows.Count == 0)
            {
                TOURVIZ.Style.Add("display", "none");
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

    protected void showMenus()
    {
        StringBuilder st = new StringBuilder();
        st.Append(" <nav class='nav black-menu'><ul>");
        string childItems = getMenuItems(0);
        st.Append(childItems);
        st.Append("<div class='search-top'>");
        st.Append("<form action='/Search.aspx'>");
        st.Append("<input type='text' placeholder='جستجو' name='word' class='inline-search1'>");
        st.Append("</form>");
        st.Append("</div>");
        st.Append("<ul style='float:left;position:relative;border-right:solid 1px black' id='LoginMenuBTN'></ul>");
        st.Append("<div class='clear'></div>");
        
        st.Append("</nav>");
        container.InnerHtml = st.ToString();
    }
    StringBuilder sbMenu = new StringBuilder();
    int childCount = 0;
    public string getMenuItems(int parentId)
    {

        var rowColl = DataT.AsEnumerable();
        var menuObj = from r in rowColl
                      where r.Field<int>(1) == parentId
                      select r;

        foreach (var obj in menuObj)
        {
            if (obj.ItemArray[2].ToString() == "منوی مادر و اصلی") continue;
            childCount = rowColl.Count(r => r.Field<int>(1) == obj.Field<int>(0));

            if (childCount > 0)
            {
                string TAG = "";
                if (obj.Field<int>(1) == 0)
                {
                    TAG = "<li><a class='drop' href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" >" + obj.Field<string>(2) + "</a><ul class='levels'>";
                }
                else
                {
                    TAG = "<li><a href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" >" + obj.Field<string>(2) + "</a><ul>";
                }
                sbMenu.Append(TAG);
                getMenuItems(obj.Field<int>(0));
            }
            else
            {

                sbMenu.Append("<li><a href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" >" + obj.Field<string>(2) + "</a></li>");
            }
        }

        sbMenu.Append("</ul>");
        return sbMenu.ToString();
    }

    protected void showMenus2()
    {
        StringBuilder st = new StringBuilder();
        st.Append(" <div id='nav'><ul>");
        string childItems = getMenuItems2(0);
        st.Append(childItems);
        st.Append("<div class='search-top'>");
        st.Append("<form action='/Search.aspx'>");
        st.Append("<input type='text'  placeholder='جستجو' name='word' class='inline-search'>");
        st.Append("</form>");
        st.Append("</div>");
        st.Append("<ul style='float:left;position:relative;border-right:solid 1px black' id='LoginMenuBTN'></ul>");
        st.Append("<div class='clear'></div>");

        st.Append("</div>\n");
        container.InnerHtml = st.ToString();
    }
    
    public string getMenuItems2(int parentId)
    {

        var rowColl = DataT.AsEnumerable();
        var menuObj = from r in rowColl
                      where r.Field<int>(1) == parentId
                      select r;

        foreach (var obj in menuObj)
        {
            if (obj.ItemArray[2].ToString() == "منوی مادر و اصلی") continue;
            childCount = rowColl.Count(r => r.Field<int>(1) == obj.Field<int>(0));

            if (childCount > 0)
            {
                string TAG = "";
                if (obj.Field<int>(1) == 0)
                {
                    TAG = "<li><a href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" >" + obj.Field<string>(2) + "</a><ul class='sub-menu'>\n";
                }
                else
                {
                    TAG = "<li><a href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" class='myArrow' >" + obj.Field<string>(2) + "</a><ul class='sub-menu'>\n";
                }
                sbMenu.Append(TAG);
                getMenuItems2(obj.Field<int>(0));
            }
            else
            {

                sbMenu.Append("<li><a href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" >" + obj.Field<string>(2) + "</a></li>\n");
            }
        }

        sbMenu.Append("</ul>\n");
        return sbMenu.ToString();
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
        st.Append("<div>\n<div class='box_skitter box_skitter_large'><ul>\n");
        string childItems = getSlideItems();
        st.Append(childItems);
        st.Append("</ul></div></div>");
        content.InnerHtml = st.ToString();
    }
    
    
    protected void LoadKeyWords()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT SiteKey,SlideInterval,News,BGColor,SiteDesc FROM SiteSetting WHERE ID = 1", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            StringBuilder st = new StringBuilder();
            int i = 1;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //var keywords = new HtmlMeta { Name = "keywords", Content = dr[0].ToString() };
                    //head.Controls.Add(keywords);
                    StringBuilder sb = new StringBuilder();
                    Random r = new Random();
                    sb.Append("<script type='text/javascript'>");
                    sb.Append("SlideShowStart('" + dr[1].ToString() + "')");
                    sb.Append("</script>");
                    Page.RegisterStartupScript("Slide" + r.Next(1,1000), sb.ToString());
                    if (dr[2].ToString() == "True")
                    {
                        NewsHeader.Visible = true;
                        NewsBody.Visible = true;
                        LoadNewsLeft();
                    }
                    string CurrentColor = dr[3].ToString();
                    MarkSite.Style.Add("background-color", "#" + CurrentColor);
                    //var SiteDescr = new HtmlMeta { Name = "description", Content = dr["SiteDesc"].ToString() };
                    //head.Controls.Add(SiteDescr);
                    
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
                    st.Append("<li><a href='" + dr[0].ToString() + "'><img src='" + dr[1].ToString() + "' class='" + dr[2].ToString() + "' /></a><div class='label_text'><p>" + dr[3].ToString() + "</p></div></li>\n");
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
    private void MessageBox(string MessageText)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("alert('" + MessageText + "')");
        sb.Append("</script>");
        Page.RegisterStartupScript("show2", sb.ToString());
    }
    int scriptNumber = 0;
    protected void CheckForLogin()
    {
        try
        {
            //System.Threading.Thread.Sleep(2000);
            StringBuilder sb = new StringBuilder();
            string nnn = "";
            if (Session["EsmFamil"] != null)
            {
                nnn = Session["EsmFamil"].ToString();
            }
            else
            {
                nnn = "1";
            }
            sb.Append("<script type='text/javascript'>");
            sb.Append("ChangeLogin('" + nnn+ "')");
            sb.Append("</script>");
            Page.RegisterStartupScript("function" + scriptNumber.ToString(), sb.ToString());
            scriptNumber++;
        }
        catch { }
    }
    protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Label lbl = ((Label)e.Item.FindControl("Label3"));

        long n;
        bool isNumeric = long.TryParse(lbl.Text, out n);
        if (isNumeric == true)
            lbl.Text = string.Format("{0:#,##0}", decimal.Parse(lbl.Text)) + " تومان";
    }
}
