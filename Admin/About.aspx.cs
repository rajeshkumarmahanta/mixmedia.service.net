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
using System.Xml.Linq;

public partial class Admin_About : System.Web.UI.Page
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
            filldata();
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if (fileupldaboutimg.HasFile)
        {
            string ext = Path.GetExtension(fileupldaboutimg.FileName);
            ext.ToLower();
            if (ext==".jpg" || ext==".jpeg" || ext==".png")
            {
                //string filename = fileupldaboutimg.FileName;

                string filepath = "~/assests/about-pic/profile-image.jpg";
                fileupldaboutimg.SaveAs(Server.MapPath(filepath));
                connection();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tbl_about (Headingtext,ContentText,AboutImage) values('"+txtaboutheading.Text.ToString()+"','"+txtaboutheadingcont.Text.ToString()+"','"+filepath+"')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('successfully save')</script>");
                filldata();
                clear();
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
        txtaboutheading.Text = "";
        txtaboutheadingcont.Text = "";
    }
    protected void filldata()
    {
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand(" select * from tbl_about", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "tbl_about");
        AboutGrid.DataSource = ds;
        AboutGrid.DataBind();
        con.Close();
    }
    protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(AboutGrid.DataKeys[e.RowIndex].Value);
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from tbl_about where Id = " + id, con);
        cmd.ExecuteNonQuery();
        con.Close();
        filldata();
    }

    protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        AboutGrid.EditIndex= e.NewEditIndex;
        filldata();

    }

    protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        AboutGrid.EditIndex = -1;
        filldata();
    }

    protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //find image id of edit row
        string id = AboutGrid.DataKeys[e.RowIndex].Value.ToString();
        // find values for update
        TextBox aboutheading = (TextBox)AboutGrid.Rows[e.RowIndex].FindControl("txttblheadingtext");
        TextBox aboutcontent = (TextBox)AboutGrid.Rows[e.RowIndex].FindControl("txttblcontentext");
        FileUpload FileUpload1 = (FileUpload)AboutGrid.Rows[e.RowIndex].FindControl("fileuploadtblimg");
        connection();
        con.Open();
        string imgpath = "~/assests/about-pic/profile-image.jpg";
        if (FileUpload1.HasFile)
        {
            //save image in folder
            FileUpload1.SaveAs(Server.MapPath(imgpath));
           

        }
        else
        {
            // use previous user image if new image is not changed
            Image img = (Image)AboutGrid.Rows[e.RowIndex].FindControl("tblimg");
            imgpath = img.ImageUrl;
        }
        SqlCommand cmd = new SqlCommand("update tbl_about set HeadingText='" + aboutheading.Text + "',ContentText='" + aboutcontent.Text + "',AboutImage='" + imgpath + "' where Id=" + id + "", con);
        connection();
        con.Open();
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Update successfully')</script>");
        con.Close();
        AboutGrid.EditIndex = -1;
        filldata();

    }
    ////when update Image delete from  folder
    //protected void ImageDeleteFromFolder(string imagedlt)
    //{
    //    string file_name = imagedlt;
    //    string path = Server.MapPath(@"~/assests/about-pic/" + imagedlt);
    //    FileInfo file = new FileInfo(path);

    //    if (file.Exists) //check file exsit or not
    //    {
    //        file.Delete();
    //        Response.Write("<script>alert('file_name + image deleted successfully')</script>");

    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('file_name + This image does not exists')</script>");

    //    }
    //}



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
}