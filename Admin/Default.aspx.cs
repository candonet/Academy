using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void LogoutUser()
    {
        string v = Request.QueryString["action"];
        if (v != null)
        {
            if (v == "logout")
            {
                Session.Clear();
                Response.Redirect("~/");
            }
        }
        else
        {
            //TitleTour.InnerHtml = "خطا";
            //BodyTour.InnerHtml = "صفحه مورد نظر یافت نشد";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["User"]) != null)
        {
            if (!IsPostBack)
            {
                Label1.Text = Session["User"].ToString();
            }
        }
        else
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }
}