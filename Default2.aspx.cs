using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        XmlTextWriter writer = new XmlTextWriter(Server.MapPath("~/sitemap.xml"), System.Text.Encoding.UTF8);
        
        //Start XM DOcument
        writer.WriteStartDocument(true);
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 2;

        //ROOT Element
        writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
        
        writer.WriteStartElement("url");

        //call create nodes method
        createNode("Product 1", "20%", writer);
        createNode("Product 2", "20%", writer);
        createNode("Product 3", "20%", writer);
        createNode("Product 4", "20%", writer);

        writer.WriteEndElement();
        writer.WriteEndElement();

        //End XML Document
        writer.WriteEndDocument();
        
        //Close writer
        writer.Close();
        
    }
    private void button1_Click(object sender, EventArgs e)
    {
        
    }

    private void createNode( string pName, string pPrice, XmlTextWriter writer)
    {
        writer.WriteStartElement("url");
        writer.WriteStartElement("loc");
        writer.WriteString(pName);
        writer.WriteEndElement();
        writer.WriteStartElement("priority");
        writer.WriteString(pPrice);
        writer.WriteEndElement();
        writer.WriteEndElement();
    }
}