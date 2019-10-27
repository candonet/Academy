using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManagePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
    }
    protected void CheckSafe()
    {
        if ((Session["User"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AddPage.aspx");
    }
}