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

public partial class Config : System.Web.UI.Page
{
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
    protected void CheckSafe()
    {
        if ((Session["UserID"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("/Login");
        }
        if (Session["GroupID"].ToString() == "3") Page.Response.Redirect("~/Member/Config.aspx");
    }

    protected void LoadInfo()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT Name,Family,Email From MemberDetails WHERE MemberID = " + Session["UserID"], con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Nam.Text = dr[0].ToString();
                Famil.Text = dr[1].ToString();
                Email.Text = dr[2].ToString();
            }
            con.Close();
        }
        catch { }
        finally
        {
            con.Close();
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        LoadInfo();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
        //RemoveSlideShows();
        if (!IsPostBack)
        {
            if (Session["GroupID"].ToString() == "1")
            {
                Page.Response.Redirect("~/Admin/Setting.aspx");
            }
            else if (Session["GroupID"].ToString() == "3")
            {
                Page.Response.Redirect("~/Member/Config.aspx");
            }
            LoadSlides();
        }
    }
    protected void LoadSlides()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 3", con);
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
    protected void BTN_Click(object sender, EventArgs e)
    {

        if (CurrentPass.Text.Trim() != "" && Password.Text.Trim() != "" && Repass.Text.Trim() != "")
        {
            if (Password.Text.Trim() == Repass.Text.Trim())
            {
                if (Password.Text.Length > 6)
                {
                    string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                    SqlConnection con = new SqlConnection(constring);
                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Members Set Password = " + CheckNull(Incode(Password.Text.Trim()), 1) + " WHERE ID = '" + Session["UserID"].ToString() + "' AND Password = " + CheckNull(Incode(CurrentPass.Text.Trim()), 1), con);
                        con.Open();
                        int n = cmd.ExecuteNonQuery();
                        if (n == 0)
                        {
                            ErrorMSG1.Attributes["class"] = "LoginError";
                            ErrorMSG1.Visible = true;
                            ErrorMSG1.InnerHtml = "کلمه عبورفعلی اشتباه است";
                        }
                        else
                        {
                            ErrorMSG1.Visible = true;
                            ErrorMSG1.Attributes["class"] = "ProgressSuccess";
                            ErrorMSG1.InnerHtml = "کلمه عبور با موفقیت بروزرسانی شد";
                        }
                        con.Close();
                    }
                    catch (Exception exp)
                    {
                        ErrorMSG1.Attributes["class"] = "LoginError";
                        ErrorMSG1.Visible = true;
                        ErrorMSG1.InnerHtml = exp.Message;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    ErrorMSG1.Attributes["class"] = "LoginError";
                    ErrorMSG1.Visible = true;
                    ErrorMSG1.InnerHtml = "کلمه عبور حداقل 6 حرف باید باشد";
                }
            }
            else
            {
                ErrorMSG1.Attributes["class"] = "LoginError";
                ErrorMSG1.Visible = true;
                ErrorMSG1.InnerHtml = "کلمه عبور جدید و تکرار آن با هم برابر نیستند";
            }
        }
        else
        {
            ErrorMSG1.Attributes["class"] = "LoginError";
            ErrorMSG1.Visible = true;
            ErrorMSG1.InnerHtml = "لطفا مقادیر را پر کنید";
        }
        
        
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

    protected string getUsername()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Username From Members WHERE ID = " + Session["UserID"].ToString(), con);
                SqlDataReader dr = null;
                con.Open();
                string FeedbackText = "";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    FeedbackText = dr[0].ToString();
                }
                con.Close();
                return FeedbackText;
            }
            catch { return "error"; }
            finally
            {
                con.Close();
            }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Nam.Text.Trim() != "" && Famil.Text.Trim() != "" && Email.Text.Trim() != "" && Email.Text.IndexOf('@') != -1)
        {
            if (FileUpload1.FileContent.Length < (100 * 1024))
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    if (FileUpload1.HasFile)
                    {
                        string p = MapPath("~/avatar/" + getUsername() + ".jpg");
                        FileUpload1.SaveAs(p);
                    }
                    SqlCommand cmd = new SqlCommand("Update MemberDetails Set Name = " + CheckNull(Nam.Text, 1) + " , Family = " + CheckNull(Famil.Text, 1) + " , Email = " + CheckNull(Email.Text, 1), con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ErrorMSG2.Visible = true;
                    ErrorMSG2.Attributes["class"] = "ProgressSuccess";
                    ErrorMSG2.InnerHtml = "مشخصات با موفقیت بروزرسانی شد";
                }
                catch (Exception exp)
                {
                    ErrorMSG2.Attributes["class"] = "LoginError";
                    ErrorMSG2.Visible = true;
                    ErrorMSG2.InnerHtml = exp.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                ErrorMSG2.Attributes["class"] = "LoginError";
                ErrorMSG2.Visible = true;
                ErrorMSG2.InnerHtml = "سایز عکس بیشتر از حد مجاز می باشد";
            }
        }
        else
        {
            ErrorMSG2.Attributes["class"] = "LoginError";
            ErrorMSG2.Visible = true;
            ErrorMSG2.InnerHtml = "لطفا مقادیر را درست پر کنید";
        }
    }
}