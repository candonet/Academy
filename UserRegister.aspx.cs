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
using System.Net.Mail;
using System.IO;
using System.Net;

public partial class UserRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
            SqlCommand cmd = new SqlCommand("select Slide1,Slide2 FROM manageslides where id = 7", con);
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

    protected void BTN_Click(object sender, EventArgs e)
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        string returnValue = string.Empty;
        string User = Username.Text.Trim();
        string Pass = Password.Text.Trim();
        string esm = Nam.Text.Trim();
        string famil = Famil.Text.Trim();
        string email = Email.Text.Trim();
        if (User != "" && Pass != "" && esm != "" && famil != "" && email != "")
        {
            if (email.IndexOf('@') > 0)
            {
                if (Password.Text.Trim() == RePassword.Text.Trim())
                {
                    if (CheckBox1.Checked == true)
                    {
                        if (FileUpload1.HasFile)
                        {
                            if (FileUpload1.FileContent.Length > (20 * 1024))
                            {
                                returnValue = "سایز عکس بیشتر از حد مجاز می باشد";
                                goto l1;
                            }
                            if (Path.GetExtension(FileUpload1.FileName).ToLower() != "jpg" || Path.GetExtension(FileUpload1.FileName).ToLower() != "jpeg")
                            {
                                returnValue = "پسوند عکس مورد قبول نمی باشد. فقط jpg";
                                goto l1;
                            }
                        }
                        try
                        {
                            SqlDataReader dr = null;
                            SqlCommand cmd = new SqlCommand("select 1 from Members where username = '" + User + "'", con);
                            con.Open();
                            dr = cmd.ExecuteReader();
                            bool flg = false;
                            if (dr.HasRows != true)
                            {
                                flg = true;
                            }
                            con.Close();
                            if (flg == true)
                            {
                                string khabarname = "";
                                if (CheckBox2.Checked == true)
                                    khabarname = "1";
                                else
                                    khabarname = "0";
                                string AVA = "";
                                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Ticks.ToString() + ".jpg";
                                time = Username.Text.Trim() + ".jpg";
                                if (FileUpload1.HasFile)
                                {
                                    string p = MapPath("~/avatar/");
                                    p += time;
                                    FileUpload1.SaveAs(p);
                                    AVA = time;
                                }
                                cmd.CommandText = "INSERT INTO Members(username,password,status) VALUES ('" + User.ToLower() + "','" + Incode( Pass) + "',0);Declare @CurrentID bigint;set @CurrentID = SCOPE_IDENTITY();INSERT INTO GroupMember(UserID,GroupID) VALUES(@CurrentID,2);INSERT INTO MemberDetails(MemberID,Name,Family,Email,KhabarName,Avatar,JoinDate) VALUES (@CurrentID,'" + esm + "','" + famil + "','" + email + "'," + khabarname + ", '" + AVA + "','" + GetCurrentDate() + "');select @CurrentID;";
                                con.Open();
                                long CurrentID = Convert.ToInt64(cmd.ExecuteScalar());
                                con.Close();
                                string TokenCode = Guid.NewGuid().ToString();
                                cmd.CommandText = "INSERT INTO TokenTable(UserID,TokenCode,EmailAddress) VALUES(" + CurrentID + ", '" + TokenCode + "' , '" + Email.Text.Trim() + "' )";
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                SmtpClient mail = new SmtpClient();
                                MailMessage msg = new MailMessage();
                                msg.To.Add(Email.Text.ToString());
                                StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory.ToString() + ("\\Verify-Email\\register.html"));
                                string Body = sr.ReadToEnd();
                                sr.Close();
                                Body = Body.Replace("#URL#", "http://abcsafar.com/Verify-Email/activation.aspx?Token=" + TokenCode + "&email=" + Email.Text);
                                Body = Body.Replace("#Esm#", esm);
                                Body = Body.Replace("#Famil#", famil);
                                msg.From = new MailAddress("support@abcsafar.com", "Activition");
                                msg.Body = Body;
                                msg.Subject = "فعال سازی ایمیل";
                                msg.IsBodyHtml = true;
                                mail.EnableSsl = false;
                                mail.Host = "mail.abcsafar.com";
                                mail.Port = 25;
                                mail.Credentials = new NetworkCredential("support@abcsafar.com", "JB6jbjb??");
                                //mail.UseDefaultCredentials = false;
                                mail.Send(msg);
                                returnValue = "2";
                                returnValue = "1";
                            }
                            else
                            {
                                returnValue = "این نام کاربری قبلا ساخته شده است";
                            }
                        }
                        catch (Exception exp)
                        {
                            returnValue = "خطا در اتصال به سرور - لطفا دوباره تلاش کنید" + " " + exp.Message;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                    else
                        returnValue = "شما باید با قوانین سایت ما موافقت  داشته باشید";
                }
                else
                    returnValue = "کلمه عبور و تکرار آن با هم تطابق ندارند";
            }
            else
            {
                returnValue = "ایمیل را درست وارد کنید";
            }
        }
        else
        {
            returnValue = "لطفا مقادیر را پر کنید";
        }
   l1:
        if (returnValue != "1")
        {
            ErrorMSG.Visible = true;
            ErrorMSG.InnerHtml = returnValue.ToString();
        }
        else
        {
            ErrorMSG.Visible = true;
            ErrorMSG.Attributes["class"]="RegSuccess";
            ErrorMSG.InnerHtml="یک ایمیل حاوی لینک فعال سازی به ایمیل " + email + " ارسال شد.";
            RegisterTable.Visible = false;
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
        return (sal.ToString()  + M  + R).ToString();
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
}