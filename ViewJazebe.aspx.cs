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

public partial class ViewJazebe : System.Web.UI.Page
{
    protected void LoadPage()
    {
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 4) v = HttpUtility.UrlDecode(NNN[4]);
        if (v != null && v != "")
        if (v != null && v != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("select Title,Nbody,PicA,KeyW From Jazebe WHERE JazebeProfile like N'" + v + "'", con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    TitleTour.InnerHtml = dr[0].ToString();
                    Label1.Text = dr[1].ToString();
                    Image1.ImageUrl = dr[2].ToString();
                    this.Title = dr[0].ToString();
                    this.MetaKeywords = dr["KeyW"].ToString();
                }
                else
                {
                    this.Title = "خطا";
                    TitleTour.InnerHtml = "خطا";
                    BodyTour.InnerHtml = "متاسفانه خبر مورد نظر در سیستم موجود نمی باشد";
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
            this.Title = "خطا";
            TitleTour.InnerHtml = "خطا";
            BodyTour.InnerHtml = "صفحه مورد نظر یافت نشد";
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
         //   RemoveSlideShows();
            LoadPage();
            LoadSlides();
        }
    }
    protected void LoadSlides()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 16", con);
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
}