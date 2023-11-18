using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader dr;
    public void connection()
    {
        string Connst = string.Empty;
        Connst = ConfigurationManager.AppSettings["const"].ToString();
        SqlConnection.ClearAllPools();
        con = new SqlConnection(Connst);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void linkbtntwitter_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://twitter.com/RajeshKumar2128");
    }

    protected void linkbtninstagram_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.instagram.com/the_scripy_2128/");

    }

    protected void linkbtnfacebook_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.facebook.com/a.king.rajesh.kumar");

    }

    protected void linkbtnemail_Click(object sender, EventArgs e)
    {
        Response.Redirect("mailto:rajeshmahanta@gmail.com");

    }

    protected void linkbtnhome_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");

    }

    //protected void linkbtnadminpannel_Click1(object sender, EventArgs e)
    //{
    //    Response.Redirect("~//Admin/login.aspx");

    //}

    protected void linkbtnyt_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.youtube.com/@a_rajesh_kumar_vlogs");
    }

    protected void linkbtnservices_Click(object sender, EventArgs e)
    {
        Response.Redirect("Services.aspx");
    }

    protected void linkbtncontact_Click(object sender, EventArgs e)
    {
        Response.Redirect("Contact.aspx");
    }

    protected void linkbtnteam_Click(object sender, EventArgs e)
    {
        Response.Redirect("team.aspx");
    }
}
