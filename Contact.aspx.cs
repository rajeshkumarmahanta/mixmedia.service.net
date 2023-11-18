using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
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

    }


    protected void btnsend_Click(object sender, EventArgs e)
    {
        if(txtcontname.Text=="" && txtcontmail.Text=="" && txtcontsubject.Text=="" && txtcontmsg.Text=="")
        {
            Response.Write("<script>alert('Please fill the blank box')</script>");
        }
        else
        {
            connection();
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_contact (Name,Email,Subject,Message) values('"+txtcontname.Text.ToString()+"','"+txtcontmail.Text.ToString()+"','"+txtcontsubject.Text.ToString()+"','"+txtcontmsg.Text.ToString()+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Your message has been sent. Thank you!')</script>");
            clear();
        }
        

    }
    protected void clear()
    {
        txtcontname.Text="";
        txtcontmail.Text="";
        txtcontsubject.Text="";
        txtcontmsg.Text="";
    }
}