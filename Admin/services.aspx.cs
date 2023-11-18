using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_services : System.Web.UI.Page
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
        if (IsPostBack==false)
        {
            serviceview();
        }
    }


    public void serviceview()
    {
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand(" select * from tbl_services", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "tbl_services");
        ServicesGrid.DataSource = ds;
        ServicesGrid.DataBind();
        con.Close();
    }


    protected void btnaddservice_Click(object sender, EventArgs e)
    {
            if (serviceimg.HasFile)
            {
                string ext = Path.GetExtension(serviceimg.FileName);
                ext.ToLower();
                if (ext==".jpg" || ext==".jpeg" || ext==".png")
                {
                string filename = serviceimg.FileName;

                string filepath = "~/assests/services-img/" + filename;
                serviceimg.SaveAs(Server.MapPath(filepath));
                connection();
                 con.Open();
                SqlCommand cmd = new SqlCommand("insert into tbl_services (ServiceImage,ServicesHeading,ServicesContent) values('"+filepath+"','"+txtservicesheading.Text.ToString()+"','"+txtservicescont.Text.ToString()+"')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Services Added')</script>");
                clear();
                con.Close();
                serviceview();
            }
                else
                {
                    Response.Write("<script>alert('Please select .jpg' or .png or .jpeg or .psd)</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Please select a file')</script>");

            }

        }
    protected void clear()
    {
        txtservicesheading.Text="";
        txtservicescont.Text="";

    }



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
    protected void linkbtncontmsg_Click(object sender, EventArgs e)
    {
        Response.Redirect("contact.aspx");
    }
    protected void linkbtnabout_Click(object sender, EventArgs e)
    {
        Response.Redirect("About.aspx");
    }
    protected void linkbtnlogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    protected void linkbtnteamber_Click(object sender, EventArgs e)
    {
        Response.Redirect("teamember.aspx");
    }

    protected void ServicesGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = ServicesGrid.DataKeys[e.RowIndex].Value.ToString();
        // find values for update
        TextBox servicesheading = (TextBox)ServicesGrid.Rows[e.RowIndex].FindControl("txttblservicehead");
        TextBox servicescontent = (TextBox)ServicesGrid.Rows[e.RowIndex].FindControl("txttblservcecont");
        FileUpload FileUpload = (FileUpload)ServicesGrid.Rows[e.RowIndex].FindControl("fileuploadtblimg");
        connection();
        con.Open();
        string filename = FileUpload.FileName;
        string imgpath = "~/assests/services-img/" + filename;
        if (FileUpload.HasFile)
        {
            //save image in folder
            FileUpload.SaveAs(Server.MapPath(imgpath));


        }
        else
        {
            // use previous user image if new image is not changed
            Image img = (Image)ServicesGrid.Rows[e.RowIndex].FindControl("tblimg");
            imgpath = img.ImageUrl;
        }
        SqlCommand cmd = new SqlCommand("update tbl_services set ServiceImage='" + imgpath + "',ServicesHeading='" + servicesheading.Text + "',ServicesContent='" + servicescontent.Text + "' where Id=" + id + "", con);
        connection();
        con.Open();
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Update successfully')</script>");
        con.Close();
        ServicesGrid.EditIndex = -1;
        serviceview();
    }

    protected void ServicesGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        ServicesGrid.EditIndex = -1;
        serviceview();
    }

    protected void ServicesGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ServicesGrid.EditIndex= e.NewEditIndex;
        serviceview();
    }

    protected void ServicesGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(ServicesGrid.DataKeys[e.RowIndex].Value);
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from tbl_services where Id = " + id, con);
        cmd.ExecuteNonQuery();
        con.Close();
        serviceview();
    }
}