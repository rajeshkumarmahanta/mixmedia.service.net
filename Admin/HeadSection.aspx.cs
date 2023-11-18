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
public partial class Admin_HeadSection : System.Web.UI.Page
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
            GridData();
        }
      
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        if (sliderimg1.HasFile && sliderimg2.HasFile && sliderimg3.HasFile)
        {
            string ext1 = Path.GetExtension(sliderimg1.FileName);
            string ext2 = Path.GetExtension(sliderimg2.FileName);
            string ext3 = Path.GetExtension(sliderimg3.FileName);
            ext1.ToLower();
            if (ext1==".jpg" || ext1==".jpeg" || ext1==".png" && ext2==".jpg" || ext2==".jpeg" || ext2==".png" && ext3==".jpg" || ext3==".jpeg" || ext3==".png")
            {
             
                string filepath1 = "~/SliderImage/sliderimage1.jpg";
                string filepath2 = "~/SliderImage/sliderimage2.jpg";
                string filepath3 = "~/SliderImage/sliderimage3.jpg";
                sliderimg1.SaveAs(Server.MapPath(filepath1));
                sliderimg2.SaveAs(Server.MapPath(filepath2));
                sliderimg3.SaveAs(Server.MapPath(filepath3));
                connection();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tbl_heading (Caption1,CaptionContent1,SliderImage1,Caption2,CaptionContent2,SliderImage2,Caption3,CaptionContent3,SliderImage3) values('"+txtcaption1.Text.ToString()+"','"+txtcontent1.Text.ToString()+"','"+filepath1+"','"+txtcaption2.Text.ToString()+"','"+txtcontent2.Text.ToString()+"','"+filepath2+"','"+txtcaption3.Text.ToString()+"','"+txtcontent3.Text.ToString()+"','"+filepath3+"')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                txtcaption1.Text = "";
                txtcaption2.Text = "";
                txtcaption3.Text = "";
                txtcontent1.Text = "";
                txtcontent2.Text = "";
                txtcontent3.Text = "";

                Response.Write("<script>alert('successfully save')</script>");
                GridData();
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
    private void GridData()
    {
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand(" select * from tbl_heading", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "tbl_heading");
        GridviewData.DataSource = ds;
        GridviewData.DataBind();
        con.Close();
    }

    protected void GridviewData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridviewData.DataKeys[e.RowIndex].Value);
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from tbl_heading where Id = " + id, con);
        cmd.ExecuteNonQuery();
        con.Close();
        GridData();
    }

    protected void linkbtnhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin.aspx");
    }

    protected void linkbtnheading_Click(object sender, EventArgs e)
    {
        Response.Redirect("HeadSection.aspx");

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