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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Error"]) != null)
        {
            ErrorMSG.Visible = true;
            ErrorMSG.InnerHtml = Session["Error"].ToString();
            Session.Contents.Remove("Error");
        }
        if (Session["GroupID"] != null)
            Response.Redirect("/");
        this.Title = "ورود";
        //RemoveSlideShows();
        if (!IsPostBack)
            LoadSlides();
    }
    protected void LoadSlides()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 2", con);
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
    private void MessageBox(string MessageText)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("alert('" + MessageText + "')");
        sb.Append("</script>");
        Page.RegisterStartupScript("show2", sb.ToString());
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

    public static string Incode(string Entry)
    {
        byte[] array;
        string s1 = string.Empty;
        string s2 = string.Empty;
        Entry = Entry.ToUpper();
        array = Encoding.ASCII.GetBytes(Entry);
        for (int i = 0; i <= array.Length - 1; i++)
        {
            array[i] -= 13;
            s1 += array[i].ToString().Substring(0, 1);
            s2 += array[i].ToString().Substring(1, 1);
        }
        return (s1 + s2);
    }
    protected void BTN_Click(object sender, EventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        string returnValue = string.Empty;
        string User = UserName.Text;
        string Pass = Password.Text;
        string Permission = string.Empty;
        if (User != "" && Pass != "")
        {
            try
            {
                SqlDataReader dr = null;
                string HashPass = Incode(Pass);
                SqlCommand cmd = new SqlCommand("SELECT status FROM Members WHERE Username like '" + User + "' AND Password like '" + HashPass + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if ((dr).HasRows == true)
                {
                    while (dr.Read())
                    {
                        if (dr[0].ToString() == "True")
                        {
                            returnValue = "1";
                            break;
                        }
                        else
                        {
                            returnValue = "این نام کاربری غیر فعال شده است";
                            break;
                        }
                    }
                }
                else
                    returnValue = "نام کاربری و کلمه عبور اشتباه می باشند";
                con.Close();
                if (returnValue == "1")
                {
                    cmd.CommandText = "select GroupID,GroupMember.UserID from GroupMember,Members where GroupMember.UserID = (select ID from Members where username = '" + User + "')  and GroupMember.UserID = Members.ID";
                    dr = null;
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        Session["GroupID"] = dr[0].ToString();
                        Session["UserID"] = dr[1].ToString();
                        SabteLog(dr[1].ToString());
                        if (dr[0].ToString() == "3")
                            FillSessions2(dr[1].ToString());
                        else
                            FillSessions(dr[1].ToString());
                    }
                    else
                    {
                        Session["GroupID"] = "none";
                    }

                    if (Session["GroupID"].ToString() == "1")
                    {
                        Session["User"] = User;
                        Page.Response.Redirect("~/Admin/Default.aspx");
                    }
                    else if (Session["GroupID"].ToString() == "3")
                    {
                        Session["Member"] = User;
                        Page.Response.Redirect("~/Member/Default.aspx");
                    }
                    else if (Session["GroupID"] == "none")
                        Page.Response.Redirect("~/Default.aspx");
                    con.Close();
                }
                else
                {
                    ErrorMSG.InnerHtml = returnValue;
                    ErrorMSG.Visible = true;
                }
                
            }
            catch (SqlException ex)
            {
                returnValue = "خطا در اتصال به سرور - لطفا دوباره تلاش کنید";
                ErrorMSG.InnerHtml = returnValue;
                ErrorMSG.Visible = true;
            }
            finally
            {
                con.Close();
            }
        }
        else
        {
            returnValue = "لطفا مقادیر را پر کنید";
            ErrorMSG.InnerHtml = returnValue;
            ErrorMSG.Visible = true;
        }
            
    }
    protected void FillSessions2(string MemUserID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT AgencyDetail.nam as EsmFamil,AgencyDetail.email,Members.username from AgencyDetail,Members WHERE AgencyDetail.UserID = Members.ID AND AgencyDetail.UserID = " + MemUserID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Session["EsmFamil"] = dr[0].ToString();
                Session["UserEmail"] = dr[1].ToString();
                Session["Avatar"] = "/Agency/logo/" + dr[2].ToString() + ".jpg";
            }
            else
            {
                Session["EsmFamil"] = "درج نشده";
                Session["UserEmail"] = "درج نشده";
                Session["Avatar"] = "درج نشده";
            }
            con.Close();
        }
        catch { }
        finally
        {
            con.Close();
        }
    }
    protected void FillSessions(string MemUserID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT (MemberDetails.Name + ' ' + MemberDetails.Family) as EsmFamil,MemberDetails.Email,Members.username from MemberDetails,Members WHERE MemberDetails.MemberID = Members.ID AND MemberDetails.MemberID = " + MemUserID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Session["EsmFamil"] = dr[0].ToString();
                Session["UserEmail"] = dr[1].ToString();
                Session["Avatar"] = "/avatar/" + dr[2].ToString() + ".jpg";
            }
            else
            {
                Session["EsmFamil"] = "درج نشده";
                Session["UserEmail"] = "درج نشده";
                Session["Avatar"] = "درج نشده";
            }
            con.Close();
        }
        catch { }
        finally
        {
            con.Close();
        }
    }
    protected void SabteLog(string MemUserID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO LoginLog(UserID,LastTime) VALUES (" + MemUserID + ", '" + GetCurrentDate() + " - " + GetCurrentTime() + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch { }
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
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
}