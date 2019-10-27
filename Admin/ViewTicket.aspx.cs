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
using System.IO;

public partial class Admin_ViewTicket : System.Web.UI.Page
{
    protected void CheckSafe()
    {
        if ((Session["User"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }

    protected void LoadTicket()
    {
        string v = Request.QueryString["id"];
        if (v != null && v != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd2 = new SqlCommand("SELECT 1 from Ticket WHERE ID = " + v , con);
                SqlDataReader dr = null;
                con.Open();
                bool flg = false;
                dr = cmd2.ExecuteReader();
                if (dr.HasRows)
                {
                    flg = true;
                }
                con.Close();
                if (flg == true)
                {
                    SqlCommand cmd = new SqlCommand("select MSG,ReplyDate,(select Username From Members Where ID = UserID) as Esm FROM TicketComment WHERE TicketID = " + v + " ORDER BY ID DESC", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataList1.DataSource = ds.Tables[0].DefaultView;
                    DataList1.DataBind();
                    Label1.Text = v.ToString() + "#";
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        Button2.Visible = false;
                        Label1.Visible = false;
                        ErrorMSG.Visible = true;
                        ErrorMSG.InnerHtml = "متاسفانه تیکت مورد نظر یافت نشد";
                        MainReport.Visible = false;
                    }
                }
                else
                {
                    Button2.Visible = false;
                    Label1.Visible = false;
                    ErrorMSG.Visible = true;
                    ErrorMSG.InnerHtml = "متاسفانه تیکت مورد نظر یافت نشد";
                    MainReport.Visible = false;
                }
            }
            catch (Exception exp)
            {
                ErrorMSG.Visible = true;
                ErrorMSG.InnerHtml = "خطا در اتصال به دیتابیس-لطفا بعدا تلاش کنید";
                MainReport.Visible = false;
            }
        }
        else
        {
            Button2.Visible = false;
            Label1.Visible = false;
            ErrorMSG.Visible = true;
            ErrorMSG.InnerHtml = "متاسفانه تیکت مورد نظر یافت نشد";
            MainReport.Visible = false;
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        LoadTicket();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
    }
    string CurrentItem = "";
    int FirstTime = 0;
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Label lbl = ((Label)e.Item.FindControl("lblname"));
        HtmlControl div = e.Item.FindControl("HeaderColor") as HtmlControl;
        if (FirstTime == 0)
        {
            CurrentItem = lbl.Text;
            FirstTime++;
        }
        if (CurrentItem == lbl.Text) div.Attributes["class"] = "Memb";
        else div.Attributes["class"] = "Staff";
    }
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string v = Request.QueryString["id"];
        if (v != null && v != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string MMM = MSG.Text.Trim().Replace("\n", "<br/>");
                SqlCommand cmd = new SqlCommand("INSERT INTO TicketComment(MSG,ReplyDate,UserID,TicketID) VALUES (" + CheckNull(MMM, 1) + " , " + CheckNull((GetCurrentDate() + " " + GetCurrentTime()), 1) + "," + Session["UserID"].ToString() + " , " + v + "); UPDATE Ticket SET sts1 = N'پاسخ داده شده' WHERE ID = " + v, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DataList1.DataBind();
            }
            catch (Exception exp)
            {

            }
        }
        else
        {
            Button2.Visible = false;
            Label1.Visible = false;
            ErrorMSG.Visible = true;
            ErrorMSG.InnerHtml = "متاسفانه تیکت مورد نظر یافت نشد";
            MainReport.Visible = false;
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        string v = Request.QueryString["id"];
        if (v != null && v != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string MMM = MSG.Text.Trim().Replace("\n", "<br/>");
                SqlCommand cmd = new SqlCommand("UPDATE Ticket SET sts1 = N'بسته' WHERE ID = " + v, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/admin/supportticket.aspx");
            }
            catch (Exception exp)
            {

            }
        }
        else
        {
            Button2.Visible = false;
            Label1.Visible = false;
            ErrorMSG.Visible = true;
            ErrorMSG.InnerHtml = "متاسفانه تیکت مورد نظر یافت نشد";
            MainReport.Visible = false;
        }
    }
}