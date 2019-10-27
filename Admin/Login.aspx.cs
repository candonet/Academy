using System;
using System.Configuration;
using System.Data;
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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
public partial class Admin_Login : System.Web.UI.Page
{
    static string code = "";
    static Random rand = new Random();
    private static void CreateCaptchaImage()
    {
        try
        {
            code = GetRandomText();
            Bitmap bitmap = new Bitmap(80, 30, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Yellow);
            Rectangle rect = new Rectangle(0, 0, 200, 30);
            SolidBrush blue = new SolidBrush(Color.FromArgb(247, 212, 212));
            SolidBrush black = new SolidBrush(Color.Black);
            int counter = 0;
            g.DrawRectangle(pen, rect);
            g.FillRectangle(blue, rect);

            for (int i = 0; i < code.Length; i++)
            {
                g.DrawString(code[i].ToString(), new Font("Tahoma", 11 + rand.Next(0, 0), FontStyle.Bold), black, new PointF(counter + rand.Next(0, 0), 5));
                counter += 15;
            }
            DrawRandomLines(g);
            //bitmap.Save(Response.OutputStream, ImageFormat.Gif);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, ImageFormat.Gif);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            Page page = (Page)HttpContext.Current.Handler;

            System.Web.UI.HtmlControls.HtmlImage MYIMAGE = (System.Web.UI.HtmlControls.HtmlImage)page.FindControl("myimg");

            MYIMAGE.Src = "data:image/gif;base64," + base64Data;
            g.Dispose();
            bitmap.Dispose();

        }
        catch (Exception exp)
        {
            //return "";
        }
    }

    [System.Web.Services.WebMethod]
    public static string CreateCaptchaImage2(string Request)
    {
        string result = "";
        try
        {
            code = GetRandomText();
            Bitmap bitmap = new Bitmap(80, 30, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Yellow);
            Rectangle rect = new Rectangle(0, 0, 200, 30);
            SolidBrush blue = new SolidBrush(Color.FromArgb(247, 212, 212));
            SolidBrush black = new SolidBrush(Color.Black);
            int counter = 0;
            g.DrawRectangle(pen, rect);
            g.FillRectangle(blue, rect);

            for (int i = 0; i < code.Length; i++)
            {
                g.DrawString(code[i].ToString(), new Font("Tahoma", 11 + rand.Next(0, 0), FontStyle.Bold), black, new PointF(counter + rand.Next(0, 0), 5));
                counter += 15;
            }
            DrawRandomLines(g);
            //bitmap.Save(Response.OutputStream, ImageFormat.Gif);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, ImageFormat.Gif);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            result = "data:image/gif;base64," + base64Data;
            g.Dispose();
            bitmap.Dispose();

        }
        catch (Exception exp)
        {
            result = "خطا در اتصال به سرور - لطفا دوباره تلاش کنید";
        }
        return result;
    }
    private static void DrawRandomLines(Graphics g)
    {
        try
        {
            SolidBrush yellow = new SolidBrush(Color.Yellow);
            for (int i = 0; i < 30; i++)
            { g.DrawLines(new Pen(Color.Red, 1), GetRandomPoints()); }
        }
        catch (Exception exp)
        {

        }
    }

    private static Point[] GetRandomPoints()
    {
        try
        {
            Point[] points = { new Point(rand.Next(0, 200), rand.Next(1, 200)), new Point(rand.Next(0, 200), rand.Next(1, 200)) };
            return points;
        }
        catch (Exception exp)
        {
            return null;
        }
    }

    private static string GetRandomText()
    {
        try
        {
            StringBuilder randomText = new StringBuilder();
            string alphabets = "012345679";
            Random r = new Random();
            for (int j = 0; j <= 4; j++)
            { randomText.Append(alphabets[r.Next(alphabets.Length)]); }
            HttpContext.Current.Session["CaptchaCode"] = randomText.ToString();
            return HttpContext.Current.Session["CaptchaCode"] as String;
        }
        catch (Exception exp)
        {
            return null;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Error"]) != null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("ShowError()");
            sb.Append("</script>");
            Page.RegisterStartupScript("show",sb.ToString());
            Label1.Text = Session["Error"].ToString();
            Session.Contents.Remove("Error");
        }
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

    [System.Web.Services.WebMethod]
    public static string CheckUserName(string Request)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        string returnValue = string.Empty;
        string[] Data = Request.Split(':');
        string User = Data[0].Trim().ToLower();
        string Pass = Data[1].Trim().ToLower();
        string CaptchaCode = Data[2].Trim().ToLower();
        if (HttpContext.Current.Session["CaptchaCode"].ToString() == CaptchaCode)
        {
            if (User != "" && Pass != "")
            {
                try
                {
                    SqlDataReader dr = null;
                    string HashPass = Incode(Pass);
                    SqlCommand cmd = new SqlCommand("SELECT password,status FROM Members WHERE Username like '" + User + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if ((dr).HasRows == true)
                    {
                        while (dr.Read())
                            if (dr[0].ToString().Trim() == HashPass)
                            {
                                if (dr[1].ToString() == "True")
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
                            else
                                returnValue = "نام کاربری و رمز ورود اشتباه می باشند";
                    }
                    else returnValue = "چنین نام کاربری وجود ندارد";
                    con.Close();
                }
                catch
                {
                    returnValue = "خطا در اتصال به سرور - لطفا دوباره تلاش کنید";
                }
            }
            else
            {
                returnValue = "لطفا مقادیر را پر کنید";
            }
            
        }
        else
            returnValue = returnValue = "تصویر امنیتی را درست وارد کنید";

        return returnValue;
    }

	[System.Web.Services.WebMethod]
    public static string TestMethod(string Request)
    {
        return "we got your request : " + Request;
    }
	
	[System.Web.Services.WebMethod]
    public static string  SaveImage(string Based64BinaryString)
   {
       string result = "";
       try
       {
           string format = "";
           string path = HttpContext.Current.Server.MapPath("IMG/");
           string name = DateTime.Now.ToString("hhmmss");
 
           if (Based64BinaryString.Contains("data:application/zip;base64,"))
           {
               format = "zip";
           }
           if (Based64BinaryString.Contains("data:;base64,"))
           {
               format = "zip";
           }
           if (Based64BinaryString.Contains("data:image/jpeg;base64,"))
           {
               format = "jpg";
           }
           if (Based64BinaryString.Contains("data:image/png;base64,"))
           {
               format = "png";
           }
           if (Based64BinaryString.Contains("data:text/plain;base64,"))
           {
               format = "txt";
           }
 
           string str = Based64BinaryString.Replace("data:image/jpeg;base64,", " ");//jpg check
           str = str.Replace("data:image/png;base64,", " ");//png check
           str = str.Replace("data:text/plain;base64,", " ");//text file check
           str = str.Replace("data:;base64,", " ");//zip file check
           str = str.Replace("data:application/zip;base64,", " ");//zip file check
 
           byte[] data = Convert.FromBase64String(str);
 
           
           {
               MemoryStream ms = new MemoryStream(data, 0, data.Length);
               ms.Write(data, 0, data.Length);
               System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
               image.Save(path + "/IMG" + name + ".jpg");
               result = "image uploaded successfully";
           }
       }
       catch (Exception ex)
       {
           result = "Error : " + ex;
       }
       return result;
   }
	
    protected void Button1_Click(object sender, EventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        string returnValue = string.Empty;
        string User = TextBox1.Value;
        string Pass = TextBox2.Value;
        string Permission = string.Empty;
        if (User != "" && Pass != "")
        {
            try
            {
                SqlDataReader dr = null;
                string HashPass = Incode(Pass);
                SqlCommand cmd = new SqlCommand("SELECT password,status FROM Members WHERE Username like '" + User + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if ((dr).HasRows == true)
                {
                    while (dr.Read())
                    {
                        if (dr[0].ToString().Trim() == HashPass)
                        {
                            if (dr[1].ToString() == "True")
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
                        else
                            returnValue = "نام کاربری و رمز ورود اشتباه می باشند";
                    }
                }
                else
                    returnValue = "چنین نام کاربری وجود ندارد";
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

                    if (Session["GroupID"].ToString() == "1")
                    {
                        Session["User"] = User;
                        Page.Response.Redirect("~/Admin/Default.aspx");
                    }
                    else if (Session["GroupID"].ToString() == "3")
                    {
                        Session["Member"] = User;
                        Page.Response.Redirect("~/Member/Default.aspx");
                    }
                    else if (Session["GroupID"] == "none")
                        Page.Response.Redirect("~/Default.aspx");
                    con.Close();
                }
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type='text/javascript'>");
                    sb.Append("ShowError()");
                    sb.Append("</script>");
                    Page.RegisterStartupScript("show2", sb.ToString());
                    Label1.Text = returnValue;
                }
            }
            catch (SqlException ex)
            {
                returnValue = "خطا در اتصال به سرور - لطفا دوباره تلاش کنید";
                Label1.Text = returnValue;
            }
        }
        else
        {
            returnValue = "لطفا مقادیر را پر کنید";
            Label1.Text = returnValue;
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        CreateCaptchaImage();
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
}