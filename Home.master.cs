using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class Home : System.Web.UI.MasterPage
{
    int scriptNumber = 0;
    protected void CheckForLogin()
    {
        try
        {
            //System.Threading.Thread.Sleep(2000);
            StringBuilder sb = new StringBuilder();
            string nnn = "";
            if (Session["EsmFamil"] != null)
            {
                nnn = Session["EsmFamil"].ToString();
            }
            else
            {
                nnn = "1";
            }
            sb.Append("<script type='text/javascript'>");
            sb.Append("ChangeLogin('" + nnn + "')");
            sb.Append("</script>");
            Page.RegisterStartupScript("function" + scriptNumber.ToString(), sb.ToString());
            scriptNumber++;
        }
        catch { }
    }

    public DataTable DataT = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        string LastQu = "SELECT ID,ParentID,MenuName,MenuProfile From MenuList where status = 1 order by SO";
        SqlDataAdapter dp = new SqlDataAdapter(LastQu, con);
        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dp);
        dp.FillSchema(DataT, SchemaType.Source);
        dp.Fill(DataT);
        showMenus2();
        CheckForLogin();
        LoadKeyWords();
    }
    protected void LoadKeyWords()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT SiteKey,BGColor,SiteDesc FROM SiteSetting WHERE ID = 1", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            StringBuilder st = new StringBuilder();
            int i = 1;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    var keywords = new HtmlMeta { Name = "keywords", Content = dr[0].ToString() };
                    head.Controls.Add(keywords);
                    string CurrentColor = dr[1].ToString();
                    MarkSite.Style.Add("background-color", "#" + CurrentColor);
                    var SiteDescr = new HtmlMeta { Name = "description", Content = dr["SiteDesc"].ToString() };
                    head.Controls.Add(SiteDescr);
                }
            }
            con.Close();

        }
        catch { }
        finally
        {
            con.Close();
        }
    }
    protected void showMenus()
    {
        StringBuilder st = new StringBuilder();
        st.Append(" <nav class='nav black-menu'><ul>");
        string childItems = getMenuItems(0);
        st.Append(childItems);
        st.Append("<div class='search-top'>");
        st.Append("<form action='/Search.aspx'>");
        st.Append("<input type='text'  placeholder='جستجو' name='word' class='inline-search1'>");
        st.Append("</form><div class='clear'></div>");
        st.Append("</div><div class='clear'></div>");
        st.Append("</ul></nav>");
        container.InnerHtml = st.ToString();
    }
    StringBuilder sbMenu = new StringBuilder();
    int childCount = 0;
    public string getMenuItems(int parentId)
    {

        var rowColl = DataT.AsEnumerable();
        var menuObj = from r in rowColl
                      where r.Field<int>(1) == parentId
                      select r;

        foreach (var obj in menuObj)
        {
            if (obj.ItemArray[2].ToString() == "منوی مادر و اصلی") continue;
            childCount = rowColl.Count(r => r.Field<int>(1) == obj.Field<int>(0));

            if (childCount > 0)
            {
                string TAG = "";
                if (obj.Field<int>(1) == 0)
                {
                    TAG = "<li><a class='drop' href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" >" + obj.Field<string>(2) + "</a><ul class='levels'>";
                }
                else
                {
                    TAG = "<li><a href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" >" + obj.Field<string>(2) + "</a><ul>";
                }
                sbMenu.Append(TAG);
                getMenuItems(obj.Field<int>(0));
            }
            else
            {

                sbMenu.Append("<li><a href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" >" + obj.Field<string>(2) + "</a></li>");
            }
        }

        sbMenu.Append("</ul>");
        return sbMenu.ToString();
    }

    protected void showMenus2()
    {
        StringBuilder st = new StringBuilder();
        st.Append(" <div id='nav'><ul>");
        string childItems = getMenuItems2(0);
        st.Append(childItems);
        st.Append("<div class='search-top'>");
        st.Append("<form action='/Search.aspx'>");
        st.Append("<input type='text'  placeholder='جستجو' name='word' class='inline-search'>");
        st.Append("</form>");
        st.Append("</div>");
        st.Append("<ul style='float:left;position:relative;border-right:solid 1px black' id='LoginMenuBTN'></ul>");
        st.Append("<div class='clear'></div>");

        st.Append("</div>\n");
        container.InnerHtml = st.ToString();
    }

    public string getMenuItems2(int parentId)
    {

        var rowColl = DataT.AsEnumerable();
        var menuObj = from r in rowColl
                      where r.Field<int>(1) == parentId
                      select r;

        foreach (var obj in menuObj)
        {
            if (obj.ItemArray[2].ToString() == "منوی مادر و اصلی") continue;
            childCount = rowColl.Count(r => r.Field<int>(1) == obj.Field<int>(0));

            if (childCount > 0)
            {
                string TAG = "";
                if (obj.Field<int>(1) == 0)
                {
                    TAG = "<li><a href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" >" + obj.Field<string>(2) + "</a><ul class='sub-menu'>\n";
                }
                else
                {
                    TAG = "<li><a href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" class='myArrow' >" + obj.Field<string>(2) + "</a><ul class='sub-menu'>\n";
                }
                sbMenu.Append(TAG);
                getMenuItems2(obj.Field<int>(0));
            }
            else
            {

                sbMenu.Append("<li><a href='" + obj.Field<string>(3).ToString() + "' onClick=\"if(this.href.substr(this.href.length-1,1) =='#') event.preventDefault();\" >" + obj.Field<string>(2) + "</a></li>\n");
            }
        }

        sbMenu.Append("</ul>\n");
        return sbMenu.ToString();
    }
}
