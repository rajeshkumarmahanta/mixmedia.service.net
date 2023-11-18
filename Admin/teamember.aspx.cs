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

public partial class Admin_teamember : System.Web.UI.Page
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

    protected void Save_Click(object sender, EventArgs e)
    {
        if (fileupldmemberimg.HasFile)
        {
            string ext = Path.GetExtension(fileupldmemberimg.FileName);
            ext.ToLower();
            if (ext==".jpg" || ext==".jpeg" || ext==".png")
            {
                string filename = fileupldmemberimg.FileName;

                string filepath = "~/assests/team-member-pic/" + filename;
                fileupldmemberimg.SaveAs(Server.MapPath(filepath));
                connection();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tbl_team (TeamMemberName,Designation,Images, facebooklink,twitterlink,instagramlink,linkedinlink) values('"+txtmebername.Text.ToString()+"','"+txtdesignation.Text.ToString()+"','"+filepath+"','"+txtfblink.Text.ToString()+"','"+txttwitterlink.Text.ToString()+"','"+instagramlink.Text.ToString()+"','"+linkedinlink.Text.ToString()+"')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Member Added')</script>");
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
        txtmebername.Text = "";
        txtdesignation.Text = "";
        txtfblink.Text = "";
        txttwitterlink.Text = "";
        instagramlink.Text = "";
        linkedinlink.Text = "";
    }
    protected void filldata()
    {
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand(" select * from tbl_team", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "tbl_team");
        memberGrid.DataSource = ds;
        memberGrid.DataBind();
        con.Close();
    }

    protected void memberGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(memberGrid.DataKeys[e.RowIndex].Value);
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from tbl_team where Id = " + id, con);
        cmd.ExecuteNonQuery();
        con.Close();
        filldata();
    }

    protected void memberGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        memberGrid.EditIndex= e.NewEditIndex;
        filldata();
    }

    protected void memberGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        memberGrid.EditIndex = -1;
        filldata();
    }

    protected void memberGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //find image id of edit row
        string id = memberGrid.DataKeys[e.RowIndex].Value.ToString();
        // find values for update
        TextBox TeamMemberName = (TextBox)memberGrid.Rows[e.RowIndex].FindControl("txttblmembername");
        TextBox TeamMemberDesgn = (TextBox)memberGrid.Rows[e.RowIndex].FindControl("txttblmberdsgn");
        TextBox fblink = (TextBox)memberGrid.Rows[e.RowIndex].FindControl("txttblmberfblink");
        TextBox twitterlink = (TextBox)memberGrid.Rows[e.RowIndex].FindControl("txttblmbertwiterlink");
        TextBox instalink = (TextBox)memberGrid.Rows[e.RowIndex].FindControl("txttblmberinstalink");
        TextBox linkedinlink = (TextBox)memberGrid.Rows[e.RowIndex].FindControl("txttblmberlinkedinlink");
        FileUpload FileUpload1 = (FileUpload)memberGrid.Rows[e.RowIndex].FindControl("fileuploadtblimg");
        connection();
        con.Open();
        string filename = FileUpload1.FileName;
        string imgpath = "~/assests/team-member-pic/" + filename;
        if (FileUpload1.HasFile)
        {
            //save image in folder
            FileUpload1.SaveAs(Server.MapPath(imgpath));


        }
        else
        {
            // use previous user image if new image is not changed
            Image img = (Image)memberGrid.Rows[e.RowIndex].FindControl("tblimg");
            imgpath = img.ImageUrl;
        }
        SqlCommand cmd = new SqlCommand("update tbl_team set TeamMemberName='" + TeamMemberName.Text + "',Designation='" + TeamMemberDesgn.Text + "',Images='" + imgpath + "',facebooklink='"+fblink.Text+"',twitterlink='"+twitterlink.Text+"',instagramlink='"+instalink.Text+"',linkedinlink='"+linkedinlink.Text+"' where Id=" + id + "", con);
        connection();
        con.Open();
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Update successfully')</script>");
        con.Close();
        memberGrid.EditIndex = -1;
        filldata();

    }
    //when update Image delete from  folder
    protected void ImageDeleteFromFolder(string imagedlt)
    {
        string file_name = imagedlt;
        string path = Server.MapPath(@"~/assests/team-member-pic/" + imagedlt);
        FileInfo file = new FileInfo(path);

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
}