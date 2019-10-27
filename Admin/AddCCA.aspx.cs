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

public partial class Admin_AddCCA : System.Web.UI.Page
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
        if ((Session["User"]) != null)
        {
            if (!IsPostBack)
            {
                LoadSlide();
                LoadCities();
                LoadArea();
            }
        }
        else
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }

    private void LoadSlide()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT ID,Name From Country order by Id ", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList1.Items.Clear();
            DropDownList3.Items.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList1.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList3.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
                if (DropDownList1.Items.Count > 0)
                {
                    DropDownList1.SelectedIndex = 0;
                    DropDownList3.SelectedIndex = 0;
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }


    private void LoadCities()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT ID,Name From City order by Id ", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList2.Items.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList2.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList5.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
                if (DropDownList2.Items.Count > 0)
                {
                    DropDownList2.SelectedIndex = 0;
                    DropDownList5.SelectedIndex = 0;
                }

            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }

    private void LoadArea()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT ID,Name From Area order by Id ", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList4.Items.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList4.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
                if (DropDownList4.Items.Count > 0)
                {
                    DropDownList4.SelectedIndex = 0;
                }

            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        CurrentCountry.Text = DropDownList1.Text;
        ShowCountryItem();
        MenuInsert2.Enabled = true;
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
        CheckSafe();
        if (CountryName.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {

                SqlCommand cmd = new SqlCommand("insert into Country(Name) VALUES (" + CheckNull(CountryName.Text, 1) + ")", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "کشور جدید با موفقیت درج شد";
                LoadSlide();
                CountryName.Text = "";
                CurrentCountry.Text = "";
            }
            catch (Exception exp)
            {
                Label1.Text = exp.Message;
                Label1.ForeColor = Color.Red;
            }
        }
        else
        {
            Label1.Text = "لطفا مقادیر را درست وارد کنید";
            Label1.ForeColor = Color.Red;
        }
    }
    protected void ShowCountryItem()
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = DropDownList1.Text.Split('-');
            SqlCommand cmd = new SqlCommand("SELECT Name From Country WHERE Id =" + Data[0], con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                CountryName.Text = dr[0].ToString();
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }
    protected void MenuInsert2_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (CurrentCountry.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data2 = CurrentCountry.Text.Split('-');
                SqlCommand cmd = new SqlCommand("Update Country Set Name = " + CheckNull(CountryName.Text, 1) + " WHERE id = " + Data2[0], con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "مشخصات کشور با موفقیت بروز رسانی شد";
                LoadSlide();
                MenuInsert2.Enabled = false;
            }
            catch (Exception exp)
            {
                Label1.Text = exp.Message;
                Label1.ForeColor = Color.Red;
            }
        }
        else
        {
            Label1.Text = "لطفا مقادیر را درست وارد کنید";
            Label1.ForeColor = Color.Red;
        }
    }
    protected void MenuInsert3_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (CurrentCountry.Text.Trim() != "" )
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data2 = CurrentCountry.Text.Split('-');
                SqlCommand cmd = new SqlCommand("Delete from Country where id = " + Data2[0], con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "کشور با موفقیت حذف شد";
                CountryName.Text = "";
                CurrentCountry.Text = "";
                LoadSlide();
            }
            catch (Exception exp)
            {
                Label1.Text = exp.Message;
                Label1.ForeColor = Color.Red;
            }
        }
        else
        {
            Label1.Text = "لطفا کشور را انتخاب کنید";
            Label1.ForeColor = Color.Red;
        }
    }
    protected void Button1_Click2(object sender, EventArgs e)
    {
        CurrentCity.Text = DropDownList2.Text;
        ShowCityItem();
        Button4.Enabled = true;
    }

    protected void SetCountry(string ID)
    {
        CheckSafe();
        for (int i = 0; i < DropDownList1.Items.Count; i++)
        {
            string[] SS = DropDownList1.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                DropDownList3.SelectedIndex = i;
                break;
            }
        }
    }
    protected void ShowCityItem()
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = DropDownList2.Text.Split('-');
            SqlCommand cmd = new SqlCommand("SELECT CountryID,Name From City WHERE Id =" + Data[0], con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                CityName.Text = dr[1].ToString();
                SetCountry(dr[0].ToString());
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label2.Text = exp.Message;
            Label2.ForeColor = Color.Red;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (CityName.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data = DropDownList3.Text.Split('-');
                SqlCommand cmd = new SqlCommand("insert into City(Name,CountryID) VALUES (" + CheckNull(CityName.Text, 1) + " , " + CheckNull(Data[0], 0) + ")", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label2.ForeColor = Color.Green;
                Label2.Text = "شهر جدید با موفقیت درج شد";
                LoadCities();
                CityName.Text = "";
                CurrentCity.Text = "";
            }
            catch (Exception exp)
            {
                Label2.Text = exp.Message;
                Label2.ForeColor = Color.Red;
            }
        }
        else
        {
            Label2.Text = "لطفا مقادیر را درست وارد کنید";
            Label2.ForeColor = Color.Red;
        }
    }
    protected void Button4_Click1(object sender, EventArgs e)
    {
        CheckSafe();
        if (CurrentCity.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data2 = CurrentCity.Text.Split('-');
                string[] Data = DropDownList3.Text.Split('-');
                SqlCommand cmd = new SqlCommand("Update City Set Name = " + CheckNull(CityName.Text, 1) + " , CountryID = " + CheckNull(Data[0], 0) + " WHERE id = " + Data2[0], con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label2.ForeColor = Color.Green;
                Label2.Text = "مشخصات شهر با موفقیت بروز رسانی شد";
                LoadCities();
                Button4.Enabled = false;
            }
            catch (Exception exp)
            {
                Label2.Text = exp.Message;
                Label2.ForeColor = Color.Red;
            }
        }
        else
        {
            Label2.Text = "لطفا مقادیر را درست وارد کنید";
            Label2.ForeColor = Color.Red;
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (CurrentCity.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data2 = CurrentCity.Text.Split('-');
                SqlCommand cmd = new SqlCommand("Delete from City where id = " + Data2[0], con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label2.ForeColor = Color.Green;
                Label2.Text = "شهر با موفقیت حذف شد";
                CityName.Text = "";
                CurrentCity.Text = "";
                LoadCities();
            }
            catch (Exception exp)
            {
                Label2.Text = exp.Message;
                Label2.ForeColor = Color.Red;
            }
        }
        else
        {
            Label2.Text = "لطفا شهر را انتخاب کنید";
            Label2.ForeColor = Color.Red;
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        CurrentArea.Text = DropDownList4.Text;
        ShowAreaItem();
        Button8.Enabled = true;
    }

    protected void SetCity(string ID)
    {
        CheckSafe();
        for (int i = 0; i < DropDownList2.Items.Count; i++)
        {
            string[] SS = DropDownList2.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                DropDownList5.SelectedIndex = i;
                break;
            }
        }
    }

    protected void ShowAreaItem()
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = DropDownList4.Text.Split('-');
            SqlCommand cmd = new SqlCommand("SELECT CityID,Name From Area WHERE Id =" + Data[0], con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                AreaName.Text = dr[1].ToString();
                SetCity(dr[0].ToString());
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label3.Text = exp.Message;
            Label3.ForeColor = Color.Red;
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (AreaName.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data = DropDownList5.Text.Split('-');
                SqlCommand cmd = new SqlCommand("insert into Area(Name,CityID) VALUES (" + CheckNull(AreaName.Text, 1) + " , " + CheckNull(Data[0], 0) + ")", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label3.ForeColor = Color.Green;
                Label3.Text = "ناحیه جدید با موفقیت درج شد";
                LoadArea();
                AreaName.Text = "";
                CurrentArea.Text = "";
            }
            catch (Exception exp)
            {
                Label3.Text = exp.Message;
                Label3.ForeColor = Color.Red;
            }
        }
        else
        {
            Label3.Text = "لطفا مقادیر را درست وارد کنید";
            Label3.ForeColor = Color.Red;
        }
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (CurrentArea.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data2 = CurrentArea.Text.Split('-');
                string[] Data = DropDownList5.Text.Split('-');
                SqlCommand cmd = new SqlCommand("Update Area Set Name = " + CheckNull(AreaName.Text, 1) + " , CityID = " + CheckNull(Data[0], 0) + " WHERE id = " + Data2[0], con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label3.ForeColor = Color.Green;
                Label3.Text = "مشخصات ناحیه با موفقیت بروز رسانی شد";
                LoadArea();
                Button8.Enabled = false;
            }
            catch (Exception exp)
            {
                Label3.Text = exp.Message;
                Label3.ForeColor = Color.Red;
            }
        }
        else
        {
            Label3.Text = "لطفا مقادیر را درست وارد کنید";
            Label3.ForeColor = Color.Red;
        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (CurrentArea.Text.Trim() != "" )
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data2 = CurrentArea.Text.Split('-');
                SqlCommand cmd = new SqlCommand("Delete from Area where id = " + Data2[0], con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label3.ForeColor = Color.Green;
                Label3.Text = "شهر با موفقیت حذف شد";
                AreaName.Text = "";
                CurrentArea.Text = "";
                LoadArea();
            }
            catch (Exception exp)
            {
                Label3.Text = exp.Message;
                Label3.ForeColor = Color.Red;
            }
        }
        else
        {
            Label3.Text = "لطفا کشور را انتخاب کنید";
            Label3.ForeColor = Color.Red;
        }
    }
}