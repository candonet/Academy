using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Security;

public partial class Admin_ManageADS : System.Web.UI.Page
{
    private void MessageBox(string MessageText)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("alert('" + MessageText + "')");
        sb.Append("</script>");
        Page.RegisterStartupScript("show2", sb.ToString());
    }
    protected void CheckSafe()
    {
        if ((Session["User"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "" && TextBox3.Text.Trim() != "" && TextBox4.Text.Trim() != "" && TextBox5.Text.Trim() != "" && (TextBox2.Text.Trim() != "" || FileUpload1.HasFile == true))
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string myQu = "";
                if (FileUpload1.HasFile)
                {
                    string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                    string p = MapPath("~/IMG/");
                    p += time;
                    TextBox2.Text = "/IMG/" + time;
                    FileUpload1.SaveAs(p);
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                    img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                    img1.Save(MapPath("~/IMG/th/") + time);
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string URLLL = "";
                if (TextBox3.Text.Trim() == "") URLLL = "#";
                else URLLL = TextBox3.Text.Trim();
                string StartDate = "";
                string[] Data = TextBox1.Text.Split('/');
                if (Data[1].Length == 1) Data[1] = "0" + Data[1];
                if (Data[2].Length == 1) Data[2] = "0" + Data[2];
                StartDate = Data[0] + Data[1] + Data[2];
                string EndDate = "";
                Data = TextBox4.Text.Split('/');
                if (Data[1].Length == 1) Data[1] = "0" + Data[1];
                if (Data[2].Length == 1) Data[2] = "0" + Data[2];
                EndDate = Data[0] + Data[1] + Data[2];

                myQu = "INSERT INTO Ads(ImageADR,URL,KeyW,StartDate,EndDate,AdsName) VALUES(N'" + TextBox2.Text.Trim() + "',N'" + URLLL + "',N'" + TextBox6.Text.Trim() + "',N'" + StartDate  + "',N'" + EndDate + "',N'" + TextBox5.Text.Trim() +"');";
                cmd.CommandText = myQu;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Label4.Text = "عملیات با موفقیت انجام شد";
                Label4.ForeColor = Color.Green;
            }
            catch (Exception exp)
            {
                Label4.Text = exp.Message;
                Label4.ForeColor = Color.Red;
            }
        }
        else
        {
            Label4.Text = "لطفا مقادیر را کامل وارد کنید";
            Label4.ForeColor = Color.Red;
        }
    }
    protected void SqlDataSource1_Updating(object sender, SqlDataSourceCommandEventArgs e)
    {
        
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        ShowAdsInfo(ID);
    }

    protected static string TabdiLtrikh(string inputValue)
    {
        return inputValue.Substring(0, 4) + "/" + inputValue.Substring(4, 2) + "/" + inputValue.Substring(6, 2);
    }

    protected void ShowAdsInfo(string AdsID)
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select AdsName,ImageADR,URL,StartDate,EndDate,KeyW,ID From Ads WHERE ID =" + AdsID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                TextBox5.Text = dr[0].ToString();
                TextBox2.Text = dr[1].ToString();
                TextBox3.Text = dr[2].ToString();
                TextBox1.Text = TabdiLtrikh(dr[3].ToString());
                TextBox4.Text = TabdiLtrikh(dr[4].ToString());
                TextBox6.Text = dr[5].ToString();
                Session["AdsID"] = AdsID;
            }
            con.Close();
            Button5.Enabled = false;
            Button6.Enabled = true;
        }
        catch (Exception exp)
        {
            Label4.Text = exp.Message;
            Label4.ForeColor = Color.Red;
        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "" && TextBox3.Text.Trim() != "" && TextBox4.Text.Trim() != "" && TextBox5.Text.Trim() != "" && (TextBox2.Text.Trim() != "" || FileUpload1.HasFile == true))
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string myQu = "";
                if (FileUpload1.HasFile)
                {
                    string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                    string p = MapPath("~/IMG/");
                    p += time;
                    TextBox2.Text = "/IMG/" + time;
                    FileUpload1.SaveAs(p);
                    System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                    img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                    img1.Save(MapPath("~/IMG/th/") + time);
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string URLLL = "";
                if (TextBox3.Text.Trim() == "") URLLL = "#";
                else URLLL = TextBox3.Text.Trim();
                string StartDate = "";
                string[] Data = TextBox1.Text.Split('/');
                if (Data[1].Length == 1) Data[1] = "0" + Data[1];
                if (Data[2].Length == 1) Data[2] = "0" + Data[2];
                StartDate = Data[0] + Data[1] + Data[2];
                string EndDate = "";
                Data = TextBox4.Text.Split('/');
                if (Data[1].Length == 1) Data[1] = "0" + Data[1];
                if (Data[2].Length == 1) Data[2] = "0" + Data[2];
                EndDate = Data[0] + Data[1] + Data[2];

                myQu = "Update ADS SET ImageADR = N'" + TextBox2.Text.Trim() + "',URL = N'" + URLLL + "',KeyW = N'" + TextBox6.Text.Trim() + "',StartDate = '" + StartDate + "',EndDate ='" + EndDate + "',AdsName=N'" + TextBox5.Text.Trim() + "' WHERE ID = " + Session["AdsID"].ToString() ;
                cmd.CommandText = myQu;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Label4.Text = "عملیات با موفقیت انجام شد";
                Label4.ForeColor = Color.Green;
            }
            catch (Exception exp)
            {
                Label4.Text = exp.Message;
                Label4.ForeColor = Color.Red;
            }
        }
        else
        {
            Label4.Text = "لطفا مقادیر را کامل وارد کنید";
            Label4.ForeColor = Color.Red;
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
        string CurrentDate = sal.ToString() + M + R;
        if (e.Row.RowIndex != -1)
        {
            if (Convert.ToInt32(e.Row.Cells[2].Text) < Convert.ToInt32(CurrentDate))
            {
                e.Row.Cells[2].Text = "به اتمام رسیده";
                e.Row.Cells[2].CssClass = "TaedNashode";
            }
            else
            {
                e.Row.Cells[2].Text = "نمایش";
                e.Row.Cells[2].CssClass = "TaedShode";
            }
            e.Row.Cells[3].Text = TabdiLtrikh(e.Row.Cells[3].Text);
        }
    }
}