<%@ Application Language="C#" %>

<script runat="server">

    
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);  

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }
    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.MapPageRoute("Parameters1", "Register", "~/UserRegister.aspx");
        routes.MapPageRoute("Parameters2", "Login", "~/Login.aspx");
        routes.MapPageRoute("Parameters3", "agencyRegistration", "~/AgencyRegister.aspx");
        routes.MapPageRoute("Parameters4", "Config", "~/Config.aspx");
        routes.MapPageRoute("Parameters5", "agencies", "~/AgencyCat.aspx");
        routes.MapPageRoute("Parameters6", "about", "~/AboutUs.aspx");
        routes.MapPageRoute("Parameters7", "ارسال-خبر", "~/ErsalKhabar.aspx");
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constring);
        try
        {
            //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select namEng,ID from AgencyDetail where sts = 1", con);
            //System.Data.SqlClient.SqlDataReader dr = null;
            //con.Open();
            //dr = cmd.ExecuteReader();
            int i = 1;
            //while (dr.Read())
            //{
            //    if (dr[0].ToString().Trim() != "")
            //    {
                    routes.MapPageRoute("Agency" + i.ToString(), "Agency/{AgencyName}", "~/ViewAgency.aspx");
                    i++;
                    routes.MapPageRoute("Agency" + i.ToString(), "Agency/{AgencyName}/{Page}", "~/ViewAgency.aspx");
                    i++;
            //    }
            //}
            //con.Close();
            //cmd.CommandText = "SELECT HotelProfile FROM Hotel WHERE Active = 1";
            //dr = null;
            //con.Open();
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    if (dr[0].ToString().Trim() != "")
            //    {
                    routes.MapPageRoute("Hotel" + i.ToString(), "Hotels/{HotelName}", "~/ViewHotel.aspx");
                    i++;
                    routes.MapPageRoute("Hotel" + i.ToString(), "Hotels/{HotelName}/{Page}", "~/ViewHotel.aspx");
                    i++;
            //    }
            //}
            //con.Close();
            //cmd.CommandText = "SELECT TourProfile FROM TourBase";
            //dr = null;
            //con.Open();
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    if (dr[0].ToString().Trim() != "")
            //    {
                    routes.MapPageRoute("Tour" + i.ToString(), "Tours/{TourName}", "~/ViewTour.aspx");
                    i++;
            //    }
            //}
            //con.Close();
                    routes.MapPageRoute("News" + i.ToString(), "News/{NewsName}", "~/ViewNews.aspx");
                    i++;
                    routes.MapPageRoute("Jazebe" + i.ToString(), "Jazebe/{JazebeName}", "~/ViewJazebe.aspx");
                    i++;
                    routes.MapPageRoute("Page" + i.ToString(), "Pages/{PageName}", "~/ViewPage.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "تورها", "~/TourCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "تورها/{TourCat}", "~/TourCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "تورها/{TourCat}/{CountryName}", "~/TourCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "تورها/{TourCat}/{CountryName}/{CityName}", "~/TourCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "تورها/{TourCat}/{CountryName}/{CityName}/{AreaName}", "~/TourCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "هتل-ها/", "~/HotelCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "هتل-ها/{CountryName}", "~/HotelCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "هتل-ها/{CountryName}/{CityName}", "~/HotelCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "هتل-ها/{CountryName}/{CityName}/{AreaName}", "~/HotelCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "جاذبه-ها", "~/TouristCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "جاذبه-ها/{CountryName}", "~/TouristCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "جاذبه-ها/{CountryName}/{CityName}", "~/TouristCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "جاذبه-ها/{CountryName}/{CityName}/{AreaName}", "~/TouristCat.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "خبرها", "~/NewsArchive.aspx");
                    i++;
                    routes.MapPageRoute("TourCat" + i.ToString(), "خبرها/{NewsCat}", "~/NewsArchive.aspx");
                    i++;
                    
                    
        }
        catch { con.Close(); }
        finally { con.Close(); }
        
    }  
    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        
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
</script>
