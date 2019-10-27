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

public partial class Member_Config : System.Web.UI.Page
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

    protected void Page_PreRender(object sender, EventArgs e)
    {
        LoadInfo();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
    }
    protected void LoadInfo()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select namEng,nam,site,email,tel,faq,shomaremoj,nammodir,telmodir,YahooID,mobilen,ostan,shahr,adresMahal,khadematAG, TedadP,LocationX,LocationY,AboutUS From AgencyDetail Where UserID = " + Session["UserID"], con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Label1.Text = dr[0].ToString();
                TextBox1.Text = dr[1].ToString();
                TextBox2.Text = dr[2].ToString();
                TextBox3.Text = dr[3].ToString();
                TextBox4.Text = dr[4].ToString();
                TextBox5.Text = dr[5].ToString();
                TextBox6.Text = dr[6].ToString();
                TextBox7.Text = dr[7].ToString();
                TextBox8.Text = dr[8].ToString();
                TextBox9.Text = dr[9].ToString();
                TextBox10.Text = dr[10].ToString();
                TextBox12.Text = dr[12].ToString();
                TextBox13.Text = dr[13].ToString().Replace("<br>", "\n");
                TextBox14.Text = dr[14].ToString().Replace("<br>", "\n");
                TextBox15.Text = dr[15].ToString();
                TextBox16.Text = dr[16].ToString();
                TextBox17.Text = dr[17].ToString();
                TextBox18.Text = dr[18].ToString().Replace("<br>","\n");
                FindItemInList(dr[11].ToString().Trim());
            }
            con.Close();
        }
        catch { }
    }

    protected void FindItemInList(string InputValue)
    {
        try
        {
            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (DropDownList1.Items[i].Text.Trim() == InputValue)
                {
                    DropDownList1.SelectedIndex = i;
                    break;
                }
            }
        }
        catch (Exception exp)
        {
            Label2.Text = exp.Message;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "" && TextBox2.Text.Trim() != "" && TextBox3.Text.Trim() != "" && TextBox4.Text.Trim() != "" && TextBox5.Text.Trim() != "" && TextBox6.Text.Trim() != "" && TextBox7.Text.Trim() != "" && TextBox8.Text.Trim() != "" && TextBox9.Text.Trim() != "" && TextBox10.Text.Trim() != "" && TextBox12.Text.Trim() != "" && TextBox13.Text.Trim() != "" && TextBox14.Text.Trim() != "" && TextBox15.Text.Trim() != "" && TextBox16.Text.Trim() != "" && TextBox17.Text.Trim() != "" && TextBox18.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string S1, S2, S3;
                S1 = TextBox13.Text.Replace("\n", "<br>");
                S2 = TextBox14.Text.Replace("\n", "<br>");
                S3 = TextBox18.Text.Replace("\n", "<br>");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update AgencyDetail SET nam = " + CheckNull(TextBox1.Text.Trim(), 1) + " , site = " + CheckNull(TextBox2.Text.Trim(), 1) + " , email = " + CheckNull(TextBox3.Text.Trim(), 1) 
                + " , tel = " + CheckNull(TextBox4.Text.Trim(), 1) + " , faq = " + CheckNull(TextBox5.Text.Trim(), 1) + " , shomaremoj = " + CheckNull(TextBox6.Text.Trim(), 1)
                + " , nammodir = " + CheckNull(TextBox7.Text.Trim(), 1) + " , telmodir = " + CheckNull(TextBox8.Text.Trim(), 1) + " , YahooID = " + CheckNull(TextBox9.Text.Trim(), 1)
                + " , mobilen = " + CheckNull(TextBox10.Text.Trim(), 1) + " , shahr = " + CheckNull(TextBox12.Text.Trim(), 1) + " , adresMahal = " + CheckNull(S1, 1)
                + " , khadematAG = " + CheckNull(S2, 1) + " , TedadP = " + CheckNull(TextBox15.Text.Trim(), 0) + " , LocationX = " + CheckNull(TextBox16.Text.Trim(), 1)
                + " , LocationY = " + CheckNull(TextBox17.Text.Trim(), 1) + " , AboutUS = " + CheckNull(S3, 1) + " , ostan = " + CheckNull(DropDownList1.Text.Trim(),1)  + " WHERE UserID = " + Session["UserID"].ToString();
                string time = Label1.Text.Trim() + ".jpg";
                if (FileUpload1.HasFile)
                {
                    string p = MapPath("~/admin/AgencyB/");
                    p += time;
                    FileUpload1.SaveAs(p);
                }
                if (FileUpload2.HasFile)
                {
                    string p2 = MapPath("~/Agency/logo/");
                    p2 += time;
                    FileUpload2.SaveAs(p2);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label2.Text = "مشخصات با موفقیت بروز رسانی شدند";
                Label2.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception exp)
            {
                Label2.Text = exp.Message;
                Label2.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            Label2.Text = "لطفا تمامی مقادیر را پر کنید";
            Label2.ForeColor = System.Drawing.Color.Red;
        }
    }
}