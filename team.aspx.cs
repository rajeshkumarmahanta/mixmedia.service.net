using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class team : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            teamview();
        }
    }
    public void teamview()
    {
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand(" select Images,TeamMemberName,Designation,facebooklink,twitterlink,instagramlink,linkedinlink from tbl_team", con);
        TeamView.DataSource = cmd.ExecuteReader();
        TeamView.DataBind();
        con.Close();
    }
}