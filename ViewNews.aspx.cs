using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class ViewNews : System.Web.UI.Page
{
    protected void LoadPage()
    {
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 4) v = HttpUtility.UrlDecode(NNN[4]);
        if (v != null && v != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("select Title,Nbody,PicA,KeyW,SubT,COALESCE(DSource,'منبع ذکر نشده') as KHDM From News WHERE NewsProfile like N'" + v + "'", con);
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
                    SubT.Text = dr["SubT"].ToString();
                    DSource.Text = dr["KHDM"].ToString();
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
                con.Close();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 14", con);
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