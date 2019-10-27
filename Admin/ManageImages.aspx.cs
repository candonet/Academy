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
using System.IO;
using System.Drawing;
using System.Data.SqlClient;

public partial class Admin_ManageImages : System.Web.UI.Page
{
    protected void LoadAksList(int ListNumb)
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select * from  (select Row_Number() over (order by ID) as RowIndex, * from Aks) as Sub  Where Sub.RowIndex > " + ((ListNumb - 1) * 10) + " and Sub.RowIndex <= " + ((ListNumb) * 10) + " order by ID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList1.DataSource = ds.Tables[0].DefaultView;
            DataList1.DataBind();

        }
        catch (Exception exp)
        {
            Label4.Text = "خطا در ارتباط با دیتابیس برای فراخوانی عکس ها";
            Label4.ForeColor = Color.Red;
        }
    }

    protected void FillPageRepeater()
    {
        CheckSafe();
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlCommand cmd = new SqlCommand("select Count(ID) FROM Aks", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    LoadNumb(dr[0].ToString());
                }
            }
            con.Close();
        }
        catch (Exception exp)
        {
            Label4.Text = "خطا در ارتباط با دیتابیس برای فراخوانی عکس ها";
            Label4.ForeColor = Color.Red;
        }
        finally { con.Close(); }
    }

    protected void LoadNumb(string CountNumb)
    {
        decimal C = Convert.ToDecimal(CountNumb);
        C = C / 10;
        C = Math.Ceiling(C);
        int n = (int)C;
        DataTable dt = new DataTable();
        dt.Columns.Add("PageNumb", typeof(string));
        for (int i = 1; i <= n; i++)
        {
            dt.Rows.Add(i.ToString());
        }
        DataList2.DataSource = dt;
        DataList2.DataBind();
    }

    protected void CheckSafe()
    {
        if ((Session["User"]) == null)
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if ((Session["User"]) != null)
        {
            if (!IsPostBack)
            {
                Session["PageNumb"] = 1;
                LoadAksList(1);
                FillPageRepeater();

            }
        }
        else
        {
            Session["Error"] = "شما مجاز به دیدن این صفحه نیستید";
            Page.Response.Redirect("~/Admin/Login.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                string time = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".jpg";
                string p = MapPath("~/IMG/");
                p += time;
                FileUpload1.SaveAs(p);
                System.Drawing.Image img1 = System.Drawing.Image.FromFile(p);
                img1 = img1.GetThumbnailImage(100, 100, null, new IntPtr());
                img1.Save(MapPath("~/IMG/th/") + time);
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    //SqlCommand cmd = new SqlCommand("UPDATE Aks Set AksA = N'" + FileUpload1.FileName + "' WHERE AksA = N'" + FileUpload1.FileName + "'", con);
                    //con.Open();
                    //int n = cmd.ExecuteNonQuery();
                    //if (n == 0)
                    //{
                    //con.Close();
                    cmd.CommandText = "INSERT INTO Aks(AksA) VALUES ( N'" + time + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //}
                    con.Close();
                    int bb = int.Parse(Session["PageNumb"].ToString());
                    bb = bb;
                    LoadAksList(bb);
                }
                catch (Exception exp)
                {
                    Label2.Text = "خطا در اتصال با دیتابیس";
                    Label2.ForeColor = Color.Red;
                }
                Label4.Text = "";
                Label2.Text = "فایل با موفقیت آپلود شد" + "<br/><a href='../IMG/" + time + "' style='text-decoration:none' /> لینک فایل</a>";
                Label2.ForeColor = Color.Green;
            }
            catch
            {
                Label2.Text = "این عکس در حال حاضر در دیتابیس قرار دارد";
                Label2.ForeColor = Color.Red;
            }
        }
        else
        {
            Label4.Text = "";
            Label2.Text = "هیچ فایلی برای آپلود انتخاب نشده است";
            Label2.ForeColor = Color.Red;
        }
    }

    protected void DeleteImageByName(string ImageName)
    {
        string ImageAddress = MapPath("~/IMG/") + ImageName;
        string ImagethAddress = MapPath("~/IMG/th/") + ImageName;
        if (File.Exists(ImageAddress))
        {
            System.IO.File.Delete(ImageAddress);
            System.IO.File.Delete(ImagethAddress);
        }
    }

    protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        string ImageID = ((Label)e.Item.FindControl("Label3")).Text;
        string ImageName = ((Label)e.Item.FindControl("Label1")).Text;
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        try
        {
            DeleteImageByName(ImageName);
            SqlCommand cmd = new SqlCommand("DELETE FROM Aks WHERE ID = " + ImageID, con);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
            Label4.Text = "عکس با موفقیت حذف شد";
            Label4.ForeColor = Color.Green;
            int bb = int.Parse(Session["PageNumb"].ToString());
            LoadAksList(bb);

        }
        catch (Exception exp)
        {
            Label4.Text = exp.Message;
            Label4.ForeColor = Color.Red;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["PageNumb"] = 1;
    }
    protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void DataList2_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        string ImageID = ((LinkButton)e.Item.FindControl("LinkButton1")).Text;
        Session["PageNumb"] = ImageID;
        LoadAksList(Convert.ToInt16(ImageID));
    }
}