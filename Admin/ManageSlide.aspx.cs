using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Data;
using System.IO;

public partial class Admin_ManageSlide : System.Web.UI.Page
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
        if ((Session["User"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
        if (!IsPostBack)
        {
            LoadList();
        }
    }

    protected void LoadList()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select * from manageslides order by ID", con);
            SqlDataReader dr = null;
            con.Open();
            dr = null;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr[0].ToString() == "1")
                    {
                        if (dr[2].ToString() == "False") DropDownList1.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList2.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "2")
                    {
                        if (dr[2].ToString() == "False") DropDownList3.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList4.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "3")
                    {
                        if (dr[2].ToString() == "False") DropDownList5.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList6.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "4")
                    {
                        if (dr[2].ToString() == "False") DropDownList7.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList8.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "5")
                    {
                        if (dr[2].ToString() == "False") DropDownList9.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList10.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "6")
                    {
                        if (dr[2].ToString() == "False") DropDownList11.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList12.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "7")
                    {
                        if (dr[2].ToString() == "False") DropDownList13.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList14.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "8")
                    {
                        if (dr[2].ToString() == "False") DropDownList15.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList16.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "9")
                    {
                        if (dr[2].ToString() == "False") DropDownList17.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList18.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "10")
                    {
                        if (dr[2].ToString() == "False") DropDownList19.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList20.Text = "مخفی";

                    }
                    else if (dr[0].ToString() == "11")
                    {
                        if (dr[2].ToString() == "False") DropDownList21.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList22.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "12")
                    {
                        if (dr[2].ToString() == "False") DropDownList23.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList24.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "13")
                    {
                        if (dr[2].ToString() == "False") DropDownList25.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList26.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "14")
                    {
                        if (dr[2].ToString() == "False") DropDownList27.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList28.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "15")
                    {
                        if (dr[2].ToString() == "False") DropDownList29.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList30.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "16")
                    {
                        if (dr[2].ToString() == "False") DropDownList31.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList32.Text = "مخفی";
                    }
                    else if (dr[0].ToString() == "17")
                    {
                        if (dr[2].ToString() == "False") DropDownList33.Text = "مخفی";
                        if (dr[3].ToString() == "False") DropDownList34.Text = "مخفی";
                    }
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label1.Text =  exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string mQ = "";
            string V1="",V2="";
            string myQ = "";
            if (DropDownList1.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList2.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 1; ";
            mQ += myQ;
            if (DropDownList3.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList4.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 2; ";
            mQ += myQ;
            if (DropDownList5.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList6.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 3; ";
            mQ += myQ;
            if (DropDownList7.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList8.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 4; ";
            mQ += myQ;
            if (DropDownList9.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList10.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 5; ";
            mQ += myQ;
            if (DropDownList11.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList12.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 6; ";
            mQ += myQ;
            if (DropDownList13.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList14.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 7; ";
            mQ += myQ;
            if (DropDownList15.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList16.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 8; ";
            mQ += myQ;
            if (DropDownList17.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList18.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 9; ";
            mQ += myQ;
            if (DropDownList19.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList20.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 10; ";
            mQ += myQ;
            if (DropDownList21.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList22.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 11; ";
            mQ += myQ;
            if (DropDownList23.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList24.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 12; ";
            mQ += myQ;
            if (DropDownList25.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList26.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 13; ";
            mQ += myQ;
            if (DropDownList27.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList28.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 14; ";
            mQ += myQ;
            if (DropDownList29.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList30.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 15; ";
            mQ += myQ;
            if (DropDownList31.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList32.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 16; ";
            mQ += myQ;
            if (DropDownList33.Text.Trim() == "نمایش") V1 = "1";
            else V1 = "0";
            if (DropDownList34.Text.Trim() == "نمایش") V2 = "1";
            else V2 = "0";
            myQ = "Update manageslides Set Slide1 = " + V1 + " , Slide2 = " + V2 + " WHERE ID = 17; ";
            mQ += myQ;
            SqlCommand cmd = new SqlCommand(mQ, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            con.Close();
            Label1.Text = "عملیات با موفقیت انجام شد";
            Label1.ForeColor = Color.Green;
        }
        catch (Exception exp)
        {
            Label1.Text = exp.Message;
            Label1.ForeColor = Color.Red;
        }
    }
}