using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

public partial class Member_Submitticket : System.Web.UI.Page
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

    protected void CheckSafe()
    {
        if ((Session["Member"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ticketmsg.Text.Trim() != "" && ticketsubject.Text != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("EXEC dbo.SubmitTicket " + CheckNull(ticketsubject.Text.Trim(), 1) + " , " + CheckNull(ticketmsg.Text.Trim(), 1) + " , " + CheckNull((GetCurrentDate() + " " + GetCurrentTime()), 1) + " , " + Session["UserID"].ToString(), con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/Member/supportticket.aspx");
            }
            catch (Exception exp)
            {
                ErrorMSG.Visible = true;
                ErrorMSG.InnerHtml = exp.Message;
            }
        }
        else
        {
            ErrorMSG.Visible = true;
            ErrorMSG.InnerHtml = "لطفا مقادیر مورد نظر را بدرستی وارد کنید" ;
        }
    }
}