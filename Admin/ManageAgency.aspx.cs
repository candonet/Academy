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

public partial class Admin_ManageAgency : System.Web.UI.Page
{
    private void MessageBox(string MessageText)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("alert('" + MessageText + "')");
        sb.Append("</script>");
        Page.RegisterStartupScript("show2", sb.ToString());
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
    protected void CheckSafe()
    {
        if ((Session["User"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
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

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            if (e.Row.Cells[2].Text == "True")
            {
                e.Row.Cells[2].Text = "فعال";
                e.Row.Cells[2].CssClass = "TaedShode";
            }
            else
            {
                e.Row.Cells[2].Text = "غیر فعال";
                e.Row.Cells[2].CssClass = "TaedNashode";
            }
            if (e.Row.Cells[3].Text == "True")
            {
                e.Row.Cells[3].Text = "تایید شده";
                e.Row.Cells[3].CssClass = "TaedShode";
            }
            else
            {
                e.Row.Cells[3].Text = "تایید نشده";
                e.Row.Cells[3].CssClass = "TaedNashode";
            }
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        e.Cancel = true;
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string CurrentID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string AgencyID = Label5.Text.Trim();
            string myqu = "";
            myqu += "DELETE FROM GroupMember WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM HotelComment WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM Mojavez WHERE UserID = " + AgencyID;
            myqu += "; DELETE FROM AgencyComment WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM LoginLog WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM TokenTable WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM TourBase WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM watcher WHERE UserID = " + CurrentID;

            myqu += "; DELETE FROM AgencyDetail WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM Members WHERE ID = " + CurrentID + ";";
            SqlCommand cmd = new SqlCommand(myqu, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox("آژانس مورد نظر با موفقیت حذف شد");
            GridView1.DataBind();
        }
        catch (Exception exp)
        {
            Label4.Text = exp.Message;
            Label4.ForeColor = Color.Red;
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        e.Cancel = true;
        LoadInfo(GridView1.DataKeys[e.RowIndex].Value.ToString());
        GetAgencyID(GridView1.DataKeys[e.RowIndex].Value.ToString());
        Button6.Enabled = true;
        Label4.Text = "";
    }

    protected void GetAgencyID(string UserID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select AgencyDetail.ID from Members,AgencyDetail where AgencyDetail.UserID=Members.ID AND Members.ID= " + UserID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Label5.Text = dr[0].ToString();
            }
        }
        catch (Exception exp)
        {
            con.Close();
        }
    }

    protected static string TabdiLtrikh(string inputValue)
    {
        return inputValue.Substring(0, 4) + "/" + inputValue.Substring(4, 2) + "/" + inputValue.Substring(6, 2);
    }

    protected void LoadInfo(string inputID)
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Members.username,AgencyDetail.nam,AgencyDetail.tel,AgencyDetail.faq,AgencyDetail.email,AgencyDetail.JoinDate,Members.status,AgencyDetail.STS,AgencyDetail.BandB,AgencyDetail.TedadP,AgencyDetail.LocationX,AgencyDetail.LocationY,AgencyDetail.CTour,AgencyDetail.CHotel,AgencyDetail.RefName,AgencyDetail.RefTel FROM AgencyDetail,Members WHERE AgencyDetail.UserID =" + inputID + " AND Members.ID = " + inputID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Label1.Text =  inputID;
                UserTXT.Text = dr[0].ToString();
                NAM.Text = dr[1].ToString();
                TEL.Text = dr[2].ToString();
                FAQ.Text = dr[3].ToString();
                Email.Text = dr[4].ToString();
                string stat = dr[7].ToString();
                if (stat == "True") DropDownList1.SelectedIndex = 0;
                else DropDownList1.SelectedIndex = 1;
                if (dr[5].ToString() != "")
                    Label2.Text = dr[5].ToString();
                string vazi = dr[6].ToString();
                if (vazi == "True") DropDownList2.SelectedIndex = 0;
                else DropDownList2.SelectedIndex = 1;
                if (dr[8].ToString() != "")
                {
                    HyperLink1.NavigateUrl = "/admin/AgencyB/" + dr[8].ToString();
                    HyperLink1.Text = "نمایش";
                }
                else
                    HyperLink1.Text = "تصویری در سیستم درج نشده";
                TedadP.Text = dr["TedadP"].ToString();
                LocationX.Text = dr["LocationX"].ToString();
                LocationY.Text = dr["LocationY"].ToString();
                if (dr["CTour"].ToString() == "True") DropDownList5.SelectedIndex = 0;
                else DropDownList5.SelectedIndex = 1;
                if (dr["CHotel"].ToString() == "True") DropDownList4.SelectedIndex = 0;
                else DropDownList4.SelectedIndex = 1;
                RefName.Text = dr["RefName"].ToString();
                RefTel.Text = dr["RefTel"].ToString();
                CheckLastLogin(inputID);
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label4.Text = exp.Message;
            Label4.ForeColor = Color.Red;
        }
    }

    protected void CheckLastLogin(string UserID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select top 1 LastTime from LoginLog where UserID = " + UserID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Label3.Text = dr[0].ToString();
            }
            else
            {
                Label3.Text = "این کاربر تاکنون به حساب کاربری خود متصل نشده";
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label4.Text = exp.Message;
            Label4.ForeColor = Color.Red;
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        if (UserTXT.Text.Trim() != "" && TEL.Text.Trim() != "" && FAQ.Text.Trim() != "" && Email.Text.Trim() != "" && NAM.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string UserID = Label1.Text.Replace("#", "");
                string cond = "";
                if (DropDownList2.SelectedIndex == 0) cond = "1";
                else cond = "0";
                string CTour = "0";
                if (DropDownList5.SelectedIndex == 0) CTour = "1";
                string CHotel = "0";
                if (DropDownList4.SelectedIndex == 0) CHotel = "1";
                string myqu = "";
                if (PasswordTXT.Text.Trim() != "")
                    myqu = "Update Members set status = " + cond + " , username = '" + UserTXT.Text.Trim() + "' , Password = '" + Incode(PasswordTXT.Text.Trim()) + "' where ID=" + UserID;
                else
                    myqu = "Update Members set status = " + cond + " , username = '" + UserTXT.Text.Trim() + "' where ID=" + UserID;
                if (DropDownList1.SelectedIndex == 0) cond = "1";
                else cond = "0";
                myqu += "; UPDATE AgencyDetail Set CHotel = " + CHotel + " , CTour = " + CTour + " , LocationX = " + CheckNull(LocationX.Text,1) + ", LocationY = " + CheckNull(LocationY.Text,1) + " , TedadP = " + CheckNull(TedadP.Text.Trim(),1) + " , nam = N'" + NAM.Text.Trim() + "' , tel = N'" + TEL.Text.Trim() + "' , faq = N'" + FAQ.Text.Trim() + "' , email = N'" + Email.Text.Trim() + "' , STS = " + cond + " WHERE UserID = " + UserID + ";";
                SqlCommand cmd = new SqlCommand(myqu, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label4.Text = "ویرایش با موفقیت انجام شد";
                Label4.ForeColor = Color.Green;
                GridView1.DataBind();
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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        if (Label5.Text.Trim() != "0")
        {
            SqlDataSource2.InsertParameters[0].DefaultValue = Label5.Text.Trim();
            SqlDataSource2.InsertParameters[1].DefaultValue = DropDownList3.Text;
            SqlDataSource2.Insert();
            GridView2.DataBind();
        }
    }
}