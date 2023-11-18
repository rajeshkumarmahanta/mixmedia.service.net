using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_contact : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;

    public void connection()
    {
        string Connst = string.Empty;
        Connst = ConfigurationManager.AppSettings["const"].ToString();
        SqlConnection.ClearAllPools();
        con = new SqlConnection(Connst);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            messageview();
        }
    }

    public void messageview()
    {
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand(" select * from tbl_contact", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "tbl_contact");
        ContactGrid.DataSource = ds;
        ContactGrid.DataBind();
        con.Close();
    }

    protected void ContactGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(ContactGrid.DataKeys[e.RowIndex].Value);
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from tbl_contact where Id="+id, con);
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Message deleted.')</script>");
        con.Close();
        messageview();
    }
        //int id = Convert.ToInt32(AboutGrid.DataKeys[e.RowIndex].Value);
        //connection();
        //con.Open();
        //SqlCommand cmd = new SqlCommand("delete from tbl_about where Id = " + id, con);
        //cmd.ExecuteNonQuery();
        //con.Close();
        //filldata();
    
    protected void linkbtnhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin.aspx");
    }

    protected void linkbtnheading_Click(object sender, EventArgs e)
    {
        Response.Redirect("HeadSection.aspx");

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

    protected void linkbtnabout_Click(object sender, EventArgs e)
    {
        Response.Redirect("About.aspx");
    }
    protected void linkbtncontmsg_Click(object sender, EventArgs e)
    {
        Response.Redirect("contact.aspx");
    }
    protected void linkbtnlogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    protected void linkbtnteamber_Click(object sender, EventArgs e)
    {
        Response.Redirect("teamember.aspx");
    }

}