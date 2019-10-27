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
using System.Drawing;

public partial class ViewPage : System.Web.UI.Page
{
    protected void LoadSlides()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 17", con);
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

    protected void LoadPage()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            var NN = Request.Url.AbsoluteUri.ToString();
            string[] NNN = NN.Split('/');
            string v = "";
            if (NNN.Length > 4) v = HttpUtility.UrlDecode(NNN[4]);
            if (v != null && v != "")
            {
                
                SqlCommand cmd = new SqlCommand("SELECT Title,PageHTML,KeyWord From Page WHERE PageProfile like N'" + v.ToString() + "'", con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TitleTour.InnerHtml = dr[0].ToString();
                        Label1.Text = Server.HtmlDecode(dr[1].ToString());
                        this.Title = dr[0].ToString();
                        this.MetaKeywords = dr["KeyWord"].ToString();
                    }
                }
                con.Close();
            }
        }
        catch (Exception exp)
        {
            Label1.Text = "خطا در اتصال با دیتابیس";
            Label1.ForeColor = Color.Red;
        }
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
            LoadPage();
            LoadSlides();
        }
    }
}