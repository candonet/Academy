using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;

public partial class ViewHotel : System.Web.UI.Page
{
    public static string Decode(string input)
    {
        string ex = "";
        if (string.IsNullOrEmpty(input)) return "0";
        for (int i = 0; i < input.Length; i++)
        {

            try
            {
                string b = Convert.ToInt64(input.Substring(i, 1)).ToString();
                ex += b;
            }
            catch { }
        }
        if (string.IsNullOrEmpty(ex)) return "0";

        return ex;
    }
    protected void LoadHotel()
    {
        //string v = Request.QueryString["HotelID"];
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 4) v = HttpUtility.UrlDecode(NNN[4]);
        else v = Request.QueryString["HotelID"];
        if (v != null && v.Trim() != "" )
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {

                SqlCommand cmd = new SqlCommand("select Title,Tozihat,Setare,AboutHotel,KeyWord,ID,IconImage,HotelProfile FROM Hotel WHERE Active = 1 and (HotelProfile like N'" + v + "' OR ID = " + Decode(v) + " )", con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                string HotelID = "";
                bool flg = false;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Label1.Text = dr[0].ToString();
                        this.Title = dr[0].ToString();
                        Header.Description = dr[1].ToString();
                        HtmlMeta Graph = new HtmlMeta();
                        Graph.Name = "og:type";
                        Graph.Content = "product";
                        Header.Controls.Add(Graph);
                        Graph = new HtmlMeta();
                        Graph.Name = "og:image";
                        Graph.Content = dr["IconImage"].ToString();
                        Header.Controls.Add(Graph);
                        Graph = new HtmlMeta();
                        Graph.Name = "og:title";
                        Graph.Content = dr[0].ToString();
                        Header.Controls.Add(Graph);
                        Graph = new HtmlMeta();
                        Graph.Name = "og:description";
                        Graph.Content = dr[1].ToString();
                        Header.Controls.Add(Graph);
                        Graph = new HtmlMeta();
                        Graph.Name = "og:url";
                        Graph.Content = NN;
                        Header.Controls.Add(Graph);
                        Graph = new HtmlMeta();
                        Graph.Name = "og:site_name";
                        Graph.Content = this.Title ;
                        Header.Controls.Add(Graph);
                        Graph = new HtmlMeta();
                        Graph.Name = "twitter:card";
                        Graph.Content = "summary";
                        Header.Controls.Add(Graph);
                        Graph = new HtmlMeta();
                        Graph.Name = "twitter:image:src";
                        Graph.Content = dr["IconImage"].ToString();
                        Header.Controls.Add(Graph);
                        Graph = new HtmlMeta();
                        Graph.Name = "twitter:title";
                        Graph.Content = dr[0].ToString();
                        Header.Controls.Add(Graph);
                        Graph = new HtmlMeta();
                        Graph.Name = "twitter:description";
                        Graph.Content = dr[1].ToString();
                        Header.Controls.Add(Graph);
                        Graph = new HtmlMeta();
                        Graph.Name = "twitter:domain";
                        Graph.Content = NN;
                        Header.Controls.Add(Graph);
                        Graph = new HtmlMeta();
                        Graph.Name = "twitter:creator";
                        Graph.Content = "www.abcsafar.com";
                        Header.Controls.Add(Graph);
                        int n = Convert.ToInt16(dr[2].ToString());
                        string ExitTxt="";
                        for (int i = 0; i < n; i++)
                            ExitTxt += "<img src='/images/star.ico' />";
                        Label2.Text = ExitTxt;
                        Label3.Text = dr[3].ToString();
                        Label4.Text = dr[1].ToString();
                        flg = true;
                        this.MetaKeywords = dr["KeyWord"].ToString();
                        HotelID = dr["ID"].ToString();
                        Header.Keywords = dr["KeyWord"].ToString();
                        Label7.Text = dr["HotelProfile"].ToString().Replace("-", " ");
                    }
                }
                con.Close();
                if (flg == true)
                {
                    v = HotelID;
                    SqlDataSource1.SelectCommand = "SELECT InfoHotel.[Nam] FROM [HotelDetail],InfoHotel WHERE ([HotelID] = " + v + ") AND InfoHotel.ID = HotelDetail.Nam";
                    LoadFirstPic(v);
                    LoadAllPics(v);
                    LoadTakmili(v);
                    GetCounts(v);
                    GetAVG(v);
                    LoadComments(v);
                    TitleTour.Visible = false;
                }
                else
                {
                    this.Title = "خطا";
                    TitleTour.InnerHtml = "خطا";
                    BodyTour.InnerHtml = "متاسفانه هتل مورد نظر یافت نشد";
                }
            }
            catch (Exception exp)
            {
                this.Title = "خطا";
                TitleTour.InnerHtml = "خطا";
                BodyTour.InnerHtml = "متاسفانه هتل مورد نظر یافت نشد";
            }
            finally
            {
                con.Close();
            }
        }
        else
        {
            this.Title = "خطا";
            TitleTour.InnerHtml = "خطا";
            BodyTour.InnerHtml = "صفحه مورد نظر یافت نشد";
        }
    }

    private void MessageBox(string MessageText)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("alert('" + MessageText + "')");
        sb.Append("</script>");
        Page.RegisterStartupScript("show2", sb.ToString());
    }
    int bbbc = 0;
    private void SetValue(string MessageText,string INdex)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("SetPro(" + MessageText + "," +INdex  + ")");
        sb.Append("</script>");
        bbbc++;
        Page.RegisterStartupScript("SetPro" + bbbc.ToString(), sb.ToString());
    }

    protected void LoadFirstPic(string HID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT top 1 ImageAddress FROM HotelImage where HotelID = " + HID + " order by ID", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                img1.ImageUrl = "/IMG/" + dr[0].ToString();
            }
            con.Close();
        }
        catch {  }
        finally
        {
            con.Close();
        }
    }


    protected void GetCounts(string HID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string myQu = "select COUNT(ID) from HotelComment WHERE HotelID = " + HID + " AND sts = 1;";
            myQu += "select COUNT(ID) from HotelComment WHERE HotelID = " + HID + " AND KindID = 1 AND sts = 1;";
            myQu += "select COUNT(ID) from HotelComment WHERE HotelID = " + HID + " AND KindID = 2 AND sts = 1;";
            myQu += "select COUNT(ID) from HotelComment WHERE HotelID = " + HID + " AND KindID = 3 AND sts = 1;";
            myQu += "select COUNT(ID) from HotelComment WHERE HotelID = " + HID + " AND KindID = 4 AND sts = 1;";
            myQu += "select COUNT(ID) from HotelComment WHERE HotelID = " + HID + " AND KindID = 5 AND sts = 1;";
            SqlCommand cmd = new SqlCommand(myQu, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                lb1.Text = dr[0].ToString();
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                lb2.Text = dr[0].ToString();
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                lb3.Text = dr[0].ToString();
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                lb4.Text = dr[0].ToString();
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                lb5.Text = dr[0].ToString();
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                lb6.Text = dr[0].ToString();
            }
            con.Close();
        }
        catch { }
        finally
        {
            con.Close();
        }
    }

    protected void GetAVG(string HID)
    {
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 5) v = NNN[5];
        else v = Request.QueryString["Type"];
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string myQu = "";
            if (v == null || v == "1")
            {
                myQu = "select ROUND(AVG(CAST(Keifiat AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(Tamizi AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(Amalkard AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(Tafrihat AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(Mantaqe AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(Arzesh AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND sts = 1;";
                myQu += "select COUNT(ID) from HotelComment WHERE HotelID = " + HID + " AND sts = 1;";
            }
            else
            {
                int typeID = Convert.ToInt16(v);
                myQu = "select ROUND(AVG(CAST(Keifiat AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(Tamizi AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(Amalkard AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(Tafrihat AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(Mantaqe AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(Arzesh AS FLOAT)), 1) from HotelComment WHERE HotelID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select COUNT(ID) from HotelComment WHERE HotelID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
            }
            SqlCommand cmd = new SqlCommand(myQu, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            decimal Sum = 0;
            if (dr.HasRows && dr != null)
            {
                dr.Read();
                if (dr[0] != DBNull.Value)
                {
                    SetValue(dr[0].ToString(), "1");
                    Sum += Convert.ToDecimal(dr[0].ToString());
                }
                //SetValue(dr[0].ToString(), "1");
                
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                if (dr[0] != DBNull.Value)
                {
                    SetValue(dr[0].ToString(), "2");
                    Sum += Convert.ToDecimal(dr[0].ToString());
                }
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                if (dr[0] != DBNull.Value)
                {
                    SetValue(dr[0].ToString(), "3");
                    Sum += Convert.ToDecimal(dr[0].ToString());
                }
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                if (dr[0] != DBNull.Value)
                {
                    SetValue(dr[0].ToString(), "4");
                    Sum += Convert.ToDecimal(dr[0].ToString());
                }
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                if (dr[0] != DBNull.Value)
                {
                    SetValue(dr[0].ToString(), "5");
                    Sum += Convert.ToDecimal(dr[0].ToString());
                }
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                if (dr[0] != DBNull.Value)
                {
                    SetValue(dr[0].ToString(), "6");
                    Sum += Convert.ToDecimal(dr[0].ToString());
                }
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                CountSP.Text = dr[0].ToString();
            }
            decimal aVN= Math.Round((Sum / 6),2);
            if (aVN > 0 && aVN <= 2)
                RANK.Text = "خیلی بد";
            else if (aVN > 2 && aVN <= 4)
                RANK.Text = "بد";
            else if (aVN > 4 && aVN <= 6)
                RANK.Text = "متوسط";
            else if (aVN > 6 && aVN <= 8)
                RANK.Text = "خوب";
            else if (aVN > 6 && aVN <= 10)
                RANK.Text = "خیلی خوب";
            SetEmtiaz((aVN.ToString()));
            con.Close();
        }
        catch(Exception exp) { }
        finally
        {
            con.Close();
        }
    }

    private void SetEmtiaz(string Emtiaz)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("SetEmtiaz(" + Emtiaz + ")");
        sb.Append("</script>");
        bbbc++;
        Page.RegisterStartupScript("SetPro" + bbbc.ToString(), sb.ToString());
    }

    protected void LoadTakmili(string HID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Room,Address,Tel,Site,SiteFilter FROM takmiliHotel WHERE HotelID =" + HID + " order by ID", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                lblRoom.Text = dr[0].ToString();
                lblAddress.Text = dr[1].ToString();
                lbltel.Text = dr[2].ToString();
                if (dr["SiteFilter"].ToString() == "False") HyperLink1.CssClass = "FilterLink";
                HyperLink1.Text = dr[3].ToString();
                HyperLink1.NavigateUrl = "http://" + dr[3].ToString();
            }
            con.Close();
        }
        catch { }
        finally
        {
            con.Close();
        }
    }

    protected void LoadAllPics(string HID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select ImageAddress FROM HotelImage where HotelID = " + HID + " order by ID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList1.DataSource = ds.Tables[0].DefaultView;
            DataList1.DataBind();
        }
        catch (Exception exp)
        {
           
        }
        finally
        {
            con.Close();
        }
    }

    [System.Web.Services.WebMethod]
    public static string VoteToUser(string Requesto)
    {
        try
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string returnValue = string.Empty;
            string[] Data = Requesto.Split(':');
            string PostID = Data[0].Trim().ToLower();
            string opr = Data[1].Trim().ToLower();
            string TableID = Data[2].Trim().ToLower();
            if (opr.ToLower() == "p") opr = "M";
            else if (opr.ToLower() == "m") opr = "P";
            if (PostID != "" && opr != "" && TableID != "")
            {
                try
                {
                    string ipaddress = "";
                    HttpRequest request = HttpContext.Current.Request;
                    ipaddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (ipaddress == "" || ipaddress == null)
                        ipaddress = request.ServerVariables["REMOTE_ADDR"];
                    SqlCommand cmd = new SqlCommand("UPDATE VoteHotel Set CommentID = CommentID where IPAdd = '" + ipaddress + "' AND CommentID = " + PostID, con);
                    con.Open();
                    int n = cmd.ExecuteNonQuery();
                    con.Close();
                    if (n == 0)
                    {
                        string myQu = "";
                        if (opr == "M") myQu = "Update HotelComment Set emMan = emMan + 1 WHERE ID = " + PostID + ";";
                        else myQu = "Update HotelComment Set emMos = emMos + 1 WHERE ID = " + PostID + ";";
                        myQu+="INSERT INTO VoteHotel(CommentID,IPAdd) VALUES(" + PostID + ",'" + ipaddress + "');";
                        cmd.CommandText = myQu;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        return "امتیاز شما ثبت شد" + "-" + TableID + "-" + opr;
                    }
                    else
                    {
                        return "شما قبلا امتیاز داده‌اید" + "-" + TableID;
                    }

                }
                catch
                {
                    returnValue = "خطا" + "-" + TableID ;
                }
            }
            else
            {
                returnValue = "خطا" + "-" + TableID ;
            }
            return returnValue;
        }
        catch
        {
            return "خطا";
        }
    }

    protected void LoadComments(string HID)
    {
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 5) v = NNN[5];
        else v = Request.QueryString["Type"];
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string mQu = "";

            if (v == null || v == "1")
                mQu = "SELECT (SELECT SUM(emMos) from HotelComment where HotelComment.UserID = Members.ID) as Bomba1,(SELECT SUM(emMan) from HotelComment where HotelComment.UserID = Members.ID) as Bomba2,(SELECT COUNT(ID) from HotelComment where HotelComment.UserID = Members.ID) as Bomba3,emMos,emMan,HotelComment.ID as Aydi,NamLast,Title,Tozihat,SUBSTRING(Tozihat, 1, 220) AS TozihatKot,KindSafar.Nam as KIND,TarikhM,PostDate,Advice,avatar as AksAvatar from HotelComment,KindSafar,Members WHERE KindSafar.ID = HotelComment.KindID and HotelComment.UserID=Members.ID AND  HotelID = " + HID + " AND sts = 1 order by HotelComment.ID";
            else
            {
                int type = Convert.ToInt16(v);
                mQu = "SELECT (SELECT SUM(emMos) from HotelComment where HotelComment.UserID = Members.ID) as Bomba1,(SELECT SUM(emMan) from HotelComment where HotelComment.UserID = Members.ID) as Bomba2,(SELECT COUNT(ID) from HotelComment where HotelComment.UserID = Members.ID) as Bomba3,emMos,emMan,HotelComment.ID as Aydi,NamLast,Title,Tozihat,SUBSTRING(Tozihat, 1, 220) AS TozihatKot,KindSafar.Nam as KIND,TarikhM,PostDate,Advice,avatar as AksAvatar from HotelComment,KindSafar,Members WHERE KindSafar.ID = HotelComment.KindID and HotelComment.UserID=Members.ID AND HotelID = " + HID + " AND KindID = " + (type - 1).ToString() + " AND sts = 1 Order BY HotelComment.ID";
            }
            SqlCommand cmd = new SqlCommand(mQu, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList3.DataSource = ds.Tables[0].DefaultView;
            DataList3.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
                CommentTable.Visible = true;
        }
        catch (Exception exp)
        {
            MessageBox(exp.Message);
        }
        finally
        {
            con.Close();
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            SendComment.Visible = false;
            LoginTable.Visible = true;
        }
        else
        {
            SendComment.Visible = true;
            esmFamil.Text = Session["EsmFamil"].ToString();
            emeil.Text = Session["UserEmail"].ToString();
            LoginTable.Visible = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadHotel();
            
            LoadType();
            //RemoveSlideShows();
            LoadSlides();
        }
    }

    protected void LoadSlides()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 12", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr[0].ToString() == "False")
                    {
                        HtmlGenericControl divMaster1 = (HtmlGenericControl)this.Master.FindControl("page1");
                        divMaster1.Visible = false;
                    }
                    if (dr[1].ToString() == "False")
                    {
                        HtmlGenericControl divMaster2 = (HtmlGenericControl)this.Master.FindControl("HorSlide");
                        divMaster2.Visible = false;
                    }
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {

        }
    }
    protected void LoadType()
    {
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 5) v = NNN[5];
        else v = Request.QueryString["Type"];
        if (v != null)
        {
            SetDefaultCSS();
            if (v == "1") tag1.Attributes.Add("class", "FirstColSelected");
            if (v == "2") tag2.Attributes.Add("class", "FirstColSelected");
            if (v == "3") tag3.Attributes.Add("class", "FirstColSelected");
            if (v == "4") tag4.Attributes.Add("class", "FirstColSelected");
            if (v == "5") tag5.Attributes.Add("class", "FirstColSelected");
            if (v == "6") tag6.Attributes.Add("class", "FirstColSelected");
        }
    }

    protected void SetDefaultCSS()
    {
        tag1.Attributes.Add("class", "FirstCol");
        tag2.Attributes.Add("class", "FirstCol");
        tag3.Attributes.Add("class", "FirstCol");
        tag4.Attributes.Add("class", "FirstCol");
        tag5.Attributes.Add("class", "FirstCol");
        tag6.Attributes.Add("class", "FirstCol");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
    int CommentCounter = -1;
    protected void DataList3_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        Label lb = ((Label)e.Item.FindControl("TaeedCH"));
        Image Avatarimg = ((Image)e.Item.FindControl("Image2"));
        if (lb.Text == "True")
        {
            lb.Text = "این هتل را به شما پیشنهاد می کنم";
            lb.CssClass = "Taed";
        }
        else
            lb.Text = "";
        string AvatarPath = MapPath("~/" + Avatarimg.ImageUrl);
        if (System.IO.File.Exists(AvatarPath) == false)
        {
            Avatarimg.ImageUrl = "/images/Pavatar.png";
        }
        else
        {
            Avatarimg.ImageUrl = Avatarimg.ImageUrl;
        }
        //HtmlControl div = e.Item.FindControl("MoreInfo") as HtmlControl;
        //try
        //{


        //    HtmlControl div = e.Item.FindControl("MoreInfo") as HtmlControl;
        //    div.ID = "MoreInfo" + (CommentCounter + 1).ToString();
        //    CommentCounter++;
        //}
        //catch { MessageBox("error"); }
    }
    protected bool CheckForPost()
    {
        bool flg = false;
        if (esmFamil.Text.Trim() == "")
        {
            flg = true;
            ver1.Text = "*";
        }
        else
        {
            ver1.Text = "";
        }
        if (emeil.Text.Trim() == "")
        {
            flg = true;
            ver2.Text = "*";
        }
        else
        {
            ver2.Text = "";
        }
        if (shoql.Text.Trim() == "")
        {
            flg = true;
            ver3.Text = "*";
        }
        else
        {
            ver3.Text = "";
        }
        if (onvan.Text.Trim() == "")
        {
            flg = true;
            ver4.Text = "*";
        }
        else
        {
            ver4.Text = "";
        }
        if (didgah.Text.Trim() == "")
        {
            flg = true;
            ver5.Text = "*";
        }
        else
        {
            ver5.Text = "";
        }
        if (!FileUpload1.HasFile)
        {
            flg = true;
            ver6.Text = "*";
        }
        else
        {
            ver6.Text = "";
        }
        if (Path.GetExtension(FileUpload1.FileName).ToString().ToLower() != ".jpg")
        {
            flg = true;
            ver6.Text = "پسوند فایل انتخاب شده نا معتبر میباشد";
        }
        else
        {
            ver6.Text = "";
        }
        return flg;
    }
    /// <summary>
    /// 1 for text - 0 for number
    /// </summary>
    /// <param name="InputValue"></param>
    /// <param name="i"></param>
    /// <returns></returns>
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
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (CheckForPost() == false)
            {
                string v = Request.QueryString["HotelID"];
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {

                    string myQu = "";
                    string KindID = "" + (DropDownList14.SelectedIndex + 1).ToString();
                    string NamLs = "," + CheckNull(esmFamil.Text.Trim(), 1);
                    string Eml = "," + CheckNull(emeil.Text.Trim(), 1);
                    string ost = "," + CheckNull(DropDownList1.Text, 1);
                    string salt = "," + CheckNull((DropDownList11.Text + " " + DropDownList12.Text + " " + DropDownList13.Text), 1);
                    string shql = "," + CheckNull(shoql.Text.Trim(), 1);
                    string Tarikhks = "," + CheckNull((DropDownList2.Text + " " + DropDownList3.Text + " " + DropDownList4.Text), 1);
                    string onv = "," + CheckNull(onvan.Text.Trim(), 1);
                    string toz = "," + CheckNull(didgah.Text.Trim().Replace("\n", "<br/>"), 1);
                    string adv = "";
                    if (CheckBox1.Checked == true) adv = ",1";
                    else adv = ",0";
                    string keifi = "," + CheckNull(DropDownList5.Text, 0);
                    string tamiz = "," + CheckNull(DropDownList6.Text, 0);
                    string amal = "," + CheckNull(DropDownList7.Text, 0);
                    string tafri = "," + CheckNull(DropDownList8.Text, 0);
                    string mantq = "," + CheckNull(DropDownList9.Text, 0);
                    string arze = "," + CheckNull(DropDownList10.Text, 0);
                    string HtlID = "," + v;
                    string UsrID = "," + Session["UserID"].ToString();
                    string PostD = "," + CheckNull(GetCurrentDate(), 1);
                    string ava = "," + Session["Avatar"].ToString();
                    myQu = "INSERT INTO HotelComment(KindID,NamLast,Email,Ostan,SalTavalod,Shoql,TarikhM,Title,Tozihat,Advice,Keifiat,Tamizi,Amalkard,Tafrihat,Mantaqe,Arzesh,HotelID,UserID,PostDate,avatar) VALUES (";
                    myQu += KindID + NamLs + Eml + ost + salt + shql + Tarikhks + onv + toz + adv + keifi + tamiz + amal + tafri + mantq + arze + HtlID + UsrID + PostD + ava + ");";
                    myQu += "SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(myQu, con);
                    con.Open();
                    long CurrentID = Convert.ToInt64(cmd.ExecuteScalar());
                    con.Close();
                    string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                    string p = MapPath("~/Member/watcher/");
                    p += time;
                    FileUpload1.SaveAs(p);
                    cmd.CommandText = "insert into watcher(PicAdd,PostID,UserID) Values ('" + time + "' , " + CheckNull(CurrentID.ToString(), 0) + "," + CheckNull(Session["UserID"].ToString(), 0) + ");";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadComments(v);
                }
                catch (Exception exp) { MessageBox(exp.Message); }
                finally
                {
                    con.Close();
                }
            }
            else
                MessageBox("لطفا مقادیر را درست وارد کنید");
        }
    }

    protected string GetCurrentDate()
    {
        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
        int sal = pc.GetYear(dt);
        int mah = pc.GetMonth(dt);
        int roz = pc.GetDayOfMonth(dt);
        string M, R;
        if (mah < 10) M = "0" + mah.ToString();
        else M = mah.ToString();
        if (roz < 10) R = "0" + roz.ToString();
        else R = roz.ToString();
        return (sal.ToString() + "/" + M + "/" + R).ToString();
    }

    protected string GetCurrentTime()
    {
        int H = DateTime.Now.Hour;
        int M1 = DateTime.Now.Minute;
        string HH = H.ToString();
        string MM = M1.ToString();
        if (H < 10) HH = "0" + HH;
        if (M1 < 10) MM = "0" + MM;
        string Saat = (HH + ":" + MM).ToString();
        return Saat;
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        string returnValue = string.Empty;
        string User = UserNameLogin.Text;
        string Pass = PasswordLogin.Text;
        string Permission = string.Empty;
        if (User != "" && Pass != "")
        {
            try
            {
                SqlDataReader dr = null;
                string HashPass = Incode(Pass);
                SqlCommand cmd = new SqlCommand("SELECT status FROM Members WHERE Username like '" + User + "' AND Password like '" + HashPass + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if ((dr).HasRows == true)
                {
                    while (dr.Read())
                    {
                        if (dr[0].ToString() == "True")
                        {
                            returnValue = "1";
                            break;
                        }
                        else
                        {
                            returnValue = "این نام کاربری غیر فعال شده است";
                            break;
                        }
                    }
                }
                else
                    returnValue = "نام کاربری و کلمه عبور اشتباه می باشند";
                con.Close();
                if (returnValue == "1")
                {
                    cmd.CommandText = "select GroupID,GroupMember.UserID from GroupMember,Members where GroupMember.UserID = (select ID from Members where username = '" + User + "')  and GroupMember.UserID = Members.ID";
                    dr = null;
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        Session["GroupID"] = dr[0].ToString();
                        Session["UserID"] = dr[1].ToString();
                        SabteLog(dr[1].ToString());
                        if (dr[0].ToString() == "3")
                            FillSessions2(dr[1].ToString());
                        else
                            FillSessions(dr[1].ToString());
                    }
                    else
                    {
                        Session["GroupID"] = "none";
                    }
                    con.Close();
                }
                else
                {
                    ErrorMSG.Text = returnValue;
                    ErrorMSG.Visible = true;
                }

            }
            catch (SqlException ex)
            {
                returnValue = "خطا در اتصال به سرور - لطفا دوباره تلاش کنید";
                ErrorMSG.Text = returnValue;
                ErrorMSG.Visible = true;
            }
            finally
            {
                con.Close();
            }
        }
        else
        {
            returnValue = "لطفا مقادیر را پر کنید";
            ErrorMSG.Text = returnValue;
            ErrorMSG.Visible = true;
        }
    }
    protected void FillSessions2(string MemUserID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT AgencyDetail.nam as EsmFamil,AgencyDetail.email,Members.username from AgencyDetail,Members WHERE AgencyDetail.UserID = Members.ID AND AgencyDetail.UserID = " + MemUserID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Session["EsmFamil"] = dr[0].ToString();
                Session["UserEmail"] = dr[1].ToString();
                Session["Avatar"] = "/Agency/logo/" + dr[2].ToString() + ".jpg";
            }
            else
            {
                Session["EsmFamil"] = "درج نشده";
                Session["UserEmail"] = "درج نشده";
                Session["Avatar"] = "درج نشده";
            }
            con.Close();
        }
        catch { }
        finally
        {
            con.Close();
        }
    }
    protected void FillSessions(string MemUserID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT (MemberDetails.Name + ' ' + MemberDetails.Family) as EsmFamil,MemberDetails.Email,Members.username from MemberDetails,Members WHERE MemberDetails.MemberID = Members.ID AND MemberDetails.MemberID = " + MemUserID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Session["EsmFamil"] = dr[0].ToString();
                Session["UserEmail"] = dr[1].ToString();
                Session["Avatar"] = "/avatar/" + dr[2].ToString() + ".jpg";
            }
            else
            {
                Session["EsmFamil"] = "درج نشده";
                Session["UserEmail"] = "درج نشده";
                Session["Avatar"] = "درج نشده";
            }
            con.Close();
        }
        catch { }
        finally
        {
            con.Close();
        }
    }

    protected void SabteLog(string MemUserID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO LoginLog(UserID,LastTime) VALUES (" + MemUserID + ", '" + GetCurrentDate() + " - " + GetCurrentTime() + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch { }
        finally
        {
            con.Close();
        }
    }
    protected void RemoveSlideShows()
    {
        try
        {
            //System.Threading.Thread.Sleep(2000);
            HtmlGenericControl divMaster1 = (HtmlGenericControl)this.Master.FindControl("page1");
            divMaster1.Visible = false;
            HtmlGenericControl divMaster2 = (HtmlGenericControl)this.Master.FindControl("HorSlide");
            divMaster2.Visible = false;
        }
        catch { }
    }
    protected void DataList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}