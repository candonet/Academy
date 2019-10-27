using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

public partial class NewsArchive : System.Web.UI.Page
{
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
                {
                    string[] WithoutWater = NNN[i].Split('?');
                    v += "/" + HttpUtility.UrlDecode(WithoutWater[0]);
                }
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

    protected void LoadNews(string CurrentURL)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            Uri myUri = new Uri(CurrentURL.Trim());
            string v = HttpUtility.ParseQueryString(myUri.Query).Get("CatID");
            //string v = Request.QueryString["CatID"];
            string mQu = "";
            if (v != null)
            {
                mQu = "select  NewsProfile,Title,PicA,SUBSTRING(NBody, 1, 220) as TinyMatn From News where CatID = " + Decode(v) + " order by id desc";
            }
            else
            {
                mQu = "select  NewsProfile,Title,PicA,SUBSTRING(NBody, 1, 220) as TinyMatn From News order by id desc";
            }
            SqlCommand cmd = new SqlCommand(mQu, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ListView1.DataSource = ds.Tables[0].DefaultView;
            ListView1.DataBind();
            if (ds.Tables[0].Rows.Count == 0)
            {
                TitleTour.InnerHtml = "خطا";
                BodyTour.InnerHtml = "متاسفانه لینک مورد نظر درست نمی باشد";
            }
            else
            {
                GetCatName(Decode(v));
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

    protected void GetCatName(string CatID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT CatName from NewsCat WHERE ID = " + CatID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                TitleTour.InnerHtml = dr[0].ToString();
            }
            con.Close();
        }
        catch { }
        finally
        {
            con.Close();
        }
    }
    protected void RemoveSlideShows()
    {
        try
        {
            //System.Threading.Thread.Sleep(2000);
            HtmlGenericControl divMaster1 = (HtmlGenericControl)this.Master.FindControl("page1");
            divMaster1.Visible = false;
            HtmlGenericControl divMaster2 = (HtmlGenericControl)this.Master.FindControl("HorSlide");
            divMaster2.Visible = false;
        }
        catch { }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //RemoveSlideShows();
            string NNN = LoadMyQueries();
            LoadNews(NNN);
            LoadSlides();
        }
        this.Title = "آرشیو اخبار";
        LoadPageNumb();
    }
    protected void LoadPageNumb()
    {
        string v = Request.QueryString["page"];
        int totalRows = DataPager1.TotalRowCount;
        int pageSize = DataPager1.PageSize;
        int totalPage = (int)Math.Ceiling((decimal)totalRows / pageSize);
        int SelectedPage = ((Convert.ToInt16(Decode(v))-1) * 10);
        if (SelectedPage >= 0)
        {
            if (SelectedPage <= (totalPage * 10))
            {
                if (v != null)
                {
                    DataPager1.SetPageProperties(SelectedPage, DataPager1.MaximumRows, false);
                    ListView1.DataBind();
                }
                else
                {
                    DataPager1.SetPageProperties(0, DataPager1.MaximumRows, false);
                    ListView1.DataBind();
                }
            }
            else
            {
                this.Title = "خطا";
                TitleTour.InnerText = "خطا";
                BodyTour.InnerHtml = "متاسفانه لینک مورد نظر قابل دسترسی نیست";
            }
        }
        else
        {
            DataPager1.SetPageProperties(0, DataPager1.MaximumRows, false);
            ListView1.DataBind();
        }
            
        
    }
    protected void LoadSlides()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 13", con);
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
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DataPager1_PreRender(object sender, EventArgs e)
    {
        DataPager dataPager = sender as DataPager;
        StringBuilder stringBuilder = new StringBuilder();
        string currentPath = "";
        int totalRows = dataPager.TotalRowCount;
        int pageSize = dataPager.PageSize;
        int totalPage = (int)Math.Ceiling((decimal)totalRows / pageSize);
        int selectedPage = (dataPager.StartRowIndex / pageSize) + 1;
        int startPage = selectedPage - (totalRows / 2);
        startPage = (startPage < 1) ? 1 : startPage;
        int endPage = startPage + totalRows - 1;
        endPage = (endPage > totalPage) ? totalPage : endPage;
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 3)
            for (int i = 3; i < NNN.Length; i++)
            {
                string[] WithoutWater = NNN[i].Split('?');
                v += "/" + HttpUtility.UrlDecode(WithoutWater[0]);
            }
        for (int i = startPage; i <= endPage; i++)
        {
            if (selectedPage != i)
            {
                string[] NNN2 = NN.Split('/');
                string v2 = "";
                if (NNN2.Length > 3)
                    for (int j = 0; j < NNN2.Length; j++)
                    {
                        string[] WithoutWater2 = NNN2[j].Split('?');
                        v2 += "/" + HttpUtility.UrlDecode(WithoutWater2[0]);
                    }
                string CurrentURL = HttpUtility.UrlDecode(NN.Trim());
                if (i == 1)
                {
                    if (CurrentURL.Replace("/", "") == v2.Trim().Replace("/", ""))
                    {
                        stringBuilder.Append(string.Format(@"<div class=""DataPagerBTNSLC"">{0}</div>", i));
                    }
                    else
                    {
                        stringBuilder.Append(string.Format(@"<a href=""{0}{1}"" class=""DataPagerBTN"" >{2}</a>", currentPath, i == 1 ? v : string.Format("?page={0}", i), i));
                    }
                }
                else
                {
                    stringBuilder.Append(string.Format(@"<a href=""{0}{1}"" class=""DataPagerBTN"" >{2}</a>", currentPath, i == 1 ? v : string.Format("?page={0}", i), i));
                }
            }
            else
            {
                stringBuilder.Append(string.Format(@"<div class=""DataPagerBTNSLC"">{0}</div>", i));
            }
        }
        Literal spaceb = new Literal();
        spaceb.Text = stringBuilder.ToString();
        dataPager.Controls.Add(spaceb);
    }

}