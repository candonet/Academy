using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Routing;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class ViewAgency : System.Web.UI.Page
{
    private void MessageBox(string MessageText)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("alert('" + MessageText + "')");
        sb.Append("</script>");
        Page.RegisterStartupScript("show2", sb.ToString());
    }
    protected string getMonthName(string InputData)
    {
        string returValue = "";
        string[] Data = InputData.Split('/');
        if (Data.Length == 3)
        {
            string Mah = Data[1].ToString();
            if (Mah == "01" || Mah == "1")
                returValue = Data[2] + " فروردین " + Data[0];
            else if (Mah == "02" || Mah == "2")
                returValue = Data[2] + " اردیبهشت " + Data[0];
            else if (Mah == "03" || Mah == "3")
                returValue = Data[2] + " خرداد " + Data[0];
            else if (Mah == "04" || Mah == "4")
                returValue = Data[2] + " تیر " + Data[0];
            else if (Mah == "05" || Mah == "5")
                returValue = Data[2] + " مرداد " + Data[0];
            else if (Mah == "06" || Mah == "6")
                returValue = Data[2] + " شهریور " + Data[0];
            else if (Mah == "07" || Mah == "7")
                returValue = Data[2] + " مهر " + Data[0];
            else if (Mah == "08" || Mah == "8")
                returValue = Data[2] + " آبان " + Data[0];
            else if (Mah == "09" || Mah == "9")
                returValue = Data[2] + " آذر " + Data[0];
            else if (Mah == "10" || Mah == "1")
                returValue = Data[2] + " دی " + Data[0];
            else if (Mah == "11" || Mah == "1")
                returValue = Data[2] + " بهمن " + Data[0];
            else if (Mah == "12" || Mah == "1")
                returValue = Data[2] + " اسفند " + Data[0];
        }
        else
            returValue = InputData;
        return returValue;
    }
    protected string GetCDATE()
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
        string CurrentDate = sal.ToString() + "/" + M + "/" + R;
        return CurrentDate;
    }
    protected string GetCDATE2()
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
        string CurrentDate = sal.ToString() + M + R;
        return CurrentDate;
    }
    protected void FillDataGrid1(string USID)
    {

        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string myQu = "AgencyDetail.UserID = " + USID;
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            SqlCommand cmd = new SqlCommand("select top 30 TourBase.nam , modat , tarikh1,tarikh2,kind,AgencyDetail.nam,TourBase.ID,(select MIN(CAST(LEFT(qeimat1, Patindex('%[^-.0-9]%', qeimat1 + 'x') - 1) AS Float)) from TourHotel Where TourID = TourBase.ID) as AB3,TourProfile,Qeimat1P,Qeimat1Pv From TourBase,AgencyDetail,TourHotel WHERE AgencyDetail.UserID = TourBase.UserID AND " + myQu + " AND TourHotel.ID in (select top 1 ID from TourHotel where TourBase.ID=TourHotel.TourID) and Tarikh2 > '" + GetCDATE() + "' order by TourBase.ID desc", con);
            dt.Columns.Add("عنوان", typeof(string));
            dt.Columns.Add("قیمت از", typeof(string));
            dt.Columns.Add("مدت اقامت", typeof(string));
            dt.Columns.Add("تاریخ", typeof(string));
            dt.Columns.Add("نوع سفر", typeof(string));
            dt.Columns.Add("آژانس", typeof(string));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("TourProfile", typeof(string));
            dt.Columns.Add("qeimat1p", typeof(string));
            dt.Columns.Add("qeimat1pv", typeof(string));
            dt.Columns.Add("Tarikh2", typeof(string));
            //dt.Columns.Add
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataRow NewRow = dt.NewRow();
                    NewRow[0] = dr[0].ToString();
                    NewRow[2] = dr[1].ToString();
                    NewRow[3] = getMonthName(dr[2].ToString()) + " الی " + getMonthName(dr[3].ToString());
                    NewRow[4] = dr[4].ToString();
                    NewRow[5] = dr[5].ToString();
                    NewRow[6] = dr[6].ToString();
                    NewRow[1] = dr[7].ToString();
                    NewRow[7] = dr[8].ToString();
                    NewRow[8] = dr[9].ToString();
                    NewRow[9] = dr[10].ToString();
                    NewRow[10] = dr[3].ToString();
                    dt.Rows.Add(NewRow);
                }
            }
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                Dakheli.InnerHtml = "هیچ تور فعالی وجود ندارد";
            }
        }
        catch (Exception exp)
        {


        }
        finally
        {
            con.Close();
        }

    }
    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].CssClass = "MMM";
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
        e.Row.Cells[11].Visible = false;
        if (e.Row.RowIndex != -1)
        {
            e.Row.CssClass = "ItemList";
            e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='hand';this.style.backgroundColor='#ffccff';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#ffffff';";
            //e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(GridView5, "Select$" + e.Row.RowIndex.ToString()));
        }
        else
        {
            e.Row.CssClass = "LabelHeader2";
        }
        if (e.Row.RowIndex != -1)
        {
            string[] tdate = e.Row.Cells[11].Text.Split('/');
            if (tdate[1].Length == 1) tdate[1] = "0" + tdate[1];
            if (tdate[2].Length == 1) tdate[2] = "0" + tdate[2];
            if (Convert.ToInt32(tdate[0] + tdate[1] + tdate[2]) >= Convert.ToInt32(GetCDATE2()))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    long n;
                    bool isNumeric = long.TryParse(e.Row.Cells[2].Text, out n);
                    if (isNumeric == true)
                        if (e.Row.Cells[2].Text != "0")
                            e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[2].Text)) + " تومان";
                        else
                        {
                            isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                            if (isNumeric == true)
                                e.Row.Cells[2].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                        }
                    else
                    {
                        isNumeric = long.TryParse(e.Row.Cells[9].Text, out n);
                        if (isNumeric == true)
                            e.Row.Cells[1].Text = string.Format("{0:#,##0}", decimal.Parse(e.Row.Cells[9].Text)) + " " + e.Row.Cells[10].Text;
                    }
                }
            }
            else
                e.Row.Visible = false;
        }
    }

    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Page.Response.Redirect("/Tours/" + GridView1.SelectedRow.Cells[7].Text.ToString());
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

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

    protected void GetCounts(string HID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string myQu = "select COUNT(ID) from AgencyComment WHERE AgencyID = " + HID + " AND sts = 1;";
            myQu += "select COUNT(ID) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = 1 AND sts = 1;";
            myQu += "select COUNT(ID) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = 2 AND sts = 1;";
            myQu += "select COUNT(ID) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = 3 AND sts = 1;";
            myQu += "select COUNT(ID) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = 4 AND sts = 1;";
            SqlCommand cmd = new SqlCommand(myQu, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                lbl1.Text = dr[0].ToString();
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                lbl2.Text = dr[0].ToString();
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                lbl3.Text = dr[0].ToString();
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                lbl4.Text = dr[0].ToString();
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                lbl5.Text = dr[0].ToString();
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
        if(NNN.Length>5) v = NNN[5];
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string myQu = "";
            if (v == null || v == "1" || v =="")
            {
                myQu = "select ROUND(AVG(CAST(ad1 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad2 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad3 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad4 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad5 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad6 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad7 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND sts = 1;";
                myQu += "select COUNT(ID) from AgencyComment WHERE AgencyID = " + HID + " AND sts = 1;";
            }
            else
            {
                int typeID = Convert.ToInt16(v);
                myQu = "select ROUND(AVG(CAST(ad1 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad2 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad3 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad4 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad5 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad6 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select ROUND(AVG(CAST(ad7 AS FLOAT)), 1) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
                myQu += "select COUNT(ID) from AgencyComment WHERE AgencyID = " + HID + " AND KindID = " + (typeID - 1).ToString() + " AND sts = 1;";
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
                if (dr[0] != DBNull.Value)
                {
                    SetValue(dr[0].ToString(), "7");
                    Sum += Convert.ToDecimal(dr[0].ToString());
                }
            }
            dr.NextResult();
            if (dr.HasRows)
            {
                dr.Read();
                CountSP.Text = dr[0].ToString();
            }
            decimal aVN = Math.Round((Sum / 7), 2);
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
        catch (Exception exp) { }
        finally
        {
            con.Close();
        }
    }

    protected void LoadComments(string HID)
    {
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 5) v = NNN[5];
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            string mQu = "";

            if (v == null || v == "1" || v == "")
                mQu = "SELECT (SELECT SUM(emMos) from AgencyComment where AgencyComment.UserID = Members.ID) as Bomba1,(SELECT SUM(emMan) from AgencyComment where AgencyComment.UserID = Members.ID) as Bomba2,(SELECT COUNT(ID) from AgencyComment where AgencyComment.UserID = Members.ID) as Bomba3,emMos,emMan,AgencyComment.ID as Aydi,NamLast,Title,Tozihat,SUBSTRING(Tozihat, 1, 220) AS TozihatKot,AgencyKind.Nam as KIND,TarikhM,PostDate,Advice,avatar as AksAvatar from AgencyComment,AgencyKind,Members WHERE AgencyKind.ID = AgencyComment.KindID and AgencyComment.UserID=Members.ID AND  AgencyID = " + HID + " AND sts = 1 order by AgencyComment.ID";
            else
            {
                int type = Convert.ToInt16(v);
                mQu = "SELECT (SELECT SUM(emMos) from AgencyComment where AgencyComment.UserID = Members.ID) as Bomba1,(SELECT SUM(emMan) from AgencyComment where AgencyComment.UserID = Members.ID) as Bomba2,(SELECT COUNT(ID) from AgencyComment where AgencyComment.UserID = Members.ID) as Bomba3,emMos,emMan,AgencyComment.ID as Aydi,NamLast,Title,Tozihat,SUBSTRING(Tozihat, 1, 220) AS TozihatKot,AgencyKind.Nam as KIND,TarikhM,PostDate,Advice,avatar as AksAvatar from AgencyComment,AgencyKind,Members WHERE AgencyKind.ID = AgencyComment.KindID and AgencyComment.UserID=Members.ID AND AgencyID = " + HID + " AND KindID = " + (type - 1).ToString() + " AND sts = 1 Order BY AgencyComment.ID";
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
                    SqlCommand cmd = new SqlCommand("UPDATE VoteAgency Set CommentID = CommentID where IPAdd = '" + ipaddress + "' AND CommentID = " + PostID, con);
                    con.Open();
                    int n = cmd.ExecuteNonQuery();
                    con.Close();
                    if (n == 0)
                    {
                        string myQu = "";
                        if (opr == "M") myQu = "Update AgencyComment Set emMan = emMan + 1 WHERE ID = " + PostID + ";";
                        else myQu = "Update AgencyComment Set emMos = emMos + 1 WHERE ID = " + PostID + ";";
                        myQu += "INSERT INTO VoteAgency(CommentID,IPAdd) VALUES(" + PostID + ",'" + ipaddress + "');";
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
                    returnValue = "خطا" + "-" + TableID;
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                returnValue = "خطا" + "-" + TableID;
            }
            return returnValue;
        }
        catch
        {
            return "خطا";
        }
    }

    int bbbc = 0;
    private void SetEmtiaz(string Emtiaz)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("SetEmtiaz(" + Emtiaz + ")");
        sb.Append("</script>");
        bbbc++;
        Page.RegisterStartupScript("SetPro" + bbbc.ToString(), sb.ToString());
    }

    private void SetValue(string MessageText, string INdex)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("SetPro(" + MessageText + "," + INdex + ")");
        sb.Append("</script>");
        bbbc++;
        Page.RegisterStartupScript("SetPro" + bbbc.ToString(), sb.ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.RouteData.Values.Count > 0)
        {
            var NN = Request.Url.AbsoluteUri.ToString();
            string[] NNN = NN.Split('/');
            string HotelName = NNN[4];
            LoadAgency(HotelName);
            LoadType();
        }
        else
        {
            this.Title = "خطا";
            TitleTour.InnerHtml = "خطا";
            BodyTour.InnerHtml = "متاسفانه آژانس مورد نظر یافت نشد";
        }

        RemoveSlideShows();
    }
    protected void LoadSlides()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 6", con);
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
    protected void LoadAgency(string inputValue)
    {
        if (inputValue != null && inputValue != "")
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("select nam,ID,UserID From AgencyDetail WHERE namEng = '" + inputValue + "' AND STS = 1", con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    TitleTour.Visible = false;
                    Label1.Text = dr[0].ToString();
                    this.Title = dr[0].ToString();
                    loadInfo1(dr[1].ToString());
                    GetCounts(dr[1].ToString());
                    GetAVG(dr[1].ToString());
                    LoadComments(dr[1].ToString());
                    FillDataGrid1(dr[2].ToString());
                }
                else
                {
                    TitleTour.Visible = true;
                    this.Title = "خطا";
                    TitleTour.InnerHtml = "خطا";
                    BodyTour.InnerHtml = "متاسفانه آژانس مورد نظر یافت نشد";
                }
                con.Close();
            }
            catch (Exception exp)
            {

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

    protected void loadInfo1(string AgencyID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT nammodir,shomaremoj,tel,faq,mobilen,adresMahal,khadematAG,site,LogoADR,TedadP,LocationX,LocationY,AboutUs,namEng FROM AgencyDetail where ID = " + AgencyID, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (dr[0].ToString() != "") lb1.Text = dr[0].ToString();
                if (dr[1].ToString() != "") lb2.Text = dr[1].ToString();
                if (dr[2].ToString() != "") { lb3.Text = dr[2].ToString(); lbltel.Text = dr[2].ToString(); }
                if (dr[3].ToString() != "") { lb4.Text = dr[3].ToString(); lblfaq.Text = dr[3].ToString(); }
                if (dr[4].ToString() != "") lb5.Text = dr[4].ToString();
                if (dr[5].ToString() != "") lb6.Text = dr[5].ToString();
                if (dr[6].ToString() != "") lb7.Text = dr[6].ToString();
                if (dr["AboutUs"].ToString() != "") AboutUS.Text = dr["AboutUs"].ToString();
                if (dr[7].ToString() != "")
                {
                    HyperLink2.Text = dr[7].ToString();
                    HyperLink2.NavigateUrl = "http://" + dr[7].ToString();
                    HyperLink1.Text = dr[7].ToString();
                    HyperLink1.NavigateUrl ="http://" + dr[7].ToString();
                }
                lbperson.Text = dr[9].ToString();
                Image1.ImageUrl = "/Agency/logo/" + dr["namEng"].ToString() + ".jpg";
                ShowMap(dr[10].ToString(), dr[11].ToString());
                LoadMojavez(AgencyID);
            }
            con.Close();
        }
        catch (Exception exp)
        {
            con.Close();
        }
        finally
        {
            con.Close();
        }
    }

    public int PublicIndex = 0;
    protected void ShowMap(string LocationX, string LocationY)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("ShowMap(" + LocationX + ","+ LocationY + ")");
        sb.Append("</script>");
        PublicIndex++;
        Page.RegisterStartupScript("ShowMap" + PublicIndex.ToString(), sb.ToString());
    }

    protected void LoadMojavez(string AgencyID)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select meqdar FROM Mojavez where UserID = " + AgencyID + " order by ID", con);
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

    protected void LoadType()
    {
        var NN = Request.Url.AbsoluteUri.ToString();
        string[] NNN = NN.Split('/');
        string v = "";
        if (NNN.Length > 5) v = NNN[5];
        if (v != null)
        {
            SetDefaultCSS();
            if (v == "1" || v == "") tag1.Attributes.Add("class", "FirstColSelected");
            if (v == "2") tag2.Attributes.Add("class", "FirstColSelected");
            if (v == "3") tag3.Attributes.Add("class", "FirstColSelected");
            if (v == "4") tag4.Attributes.Add("class", "FirstColSelected");
            if (v == "5") tag5.Attributes.Add("class", "FirstColSelected");
        }
    }

    protected void SetDefaultCSS()
    {
        tag1.Attributes.Add("class", "FirstCol");
        tag2.Attributes.Add("class", "FirstCol");
        tag3.Attributes.Add("class", "FirstCol");
        tag4.Attributes.Add("class", "FirstCol");
        tag5.Attributes.Add("class", "FirstCol");
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
    protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Label lb = ((Label)e.Item.FindControl("TaeedCH"));
        Image Avatarimg = ((Image)e.Item.FindControl("Image2"));
        if (lb.Text == "True")
        {
            lb.Text = " استفاده از خدمات این آژانس توسط این کاربر توصیه شده است.";
            lb.CssClass = "TaedAg";
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
        if (System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower() != ".jpg")
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

    protected string GetAgencyID()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            var NN = Request.Url.AbsoluteUri.ToString();
            string[] NNN = NN.Split('/');
            string AgencyName = NNN[4];
            SqlCommand cmd = new SqlCommand("select ID from AgencyDetail WHERE namEng = '" + AgencyName + "'", con);
            SqlDataReader dr = null;
            con.Open();
            string ReturnValue="";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ReturnValue = dr[0].ToString();
            }
            con.Close();
            return ReturnValue;
        }
        catch { return "error"; }
        finally
        {
            con.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (CheckForPost() == false)
            {
                string v = GetAgencyID();
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
                    string ad1 = "," + CheckNull(DropDownList5.Text, 0);
                    string ad2 = "," + CheckNull(DropDownList6.Text, 0);
                    string ad3 = "," + CheckNull(DropDownList7.Text, 0);
                    string ad4 = "," + CheckNull(DropDownList8.Text, 0);
                    string ad5 = "," + CheckNull(DropDownList9.Text, 0);
                    string ad6 = "," + CheckNull(DropDownList10.Text, 0);
                    string ad7 = "," + CheckNull(DropDownList15.Text, 0);
                    string HtlID = "," + v;
                    string UsrID = "," + Session["UserID"].ToString();
                    string PostD = "," + CheckNull(GetCurrentDate(), 1);
                    string ava = "," + Session["Avatar"].ToString();
                    myQu = "INSERT INTO AgencyComment(KindID,NamLast,Email,Ostan,SalTavalod,Shoql,TarikhM,Title,Tozihat,Advice,ad1,ad2,ad3,ad4,ad5,ad6,ad7,AgencyID,UserID,PostDate,avatar) VALUES (";
                    myQu += KindID + NamLs + Eml + ost + salt + shql + Tarikhks + onv + toz + adv + ad1 + ad2 + ad3 + ad4 + ad5 + ad6 + ad7 + HtlID + UsrID + PostD + ava + ");";
                    myQu += "SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(myQu, con);
                    con.Open();
                    long CurrentID = Convert.ToInt64(cmd.ExecuteScalar());
                    con.Close();
                    string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                    string p = MapPath("~/Member/watcher/");
                    p += time;
                    FileUpload1.SaveAs(p);
                    cmd.CommandText = "insert into agencyWatcher(PicAdd,PostID,UserID) Values ('" + time + "' , " + CheckNull(CurrentID.ToString(), 0) + "," + CheckNull(Session["UserID"].ToString(), 0) + ");";
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
    protected void DataList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}