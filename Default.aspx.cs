using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
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
        headingview();
        DLbind();
        aboutview();
    }
    public void headingview()
    {
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand("select Caption1,CaptionContent1,Caption2,CaptionContent2,Caption3,CaptionContent3 from tbl_heading", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            caption1.InnerHtml = Convert.ToString(dr["Caption1"]);
            caption2.InnerHtml = Convert.ToString(dr["Caption2"]);
            caption3.InnerHtml = Convert.ToString(dr["Caption3"]);
            captioncontent1.InnerHtml = Convert.ToString(dr["CaptionContent1"]);
            captioncontent2.InnerHtml = Convert.ToString(dr["CaptionContent2"]);
            captioncontent3.InnerHtml = Convert.ToString(dr["CaptionContent3"]);

        }
        con.Close();
    }
    public void aboutview()
    {
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand("select HeadingText,ContentText from tbl_about", con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {

            aboutheading.InnerHtml = Convert.ToString(dr["HeadingText"]);
            aboutheadingmodal.InnerHtml = Convert.ToString(dr["HeadingText"]);
            aboutcontent.InnerHtml = Convert.ToString(dr["ContentText"]);
            aboutcontentmodal.InnerHtml = Convert.ToString(dr["ContentText"]);
        }
        con.Close();
    }
    protected void DLbind()
    {
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand("select ImageContent, Images from tbl_imagedata", con);
        //SqlDataReader dr = cmd.ExecuteReader();
        galleryview.DataSource = cmd.ExecuteReader();
        galleryview.DataBind();
        con.Close();
    }
}