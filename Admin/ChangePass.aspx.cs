using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Drawing;

public partial class Admin_ChangePass : System.Web.UI.Page
{
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (CurrentPass.Text.Trim() != "" && NewPass.Text.Trim() != "" && RNewPass.Text.Trim() != "")
        {
            if (NewPass.Text.Trim() == RNewPass.Text.Trim())
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Members Set Password = " + CheckNull(Incode(RNewPass.Text.Trim()), 1) + " WHERE Username = '" + Session["User"].ToString() + "' AND Password = " + CheckNull(Incode(CurrentPass.Text.Trim()), 1), con);
                    con.Open();
                    int n = cmd.ExecuteNonQuery();
                    if (n == 0)
                    {
                        Label2.Text = "کلمه عبورفعلی اشتباه است";
                        Label2.ForeColor = Color.Red;
                    }
                    else
                    {
                        Label2.Text = "کلمه عبور با موفقیت بروزرسانی شد";
                        Label2.ForeColor = Color.Red;
                    }
                    con.Close();
                }
                catch (Exception exp)
                {
                    Label2.Text = exp.Message;
                    Label2.ForeColor = Color.Red;
                }
            }
            else
            {
                Label2.ForeColor = Color.Red;
                Label2.Text = "کلمه عبور جدید و تکرار آن با هم برابر نیستند";
            }
        }
        else
        {
            Label2.ForeColor = Color.Red;
            Label2.Text = "لطفا مقادیر را پر کنید";
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
}