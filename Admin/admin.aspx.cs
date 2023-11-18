using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Admin_admin : System.Web.UI.Page
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
        if(IsPostBack==false)
        {
            filldata();
        }
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        if (fileuploadimage.HasFile && fileuploadfile.HasFile)
        {
            string ext1 = Path.GetExtension(fileuploadimage.FileName);
            string ext2 = Path.GetExtension(fileuploadfile.FileName);
            ext1.ToLower();
            ext2.ToLower();
            if (ext1==".jpg" || ext1==".jpeg" || ext1==".png" && ext2==".jpg" || ext2==".png" || ext2==".jpeg" ||ext2==".psd")
            {
                string filename1 =fileuploadimage.FileName;
                string filename2 =fileuploadfile.FileName;
                string filepath1 = "~/GalleryImages/" + filename1;
                string filepath2 = "~/Files/" + filename2;
                fileuploadimage.SaveAs(Server.MapPath(filepath1));
                fileuploadfile.SaveAs(Server.MapPath(filepath2));
                connection();
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into tbl_imagedata (ImageContent,Images,Files) values('"+txtname.Text.ToString()+"','"+filepath1+"','"+filepath2+"')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                txtname.Text = "";
                Response.Write("<script>alert('successfully save')</script>");
                filldata();
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
    protected void filldata()
    {
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand(" select * from tbl_imagedata", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "tbl_imagedata");
        Gridview1.DataSource = ds;
        Gridview1.DataBind();
        con.Close();
    }

    protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(Gridview1.DataKeys[e.RowIndex].Value);
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from tbl_imagedata where Id = " + id, con);
        cmd.ExecuteNonQuery();
        con.Close();
        filldata();
    }

    protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Gridview1.EditIndex= e.NewEditIndex;
        filldata();

    }

    protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Gridview1.EditIndex = -1;
        filldata();
    }

    protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //find image id of edit row
        string id = Gridview1.DataKeys[e.RowIndex].Value.ToString();
        // find values for update
        TextBox name = (TextBox)Gridview1.Rows[e.RowIndex].FindControl("txttblname");
        FileUpload FileUpload1 = (FileUpload)Gridview1.Rows[e.RowIndex].FindControl("fileuploadtblimg");
        FileUpload FileUpload2 = (FileUpload)Gridview1.Rows[e.RowIndex].FindControl("fileuploadtblfile");
        connection();
        con.Open();
        string imgpath = "~/GalleryImages/";
        string filepath = "~/Files/";
        if (FileUpload1.HasFile && FileUpload2.HasFile)
        {
            imgpath = imgpath + FileUpload1.FileName;
           filepath = filepath + FileUpload2.FileName;
            //save image in folder
            FileUpload1.SaveAs(MapPath(imgpath));
            FileUpload2.SaveAs(MapPath(filepath));


        }
        else
        {
            // use previous user image if new image is not changed
            Image img = (Image)Gridview1.Rows[e.RowIndex].FindControl("tblimage");
            Image file = (Image)Gridview1.Rows[e.RowIndex].FindControl("tblfile");
            imgpath = img.ImageUrl;
            filepath = img.ImageUrl;
        }
        SqlCommand cmd = new SqlCommand("update tbl_imagedata set ImageContent='" + name.Text + "',Images='" + imgpath + "',Files='"+filepath+"'  where Id=" + id + "", con);
        connection();
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Gridview1.EditIndex = -1;
        filldata();
    }

    //Image delete from folder
    protected void ImageDeleteFromFolder(string imagedlt)
    {
        string file_name = imagedlt;
        string path1 = Server.MapPath(@"~/GalleryImages/" + imagedlt);
        FileInfo file = new FileInfo(path1);

        if (file.Exists) //check file exsit or not
        {
            file.Delete();
            Response.Write("<script>alert('file_name + image deleted successfully')</script>");
           
        }
        else
        {
            Response.Write("<script>alert('file_name + This image does not exists')</script>");
            
        }
    }
    protected void FileDeleteFromFolder(string Filedlt)
    {
        string file_name = Filedlt;
        string path2 = Server.MapPath(@"~/Files/" + Filedlt);
        FileInfo file = new FileInfo(path2);

        if (file.Exists) //check file exsit or not
        {
            file.Delete();
            Response.Write("<script>alert('file_name + file deleted successfully')</script>");

        }
        else
        {
            Response.Write("<script>alert('file_name + This file does not exists')</script>");

        }
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
    protected void linkbtncontmsg_Click(object sender, EventArgs e)
    {
        Response.Redirect("contact.aspx");
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
    protected void linkbtnlogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    protected void linkbtnteamber_Click(object sender, EventArgs e)
    {
        Response.Redirect("teamember.aspx");
    }
}