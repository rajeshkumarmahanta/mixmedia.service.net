using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Services : System.Web.UI.Page
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
        ServiceList();
    }
    protected void ServiceList()
    {
        connection();
        con.Open();
        SqlCommand cmd = new SqlCommand(" select ServiceImage, ServicesHeading, ServicesContent from tbl_services", con);
        //SqlDataReader dr = cmd.ExecuteReader();
        ServiceListView.DataSource = cmd.ExecuteReader();
        ServiceListView.DataBind();
        con.Close();
    }
}