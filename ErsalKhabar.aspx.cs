using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.Text;

public partial class ErsalKhabar : System.Web.UI.Page
{
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["UserID"]) == null)
        {
            LoginDiv.Visible = true;
            SendNews.Visible = false;
        }
        else
        {
            SendNews.Visible = true;
            LoginDiv.Visible = false;
        }

        //RemoveSlideShows();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CreateCaptchaImage();
            lblMessage.Text = "*";
            lblMessage.Visible = false;
            LoadCat();
            LoadSlides();
        }

    }
    protected void LoadSlides()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 5", con);
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
    string code = "";
    Random rand = new Random();
    private void CreateCaptchaImage()
    {
        code = GetRandomText();
        Bitmap bitmap = new Bitmap(200, 60, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        Graphics g = Graphics.FromImage(bitmap);
        Pen pen = new Pen(Color.Yellow);
        Rectangle rect = new Rectangle(0, 0, 200, 60);
        SolidBrush blue = new SolidBrush(Color.FromArgb(247, 212, 212));
        SolidBrush black = new SolidBrush(Color.Black);
        int counter = 0;
        g.DrawRectangle(pen, rect);
        g.FillRectangle(blue, rect);

        for (int i = 0; i < code.Length; i++)
        {
            g.DrawString(code[i].ToString(), new Font("Tahoma", 12 + rand.Next(15, 20), FontStyle.Italic), black, new PointF(counter + rand.Next(15, 20), 10));
            counter += 28;
        }
        DrawRandomLines(g);
        //bitmap.Save(Response.OutputStream, ImageFormat.Gif);
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        bitmap.Save(ms, ImageFormat.Gif);
        var base64Data = Convert.ToBase64String(ms.ToArray());
        myimg.Src = "data:image/gif;base64," + base64Data;
        g.Dispose();
        bitmap.Dispose();
    }

    private void DrawRandomLines(Graphics g)
    {
        SolidBrush yellow = new SolidBrush(Color.Yellow);
        for (int i = 0; i < 30; i++)
        { g.DrawLines(new Pen(Color.Red, 1), GetRandomPoints()); }
    }

    private Point[] GetRandomPoints()
    {
        Point[] points = { new Point(rand.Next(0, 200), rand.Next(1, 200)), new Point(rand.Next(0, 200), rand.Next(1, 200)) };
        return points;
    }
    
    private string GetRandomText()
    {

        StringBuilder randomText = new StringBuilder();
        string alphabets = "012345679ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        Random r = new Random();
        for (int j = 0; j <= 5; j++)
        { randomText.Append(alphabets[r.Next(alphabets.Length)]); }
        Session["CaptchaCode"] = randomText.ToString();
        return Session["CaptchaCode"] as String;
    }

    protected void BTN_Click(object sender, EventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        string returnValue = string.Empty;
        string User = UserName.Text;
        string Pass = Password.Text;
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
                    Response.Redirect("/ارسال-خبر");
                    con.Close();
                }
                else
                {
                    ErrorMSG.InnerHtml = returnValue;
                    ErrorMSG.Visible = true;
                }

            }
            catch (SqlException ex)
            {
                returnValue = "خطا در اتصال به سرور - لطفا دوباره تلاش کنید";
                ErrorMSG.InnerHtml = returnValue;
                ErrorMSG.Visible = true;
            }
        }
        else
        {
            returnValue = "لطفا مقادیر را پر کنید";
            ErrorMSG.InnerHtml = returnValue;
            ErrorMSG.Visible = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    private void MessageBox(string MessageText)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("alert('" + MessageText + "')");
        sb.Append("</script>");
        Page.RegisterStartupScript("show2", sb.ToString());
    }
    
    private void LoadCat()
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT ID,CatName From NewsCat order by Id ", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            DropDownList1.Items.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DropDownList1.Items.Add(dr[0].ToString() + "- " + dr[1].ToString());
                }
                if (DropDownList1.Items.Count > 0)
                {
                    DropDownList1.SelectedIndex = 0;
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            //Label1.Text = exp.Message;
            //Label1.ForeColor = Color.Red;
        }
        finally
        {
            con.Close();
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
    protected void Button2_Click1(object sender, EventArgs e)
    {
        if ( FileUpload1.HasFile == true && TextBox1.Text.Trim() != "" && TextBox2.Text.Trim() != "")
        {
            if ((Session["CaptchaCode"]) != null && txtCaptcha.Text.ToLower() == Session["CaptchaCode"].ToString().ToLower())
            {
                if (FileUpload1.FileContent.Length <= (100 * 1024))
                {
                    string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                    SqlConnection con = new SqlConnection(constring);
                    try
                    {
                        string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        string PicA = "";
                        if (FileUpload1.HasFile)
                        {
                            string p = MapPath("~/IMG/");
                            p += time;
                            PicA = "/IMG/" + time;
                            FileUpload1.SaveAs(p);
                            System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                            img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                            img1.Save(MapPath("~/IMG/th/") + time);
                            cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        string BodyHTML = TextBox2.Text.Replace("\n", "<br>");
                        string[] Data = DropDownList1.Text.Split('-');
                        string STS = "0";
                        string Query = "";
                        Query = "INSERT INTO News(Title,NBody,PicA,CatID,STS,UserID) VALUES (" + CheckNull(TextBox1.Text.Trim(), 1) + "," + CheckNull(PicA, 1) + "," + CheckNull(TextBox2.Text, 1) + "," + CheckNull(Data[0], 0) + "," + STS + "," + CheckNull(Session["UserID"].ToString(), 0) + ")";
                        cmd.CommandText = Query;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblMessage.Visible = false;
                        ErrorMSG2.Visible = false;
                    }
                    catch { }
                    SendNews.Visible = false;
                    PostSuccess.Visible = true;
                }
                else
                {
                    ErrorMSG2.Visible = true;
                }
            }
            else
            {
                CreateCaptchaImage();
                lblMessage.Visible = true;
                ErrorMSG2.Visible = true;
                txtCaptcha.Text = "";
                txtCaptcha.Focus();
            }
        }
        else
        {
            CreateCaptchaImage();
            lblMessage.Visible = true;
            ErrorMSG2.Visible = true;
        }
    }
}