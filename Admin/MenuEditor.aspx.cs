using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

public partial class Admin_MenuEditor : System.Web.UI.Page
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
                LoadMenus();
                LoadLists();
                LoadNewsCat();
                sl1.Visible = false;
                sl2.Visible = false;
                sl3.Visible = false;
                sl4.Visible = false;
                sl5.Visible = false;
                dl1.Visible = false;
                dl2.Visible = false;
                dl3.Visible = false;
                dl4.Visible = false;
                dl5.Visible = false;
            }
        }
        else
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }
    private void LoadMenus()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT Id,MenuName,MenuDescription From MenuList order by Id", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            MenuList.Items.Clear();
            MenuList2.Items.Clear();
            MenuList3.Items.Clear();
            MenuList4.Items.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr[0].ToString() != "0")
                    {
                        
                        MenuList2.Items.Add(dr[0].ToString() + "- " + dr[1].ToString() + " | " + dr[2].ToString());

                        MenuList4.Items.Add(dr[0].ToString() + "- " + dr[1].ToString() + " | " + dr[2].ToString());
                    }
                    MenuList.Items.Add(dr[0].ToString() + "- " + dr[1].ToString() + " | " + dr[2].ToString());
                    MenuList3.Items.Add(dr[0].ToString() + "- " + dr[1].ToString() + " | " + dr[2].ToString());
                }
                if (MenuList.Items.Count > 0) MenuList.SelectedIndex = 0;
                if (MenuList2.Items.Count > 0) MenuList2.SelectedIndex = 0;
                if (MenuList3.Items.Count > 0) MenuList3.SelectedIndex = 0;
                if (MenuList4.Items.Count > 0) MenuList4.SelectedIndex = 0;
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }

    protected void ShowMenuItems()
    {
        CheckSafe();
        DropDownList7.Enabled = true;
        DropDownList8.Enabled = true;
        DropDownList9.Enabled = true;
        DropDownList10.Enabled = true;
        DropDownList11.Enabled = true;
        MenuList3.Enabled = true;
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = MenuList2.Text.Split('-');
            SqlCommand cmd = new SqlCommand("SELECT MenuName,URL,ParentId,MenuProfile,MenuDescription,status From MenuList WHERE Id =" + Data[0], con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                NewName2.Text = dr[0].ToString();
                MenuURL2.Text = dr[1].ToString();
                SetParent(dr[2].ToString());
                MenuProfile2.Text = dr[3].ToString();
                Tozihat2.Text = dr["MenuDescription"].ToString();
                string MSTS = dr["status"].ToString();
                if (MSTS.ToLower() == "true") DropDownList13.SelectedIndex = 0;
                else DropDownList13.SelectedIndex = 1;
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }
    protected void SetParent(string ID)
    {
        CheckSafe();
        for (int i = 0; i < MenuList3.Items.Count; i++)
        {
            string[] SS = MenuList3.Items[i].Text.Split('-');
            if (ID.Trim() == SS[0].Trim())
            {
                MenuList3.SelectedIndex = i;
                break;
            }
        }
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
        if (NewName.Text.Trim() != "" && MenuURL.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data = MenuList.Text.Split('-');
                SqlCommand cmd = new SqlCommand("insert into MenuList(ParentId,MenuName,URL,MenuDescription,MenuProfile) VALUES (" + Data[0] + "," + CheckNull(NewName.Text, 1) + "," + CheckNull(MenuURL.Text, 1) + "," + CheckNull(MenuDescription.Text, 1) + " , " + CheckNull(MenuProfile1.Text,1) + ")", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.ForeColor = Color.Green;
                Label1.Text = "منوی جدید با موفقیت درج شد";
                LoadMenus();
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
    protected void MenuList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {

        CurrentMenu.Text = MenuList2.Text;
        ShowMenuItems();
    }
    protected void MenuInsert3_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (NewName2.Text.Trim() != "" && MenuURL2.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data2 = CurrentMenu.Text.Split('-');
                SqlCommand cmd = new SqlCommand("Delete from MenuList where id = " + Data2[0], con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label2.ForeColor = Color.Green;
                Label2.Text = "منو با موفقیت حذف شد";
                CurrentMenu.Text = "";
                MenuURL2.Text = "";
                NewName2.Text = "";
                LoadMenus();
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
    protected void MenuInsert2_Click(object sender, EventArgs e)
    {
        CheckSafe();
        if (NewName2.Text.Trim() != "" && MenuURL2.Text.Trim() != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string[] Data = MenuList3.Text.Split('-');
                string[] Data2 = CurrentMenu.Text.Split('-');
                string MSTS = "";
                if (DropDownList13.SelectedIndex == 0) MSTS = "1";
                else if (DropDownList13.SelectedIndex == 1) MSTS = "0";
                SqlCommand cmd = new SqlCommand("Update MenuList Set status = " + MSTS + " , MenuDescription = " + CheckNull(Tozihat2.Text.Trim(),1) + " , MenuProfile = " + CheckNull(MenuProfile2.Text, 1) + " , ParentId = " + Data[0] + ", MenuName =" + CheckNull(NewName2.Text, 1) + " , URL = " + CheckNull(MenuURL2.Text, 1) + " WHERE id = " + Data2[0], con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label2.ForeColor = Color.Green;
                Label2.Text = "منو با موفقیت بروز رسانی شد";
                LoadMenus();
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
    protected void Logout()
    {
        Session["User"] = null;
        Page.Response.Redirect("~/Admin/Login.aspx");
    }
    protected void SetURL4Tour()
    {
        string[] Data1 = DropDownList5.Text.Split('-');
        string[] Data2 = DropDownList2.Text.Split('-');
        string[] Data3 = DropDownList3.Text.Split('-');
        string[] Data4 = DropDownList4.Text.Split('-');
        string myQu = "";
        string MenuProfile = "";
        if (Data1[0].ToString() != "" && Data1[0].ToString() != "نامشخص")
        {
            myQu += "&TourCat=" + Data1[0];
            string[] NN = Data1[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data2[0].ToString() != "" && Data2[0].ToString() != "نامشخص")
        {
            myQu += "&Country=" + Data2[0];
            string[] NN = Data2[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data3[0].ToString() != "" && Data3[0].ToString() != "نامشخص")
        {
            myQu += "&City=" + Data3[0];
            string[] NN = Data3[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data4[0].ToString() != "" && Data4[0].ToString() != "نامشخص")
        {
            myQu += "&Area=" + Data4[0];
            string[] NN = Data4[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        MenuURL.Text =  myQu;
        MenuProfile1.Text = "/" + "تورها" + MenuProfile;
    }

    protected void SetURL4Hotel()
    {
        string[] Data2 = DropDownList2.Text.Split('-');
        string[] Data3 = DropDownList3.Text.Split('-');
        string[] Data4 = DropDownList4.Text.Split('-');
        string myQu = "";
        string MenuProfile = "";
        if (Data2[0].ToString() != "" && Data2[0].ToString() != "نامشخص")
        {
            myQu += "&Country=" + Data2[0];
            string[] NN = Data2[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ","-");
        }
        if (Data3[0].ToString() != "" && Data3[0].ToString() != "نامشخص")
        {
            myQu += "&City=" + Data3[0];
            string[] NN = Data3[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data4[0].ToString() != "" && Data4[0].ToString() != "نامشخص")
        {
            myQu += "&Area=" + Data4[0];
            string[] NN = Data4[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        MenuURL.Text =  myQu;
        MenuProfile1.Text = "/" + "هتل-ها" + MenuProfile;
    }


    protected void SetURL4News()
    {
        string[] Data2 = DropDownList6.Text.Split('-');
        string myQu = "";
        string MenuProfile = "";
        if (Data2[0].ToString() != "" && Data2[0].ToString() != "نامشخص")
        {
            myQu += "&CatID=" + Data2[0];
            MenuProfile += "/" + Data2[1].Trim().Replace(" ", "-");
        }

        MenuURL.Text = myQu;
        MenuProfile1.Text = "/" + "خبرها" + MenuProfile;
    }

    protected void SetURL4Tourist()
    {
        string[] Data2 = DropDownList2.Text.Split('-');
        string[] Data3 = DropDownList3.Text.Split('-');
        string[] Data4 = DropDownList4.Text.Split('-');
        string myQu = "";
        string MenuProfile = "";
        if (Data2[0].ToString() != "" && Data2[0].ToString() != "نامشخص")
        {
            myQu += "&Country=" + Data2[0];
            string[] NN = Data2[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data3[0].ToString() != "" && Data3[0].ToString() != "نامشخص")
        {
            myQu += "&City=" + Data3[0];
            string[] NN = Data3[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data4[0].ToString() != "" && Data4[0].ToString() != "نامشخص")
        {
            myQu += "&Area=" + Data4[0];
            string[] NN = Data3[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        MenuURL.Text =  myQu;
        MenuProfile1.Text = "/" + "جاذبه-ها" + MenuProfile;
    }


    protected void SetURL4Tour2()
    {
        string[] Data1 = DropDownList8.Text.Split('-');
        string[] Data2 = DropDownList9.Text.Split('-');
        string[] Data3 = DropDownList10.Text.Split('-');
        string[] Data4 = DropDownList11.Text.Split('-');
        string myQu = "";
        string MenuProfile = "";
        if (Data1[0].ToString() != "" && Data1[0].ToString() != "نامشخص")
        {
            myQu += "&TourCat=" + Data1[0];
            string[] NN = Data1[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data2[0].ToString() != "" && Data2[0].ToString() != "نامشخص")
        {
            myQu += "&Country=" + Data2[0];
            string[] NN = Data2[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data3[0].ToString() != "" && Data3[0].ToString() != "نامشخص")
        {
            myQu += "&City=" + Data3[0];
            string[] NN = Data3[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data4[0].ToString() != "" && Data4[0].ToString() != "نامشخص")
        {
            myQu += "&Area=" + Data4[0];
            string[] NN = Data4[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        MenuURL2.Text =  myQu;
        MenuProfile2.Text = "/" + "تورها" + MenuProfile;
    }

    protected void SetURL4Hotel2()
    {
        string[] Data2 = DropDownList9.Text.Split('-');
        string[] Data3 = DropDownList10.Text.Split('-');
        string[] Data4 = DropDownList11.Text.Split('-');
        string myQu = "";
        string MenuProfile = "";
        if (Data2[0].ToString() != "" && Data2[0].ToString() != "نامشخص")
        {
            myQu += "&Country=" + Data2[0];
            string[] NN = Data2[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data3[0].ToString() != "" && Data3[0].ToString() != "نامشخص")
        {
            myQu += "&City=" + Data3[0];
            string[] NN = Data3[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data4[0].ToString() != "" && Data4[0].ToString() != "نامشخص")
        {
            myQu += "&Area=" + Data4[0];
            string[] NN = Data4[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        MenuURL2.Text = myQu;
        MenuProfile2.Text = "/" + "هتل-ها" + MenuProfile;
    }

    protected void SetURL4News2()
    {
        string[] Data2 = DropDownList12.Text.Split('-');
        string myQu = "";
        string MenuProfile = "";
        if (Data2[0].ToString() != "" && Data2[0].ToString() != "نامشخص")
        {
            myQu += "&CatID=" + Data2[0];
            MenuProfile += "/" + Data2[1].Trim().Replace(" ", "-");
        }
        MenuURL2.Text = myQu;
        MenuProfile2.Text = "/" + "خبرها" + MenuProfile;
    }

    protected void SetURL4Tourist2()
    {
        string[] Data2 = DropDownList9.Text.Split('-');
        string[] Data3 = DropDownList10.Text.Split('-');
        string[] Data4 = DropDownList11.Text.Split('-');
        string myQu = "";
        string MenuProfile = "";
        if (Data2[0].ToString() != "" && Data2[0].ToString() != "نامشخص")
        {
            myQu += "&Country=" + Data2[0];
            string[] NN = Data2[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data3[0].ToString() != "" && Data3[0].ToString() != "نامشخص")
        {
            myQu += "&City=" + Data3[0];
            string[] NN = Data3[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        if (Data4[0].ToString() != "" && Data4[0].ToString() != "نامشخص")
        {
            myQu += "&Area=" + Data4[0];
            string[] NN = Data4[1].Split('|');
            MenuProfile += "/" + NN[0].Trim().Replace(" ", "-");
        }
        MenuURL2.Text = myQu;
        MenuProfile2.Text = "/" + "جاذبه-ها" + MenuProfile;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "تور")
        {
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;
            DropDownList4.Enabled = true;
            DropDownList5.Enabled = true;
            sl1.Visible = true;
            sl2.Visible = true;
            sl3.Visible = true;
            sl4.Visible = true;
            sl5.Visible = false;
            MenuURL.Text = "";
            SetURL4Tour();
        }
        else if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "هتل")
        {
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;
            DropDownList4.Enabled = true;
            DropDownList5.Enabled = false;
            sl1.Visible = false;
            sl2.Visible = true;
            sl3.Visible = true;
            sl4.Visible = true;
            sl5.Visible = false;
            MenuURL.Text = "";
            SetURL4Hotel();
        }
        else if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "جاذبه های گردشگری")
        {
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;
            DropDownList4.Enabled = true;
            DropDownList5.Enabled = false;
            sl1.Visible = false;
            sl2.Visible = true;
            sl3.Visible = true;
            sl4.Visible = true;
            sl5.Visible = false;
            MenuURL.Text = "";
            SetURL4Tourist();
        }
        else if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "اخبار")
        {
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;
            DropDownList4.Enabled = true;
            DropDownList5.Enabled = false;
            sl1.Visible = false;
            sl2.Visible = false;
            sl3.Visible = false;
            sl4.Visible = false;
            sl5.Visible = true;
            MenuURL.Text = "";
            SetURL4News();
        }
        else
        {
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList4.Enabled = false;
            DropDownList5.Enabled = false;
            sl1.Visible = false;
            sl2.Visible = false;
            sl3.Visible = false;
            sl4.Visible = false;
            sl5.Visible = false;
            MenuURL.Text = "";
        }
    }

    private void LoadLists()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            SqlDataReader dr = null;
            cmd.CommandText = "SELECT ID,Name FROM Country order by ID";
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList2.Items.Add("نامشخص");
            DropDownList9.Items.Add("نامشخص");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList2.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList9.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
            dr = null;
            cmd.CommandText = "SELECT ID,TourCat from TourCat order by ID";
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList5.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList8.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
            LoadCities();
            LoadArea();
            LoadCities2();
            LoadArea2();
        }
        catch (Exception exp)
        {
            con.Close();
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
            string[] Data = DropDownList2.Text.Split('-');
            if (Data.Length > 1)
            {
                SqlCommand cmd = new SqlCommand("select ID,Name from City where CountryID =" + Data[0], con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                DropDownList3.Items.Clear();
                DropDownList3.Items.Add("نامشخص");
                DropDownList4.Items.Clear();
                DropDownList4.Items.Add("نامشخص");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList3.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());

                    }
                }
                con.Close();
            }
        }
        catch (Exception exp)
        {
            con.Close();
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }

    private void LoadNewsCat()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select ID,CatName from NewsCat order by ID", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList6.Items.Clear();
            DropDownList12.Items.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList6.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                    DropDownList12.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            con.Close();
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
            string[] Data = DropDownList3.Text.Split('-');
            if (Data.Length > 1)
            {
                SqlCommand cmd = new SqlCommand("select ID,Name from Area where CityID =" + Data[0], con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                DropDownList4.Items.Clear();
                DropDownList4.Items.Add("نامشخص");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList4.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());

                    }
                }
                con.Close();
            }
        }
        catch (Exception exp)
        {
            con.Close();
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }

    private void LoadCities2()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = DropDownList9.Text.Split('-');
            if (Data.Length > 1)
            {
                SqlCommand cmd = new SqlCommand("select ID,Name from City where CountryID =" + Data[0], con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                DropDownList10.Items.Clear();
                DropDownList10.Items.Add("نامشخص");
                DropDownList11.Items.Clear();
                DropDownList11.Items.Add("نامشخص");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList10.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());

                    }
                }
                con.Close();
            }
        }
        catch (Exception exp)
        {
            con.Close();
            Label2.Text = exp.Message;
            Label2.ForeColor = Color.Red;
        }
    }

    private void LoadArea2()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = DropDownList10.Text.Split('-');
            if (Data.Length > 1)
            {
                SqlCommand cmd = new SqlCommand("select ID,Name from Area where CityID =" + Data[0], con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                DropDownList11.Items.Clear();
                DropDownList11.Items.Add("نامشخص");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList11.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());

                    }
                }
                con.Close();
            }
        }
        catch (Exception exp)
        {
            con.Close();
            Label2.Text = exp.Message;
            Label2.ForeColor = Color.Red;
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCities();
        LoadArea();
        if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "تور") SetURL4Tour();
        else if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "هتل") SetURL4Hotel();
        else if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "جاذبه های گردشگری") SetURL4Tourist();

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadArea();
        if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "تور") SetURL4Tour();
        else if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "هتل") SetURL4Hotel();
        else if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "جاذبه های گردشگری") SetURL4Tourist();
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetURL4Tour();
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "تور") SetURL4Tour();
        else if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "هتل") SetURL4Hotel();
        else if (DropDownList1.Items[DropDownList1.SelectedIndex].Text.ToString() == "جاذبه های گردشگری") SetURL4Tourist();
    }
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "تور")
        {
            DropDownList8.Enabled = true;
            DropDownList9.Enabled = true;
            DropDownList10.Enabled = true;
            DropDownList11.Enabled = true;
            dl1.Visible = true;
            dl2.Visible = true;
            dl3.Visible = true;
            dl4.Visible = true;
            dl5.Visible = false;
            MenuURL2.Text = "";
            SetURL4Tour2();
        }
        else if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "هتل")
        {
            DropDownList8.Enabled = true;
            DropDownList9.Enabled = true;
            DropDownList10.Enabled = true;
            DropDownList11.Enabled = false;
            dl1.Visible = false;
            dl2.Visible = true;
            dl3.Visible = true;
            dl4.Visible = true;
            dl5.Visible = false;
            MenuURL2.Text = "";
            SetURL4Hotel2();
        }
        else if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "جاذبه های گردشگری")
        {
            
            dl1.Visible = false;
            dl2.Visible = true;
            dl3.Visible = true;
            dl4.Visible = true;
            dl5.Visible = false;
            MenuURL2.Text = "";
            SetURL4Tourist2();
        }
        else if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "اخبار")
        {
            dl1.Visible = false;
            dl2.Visible = false;
            dl3.Visible = false;
            dl4.Visible = false;
            dl5.Visible = true;
            MenuURL2.Text = "";
            SetURL4News2();
        }
        else
        {
            DropDownList8.Enabled = false;
            DropDownList9.Enabled = false;
            DropDownList10.Enabled = false;
            DropDownList11.Enabled = false;
            MenuURL2.Text = "";
            dl1.Visible = false;
            dl2.Visible = false;
            dl3.Visible = false;
            dl4.Visible = false;
            dl5.Visible = false;
        }
    }
    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetURL4Tour2();
    }
    protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCities2();
        LoadArea2();
        if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "تور") SetURL4Tour2();
        else if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "هتل") SetURL4Hotel2();
        else if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "جاذبه های گردشگری") SetURL4Tourist2();
    }
    protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadArea2();
        if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "تور") SetURL4Tour2();
        else if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "هتل") SetURL4Hotel2();
        else if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "جاذبه های گردشگری") SetURL4Tourist2();
    }
    protected void DropDownList11_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "تور") SetURL4Tour2();
        else if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "هتل") SetURL4Hotel2();
        else if (DropDownList7.Items[DropDownList7.SelectedIndex].Text.ToString() == "جاذبه های گردشگری") SetURL4Tourist2();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] Data = MenuList4.Text.Split('-');
            SqlCommand cmd = new SqlCommand("select MenuList.ID,MenuList.MenuName from (select * from MenuList where ID = " + Data[0] + ") as CD,MenuList where CD.ParentId = MenuList.ParentId order by MenuList.SO", con);
            SqlDataReader dr = null;
            ListBox1.Items.Clear();
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr[0].ToString() == "0") continue;
                    ListBox1.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label3.Text = exp.Message;
            Label3.ForeColor = Color.Red;
        }
    }

    [System.Web.Services.WebMethod]
    public static string SortMenu(string Request)
    {
        string returnValue="";
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string[] ListT = Request.Split('-');
            string mQu = "";
            for (int i = 0; i < ListT.Length-1; i++)
            {
                mQu += "UPDATE MenuList Set SO = " + CheckNull((i + 1).ToString(), 0) + " WHERE ID = " + ListT[i] + " ; ";
            }
            SqlCommand cmd = new SqlCommand(mQu, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            returnValue = "1";
        }
        catch (Exception exp)
        {
            returnValue = "0";
        }
        return returnValue;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string mQu = "";
            for (int i = 0; i < ListBox1.Items.Count; i++)
            {
                string[] Data = ListBox1.Items[i].Text.Split('-');
                mQu += "UPDATE MenuList Set SO = " + CheckNull((i+1).ToString(), 0) + " WHERE ID = " + Data[0] + " ; ";
            }
            SqlCommand cmd = new SqlCommand(mQu, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Label3.Text = "عملیات با موفقیت انجام شد";
            Label3.ForeColor = Color.Green ;
        }
        catch (Exception exp)
        {
            Label3.Text = exp.Message;
            Label3.ForeColor = Color.Red;
        }
    }
    protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetURL4News2();
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetURL4News();
    }
}