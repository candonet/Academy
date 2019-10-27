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
using System.Data;

public partial class Search : System.Web.UI.Page
{
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

    protected void SearchWord()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string v = Request.QueryString["word"];
            string mQu = "";
            if (v != null && v.Trim() != "")
            {
                v = v.Replace("+", " ");
                mQu = "select HotelProfile,Title From Hotel WHERE Title like N'%" + v + "%' OR Tozihat like N'%" + v + "%' OR AboutHotel like N'%" + v + "%' ;";
                mQu += "SELECT TourProfile,Nam FROM TourBase WHERE Nam like N'%" + v + "%' ;";
                mQu += "select NewsProfile,Title FROM News WHERE Title like N'%" + v + "%' OR NBody like N'%" + v + "%' ;";
                mQu += "select JazebeProfile,Title FROM Jazebe WHERE Title like N'%" + v + "%' OR NBody like N'%" + v + "%' ;";
                SqlCommand cmd = new SqlCommand(mQu, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ListView1.DataSource = ds.Tables[0].DefaultView;
                ListView1.DataBind();
                ListView2.DataSource = ds.Tables[1].DefaultView;
                ListView2.DataBind();
                ListView3.DataSource = ds.Tables[2].DefaultView;
                ListView3.DataBind();
                ListView4.DataSource = ds.Tables[3].DefaultView;
                ListView4.DataBind();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Head1.Visible = false;
                }
                if (ds.Tables[1].Rows.Count == 0)
                {
                    Head2.Visible = false;
                }
                if (ds.Tables[2].Rows.Count == 0)
                {
                    Head3.Visible = false;
                }
                if (ds.Tables[3].Rows.Count == 0)
                {
                    Head4.Visible = false;
                }
                if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0 && ds.Tables[2].Rows.Count == 0 && ds.Tables[3].Rows.Count == 0)
                {
                    Label1.Text = "متاسفانه موردی یافت نشد";
                }

            }
            else
            {
                Head1.Visible = false;
                Head2.Visible = false;
                Head3.Visible = false;
                Head4.Visible = false;
                Label1.Text = "متاسفانه موردی یافت نشد";
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         //   RemoveSlideShows();
            LoadSlides();
            SearchWord();
        }
    }
    protected void LoadSlides()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 4", con);
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