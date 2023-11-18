using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_login : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    public void connection()
    {
        string connst = ConfigurationManager.AppSettings["const"].ToString();
        SqlConnection.ClearAllPools();
        con= new SqlConnection(connst);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void loginbtn_Click(object sender, EventArgs e)
    {
        string username = txtusername.Text;
        string password = txtpassword.Text;
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand("select UserName, Password from tbl_user_details where UserName='"+txtusername.Text.Trim()+"' and Password='"+txtpassword.Text.Trim()+"'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('Wellcome to Adminpannel')</script>");
            Response.Redirect("admin.aspx");
        }
        else
        {
            Response.Write("<script>alert('login failed')</script>");
        }

        txtusername.Text= "";
        txtpassword.Text="";
    }
}