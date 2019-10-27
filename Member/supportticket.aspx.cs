using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_supportticket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSafe();
    }
    protected void CheckSafe()
    {
        if ((Session["Member"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowIndex != -1)
        {
            if (e.Row.Cells[2].Text == "در انتظار پاسخ") e.Row.Cells[2].CssClass = "Entezar";
            else if (e.Row.Cells[2].Text == "پاسخ داده شده") e.Row.Cells[2].CssClass = "Pasokh";
            else if (e.Row.Cells[2].Text == "بسته") e.Row.Cells[2].CssClass = "Baste";
            e.Row.Cells[3].Text = "#" + e.Row.Cells[3].Text;
            e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='hand';this.style.backgroundColor='#efeeee';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";
            e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(GridView1, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("~/Member/viewticket.aspx?id=" + GridView1.SelectedRow.Cells[3].Text.ToString().Replace("#",""));
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
}