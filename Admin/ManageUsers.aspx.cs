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

public partial class Admin_ManageUsers : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("select Members.username,MemberDetails.Name,MemberDetails.Family,MemberDetails.Email,MemberDetails.KhabarName,MemberDetails.JoinDate,Members.status FROM MemberDetails,Members WHERE MemberDetails.MemberID =" + inputID + " AND Members.ID = " + inputID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Label1.Text = "#" + inputID;
                TextBox5.Text = dr[0].ToString();
                TextBox1.Text = dr[1].ToString();
                TextBox4.Text = dr[2].ToString();
                TextBox2.Text = dr[3].ToString();
                string Khabar = dr[4].ToString();
                if (Khabar == "True") DropDownList1.SelectedIndex = 0;
                else DropDownList1.SelectedIndex = 1;
                if(dr[5].ToString() != "")
                    Label2.Text = TabdiLtrikh(dr[5].ToString());
                string vazi = dr[6].ToString();
                if (vazi == "True") DropDownList2.SelectedIndex = 0;
                else DropDownList2.SelectedIndex = 1;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
        
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        e.Cancel = true;
        LoadInfo(GridView1.DataKeys[e.RowIndex].Value.ToString());
        Button6.Enabled = true;
        Label4.Text = "";
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        e.Cancel = true;
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string CurrentID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string myqu = "";
            myqu += "DELETE FROM GroupMember WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM HotelComment WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM LoginLog WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM TokenTable WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM watcher WHERE UserID = " + CurrentID;
            myqu += "; DELETE FROM MemberDetails WHERE MemberID = " + CurrentID;
            myqu += "; DELETE FROM Members WHERE ID = " + CurrentID + ";";
            SqlCommand cmd = new SqlCommand(myqu, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox("کاربر مورد نظر با موفقیت حذف شد");
            GridView1.DataBind();
        }
        catch (Exception exp)
        {
            Label4.Text = exp.Message;
            Label4.ForeColor = Color.Red;
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

    protected void Button6_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "" && TextBox2.Text.Trim() != "" && TextBox4.Text.Trim() != "" && TextBox5.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string UserID = Label1.Text.Replace("#", "");
                string cond = "";
                if (DropDownList2.SelectedIndex == 0) cond = "1";
                else cond = "0";
                string myqu = "";
                if (Password.Text.Trim() != "")
                    myqu = "Update Members set status = " + cond + " , username = '" + TextBox5.Text.Trim() + "' , Password = '" + Incode(Password.Text.Trim()) + "' where ID=" + UserID;
                else
                    myqu = "Update Members set status = " + cond + " , username = '" + TextBox5.Text.Trim() + "' where ID=" + UserID;
                if (DropDownList1.SelectedIndex == 0) cond = "1";
                else cond = "0";
                myqu += "; UPDATE MemberDetails Set Name = N'" + TextBox1.Text.Trim() + "' , Family = N'" + TextBox4.Text.Trim() + "' , Email = N'" + TextBox2.Text.Trim() + "' , KhabarName = " + cond + " WHERE MemberID = " + UserID + ";";
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
    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {

    }
}