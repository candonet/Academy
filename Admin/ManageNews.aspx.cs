using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageNews : System.Web.UI.Page
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AddNews.aspx");
    }
    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
            SqlDataSource2.InsertParameters[0].DefaultValue = TextBox1.Text.Trim();
            SqlDataSource2.Insert();
            Label2.Text = "دسته جدید با موفقیت ثبت شد";
            Label2.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            Label2.Text = "مقادیر را کامل پر کنید";
            Label2.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ManageUncheckedNews.aspx");
    }
}