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

public partial class Verify_Email_activation : System.Web.UI.Page
{
    protected void CheckRequest()
    {
        try
        {
            string activationCode = !string.IsNullOrEmpty(Request.QueryString["Token"]) ? Request.QueryString["Token"] : Guid.Empty.ToString();
            string activeEmail = Request.QueryString["email"].ToString().Trim();
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;

            if (activeEmail != "" && activationCode.Trim() != "")
            {
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand("DELETE FROM TokenTable output deleted.UserID WHERE TokenCode = '" + activationCode + "' AND EmailAddress = '" + activeEmail + "'", con);
                SqlDataReader dr = null;
                con.Open();
                bool flg = false;
                string CurrentID = "";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    CurrentID = dr[0].ToString();
                    flg = true;
                }
                con.Close();
                if (flg == true)
                {
                    cmd.CommandText = "Update Members Set status = 1 where ID = " + CurrentID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ErrorMSG.Visible = true;
                    ErrorMSG.Attributes["class"] = "RegSuccess";
                    ErrorMSG.InnerHtml = "ایمیل شما با موفقیت فعال شد.";
                }
                else
                {
                    ErrorMSG.Visible = true;
                    ErrorMSG.InnerHtml = "متاسفانه لینک مورد نظر اشتباه می باشد";
                }
            }
            else
            {
                ErrorMSG.Visible = true;
                ErrorMSG.InnerHtml = "متاسفانه لینک مورد نظر اشتباه می باشد";
            }
        }
        catch (Exception exp)
        {
            ErrorMSG.Visible = true;
            ErrorMSG.InnerHtml = "متاسفانه لینک مورد نظر اشتباه می باشد";
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
        CheckRequest();
        RemoveSlideShows();
    }
}