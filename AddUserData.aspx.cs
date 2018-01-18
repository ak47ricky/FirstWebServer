using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AddUserData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Write("成功");
        //SqlConnection conn = new SqlConnection("server=203.0.113.11;uid=tw123411_ricky;pwd=.]~o$%R],k_H;database=tw123411_dreammaker");

        //conn.Open();

        //SqlCommand cmd = new SqlCommand("Select * from UserData", conn);
        //SqlDataReader dr = cmd.ExecuteReader();


        //while (dr.Read())
        //{
        //    Response.Write("成功");
        //}

        //Response.Write("成功");

        //Response.Write(dr.FieldCount);
        ////要釋放資源 重要!!
        //cmd.Cancel();
        //dr.Close();
        //conn.Close();
    }
}